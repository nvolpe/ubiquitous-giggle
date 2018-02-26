using System;
using System.Drawing;
using System.Collections.Generic;


using CoreFoundation;
using UIKit;
using Foundation;
using CoreGraphics;


using GuessingGame.Services;
using GuessingGame.Models;
using GuessingGame.Views;
using System.Threading.Tasks;

namespace GuessingGame
{
    [Register("GameViewController")]
    public class GameViewController : UIViewController
    {
        NSLayoutConstraint[] PlayerViewRegularConstraints;
        NSLayoutConstraint[] PlayerViewFinalConstraints;

        public List<PlayerView> PlayerViews { get; set; }

        ScoreView ScoreView;
        GuessGame Game;

        private enum VeiwClasses { StaticView = 1, DynamicView };

        public GameViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            /* 
             *  🔈
             *  
             *  Yo FanDuel, this job is perfect for me. I want it bad, I will work my ass off for you guys.
             *  
             */

            View.BackgroundColor = UIColor.White;

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            Initialize();
        }

        async void Initialize()
        {
            UIActivityIndicatorView activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
            activitySpinner.Frame = new CGRect(new CGPoint(View.Center.X - 50, View.Center.Y - 50), new CGSize(100, 100));
            activitySpinner.StartAnimating();

            View.Add(activitySpinner);

            GameDataService dataService = new GameDataService();
            var gameData = await dataService.GetGameData();

            Game = new GuessGame(gameData);

            PlayerViews = Game.GetRandomPlayers();

            Add2PlayerViews();
            AddScoreView();

            // We have data, stop showing spinner
            activitySpinner.StopAnimating();
            activitySpinner.RemoveFromSuperview();
        }

        private async void StartNewMatch()
        {
            var total = 5;

            // tick every every second 
            while (total >= 0)
            {
                await Task.Delay(1000);
                ScoreView.InfoLabel.Text = string.Format("Game Restarts in: {0}", total);
                total--;
            }

            ScoreView.InfoLabel.Text = string.Format("Your Selection:");

            RemoveOldPlayerViews();
            PlayerViews = Game.GetRandomPlayers();
            Add2PlayerViews();
        }

        private void Add2PlayerViews()
        {
            var playerView1 = PlayerViews[0];
            var playerView2 = PlayerViews[1];

            playerView1.Tag = (int)VeiwClasses.DynamicView;
            playerView2.Tag = (int)VeiwClasses.DynamicView;

            View.Add(playerView1);
            View.Add(playerView2);

            playerView1.PlayerSelected += PlayerSelected;
            playerView2.PlayerSelected += PlayerSelected;

            /* 
             *  🔈
             *  
             *  I try to write constraints in code instead of using the storyboard.. but im down with whatever you guys want.
             *  When I started my crash course in Xamarin.iOS, iOS 11 had just come out and the Xamarin designer had several bugs. So in
             *  order to deliver the iPad app for our client in time I just deleted the storyboard and started with frame based layouts.
             */

            // Start: Player view Constraints
            // -------------------------------

            // I wish i could figure out how to iterate a list of views and mathematically calculate the right constraint values.
            PlayerViewRegularConstraints = new[] {
                playerView1.WidthAnchor.ConstraintEqualTo(150),
                playerView2.WidthAnchor.ConstraintEqualTo(150),

                playerView1.HeightAnchor.ConstraintEqualTo(150),
                playerView2.HeightAnchor.ConstraintEqualTo(150),

                playerView1.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 40),
                playerView2.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 40),

                playerView1.LeadingAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeadingAnchor, 10),
                View.LayoutMarginsGuide.TrailingAnchor.ConstraintEqualTo(playerView2.TrailingAnchor, 10),
            };

            // END: Player view Constraints
            // -------------------------------

            ApplyConstraints(PlayerViewRegularConstraints);
        }

        private void RemoveOldPlayerViews()
        {
            foreach (UIView subview in View.Subviews)
            {
                if (subview.Tag == (int)VeiwClasses.DynamicView)
                    subview.RemoveFromSuperview();
            }
        }

        private void AddScoreView()
        {
            ScoreView = new ScoreView();
            View.Add(ScoreView);

            ScoreView.GuessButton.TouchUpInside += GuessButton_TouchUpInside;

            /* 
             *  🔈
             *  
             *  I should have probably used some stack views, but if I have time sunday I want to rock your world with some 
             *  constraint animations. So I'm holding out hope I can make that happen.
             *  
             */

            // Start: Score View Constraints
            // -------------------------------
            ScoreView.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 300).Active = true;
            ScoreView.LeadingAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeadingAnchor).Active = true;
            View.LayoutMarginsGuide.TrailingAnchor.ConstraintEqualTo(ScoreView.TrailingAnchor).Active = true;
            View.LayoutMarginsGuide.BottomAnchor.ConstraintEqualTo(ScoreView.BottomAnchor).Active = true;

            // END: Score View Constraints
            // -------------------------------
        }

        private void ApplyConstraints(NSLayoutConstraint[] constraints)
        {
            NSLayoutConstraint.ActivateConstraints(constraints);
        }

        private void AnimatePlayerViewOrder()
        {
            UIView.Animate(1.0, () => {
                NSLayoutConstraint.DeactivateConstraints(PlayerViewRegularConstraints);
                NSLayoutConstraint.ActivateConstraints(PlayerViewFinalConstraints);
                View.LayoutIfNeeded();
            });
        }


        private void UpdateConstraintPlacement(List<PlayerView> playerViews)
        {
            /* 
            *  🔈
            *  
            *  This was designed to add some sex appeal to the app. To discover who won, the app animates the winner to the front of the other player.
            *  Ideally I would have 3 image views, but it is 845 pm sunday night and I dont think I have time!
            *  
            */

            var playerView1 = playerViews[0]; // The winner goes first
            var playerView2 = playerViews[1];

            PlayerViewFinalConstraints = new[] {
                playerView1.WidthAnchor.ConstraintEqualTo(150),
                playerView2.WidthAnchor.ConstraintEqualTo(150),

                playerView1.HeightAnchor.ConstraintEqualTo(150),
                playerView2.HeightAnchor.ConstraintEqualTo(150),

                playerView1.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 80),
                playerView2.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 80),

                playerView1.LeadingAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeadingAnchor, 5),
                View.LayoutMarginsGuide.TrailingAnchor.ConstraintEqualTo(playerView2.TrailingAnchor, 5),
            };

            // Now animate the constraints
            AnimatePlayerViewOrder();

            foreach (var playerView in PlayerViews)
            {
                playerView.SetNeedsDisplay(); // Got fix my rounded imageviews with this call to drawrect
            }
        }


        private void GuessButton_TouchUpInside(object sender, EventArgs e)
        {
            // Disable the button so they cant guess again
            ScoreView.DisableButton();

            // Block the user from selecting a new player until the game starts back over
            foreach (var playerView in PlayerViews)
            {
                playerView.DisableImageViewButton();
            }

            // Check if they got it right?!
            bool didGuessCorrectly = Game.CheckGuess();


            if (didGuessCorrectly)
            {
                ScoreView.MessageLabel.Text = "Winnnnar!";
            }
            else
            {
                ScoreView.MessageLabel.Text = "You are a Loser, try harder.";
            }

            ScoreView.ScoreLabel.Text = string.Format("Score {0} of 10", Game.Score);

            // ----------------------------------------------
            var players = Game.GetOrderOfPlayers();

            foreach (var item in players)
            {
                var roundedPoints = Math.Round((double)item.CurrentPlayer.fppg, 2);
                item.FppgLabel.Text = string.Format("FPPG: {0}", roundedPoints); 
            }

            UpdateConstraintPlacement(players);

            if (Game.Score == 10)
            {
                // Game over, you won, start new game?
                Console.WriteLine("You Won game over");

                this.PresentViewController(new VictoryViewController(), true, null);
            }
            else
            {
                StartNewMatch();
            }
        }

        private void PlayerSelected(Player player)
        {
            Game.SelectedPlayer = player;
            ScoreView.EnableButton(player);
        }
    }
}
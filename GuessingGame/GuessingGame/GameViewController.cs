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

namespace GuessingGame
{
    [Register("GameViewController")]
    public class GameViewController : UIViewController
    {
        PlayerView playerImage;
        PlayerView playerImage1;
        ScoreView ScoreView;

        GuessGame Game;

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

            View.BackgroundColor = UIColor.LightGray;

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            Initialize();
        }


        //public override void ViewDidLayoutSubviews()
        //{
        //    //base.ViewDidLayoutSubviews();
        //}

        async void Initialize()
        {
            UIActivityIndicatorView activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
            activitySpinner.Frame = new CGRect(new CGPoint(View.Center.X - 50, View.Center.Y - 50), new CGSize(100, 100));
            activitySpinner.StartAnimating();

            View.Add(activitySpinner);

            Game = new GuessGame();
            await Game.StartNewGame();

            List<PlayerView> playerViews = Game.GetRandomPlayers();


            //var url = gameData.Players[0].images.@default.url;
            //var url1 = gameData.Players[1].images.@default.url;


            AddPlayerViews(playerViews);
            AddScoreView();

            activitySpinner.StopAnimating();
            activitySpinner.RemoveFromSuperview();
        }

        private void AddPlayerViews(List<PlayerView> playerViews)
        {
            //playerImage = CreateImageView("");
            //playerImage1 = CreateImageView("");

            playerImage = playerViews[0];
            playerImage1 = playerViews[1];

            View.Add(playerImage);
            View.Add(playerImage1);

            playerImage.PlayerSelected += PlayerSelected;
            playerImage1.PlayerSelected += PlayerSelected;

            /* 
             *  🔈
             *  
             *  I try to write constraints in code instead of using the storyboard.. but im down with whatever you guys want.
             *  When I started my crash course in Xamarin.iOS, iOS 11 had just come out and the Xamarin designer had several bugs. So in
             *  order to deliver the iPad app for our client in time I just deleted the storyboard and started with frame based layouts.
             */

            // Start: Player view Constraints
            // -------------------------------
            playerImage.WidthAnchor.ConstraintEqualTo(150).Active = true;
            playerImage1.WidthAnchor.ConstraintEqualTo(150).Active = true;

            playerImage.HeightAnchor.ConstraintEqualTo(150).Active = true;
            playerImage1.HeightAnchor.ConstraintEqualTo(150).Active = true;

            playerImage.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 40).Active = true;
            playerImage1.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 40).Active = true;

            playerImage.LeadingAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeadingAnchor, 10).Active = true;
            View.LayoutMarginsGuide.TrailingAnchor.ConstraintEqualTo(playerImage1.TrailingAnchor, 10).Active = true;

            // END: Player view Constraints
            // -------------------------------
        }


        private void AddScoreView()
        {
            ScoreView = new ScoreView();
            View.Add(ScoreView);

            /* 
             *  🔈
             *  
             *  I should have probably used some stack views, but if I have time sunday I want to rock your world with some 
             *  constraint animations. So I'm holding out hope I can make that happen.
             *  
             */

            // Start: Score View Constraints
            // -------------------------------
            ScoreView.TopAnchor.ConstraintEqualTo(playerImage1.LayoutMarginsGuide.BottomAnchor, 160).Active = true;
            ScoreView.LeadingAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeadingAnchor).Active = true;
            View.LayoutMarginsGuide.TrailingAnchor.ConstraintEqualTo(ScoreView.TrailingAnchor).Active = true;
            View.LayoutMarginsGuide.BottomAnchor.ConstraintEqualTo(ScoreView.BottomAnchor).Active = true;

            // END: Score View Constraints
            // -------------------------------
        }

        private void PlayerSelected(string playerName)
        {
            ScoreView.EnableButton(playerName);
        }
    }
}
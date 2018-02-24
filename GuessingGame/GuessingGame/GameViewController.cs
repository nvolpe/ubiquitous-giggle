using System;
using System.Drawing;

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

            // Comment out the HTTP calls. it takes too long while debugging
            //GameDataService dataService = new GameDataService();
            //GameData gameData = await dataService.GetGameData();

            //var url = gameData.Players[0].images.@default.url;
            //var url1 = gameData.Players[1].images.@default.url;

            AddPlayerViews();

            activitySpinner.StopAnimating();
            activitySpinner.RemoveFromSuperview();
        }

        private void AddPlayerViews()
        {
            //playerImage = CreateImageView("");
            //playerImage1 = CreateImageView("");

            playerImage = new PlayerView();
            playerImage1 = new PlayerView();

            //playerImage.BackgroundColor = UIColor.Blue;
            //playerImage1.BackgroundColor = UIColor.Green;

            View.Add(playerImage);
            View.Add(playerImage1);

            /* 
             *  🔈
             *  
             *  My prefernce is to write constraints in code instead of using the storyboard.. but im down with whatever you guys want.
             *  When I started my crash course in Xamarin.iOS, iOS 11 had just come out and the Xamarin designer had several bugs. So in
             *  order to deliver the iPad app for our client in time I just deleted the storyboard and started with frame based layouts.
             */

            // Start: Image view Constraints
            // -------------------------------
            //playerImage.WidthAnchor.ConstraintEqualTo(View.WidthAnchor, .25f).Active = true;
            //playerImage1.WidthAnchor.ConstraintEqualTo(View.WidthAnchor, .25f).Active = true;

            //var aspectRatio = 1;
            //playerImage.WidthAnchor.ConstraintEqualTo(playerImage.HeightAnchor, aspectRatio).Active = true;
            //playerImage1.WidthAnchor.ConstraintEqualTo(playerImage1.HeightAnchor, aspectRatio).Active = true;

            //playerImage.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 80).Active = true;
            //playerImage1.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 80).Active = true;


            //playerImage.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 20).Active = true;
            //playerImage1.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, 20).Active = true;

            //playerImage.TopAnchor.ConstraintEqualTo(playerImage1.TopAnchor).Active = true;
            //View.TrailingAnchor.ConstraintEqualTo(playerImage1.TrailingAnchor, 20).Active = true;

            //var compressionConstraint = playerImage1.LeadingAnchor.ConstraintEqualTo(playerImage.TrailingAnchor, 50);
            //compressionConstraint.Priority = (float)UILayoutPriority.DefaultHigh;
            //compressionConstraint.Active = true;
            // END: Image view Constraints
            // -------------------------------

            // Start: Image view Constraints
            // -------------------------------
            playerImage.WidthAnchor.ConstraintEqualTo(150).Active = true;
            playerImage1.WidthAnchor.ConstraintEqualTo(150).Active = true;

            playerImage.HeightAnchor.ConstraintEqualTo(150).Active = true;
            playerImage1.HeightAnchor.ConstraintEqualTo(150).Active = true;

            playerImage.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 40).Active = true;
            playerImage1.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 40).Active = true;

            playerImage.LeadingAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeadingAnchor, 10).Active = true;
            View.LayoutMarginsGuide.TrailingAnchor.ConstraintEqualTo(playerImage1.TrailingAnchor, 10).Active = true;
            // END: Image view Constraints
            // -------------------------------

            //playerImage.WidthAnchor.ConstraintEqualTo(150).Active = true;
            //playerImage.HeightAnchor.ConstraintEqualTo(150).Active = true;

            //playerImage.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            //playerImage.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
        }
    }
}
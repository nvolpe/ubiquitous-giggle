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
    //[Register("UniversalView")]
    //public class UniversalView : UIView
    //{
    //    public UniversalView()
    //    {
    //        Initialize();
    //    }

    //    public UniversalView(RectangleF bounds) : base(bounds)
    //    {
    //        Initialize();
    //    }

    //    void Initialize()
    //    {
    //        BackgroundColor = UIColor.Red;
    //    }
    //}

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

            View.BackgroundColor = UIColor.White;


            base.ViewDidLoad();

            // Perform any additional setup after loading the view

            Initialize();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            // Temporary code to apply circle image frame
            playerImage.Layer.CornerRadius = playerImage.Frame.Size.Width / 2;
            playerImage.ClipsToBounds = true;

            playerImage1.Layer.CornerRadius = playerImage1.Frame.Size.Width / 2;
            playerImage1.ClipsToBounds = true;
        }

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

            playerImage = CreateImageView("");
            playerImage1 = CreateImageView("");

            View.Add(playerImage);
            View.Add(playerImage1);


            // Start: Image view Constraints
            // -------------------------------
            playerImage.WidthAnchor.ConstraintEqualTo(View.WidthAnchor, .25f).Active = true;
            playerImage1.WidthAnchor.ConstraintEqualTo(View.WidthAnchor, .25f).Active = true;

            var aspectRatio = 1;
            playerImage.WidthAnchor.ConstraintEqualTo(playerImage.HeightAnchor, aspectRatio).Active = true;
            playerImage1.WidthAnchor.ConstraintEqualTo(playerImage1.HeightAnchor, aspectRatio).Active = true;

            playerImage.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 80).Active = true;
            playerImage1.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor, 80).Active = true;


            playerImage.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 20).Active = true;
            playerImage1.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, 20).Active = true;


            playerImage.TopAnchor.ConstraintEqualTo(playerImage1.TopAnchor).Active = true;

            View.TrailingAnchor.ConstraintEqualTo(playerImage1.TrailingAnchor, 20).Active = true;


            var compressionConstraint = playerImage1.LeadingAnchor.ConstraintEqualTo(playerImage.TrailingAnchor, 50);
            compressionConstraint.Priority = (float)UILayoutPriority.DefaultHigh;
            compressionConstraint.Active = true;
            // END: Image view Constraints
            // -------------------------------


            activitySpinner.StopAnimating();
            activitySpinner.RemoveFromSuperview();
        }

        private PlayerView CreateImageView(string uri)
        {
            UIImage image = FromUrl(uri);

            PlayerView playerImage = new PlayerView(image);
            playerImage.TranslatesAutoresizingMaskIntoConstraints = false;
            playerImage.Layer.BorderWidth = 5;
            playerImage.Layer.BorderColor = UIColor.Blue.CGColor;

            return playerImage;
        }


        private UIImage FromUrl(string uri)
        {
            return UIImage.FromFile("9524.png");

            //using (var url = new NSUrl(uri))
            //using (var data = NSData.FromUrl(url))
            //    return UIImage.LoadFromData(data);
        }

    }
}
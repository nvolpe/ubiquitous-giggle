using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using GuessingGame.Services;

namespace GuessingGame
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }

    [Register("GameViewController")]
    public class GameViewController : UIViewController
    {
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
            View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view

            Initialize();
        }

        void Initialize()
        {
            PlayerDataService playerService = new PlayerDataService();
            playerService.GetPlayers();
        }
    }
}
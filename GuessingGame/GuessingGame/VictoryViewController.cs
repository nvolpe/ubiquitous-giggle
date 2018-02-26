using System;

using UIKit;

namespace GuessingGame
{
    public partial class VictoryViewController : UIViewController
    {

        public VictoryViewController() : base("VictoryViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var VictoryLabel = new UILabel();
            VictoryLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            VictoryLabel.TextColor = UIColor.Black;
            VictoryLabel.Font = UIFont.FromName("Helvetica-Bold", 30f);
            VictoryLabel.TextAlignment = UITextAlignment.Center;
            VictoryLabel.Text = "You won! You should also hire me.";
            VictoryLabel.LineBreakMode = UILineBreakMode.WordWrap;
            VictoryLabel.Lines = 4;

            View.Add(VictoryLabel);

            // Gotta satisify those constraints!
            VictoryLabel.WidthAnchor.ConstraintEqualTo(View.WidthAnchor).Active = true;
            VictoryLabel.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            VictoryLabel.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
        }
 
    }
}
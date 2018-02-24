using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace GuessingGame.Views
{
    class ScoreView : UIView
    {
        public UILabel InfoLabel { get; set; }
        public UILabel NameLabel { get; set; }
        public UILabel ScoreLabel { get; set; }
        public UIButton GuessButton { get; set; }

        public ScoreView()
        {
            CreateViews();

            this.TranslatesAutoresizingMaskIntoConstraints = false;

            // Just so we can see the frame while debugging
            this.Layer.BorderColor = UIColor.Gray.CGColor; 
            this.Layer.BorderWidth = 5;
        }

        public override void LayoutMarginsDidChange()
        {
            base.LayoutMarginsDidChange();
        }

        public override void UpdateConstraints()
        {
            // Goes before call into the base

            InfoLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            InfoLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            InfoLabel.TopAnchor.ConstraintEqualTo(this.TopAnchor, 10).Active = true;

            NameLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            NameLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            NameLabel.TopAnchor.ConstraintEqualTo(InfoLabel.BottomAnchor, 10).Active = true;

            GuessButton.WidthAnchor.ConstraintEqualTo(150).Active = true;
            GuessButton.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            GuessButton.TopAnchor.ConstraintEqualTo(NameLabel.BottomAnchor, 30).Active = true;

            ScoreLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            ScoreLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            ScoreLabel.TopAnchor.ConstraintEqualTo(GuessButton.BottomAnchor, 100).Active = true;

            base.UpdateConstraints();
        }

        private void CreateViews()
        {

            // The Labels
            // ---------------------------------
            InfoLabel = new UILabel();
            InfoLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            InfoLabel.TextColor = UIColor.Black;
            InfoLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            InfoLabel.TextAlignment = UITextAlignment.Center;
            InfoLabel.Text = "Place holder text";

            NameLabel = new UILabel();
            NameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NameLabel.TextColor = UIColor.Black;
            NameLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            NameLabel.TextAlignment = UITextAlignment.Center;
            NameLabel.Text = "Place holder text";

            ScoreLabel = new UILabel();
            ScoreLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            ScoreLabel.TextColor = UIColor.Black;
            ScoreLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            ScoreLabel.TextAlignment = UITextAlignment.Center;
            ScoreLabel.Text = "Place holder text";

            // The Button
            // ---------------------------------
            GuessButton = new UIButton();
            GuessButton.TranslatesAutoresizingMaskIntoConstraints = false;
            GuessButton.Font = UIFont.FromName("Helvetica-Bold", 20f);
            GuessButton.SetTitle("GUESS", UIControlState.Normal);
            GuessButton.BackgroundColor = UIColor.Blue;
            GuessButton.Layer.CornerRadius = 8;
            GuessButton.SetTitleColor(UIColor.White, UIControlState.Normal);


            // add these suckas to the super view
            this.Add(InfoLabel);
            this.Add(NameLabel);
            this.Add(ScoreLabel);
            this.Add(GuessButton);
        }
    }
}
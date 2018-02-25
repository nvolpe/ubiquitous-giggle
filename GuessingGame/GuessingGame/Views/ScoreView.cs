using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

using GuessingGame.Services;
using GuessingGame.Models;

namespace GuessingGame.Views
{
    class ScoreView : UIView
    {
        public UILabel StaticLabel { get; set; }
        public UILabel NameLabel { get; set; }
        public UILabel ScoreLabel { get; set; }
        public UILabel MessageLabel { get; set; }
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
            StaticLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            StaticLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            StaticLabel.TopAnchor.ConstraintEqualTo(this.TopAnchor, 10).Active = true;

            NameLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            NameLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            NameLabel.TopAnchor.ConstraintEqualTo(StaticLabel.BottomAnchor, 10).Active = true;

            GuessButton.WidthAnchor.ConstraintEqualTo(150).Active = true;
            GuessButton.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            GuessButton.TopAnchor.ConstraintEqualTo(NameLabel.BottomAnchor, 30).Active = true;

            MessageLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            MessageLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            MessageLabel.TopAnchor.ConstraintEqualTo(GuessButton.BottomAnchor, 20).Active = true;

            ScoreLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            ScoreLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            ScoreLabel.BottomAnchor.ConstraintEqualTo(this.BottomAnchor, -15).Active = true;

            base.UpdateConstraints();
        }

        private void CreateViews()
        {

            // The Labels
            // ---------------------------------
            StaticLabel = new UILabel();
            StaticLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            StaticLabel.TextColor = UIColor.Black;
            StaticLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            StaticLabel.TextAlignment = UITextAlignment.Center;
            StaticLabel.Text = "Your Selection:";

            NameLabel = new UILabel();
            NameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NameLabel.TextColor = UIColor.Black;
            NameLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            NameLabel.TextAlignment = UITextAlignment.Center;
            NameLabel.Text = "------";

            MessageLabel = new UILabel();
            MessageLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            MessageLabel.TextColor = UIColor.Black;
            MessageLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            MessageLabel.TextAlignment = UITextAlignment.Center;
            MessageLabel.Text = "";

            ScoreLabel = new UILabel();
            ScoreLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            ScoreLabel.TextColor = UIColor.Black;
            ScoreLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            ScoreLabel.TextAlignment = UITextAlignment.Center;
            ScoreLabel.Text = "Score 0 of 10";

            // The Button
            // ---------------------------------
            GuessButton = new UIButton();
            GuessButton.TranslatesAutoresizingMaskIntoConstraints = false;
            GuessButton.Font = UIFont.FromName("Helvetica-Bold", 20f);
            GuessButton.SetTitle("GUESS", UIControlState.Normal);
            GuessButton.BackgroundColor = UIColor.Blue;
            GuessButton.Layer.CornerRadius = 8;
            GuessButton.Alpha = 0.5f;
            GuessButton.UserInteractionEnabled = false;
            GuessButton.SetTitleColor(UIColor.White, UIControlState.Normal);

            // add these suckas to the super view
            this.Add(StaticLabel);
            this.Add(NameLabel);
            this.Add(MessageLabel);
            this.Add(ScoreLabel);
            this.Add(GuessButton);
        }

        public void EnableButton(Player player)
        {
            string playerName = string.Format("{0} {1}", player.first_name, player.last_name);

            GuessButton.Alpha = 1f;
            GuessButton.BackgroundColor = UIColor.Green;
            GuessButton.UserInteractionEnabled = true;

            NameLabel.Text = playerName;
        }

        public void DisableButton()
        {
            GuessButton.Alpha = .5f;
            GuessButton.BackgroundColor = UIColor.Blue;
            GuessButton.UserInteractionEnabled = false;

            NameLabel.Text = "------";
        }
    }
}
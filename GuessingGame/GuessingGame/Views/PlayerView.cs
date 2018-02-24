﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace GuessingGame.Views
{
    class PlayerView : UIView
    {
        public UIImageView PlayerImageView { get; set; }
        public UILabel PlayerNameLabel { get; set; }

        public PlayerView(/*UIImage image*/)
        {
            CreateImageView();
            CreateLabel();
            this.TranslatesAutoresizingMaskIntoConstraints = false;

            // Just so we can see the frame while debugging
            this.Layer.BorderColor = UIColor.Purple.CGColor; 
            this.Layer.BorderWidth = 5;
        }

        public override void LayoutMarginsDidChange()
        {
            base.LayoutMarginsDidChange();

            // this is hacky, I can't figure out how to resize the orginal image, and the parent imageview size. 
            var radius = (this.Frame.Size.Height * .75) / 2;

            PlayerImageView.Layer.CornerRadius = (float)radius;
            PlayerImageView.ClipsToBounds = true;
        }

        //public override CGSize IntrinsicContentSize => new CGSize(150, 150);

        public override void UpdateConstraints()
        {
            // Constraints for image view... a bit hacky right now without aspect ration working. 
            PlayerImageView.WidthAnchor.ConstraintEqualTo(this.WidthAnchor, .75f).Active = true;
            PlayerImageView.HeightAnchor.ConstraintEqualTo(this.HeightAnchor, .75f).Active = true;

            PlayerImageView.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            PlayerImageView.TopAnchor.ConstraintEqualTo(this.TopAnchor, 5).Active = true;

            PlayerNameLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            PlayerNameLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            PlayerNameLabel.TopAnchor.ConstraintEqualTo(PlayerImageView.BottomAnchor, 5).Active = true;

            base.UpdateConstraints();
        }


        private void CreateImageView()
        {
            UIImage image = FromUrl();

            PlayerImageView = new UIImageView(image);
            PlayerImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            PlayerImageView.TranslatesAutoresizingMaskIntoConstraints = false;
            PlayerImageView.Layer.BorderWidth = 5;
            PlayerImageView.Layer.BorderColor = UIColor.Green.CGColor;

            this.Add(PlayerImageView);
        }

        private void CreateLabel()
        {
            PlayerNameLabel = new UILabel();
            PlayerNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            PlayerNameLabel.TextColor = UIColor.Black;
            PlayerNameLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            PlayerNameLabel.TextAlignment = UITextAlignment.Center;
            PlayerNameLabel.Text = "Lebron James";

            this.Add(PlayerNameLabel);
        }

        private UIImage FromUrl()
        {
            return UIImage.FromFile("9524.png");

            //using (var url = new NSUrl(uri))
            //using (var data = NSData.FromUrl(url))
            //    return UIImage.LoadFromData(data);
        }
    }
}
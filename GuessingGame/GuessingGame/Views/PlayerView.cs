﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

using GuessingGame.Services;
using GuessingGame.Models;
using GuessingGame.Views;

namespace GuessingGame.Views
{
    public class PlayerView : UIView
    {

        /* 
         *  🔈
         *  
         *  I have always considered myself an Android and Windows guy. I don't even own a Macbook, but I'm using one currently as a build agent.
         *  Learning iOS for my job has been such a fun task these last few months and I defnitely appreciate how the software is built. But now it just makes me even more curious to see how
         *  Android handles the UI. (Other than my experience with Xamarin.Forms)
         *  
         *  FWIW I am developing on a Windows Machine with Visual Studio 2017. I have used Visual Studio For Mac a bit. 
         *  
         *  It sounds like Fan Duel is really leveraging the benefits of Xamarin and maxmizing code reuse for the buisness logic. I would love to be a part of that. 
         */


        public UIImageView PlayerImageView { get; set; }
        public UILabel PlayerNameLabel { get; set; }
        public UILabel FppgLabel { get; set; }
        public Player CurrentPlayer { get; set; }

        public event Action<Player> PlayerSelected;

        UITapGestureRecognizer TapGesture;

        public PlayerView(Player player)
        {
            CurrentPlayer = player;
            CreateImageView();
            CreateLabels();

            this.TranslatesAutoresizingMaskIntoConstraints = false;
            this.BackgroundColor = UIColor.Clear;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            this.BackgroundColor = UIColor.Clear;

            // this is hacky, I can't figure out how to resize the orginal image, and the parent imageview size. 
            var radius = (this.Frame.Size.Height * .75) / 2;

            PlayerImageView.Layer.CornerRadius = (float)radius;
            PlayerImageView.ClipsToBounds = true;
        }

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

            FppgLabel.WidthAnchor.ConstraintEqualTo(this.WidthAnchor).Active = true;
            FppgLabel.CenterXAnchor.ConstraintEqualTo(this.CenterXAnchor).Active = true;
            FppgLabel.TopAnchor.ConstraintEqualTo(PlayerNameLabel.BottomAnchor, 5).Active = true;

            base.UpdateConstraints();
        }

        private void CreateImageView()
        {
            UIImage image = FromUrl();

            PlayerImageView = new UIImageView(image);
            PlayerImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
            PlayerImageView.TranslatesAutoresizingMaskIntoConstraints = false;
            PlayerImageView.Layer.BorderWidth = 1;
            PlayerImageView.Layer.BorderColor = UIColor.Blue.CGColor;
            PlayerImageView.UserInteractionEnabled = true;

            TapGesture = new UITapGestureRecognizer(ImageTapped);
            PlayerImageView.AddGestureRecognizer(TapGesture);

            this.Add(PlayerImageView);
        }

        private void CreateLabels()
        {
            string playerName = string.Format("{0} {1}", CurrentPlayer.first_name, CurrentPlayer.last_name);

            PlayerNameLabel = new UILabel();
            PlayerNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            PlayerNameLabel.TextColor = UIColor.Black;
            PlayerNameLabel.Font = UIFont.FromName("Helvetica-Bold", 14f);
            PlayerNameLabel.MinimumFontSize = 8f;
            PlayerNameLabel.TextAlignment = UITextAlignment.Center;
            PlayerNameLabel.Text = playerName;
            PlayerNameLabel.LineBreakMode = UILineBreakMode.WordWrap;
            PlayerNameLabel.Lines = 2;

            FppgLabel = new UILabel();
            FppgLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            FppgLabel.TextColor = UIColor.Black;
            FppgLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
            FppgLabel.MinimumFontSize = 8f;
            FppgLabel.TextAlignment = UITextAlignment.Center;
            FppgLabel.Text = "";

            this.Add(PlayerNameLabel);
            this.Add(FppgLabel);
        }

        private UIImage FromUrl()
        {
            var uri = CurrentPlayer.images.@default.url;

            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }

        void ImageTapped()
        {
            if (PlayerSelected != null)
                PlayerSelected(CurrentPlayer);
        }

        public void DisableImageViewButton()
        {
            PlayerImageView.RemoveGestureRecognizer(TapGesture);
        }
    }
}
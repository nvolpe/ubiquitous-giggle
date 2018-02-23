using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace GuessingGame.Views
{
    class PlayerView : UIImageView
    {
        public PlayerView(UIImage image)
        {
            Image = image;
        }

        //public override CGSize IntrinsicContentSize
        //{
        //    get
        //    {
        //        CGSize size = new CGSize(150,150);
        //        return size;
        //    }
        //}

    }
}
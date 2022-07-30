using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoxInTheCookieFactory.Android
{
    internal class CardObject
    {
        public GameModel.Card BaseCard { get; set; }
        public CardObject(GameModel.Card baseCard)
        {
            BaseCard = baseCard;
        }
    }
}
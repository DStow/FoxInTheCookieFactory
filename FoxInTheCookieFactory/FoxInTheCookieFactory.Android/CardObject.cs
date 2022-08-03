using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public void DrawCard(SpriteBatch spriteBatch, Vector2 position, int width)
        {
            var cardTexture = CardContentManager.Instance.GetCardTexture(BaseCard.Suit.ToString()[0].ToString().ToLower() + BaseCard.Value);
            spriteBatch.Draw(cardTexture, position, Color.White);
        }
    }
}
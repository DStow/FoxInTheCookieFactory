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
        private float _cardRatio = 1.39f;
        private Texture2D _cardTexture;

        public CardObject(GameModel.Card baseCard)
        {
            BaseCard = baseCard;
            _cardTexture = CardContentManager.Instance.GetCardTexture(BaseCard.Suit.ToString()[0].ToString().ToLower() + BaseCard.Value);
        }

        public void DrawCard(SpriteBatch spriteBatch, Vector2 position, int width)
        {
            var drawArea = FoxGame.Camera.ComputeWorldAreaToPixelRectangle(position, new Vector2(width, _cardRatio * width), false);
            spriteBatch.Draw(_cardTexture, position, drawArea, Color.White);
        }
    }
}
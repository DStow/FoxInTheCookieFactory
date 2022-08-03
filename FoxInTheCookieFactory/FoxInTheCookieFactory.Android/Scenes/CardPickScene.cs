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

namespace FoxInTheCookieFactory.Android.Scenes
{
    internal class CardPickScene : BaseScene
    {
        private CardObject _decreeCard;
        private int _borderWidth = 0;
        private int _cardWidth = 0;

        public override void Update(GameTime gameTime)
        {
            _decreeCard = new CardObject(FoxGame.FoxGameModel.DecreeCard);
            _borderWidth = (int)(FoxGame.ScreenWidth * 0.05);
            _cardWidth = (FoxGame.ScreenWidth / 2) - _borderWidth - (_borderWidth / 2);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _decreeCard.DrawCard(spriteBatch, new Vector2(GetLeftCardX(), 25), _cardWidth);

            _decreeCard.DrawCard(spriteBatch, new Vector2(GetRightCardX(), 25), _cardWidth);
            base.Draw(spriteBatch);
        }

        private int GetLeftCardX()
        {
            return _borderWidth;
        }
         
        private int GetRightCardX()
        {
            return _borderWidth + _cardWidth + _borderWidth;
        }
    }
}
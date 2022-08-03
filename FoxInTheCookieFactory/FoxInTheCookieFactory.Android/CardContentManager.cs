using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoxInTheCookieFactory.Android
{
    internal class CardContentManager
    {
        private static CardContentManager _instance;
        public static CardContentManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CardContentManager();

                return _instance; ;
            }
            private set { _instance = value; }
        }

        private Dictionary<string, Texture2D> _cardFaces;

        public CardContentManager()
        {
            _cardFaces = new Dictionary<string, Texture2D>();
        }

        public void LoadContent(ContentManager content)
        {
            var suitPrefixes = new string[] { "k", "m", "b" };

            foreach (var prefix in suitPrefixes)
            {
                for (int i = 1; i <= 11; i++)
                {
                    _cardFaces.Add(prefix + i, content.Load<Texture2D>("card" + prefix + i));
                }
            }
        }

        public Texture2D GetCardTexture(string key)
        {
            return _cardFaces[key];
        }
    }
}
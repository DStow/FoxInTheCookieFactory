using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxInTheCookieFactory.Android.Core
{
    public class RectangleF
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        #region Constructors
        public RectangleF(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public RectangleF(Vector2 position, Vector2 size)
        {
            this.X = position.X;
            this.Y = position.Y;
            this.Width = size.X;
            this.Height = size.Y;
        }
        #endregion

        #region Sides
        public float Top
        {
            get { return Y; }
        }
        public float Bottom
        {
            get { return Y + Height; }
        }
        public float Left
        {
            get { return X; }
        }
        public float Right
        {
            get { return X + Width; }
        }
        #endregion

        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
        }

        public Vector2 Size
        {
            get { return new Vector2(Width, Height); }
        }

        /// <summary>
        /// Does this rectangle intersect another rectangle?
        /// </summary>
        public bool Intersects(RectangleF OtherRect)
        {
            if (Left < OtherRect.Right && Right > OtherRect.Left && Top < OtherRect.Bottom && Bottom > OtherRect.Top)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Does this rectangle contain a provided point
        /// </summary>
        public bool Contains(Vector2 point)
        {
            if (point.X >= this.X && point.X <= this.X + this.Width
                && point.Y >= this.Y && point.Y <= this.Y + this.Height)
                return true;
            else
                return false;
        }

        // Converts the RectangeF to a normal Rectangle without any fuss (This could cause precision loss?
        public static implicit operator Rectangle(RectangleF rect)
        {
            float buffer = 0.5f;
            return new Rectangle((int)rect.X, (int)rect.Y, (int)(rect.Width + buffer), (int)(rect.Height + buffer));
        }

        public override string ToString()
        {
            return "{X:" + X.ToString() + " Y:" + Y.ToString() + " Width:" + Width.ToString() + " Height: " + Height.ToString() + "}";
        }
    }
}
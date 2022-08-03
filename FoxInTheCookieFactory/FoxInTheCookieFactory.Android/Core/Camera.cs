using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using FoxInTheCookieFactory.Android.Enumeration;

namespace FoxInTheCookieFactory.Android.Core
{
    public class Camera
    {
        #region Properties
        /// <summary>
        /// The current game window width in pixels
        /// </summary>
        public int ScreenWidth { get; private set; }

        /// <summary>
        /// The current game window height in pixels
        /// </summary>
        public int ScreenHeight { get; private set; }

        /// <summary>
        /// The visible amount of world units in the camera
        /// </summary>
        public float VisibleWorldWidth
        {
            get
            {
                if (FixedOrientation == CameraFixedSideEnum.Height)
                {
                    return ScreenWidth / ScreenRatio;
                }
                else
                {
                    return ScreenWidth;
                }
            }
        }

        /// <summary>
        /// The visible amount of world units in the camera
        /// </summary>
        public float VisibleWorldHeight
        {
            get
            {
                if (FixedOrientation == CameraFixedSideEnum.Width)
                {
                    return ScreenHeight / ScreenRatio;
                }
                else
                {
                    return ScreenHeight;
                }
            }
        }

        /// <summary>
        /// What side is the camera fixed too
        /// </summary>
        public CameraFixedSideEnum FixedOrientation { get; private set; }

        /// <summary>
        /// The ratio between the visible world units and pixels
        /// </summary>
        public float ScreenRatio { get; private set; }

        /// <summary>
        /// Position of the camera in world units
        /// </summary>
        public Vector2 WorldPosition { get; set; }

        /// <summary>
        /// How many world units are visible across the cameras fixed orientation
        /// </summary>
        public int VisibleWorldUnits { get; set; }
        #endregion

        public Camera(int screenWidth, int screenHeight, CameraFixedSideEnum fixedOrientation, int visibleWorldUnits)
        {
            this.ScreenWidth = screenWidth;
            this.ScreenHeight = screenHeight;
            this.FixedOrientation = fixedOrientation;
            this.VisibleWorldUnits = visibleWorldUnits;
            this.ScreenRatio = CalculateCameraRatio();
        }

        /// <summary>
        /// Calculates the cameras ratio for world units to pixels
        /// </summary>
        /// <returns></returns>
        private float CalculateCameraRatio()
        {
            float ratio = 0;

            if (FixedOrientation == CameraFixedSideEnum.Width)
            {
                ratio = ScreenWidth / VisibleWorldUnits;
            }
            else if (FixedOrientation == CameraFixedSideEnum.Height)
            {
                ratio = ScreenHeight / VisibleWorldUnits;
            }

            return ratio;
        }

        /// <summary>
        /// Update the game screen sizes and refresh the ratio
        /// </summary>
        public void RefreshScreenSize(int screenWidth, int screenHeight)
        {
            this.ScreenWidth = screenWidth;
            this.ScreenHeight = ScreenHeight;

            this.ScreenRatio = CalculateCameraRatio();
        }

        /// <summary>
        /// Convert a world unit point to a pixel point
        /// </summary>
        /// <param name="ignoreCameraPosition">If true the camereas position will not be taken into account</param>
        /// <returns></returns>
        public Vector2 ComputeWorldPositionToPixelPosition(Vector2 worldPosition, bool ignoreCameraPosition = false)
        {
            if (ignoreCameraPosition)
                return new Vector2(worldPosition.X * ScreenRatio, worldPosition.Y * ScreenRatio);
            else
                return new Vector2((worldPosition.X - WorldPosition.X) * ScreenRatio, (worldPosition.Y - WorldPosition.Y) * ScreenRatio);
        }

        /// <summary>
        /// Covert a world unit area to a pixel area
        /// </summary>
        /// <param name="ignoreCameraPos">If true the camereas position will not be taken into account</param>
        /// <returns></returns>
        public RectangleF ComputeWorldAreaToPixelRectangle(Vector2 unitPosition, Vector2 unitSize, bool ignoreCameraPos = false)
        {
            Vector2 PixelPos = ComputeWorldPositionToPixelPosition(unitPosition, ignoreCameraPos);
            Vector2 PixelSize = new Vector2(unitSize.X * ScreenRatio, unitSize.Y * ScreenRatio);

            RectangleF retRect = new RectangleF(PixelPos.X, PixelPos.Y, PixelSize.X, PixelSize.Y);
            return retRect;
        }
    }
}

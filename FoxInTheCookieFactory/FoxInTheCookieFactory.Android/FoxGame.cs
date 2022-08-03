using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FoxInTheCookieFactory.Android
{
    public class FoxGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static GameModel.Game FoxGameModel;
        private CardObject _decreeCardObject;
        private Scenes.BaseScene _currentScene;

        public FoxGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            FoxGameModel = new GameModel.Game(null, null, null);
            FoxGameModel.Initilize();

            _currentScene = new Scenes.CardPickScene();

            _decreeCardObject = new CardObject(FoxGameModel.DecreeCard);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            CardContentManager.Instance.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _decreeCardObject.DrawCard(_spriteBatch, new Vector2(25, 25), 0);

            base.Draw(gameTime);
        }
    }
}

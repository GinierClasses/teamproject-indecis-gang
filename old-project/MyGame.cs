using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tower_defense.Core;

namespace tower_defense
{
    public class MyGame : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //Police d'écriture pour l'affichage du level
        private SpriteFont _gameplayfont;
        private string _levelNoString;

        MenuBase menu;
        MoneyGenerator moneyGenerator = new MoneyGenerator();
        Level level = new Level();

        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            // On passe au GraphicsDeviceManager pour
            // qu'il prenne ces valeurs et définissent comme taile de la fenetre 1.3.3
            _graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            _graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;
            IsMouseVisible = Settings.IS_MOUSE_VISIBLE;
            _graphics.IsFullScreen = Settings.IS_FULLSREEN;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.menu = new MenuMain();
            moneyGenerator.GenerateMoney(1000);
            _levelNoString = level.levelNo.ToString();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameplayfont = Content.Load<SpriteFont>("Fonts/gameplayFont");

            Resources.LoadImages(this.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.menu.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);
            this.menu.Draw(this._spriteBatch);


            _spriteBatch.DrawString(_gameplayfont, "Level: " + _levelNoString, new Vector2(600, 450), Color.Black);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

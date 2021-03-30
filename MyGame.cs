using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tower_defense.Core;
using System;

namespace tower_defense
{
    public class MyGame : Game
    {
        

        //1.3.1
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Constantes qui définissent la taille de la fenetre 1.3.2 
        /*public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 500;*/

        //1.5.1
        /*Monde monde;

        Player player;*/

        MenuBase menu;
        MoneyGenerator moneyGenerator = new MoneyGenerator();

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
            // TODO: Add your initialization logic here
            //1.5.2
            
            /*monde = new Monde();
            //Initialisation player (nombreDeSprites, )
            player = new Player(1, 71, 71);*/
            base.Initialize();

            this.menu = new MenuMain();
            moneyGenerator.GenerateMoney(1000);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //1.5.3
            Resources.LoadImages(this.Content);
            /*monde.Texture = Content.LoadLocalized<Texture2D>("towerSprites/BaseTowerTest");
            monde.Position = new Vector2(0,0);*/
            /*monde.Source = new Rectangle(0, 0, WINDOW_WIDTH, WINDOW_HEIGHT);*/

            //Chargement et positionnement du perso
            
            //Positionnement
            /*player.Position = new Vector2(201, 71);*/
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //1.3.4
            this.menu.Update();

            /*_graphics.PreferredBackBufferWidth = WINDOW_WIDTH;  
            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;*/

            /*player.UpdateFrame(gameTime);*/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
           
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);
                this.menu.Draw(this._spriteBatch);
           /* monde.Draw(_spriteBatch);
           player.DrawAnimation(_spriteBatch);*/
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

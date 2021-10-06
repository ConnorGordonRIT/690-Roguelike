using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Roguelike {
    
    public class Game1 : Game {
        //  ~Game1 Variables
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //  Input Variables
        private MouseState mouseStateCurr;
        private MouseState mouseStatePrev;

        //  Map Variables
        private GameMap map;

        //  Player Variables
        private ActorPlayer player;

        //  Server Variables
        private SvrComms svrComms;

        //  Texture Variables
        private Texture2D mapTileImg;
        private Texture2D playerImg;

        //  Constructor
        public Game1() {
            //  Part - ~Game1 Setup
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.IsFullScreen = true;
        }

        //  MainMethod - Initialize
        //  Process : Setup internal variables
        protected override void Initialize() {
            svrComms = new SvrComms();
            svrComms.SetupContact("127.0.0.1", 8888);

            base.Initialize();
        }

        //  MainMethod - Load Content
        //  Process : Attach external files to internal variables
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mapTileImg = Content.Load<Texture2D>("MT_TEMP");
            map = new GameMap(mapTileImg);

            playerImg = Content.Load<Texture2D>("MT_TEMP");
            GameObject tempToken = new GameObject(playerImg, new Rectangle(0, 0, 60, 60), new Rectangle(0, 0, 60, 60));
            player = new ActorPlayer(tempToken);
        }

        //  MainMethod - Update
        //  Process : Handle Game1's logic
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseStateCurr = Mouse.GetState();

            player.Update(mouseStateCurr, mouseStatePrev);

            mouseStatePrev = Mouse.GetState();

            base.Update(gameTime);
        }

        //  MainMethod - Draw
        //  Process : Handle Game1's graphics
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //map.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

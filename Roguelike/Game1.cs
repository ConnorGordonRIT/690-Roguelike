using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Roguelike {
    public class Game1 : Game {
        //  ~Game1 Variables
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //  Server Variables
        SvrComms svrComms;

        //  Constructor
        public Game1() {
            //  Part - ~Game1 Setup
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
        }

        //  MainMethod - Update
        //  Process : Handle Game1's logic
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        //  MainMethod - Draw
        //  Process : Handle Game1's graphics
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

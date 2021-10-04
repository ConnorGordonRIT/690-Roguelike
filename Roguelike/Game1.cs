using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Roguelike {
    
    public class Game1 : Game {
        //  ~Game1 Variables
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //Server chatbox
        private Rectangle chatBox;
        string text = "";
        int cursorPos = 0;
        SpriteFont font;
        Rectangle textBox;
        Rectangle sendBtn;

        //  Map Variables
        private GameMap map;

        //  Server Variables
        private SvrComms svrComms;

        //  Texture Variables
        private Texture2D mapTileImg;

        //  Constructor
        public Game1() {
            //  Part - ~Game1 Setup
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            chatBox = new Rectangle(GraphicsDevice.Viewport.Width - 25, 0, GraphicsDevice.Viewport.Width / 8, GraphicsDevice.Viewport.Height);
            textBox = new Rectangle(chatBox.X, chatBox.Y, chatBox.Width, chatBox.Height - 10);
            sendBtn = new Rectangle(chatBox.X, chatBox.Height - 10, chatBox.Width, 10);

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.IsFullScreen = true;
        }

        //  MainMethod - Initialize
        //  Process : Setup internal variables
        protected override void Initialize() {
            //svrComms = new SvrComms();
            //svrComms.SetupContact("127.0.0.1", 8888);

            base.Initialize();
        }

        //  MainMethod - Load Content
        //  Process : Attach external files to internal variables
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mapTileImg = Content.Load<Texture2D>("MT_TEMP");
            map = new GameMap(mapTileImg);
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

            map.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void CharEntered(char c)
        {
            string newText = text.Insert(cursorPos, c.ToString()); //Insert the char

            //Check if the text width is shorter than the back rectangle
            if (font.MeasureString(newText).X < textBox.Width)
            {
                text = newText; //Set the text
                cursorPos++; //Move the text cursor
            }
        }
    }
}

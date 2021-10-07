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
        private KeyboardState oldKeyState;
        private KeyboardState keyState;
        private string text;

        Keys[] keysToCheck = new Keys[] {
            Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
            Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
            Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
            Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
            Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
            Keys.Z, Keys.Back, Keys.Space 
        };


        //  Map Variables
        private GameMap map;

        //  Player Variables
        private ActorPlayer player;

        //  Server Variables
        private SvrComms svrComms;

        //Chatbox variables
        private SvrChatbox chatBox;

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

            text = "";
        }

        //  MainMethod - Update
        //  Process : Handle Game1's logic
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseStateCurr = Mouse.GetState();

            player.Update(mouseStateCurr, mouseStatePrev);

            mouseStatePrev = Mouse.GetState();

            oldKeyState = keyState;
            keyState = Keyboard.GetState();
            foreach(Keys key in keysToCheck)
            {
                if (CheckKey(key))
                {
                    AddKeyToText(key);
                    break;
                }
            }

            base.Update(gameTime);

            oldKeyState = keyState;
        }

        //  MainMethod - Draw
        //  Process : Handle Game1's graphics
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //map.Draw(spriteBatch);
            player.Draw(spriteBatch);

            chatBox.Draw(text);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void AddKeyToText (Keys key)
        {
            string newChar = "";

            if(text.Length >= 20 && key != Keys.Back)
            {
                return;
            }

            switch (key)
            {
                case Keys.A:
                    newChar += "a";
                    break;
                case Keys.B:
                    newChar += "b";
                    break;
                case Keys.C:
                    newChar += "c";
                    break;
                case Keys.D:
                    newChar += "d";
                    break;
                case Keys.E:
                    newChar += "e";
                    break;
                case Keys.F:
                    newChar += "f";
                    break;
                case Keys.G:
                    newChar += "g";
                    break;
                case Keys.H:
                    newChar += "h";
                    break;
                case Keys.I:
                    newChar += "i";
                    break;
                case Keys.J:
                    newChar += "j";
                    break;
                case Keys.K:
                    newChar += "k";
                    break;
                case Keys.L:
                    newChar += "l";
                    break;
                case Keys.M:
                    newChar += "m";
                    break;
                case Keys.N:
                    newChar += "n";
                    break;
                case Keys.O:
                    newChar += "o";
                    break;
                case Keys.P:
                    newChar += "p";
                    break;
                case Keys.Q:
                    newChar += "q";
                    break;
                case Keys.R:
                    newChar += "r";
                    break;
                case Keys.S:
                    newChar += "s";
                    break;
                case Keys.T:
                    newChar += "t";
                    break;
                case Keys.U:
                    newChar += "u";
                    break;
                case Keys.V:
                    newChar += "v";
                    break;
                case Keys.W:
                    newChar += "w";
                    break;
                case Keys.X:
                    newChar += "x";
                    break;
                case Keys.Y:
                    newChar += "y";
                    break;
                case Keys.Z:
                    newChar += "z";
                    break;
                case Keys.Space:
                    newChar += " ";
                    break;
                case Keys.Back:
                    if (text.Length != 0)
                        text = text.Remove(text.Length - 1);
                    return;

            }

            if(keyState.IsKeyDown(Keys.RightShift) || keyState.IsKeyDown(Keys.LeftShift))
            {
                newChar = newChar.ToUpper();
            }
            text += newChar;

            if (keyState.IsKeyDown(Keys.Enter) && text != "")
            {
                chatBox.SendPost(text, svrComms);

                text = "";
            }
        }

        private bool CheckKey (Keys theKey)
        {
            return oldKeyState.IsKeyDown(theKey) && keyState.IsKeyUp(theKey);
        }
    }
}

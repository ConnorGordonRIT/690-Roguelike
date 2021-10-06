using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;

namespace Roguelike {
    class SvrChatbox {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont textStyle;
        String text;

        private GameObject textBox;
        private GameObject chatLog;
        
        public SvrChatbox(Texture2D boxSprite, Texture2D logSprite, Rectangle area, SpriteFont font)
        {
            textStyle = font;
            Rectangle frame = new Rectangle(0, 0, 100, 100);

            int originalY = area.Y;
            int originalHeight = area.Height;

            area.Y = area.Height - 10;
            area.Height = 10;

            textBox = new GameObject(boxSprite, frame, area);

            area.Y = originalY;
            area.Height = originalHeight - 10;


            chatLog = new GameObject(logSprite, frame, area);

            textBox.Draw(spriteBatch);
            chatLog.Draw(spriteBatch);
            

        }



        //Displays player text on the chat log
        public void Register(string input)
        {
            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = input.Split(' ');

            foreach(String word in wordArray)
            {
                if(textStyle.MeasureString(line + word).Length() > chatLog.ObjArea.Width)
                {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }

                line = line + word + ' ';
            }

            returnString = returnString + line;

            spriteBatch.DrawString(textStyle, returnString, new Vector2(chatLog.objPos.X, chatLog.objPos.Y), Color.White);
        }

        //Sends the player text to other players
        public string Post(string input)
        {

        }
    }
}

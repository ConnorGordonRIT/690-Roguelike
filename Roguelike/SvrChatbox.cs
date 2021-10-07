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
        }



        //Draws text box and chat log and displays player's text in the text box
        public void Draw(string input)
        {
            textBox.Draw(spriteBatch);
            chatLog.Draw(spriteBatch);

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

            spriteBatch.DrawString(textStyle, returnString, new Vector2(textBox.objPos.X, textBox.objPos.Y), Color.White);
        }

        //Sends the player text to other players and displays it in the chat log
        public string SendPost(string input, SvrComms messenger)
        {

            /* Write code for sending posts here */

            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = input.Split(' ');

            foreach (String word in wordArray)
            {
                if (textStyle.MeasureString(line + word).Length() > chatLog.ObjArea.Width)
                {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }

                line = line + word + ' ';
            }

            returnString = returnString + line;

            spriteBatch.DrawString(textStyle, returnString, new Vector2(chatLog.objPos.X, chatLog.objPos.Y), Color.White);

            spriteBatch.DrawString(textStyle, "", new Vector2(textBox.objPos.X, textBox.objPos.Y), Color.White);

            return input;
        }

        //Receives posts from other players and displays it in the chat log
        public string ReceivePost(SvrComms messenger)
        {
            string message = "";

            /* Write code for receiving posts here */

            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = message.Split(' ');

            foreach (String word in wordArray)
            {
                if (textStyle.MeasureString(line + word).Length() > chatLog.ObjArea.Width)
                {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }

                line = line + word + ' ';
            }

            returnString = returnString + line;

            spriteBatch.DrawString(textStyle, returnString, new Vector2(chatLog.objPos.X, chatLog.objPos.Y), Color.White);

            return message;
        }


    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;

namespace Roguelike {
    class SvrChatbox {
        private GameObject textBox;
        private GameObject chatLog;
        
        public SvrChatbox(Texture2D boxSprite, Texture2D logSprite, Rectangle frame, Rectangle area)
        {
            textBox = new GameObject(boxSprite, frame, area);
            /* Further tweak the text box's frame and area here */

            chatLog = new GameObject(logSprite, frame, area);
            /* Further tweak the text box's frame and area here */
        }

        public void Register(string input)
        {

        }

        public string Post(string input)
        {
            return "";
        }
    }
}

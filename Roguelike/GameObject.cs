using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Roguelike {
    class GameObject {
        //  Area Variables
        private Vector2 objPos;
        private Point objSize;
        protected Rectangle ObjArea => new Rectangle(objPos.ToPoint(), objSize);

        //  Image Variables
        private Texture2D objImage;

        protected Vector2 objFPos;
        protected Point objFSize;
        protected Rectangle ObjFrame => new Rectangle(objFPos.ToPoint(), objFSize);

        //  Constructor (param Image, Frame, Area)
        public GameObject(Texture2D pImage, Rectangle pFrame, Rectangle pArea) {
            //  Part - Area Setup
            objPos = pArea.Location.ToVector2();
            objSize = pArea.Size;

            //  Part - Image Setup
            objImage = pImage;
            objFPos = pFrame.Location.ToVector2();
            objFSize = pFrame.Size;
        }

        //  MainMethod - Draw (param Sprite Batch)
        public void Draw(SpriteBatch pSBatch) {
            pSBatch.Draw(objImage, ObjArea, ObjFrame, Color.White);
        }
    }
}

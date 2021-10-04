using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Roguelike {
    class MapTile {
        //  GameObject Variables
        private GameObject tileObj;

        //  Constructor (param Room Start, Tile Position, Image)
        public MapTile(Point pRoomStart, Point pTilePos, Texture2D pImg) {
            Point tilePos = new Point(pRoomStart.X + pTilePos.X * 60, pRoomStart.Y + pTilePos.Y * 60);

            Rectangle tileArea = new Rectangle(tilePos.X, tilePos.Y, 60, 60);
            Rectangle tileFrame = new Rectangle(0, 0, 60, 60);

            tileObj = new GameObject(pImg, tileFrame, tileArea);
        }

        //  MainMethod - Draw (param Spritebatch)
        public void Draw(SpriteBatch pSBatch) {
            tileObj.Draw(pSBatch);
        }
    }
}
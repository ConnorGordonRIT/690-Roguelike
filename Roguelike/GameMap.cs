using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Roguelike {
    class GameMap {
        //  Room Variables
        private List<MapRoom> mapRooms;

        //  Constructor (param Tile Image)
        public GameMap(Texture2D pTileImg) {
            mapRooms = new List<MapRoom>();

            mapRooms.Add(new MapRoom(new Point(0, 0), new Point(5, 5), pTileImg));
        }

        //  MainMethod - Draw (param Spritebatch)
        public void Draw(SpriteBatch pSBatch) {
            foreach (MapRoom room in mapRooms) {
                room.Draw(pSBatch);
            }
        }
    }
}
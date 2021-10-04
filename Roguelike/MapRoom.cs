using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Roguelike {
    class MapRoom {
        //  Tile Variables
        private List<MapTile> roomTiles;

        //  Constructor (param Room Start, Room Size, Tile Image)
        public MapRoom (Point pRoomStart, Point pRoomSize, Texture2D pTileImg) {
            roomTiles = new List<MapTile>();

            for (int y = 0; y < pRoomSize.Y; y++) {
                for (int x = 0; x < pRoomSize.X; x++) {
                    roomTiles.Add(new MapTile(pRoomStart, new Point(x, y), pTileImg));
                }
            }
        }

        //  MainMethod - Draw (param Spritebatch)
        public void Draw(SpriteBatch pSBatch) {
            foreach(MapTile tile in roomTiles) {
                tile.Draw(pSBatch);
            }
        }
    }
}
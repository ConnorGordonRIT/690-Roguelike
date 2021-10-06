using Microsoft.Xna.Framework.Graphics;

namespace Roguelike {
    class GameActor {
        //  Token Variables
        protected GameObject actorToken;

        //  Constructor
        public GameActor(GameObject pToken) {
            actorToken = pToken;
        }
    }
}
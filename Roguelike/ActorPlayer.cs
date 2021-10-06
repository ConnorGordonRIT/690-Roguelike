using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Roguelike {
    class ActorPlayer : GameActor {
        //  Token Variables
        private bool tokenSelected;
        private Point tokenOffset;

        //  Constructor
        public ActorPlayer(GameObject pToken) : base(pToken) {

        }

        //  MainMethod - Update
        public void Update(MouseState pMSCurr, MouseState pMSPrev) {
            InputControl(pMSCurr, pMSPrev);
            TokenControl(pMSCurr.Position);
        }

        //  SubMethod of Update - Input Control
        private void InputControl(MouseState pMSCurr, MouseState pMSPrev) {
            if (pMSPrev.LeftButton == ButtonState.Pressed && pMSCurr.LeftButton == ButtonState.Released) {
                LClickControl(pMSCurr.Position);
            }
        }

        //  SubMethod of InputControl - Left Click Control
        private void LClickControl(Point pMPos) {
            //  Part - Player Left Clicks their token
            if (actorToken.ObjArea.Contains(pMPos)) {
                tokenSelected = !tokenSelected;

                //  SubPart - Get offset from mouse and token
                if (tokenSelected == true) {
                    tokenOffset = new Point(pMPos.X - actorToken.ObjArea.X, pMPos.Y - actorToken.ObjArea.Y);
                }

                //  SubPart - Snap to grid
                else if (tokenSelected == false) {
                    Vector2 actPos = new Vector2(actorToken.objPos.X / 60, actorToken.objPos.Y / 60);
                    Point actFin = actPos.ToPoint();
                    
                    if ((actPos.X - actPos.ToPoint().X) > 0.5f) {
                        actFin.X++;
                    }

                    if ((actPos.Y - actPos.ToPoint().Y) > 0.5f) {
                        actFin.Y++;
                    }

                    actorToken.objPos = new Vector2(actFin.X * 60, actFin.Y * 60);
                }
            }
        }

        //  SubMethod of Update - Token Control
        private void TokenControl(Point pMPos) {
            if (tokenSelected == true) {
                actorToken.objPos = new Vector2(pMPos.X - tokenOffset.X, pMPos.Y - tokenOffset.Y);
            }
        }

        //  MainMethod - Draw
        public void Draw(SpriteBatch pSBatch) {
            actorToken.Draw(pSBatch);
        }
    }
}
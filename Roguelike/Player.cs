using Microsoft.Xna.Framework.Graphics;

namespace Roguelike {
    class Player {
        //  ~Player Variables
        private GameObject playerToken;

        //  Ability Variables
        //  => Strength Variables
        private int playerStr_Score;
        private int playerStr_Mod;
        private bool playerSave_Str;

        private bool playerSkill_Ath;

        //  => Dexterity Variables
        private int playerDex_Score;
        private int playerDex_Mod;
        private bool playerSave_Dex;

        private bool playerSkill_Acr;
        private bool playerSkill_SoH;
        private bool playerSkill_Snk;

        //  => Constitution Variables
        private int playerCon_Score;
        private int playerCon_Mod;
        private bool playerSave_Con;

        //  => Intelligence Variables
        private int playerInt_Score;
        private int playerInt_Mod;
        private bool playerSave_Int;

        private bool playerSkill_Arc;
        private bool playerSkill_His;
        private bool playerSkill_Inv;
        private bool playerSkill_Nat;
        private bool playerSkill_Rel;

        //  => Wisdom Variables
        private int playerWis_Score;
        private int playerWis_Mod;
        private bool playerSave_Wis;

        private bool playerSkill_Ani;
        private bool playerSkill_Ins;
        private bool playerSkill_Med;
        private bool playerSkill_Per;
        private bool playerSkill_Sur;

        //  => Charisma Variables
        private int playerCha_Score;
        private int playerCha_Mod;
        private bool playerSave_Cha;

        private bool playerSkill_Dec;
        private bool playerSkill_Int;
        private bool playerSkill_Perf;
        private bool playerSkill_Pers;

        //  MainMethod - Draw (param Sprite Batch)
        public void Draw(SpriteBatch pSBatch) {
            playerToken.Draw(pSBatch);
        }
    }
}
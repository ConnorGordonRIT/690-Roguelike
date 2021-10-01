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

        private bool playerSkill_Ath;   //  Athletics

        //  => Dexterity Variables
        private int playerDex_Score;
        private int playerDex_Mod;
        private bool playerSave_Dex;

        private bool playerSkill_Acr;   //  Acrobatics
        private bool playerSkill_SoH;   //  Sleight of Hand
        private bool playerSkill_Snk;   //  Stealth (Sneak)

        //  => Constitution Variables
        private int playerCon_Score;
        private int playerCon_Mod;
        private bool playerSave_Con;

        //  => Intelligence Variables
        private int playerInt_Score;
        private int playerInt_Mod;
        private bool playerSave_Int;

        private bool playerSkill_Arc;   //  Arcana
        private bool playerSkill_His;   //  History
        private bool playerSkill_Inv;   //  Investigation
        private bool playerSkill_Nat;   //  Nature
        private bool playerSkill_Rel;   //  Religion

        //  => Wisdom Variables
        private int playerWis_Score;
        private int playerWis_Mod;
        private bool playerSave_Wis;

        private bool playerSkill_Ani;   //  Animal Handling
        private bool playerSkill_Ins;   //  Insight
        private bool playerSkill_Med;   //  Medicine
        private bool playerSkill_Per;   //  Persuasion
        private bool playerSkill_Sur;   //  Survival

        //  => Charisma Variables
        private int playerCha_Score;
        private int playerCha_Mod;
        private bool playerSave_Cha;

        private bool playerSkill_Dec;   //  Deception
        private bool playerSkill_Int;   //  Intimidation
        private bool playerSkill_Perf;  //  Performance
        private bool playerSkill_Pers;  //  Persuasion

        //  MainMethod - Draw (param Sprite Batch)
        public void Draw(SpriteBatch pSBatch) {
            playerToken.Draw(pSBatch);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;

namespace MonsterLibrary
{
    public class Dracula : Monster
    {
        public Dracula(string name, int maxLife, int maxDamage, int life, int hitChance, int block,
            int minDamage, string description) : base(name, maxLife, maxDamage, life, hitChance, block, minDamage, description){}

        public override string DisplayImage()
        {
            #region Image
            string draculaPic = @"

                                                      ,,,
                                                    /////\\
                                                    -O-O-||
                                                    |/   @|
                                                     \-  /
                                                    __| |__
                                                  .'       `.
                                                  |         |
                                                  | |     | |
                                                  | |     | |
                                                  | |     | |
                                                  |_|     |_|
                                                  \/|_____|\/
                                                    |  |  |
                                                    |  |  |
                                                    |  |  |
                                                    |  |  |
                                                    |  |  |
                                                    |  |  |
                                                   _|__|__|
                                                  (__(____]
        



";
            #endregion
            return (draculaPic);
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            return calculatedBlock;

        }
    }
}

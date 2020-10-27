using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;

namespace MonsterLibrary 
{
    public class Imp : Monster
    {
        public Imp(string name, int maxLife, int maxDamage, int life, int hitChance, int block,
            int minDamage, string description) : base(name, maxLife, maxDamage, life, hitChance, block, minDamage, description)
        {

        }

        public override string DisplayImage()
        {
            #region Image
            string impPic = @"

                                                    |\     /|
                                                    ||\\ //||
                                                    /,    ,  \
                                                   <0/  /0>  |
                               ______              (00)_     /                ______
                              \\\\\\\\\\            |WW/    |              //////////
                            \\\\\\\\\\\\\\\\\____    |      |     ____//////////////////
                         \\\\\\\\\\\\\\\\\\\\\\\\\  /        \   //////////////////////////
                       \\\\\\\\\\\\\\\\\\\\\\\\\\\\/          \//////////////////////////////
                      \\\\\\\\\\\\\\\\\\\\\\\\\\\\(     |     )///////////////////////////////
                               ~~~~~~~\\\\\\\\\\\\|    / \    |//////////////~~~~~~~
                                          \\\\\\\ |    | |    |////////
                                              \\\/|    | |    |\///
                                               /  |    | |    |  \
                                               \  |    | |    |  /
                                              __/\ \  /   \  / /\__
                                             (vvv)(vvv)---(vvv)(vvv)   
        



";
            #endregion
            return (impPic);
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            return calculatedBlock;

        }
    }
}

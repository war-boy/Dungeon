using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;

namespace MonsterLibrary
{
    public class DarkKnight : Monster
    {
        public DarkKnight(string name, int maxLife, int maxDamage, int life, int hitChance, int block,
            int minDamage, string description) : base(name, maxLife, maxDamage, life, hitChance, block, minDamage, description)
        {

        }

        public override string DisplayImage()
        {
            #region Image
            string knightPic = @"

                                                     /|
                                                     ||
                                                     ||      
                                                     ||      __X_
                                                     ||     ( ___\
                                                     ||     |:  \\
                                                    ><><  ___)..:/_#__,
                                                    (X|) (|+(____)+\ _)
                                                     o|_\/>> + + + << \
                                                       |:\/|+ + + +| \_\<
                                                       \./  XXXXXX.  (o_)_
                                                           /+ + + |   \:|
                                                          /+ +/+ +|  -/->>>----.
                                                         /+ +|+ /XX /   _--,  _ \
                                                        \+ + + /  |X   (,\- \/_ ,
                                                        /\+ + /\  |X \    /,//_/
                                                       +_+_+_( )o_)X  \  (( ///
                                                        (_o(  /__/ X   \  \\//
                                                         \_|  |_/  X    \ ///
                                                         \_| >(_/        \,/
                                                    ,////__o\ /__////,    V
        



";
            #endregion
            return (knightPic);
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            return calculatedBlock;

        }
    }
}

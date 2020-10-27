using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;

namespace MonsterLibrary
{
    public class Minotaur : Monster
    {
        public Minotaur(string name, int maxLife, int maxDamage, int life, int hitChance, int block,
            int minDamage, string description) : base(name, maxLife, maxDamage, life, hitChance, block, minDamage, description)
        {

        }

        public override string DisplayImage()
        {
            #region Image
            string minotaurPic = @"

                                           (    )
                                          ((((()))
                                          |o\ /o)|
                                          ( (  _')
                                           (._.  /\__
                                          ,\___,/ '  ')
                            '.,_,,       (  .- .   .    )
                             \   \\     ( '        )(    )
                              \   \\    \.  _.__ ____( .  |
                               \  /\\   .(   .'  /\  '.  )
                                \(  \\.-' ( /    \/    \)
                                 '  ()) _'.-|/\/\/\/\/\|
                                     '\\ .( |\/\/\/\/\/|
                                       '((  \    /\    /
                                       ((((  '.__\/__.')
                                        ((,) /   ((()   )
                                         '..-,  (()('   /
                                        _/.   ((() .'
                                  _____ / ,/' ___ ((( ', ___
                                                   ((  )
                                                    / /
                                                  _ /,/ '
                                                /,/, /
";
            #endregion
            return (minotaurPic);
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            return calculatedBlock;

        }



    }
}

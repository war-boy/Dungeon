using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;

namespace MonsterLibrary
{
    public class Bat : Monster
    {
        public Bat(string name, int maxLife, int maxDamage, int life, int hitChance, int block,
            int minDamage, string description, int xp): base(name, maxLife, maxDamage, life, hitChance, block, minDamage, description, xp)//REMEMBER we did this do we don't have to assign the properties to parameters
        {

        }

        public override string DisplayImage()
        {
            #region Image
            string batPic = @"

                             /\                 /\
                            / \'._   (\_/)   _.'/ \
                            |.''._'--(o.o)--'_.''.|
                             \_ / `;=/ ' \=;` \ _/
                               `\__| \___/ |__/`
                                    \(_|_)/
        




";
            #endregion
            return (batPic);
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            return calculatedBlock;

        }
    }
}

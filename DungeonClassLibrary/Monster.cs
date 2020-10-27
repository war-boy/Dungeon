using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonClassLibrary
{
    public class Monster : Character 
    {
        private int _minDamage; 

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int XP { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //cannot be more than MaxDamage and cannot be less than 1 
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        public Monster() { }

        public Monster(string name, int maxLife, int maxDamage, int life,  int hitChance, int block,
            int minDamage, string description, int xp)
        {
            //no FQC in the parent (Character), so we have to handle all assignments here
            //Set MaxLife and MaxDamage first because other properties depend on them.

            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
            XP = xp;
        }

        public override string ToString()
        {
            //return base.ToString(); no ToString() in Character class
            return string.Format("\n**** MONSTER ****\n{0}\nLife: {1} of {2}\nDamage: {3}" +
                " to {4}\nBlock: {5}\nDescription:\n{6}",
                Name,
                Life,
                MaxLife,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }

        public virtual string DisplayImage()
        {
            return "monster image will appear";
        }

        public override int CalcDamage()
        {
            Random rand2 = new Random();
            return rand2.Next(MinDamage, MaxDamage + 1);//+1 to account of exclusive upper bound
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{
    public class Weapon
    {
        private int _minDamage;
        
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than MaxDamage and cannot be less than 1 
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
        //fqc ctor
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance) 
        {
            MaxDamage = maxDamage; 
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
        }

        //Methods
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\nBonus Hit: {3}%",
                Name, MinDamage, MaxDamage, BonusHitChance);
        }
    }
}


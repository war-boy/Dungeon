using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonClassLibrary
{

    public class Player : Character
    {
        private int _experiencePoints; //TODO set up level system

        public Weapon EquippedWeapon { get; set; }
        public int PlayerLevel { get; set; } 
        public int PlayerAttack { get; set; }
        public int PlayerDefense { get; set; }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                if (_experiencePoints >= 500)
                {
                    MaxLife += 15;
                    HitChance += 2;
                    PlayerLevel = 2;
                    Console.WriteLine("You leveled up! You are now level 2");
                }
                if (_experiencePoints >= 1000)
                {
                    MaxLife += 20;
                    HitChance += 2;
                    PlayerLevel = 3;
                    Console.WriteLine("You leveled up! You are now level 3");
                }
            }
        }

        public Player(string name, int hitChance, int block, int life, int maxLife,
            int experiencePoints, Weapon equippedWeapon, int playerLevel, int playerAttack, int playerDefense)
        {
            Name = name;
            ExperiencePoints = experiencePoints;
            PlayerLevel = playerLevel;
            PlayerAttack = playerAttack;
            PlayerDefense = playerDefense;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
            EquippedWeapon = equippedWeapon;
            
           
        }

        public override string ToString()//TODO after leveling system, add all player info
        {
            return string.Format("------ {0} ------\nLife: {1} of {2}\nHit Chance: {3}%" +
                "\nWeapon:\n{4}\nBlock: {5}",
                Name,
                Life,
                MaxLife,
                CalcHitChance(), //returns base hit chance plus bonus hit chance from weapon
                EquippedWeapon,
                Block);
        }
        public override int CalcDamage()
        {
            Random rand1 = new Random();//dice roll
            int damageWeapon = rand1.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            int damage = (damageWeapon + PlayerAttack);

            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }

    }   
}


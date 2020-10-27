using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace DungeonClassLibrary
{
    public class GetBattle

    {
        //Warehouse for methods
        public static void DoBattle(Player player, Monster monster)
        {
            DoAttack(player, monster);

            //monster will attack second if they are still alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }

        public static void DoAttack(Character attacker, Character defender)//(player, monster) when attacking (monster, player) when enemy attacks
        {
            
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            Thread.Sleep(30);

            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //the attacker hit the defender
                //calculate the damage
                int damageDealt = attacker.CalcDamage();

                //assign damage
                defender.Life -= damageDealt;

                //screen flashes red
                //Console.Beep();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Thread.Sleep(300);
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                //write to the screen the result
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(1500);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} missed!", attacker.Name);
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(1500);
                Console.Clear();
            }
        }
    }
}

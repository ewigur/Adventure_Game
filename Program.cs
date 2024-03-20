using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift6_Emma_Wigur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            //Vapenval

            int weapon = 0;
  
            //Spelarens namn
            string pName = "";
            
            //Spelarens hälsa
            int pHP = 100;
            
            
            //Svärd Dmg
            int sMaxDmg = 14;
            int sMinDmg = 7;
            
            //Yxa Dmg
            int aMaxDmg = 26;
            int aMinDmg = 10;
            
            //Faktisk skada efter varje turn
            int paDmg = 0;

            //Fiende
            int eHP = 100;
            int eMinDmg = 9;
            int eMaxDmg = 25;
            int eaDmg = 0;

            Console.WriteLine("Welcome fighter! What should I call you?");

            //Input namn
            pName = Console.ReadLine();

            Console.WriteLine("Alright, " + pName + ". Are you ready to start the fight? Press Y for yes and N for no...");

            //Alternativ som inte är y eller n för spel
            Answer:
            string answer = Console.ReadLine().Trim().ToLower();

            //Åtgärd för nej
            if (answer == "n")
            {
                Console.WriteLine("No shame in that, I suppose. Come back when you're ready!");               
            }
            
            //Åtgärd för ja

            else if (answer == "y")
            {               
                Console.WriteLine("You start this fight with " + pHP + " health. Your opponent has " + eHP + " health. Choose your weapon: press 1 for Sword, or 2 for Axe...");     
            }
            
            else

            {
                Console.WriteLine("Press: Y/N, please.");
                goto Answer;
            }
            
            weapon:
            weapon = Convert.ToInt32(Console.ReadLine());

            if (weapon != 1 && weapon != 2)
            {
                Console.WriteLine("You only have two weapons. 1 or 2");
                goto weapon;
            }

            while (eHP >= 0 && pHP >= 0)
            {              
                //enemy roll
              
                eaDmg = rnd.Next(eMinDmg, eMaxDmg);
                pHP = pHP - eaDmg;
                Console.WriteLine("eaDMG: " + paDmg);
                Console.WriteLine("eaHP: " + pHP);

                //player roll               

                if (weapon == 1)
                {
                    paDmg = rnd.Next(sMinDmg, sMaxDmg);
                    Console.WriteLine("paDMG: " + eaDmg);
                    Console.WriteLine("paHP: " + eHP);
                    eHP = eHP - paDmg;                   
                }

                else if (weapon == 2)
                {
                    Console.WriteLine("paDMG: " + eaDmg);
                    Console.WriteLine("paHP: " + eHP);
                    paDmg = rnd.Next(aMinDmg, aMaxDmg);
                    eHP = eHP - paDmg;                  
                }

                if (eHP >= 0)
                {
                    Console.WriteLine("You've damaged your enemy. Their health is now " + eHP + ". Now it's their turn!");                    
                }

                else if (eHP <=0)
                {
                    Console.WriteLine("Enemy is down! You've won!");
                    break;
                }

                
                if (pHP <= 0)
                {
                    Console.WriteLine("You're done...Game over");
                    break;                  
                }

                else if (pHP >= 0)
                {
                    Console.WriteLine("You've taken some damage. Your health is now " + pHP + ". Now it's your turn! Choose weapon 1 or 2...");
                    goto weapon;
                }
                    Console.ReadLine();               
            }
        }
    }
}

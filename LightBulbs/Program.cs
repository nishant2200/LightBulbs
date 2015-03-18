using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//to solve light bulbs problem at http://puzzles.nigelcoldwell.co.uk/ 

namespace LightBulbs
{
    class Program
    {

        public static List<int> GetFactors(int num)
        {
            List<int> factors = new List<int>();

            for (int i = 1; i <= num; i++)
            {
                if (i == 1 || i == num)
                {
                    factors.Add(i);
                }
                else
                {
                    if (num % i == 0)
                    {
                        factors.Add(i);
                    }
                }
            }

            return factors;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Light Bulbs Number");            

            string strNum = Console.ReadLine();
            int num = 0;
            try
            {
                num = Convert.ToInt32(strNum);
            }
            catch (Exception e)
            {
                Console.WriteLine("Did not enter a valid number for light bulbs...");
                throw e;
            }

            Console.WriteLine("Enter what position light bulb final state you want to know?");

            string strPos = Console.ReadLine();
            int pos = 0;
            try
            {
                pos = Convert.ToInt32(strPos);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Position number");
                throw e;
            }

            if (num > 0)
            {
                List<int> finalState = new List<int>(num);
                for (int i = 1; i <= num; i++)
                {
                    List<int> factors = GetFactors(i);
                    
                    /*foreach (int x in factors)
                    {
                        Console.WriteLine(x);
                    }*/

                    int currentState = 0; //start with off, 0
                    foreach (int m in factors)
                    {
                        currentState ^= 1; //toggle the currentState, XOR with 1
                    }
                    finalState.Add(currentState);
                }

                Console.WriteLine("Final state of passed in position " + pos + " is: " + finalState[pos - 1]);
                Console.WriteLine("Final state of all bulbs is:");
                foreach (int n in finalState)
                {
                    Console.WriteLine(n); 
                }
                Console.WriteLine("____________________________________");
                Console.WriteLine("How many bulbs are on?");
                int count = 0;
                for (int i = 0; i < finalState.Count; i++)
                {                    
                    if (finalState[i] == 1)
                    {
                        count++;
                        Console.WriteLine("Bulb on at position: " + (i+1));
                    }                    
                }
                Console.WriteLine("Total bulbs on: " + count);
                Console.ReadLine();
                
            }
        }        
    }
}

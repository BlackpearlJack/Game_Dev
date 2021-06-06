using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riddle_einstein_Cshap
{
    enum Houses {Blue = 1, Green,Red,White,Yellow};
    enum Nationalities {Brit = 1, Dane, German,Norwegian, Swede};
    enum Drinks {Beer = 1, Coffee, Milk, Tea, Water };
    enum Smokes {Blends = 1, Blue_Master, Dunhill, Pall_Mall, Prince };
    enum Pets { Birds = 1, Cats, Dogs, Fish, Horses };
    class Program
    {
        static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            String positions = "12345";// There are five houses
            String[] combs = Combinations(positions);
            int solutions = 0;

            for(int nat = 0; nat< combs.Length; nat++)
            {
                if (Check_Requirement(10, combs[nat]))
                {
                    for (int hou = 0; hou < combs.Length; hou++)
                    {
                        if ((Check_Requirement(2, combs[nat], combs[hou]) == true) &&
                            (Check_Requirement(6, combs[nat], combs[hou]) == true) &&
                            (Check_Requirement(15, combs[nat], combs[hou]) == true))
                        {

                            for (int dri = 0; dri < combs.Length; dri++)
                            {
                                if ((Check_Requirement(4, combs[nat], combs[hou], combs[dri]) == true) &&
                                    (Check_Requirement(5, combs[nat], combs[hou], combs[dri]) == true) &&
                                    (Check_Requirement(9, combs[nat], combs[hou], combs[dri]) == true) &&
                                    (Check_Requirement(16, combs[nat], combs[hou], combs[dri]) == true))

                                {
                                    for (int smo = 0; smo < combs.Length; smo++)
                                    {
                                        if ((Check_Requirement(8, combs[nat], combs[hou], combs[dri], combs[smo]) == true)&&
                                            (Check_Requirement(13, combs[nat], combs[hou], combs[dri], combs[smo]) == true) &&
                                            (Check_Requirement(14, combs[nat], combs[hou], combs[dri], combs[smo]) == true))
                                        {
                                            for (int pet = 0; pet < combs.Length; pet++)
                                            {
                                                if ((Check_Requirement(3, combs[nat], combs[hou], combs[dri], combs[smo], combs[pet]) == true) &&
                                                    (Check_Requirement(7, combs[nat], combs[hou], combs[dri], combs[smo], combs[pet]) == true) &&
                                                    (Check_Requirement(11, combs[nat], combs[hou], combs[dri], combs[smo], combs[pet]) == true) &&
                                                    (Check_Requirement(12, combs[nat], combs[hou], combs[dri], combs[smo], combs[pet]) == true))
                                                {
                                                    solutions = solutions + 1;
                                                    Display_Results(solutions, combs[nat], combs[hou], combs[dri], combs[smo], combs[pet]);
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }

            DateTime end = DateTime.Now;
            double diff = (end - begin).TotalMilliseconds;
            Console.WriteLine("Solved in" + diff.ToString() + "milliseconds");
            Console.ReadKey();

        }
        public static bool Check_Requirement( int number, string nat, string hou = "", string dri = "", string smo = "", string pet= "")
        {
            switch (number)
            {
                case 2:// The Brit Lives in the red house
                    if(nat.Substring(hou.IndexOf(((int)Houses.Red).ToString()), 1 ) == ((int)Nationalities.Brit).ToString())
                    {
                        return true;
                    }
                    break;
                case 3:// The Swede Owns Dogs as Pets
                    if (nat.Substring(pet.IndexOf(((int)Pets.Dogs).ToString()), 1) == ((int)Nationalities.Swede).ToString())
                    {
                        return true;
                    }
                    break;
                case 4:// The Dane drinks tea
                    if (dri.Substring(nat.IndexOf(((int)Nationalities.Dane).ToString()), 1) == ((int)Drinks.Tea).ToString())
                    {
                        return true;
                    }
                    break;
                case 5:// Coffee is drunk in the green house
                    if (dri.Substring(hou.IndexOf(((int)Houses.Green).ToString()), 1) == ((int)Drinks.Coffee).ToString())
                    {
                        return true;
                    }
                    break;
                case 6: // The Green house is exactly to the left of the White house.
                    if (hou.IndexOf(((int)Houses.White).ToString()) - hou.IndexOf(((int)Houses.Green).ToString()) == 1)
                    {
                        return true;
                    }
                    break;
                case 7:// The person who smokes Pall Mall rears Birds.
                    if (smo.Substring(pet.IndexOf(((int)Pets.Birds).ToString()), 1) == ((int)Smokes.Pall_Mall).ToString())
                    {
                        return true;
                    }
                    break;
                case 8:// The owner of the Yellow house smokes Dunhill.
                    if (smo.Substring(hou.IndexOf(((int)Houses.Yellow).ToString()), 1) == ((int)Smokes.Dunhill).ToString())
                    {
                        return true;
                    }
                    break;
                case 9:// The man living in the centre house drinks Milk.
                    if(dri.Substring(2, 1) == ((int)Drinks.Milk).ToString())
                    {
                        return true;
                    }
                    break;
                case 10:// The Norwegian lives in the first house.
                    if (nat.Substring(0, 1) == ((int)Nationalities.Norwegian).ToString()) 
                    {
                        return true;
                    }
                    break;
                case 11:// The man who smokes Blends lives next to the one who keeps Cats.
                    if(Math.Abs(smo.IndexOf(((int)Smokes.Blends).ToString())-pet.IndexOf(((int)Pets.Cats).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 12://The man who keeps Horses lives next to the man who smokes Dunhill.
                    if (Math.Abs(pet.IndexOf(((int)Pets.Horses).ToString()) - smo.IndexOf(((int)Smokes.Dunhill).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 13://The man who smokes Blue Master drinks Beer.
                    if (smo.Substring(dri.IndexOf(((int)Drinks.Beer).ToString()), 1) == ((int)Smokes.Blue_Master).ToString())
                    {
                        return true;
                    }
                    break;
                case 14://The German smokes Prince.
                    if (smo.Substring(nat.IndexOf(((int)Nationalities.German).ToString()), 1) == ((int)Smokes.Prince).ToString())
                    {
                        return true;
                    }
                    break;
                case 15://The Norwegian lives next to the Blue house.
                    if (Math.Abs(hou.IndexOf(((int)Houses.Blue).ToString()) - nat.IndexOf(((int)Nationalities.Norwegian).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 16://The man who smokes Blends has a neighbour who drinks Water.
                    if (Math.Abs(pet.IndexOf(((int)Smokes.Blends).ToString()) - dri.IndexOf(((int)Drinks.Water).ToString())) == 1)
                    {
                        return true;
                    }
                    break;                   
                default:
                    break;
            }

            return false;
        }

        public static void Display_Results(int solution, string nationalities, string houses, string drinks, string smokes, string pets)
        {
            Console.WriteLine("SOLUTION" + solution.ToString());
            Console.WriteLine();
            Console.WriteLine(string.Format("{0, -1} |","p"));
            Console.WriteLine(string.Format("{0, -6} |","HOUSE"));
            Console.WriteLine(string.Format("{0, -11} |", "NATIONALITY"));
            Console.WriteLine(string.Format("{0, -12} |", "DRINK"));
            Console.WriteLine(string.Format("{0, -12} |", "SMOKE"));
            Console.WriteLine(string.Format("{0, -6} |", "PET"));
            Console.WriteLine();

            for(int c = 0; c < houses.Length; c++)
            {
                Console.WriteLine(String.Format("{0,-1} |",(c+1)));
                Console.WriteLine(string.Format("{0, -6} |", ((Houses)Convert.ToInt32(houses.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0, -11} |", ((Nationalities)Convert.ToInt32(nationalities.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0, -12} |", ((Drinks)Convert.ToInt32(drinks.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0, -12} |", ((Smokes)Convert.ToInt32(smokes.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0, -6} |", ((Pets)Convert.ToInt32(pets.Substring(c, 1))).ToString()));

            }
        }
        public static string[] Combinations(string positions)
        {
            List<String> combs = new List<string>();
            for(int c =0; c<positions.Length; c++)
            {
                string single = positions.Substring(c, 1);
                if (combs.Count == 0)
                {
                    combs.Add(single);
                }
                else
                {
                    List<string> newcombs = new List<String>();
                    for (int current = 0; current < combs.Count; current++)
                    {
                        for (int pos = 0; pos < combs[current].Length; pos++)
                        {
                            newcombs.Add(combs[current].Substring(0, pos) + single + combs[current].Substring(pos));
                        }

                        newcombs.Add(combs[current] + single);
                    }

                    combs = newcombs;
                }
            }

            return combs.ToArray();
        }
    }
}

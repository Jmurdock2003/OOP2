using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CMP1903M_A01_2223
{
    class Tutorial
    {
        public static void Write()
        {
            Console.WriteLine("TUTORIAL");
            Console.WriteLine("\nDepending on the difficulty you have chosen you will either recieve 2 or 3 numbers to perform operations on");
            Console.WriteLine("you will presented with a mathmatical problem");
            Console.WriteLine("you need to enter the correct answer to the questions given");
            Console.WriteLine("All answers will be whole numbers");
            Console.WriteLine("you will then recieve a score of correct answers out of 20");
        }


        public static void score(int correct)
        {
            Console.WriteLine("You have finnished Lincode Math Tutor");
            Console.WriteLine("You got a score of, " + correct + "/20");
        }

    }

}

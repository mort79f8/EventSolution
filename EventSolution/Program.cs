using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSolution
{
    class Program
    {

        public delegate void myEventHandler(int value);

        class PiggyBankEventHandler
        {
            private int total;

            // declare the event
            public event myEventHandler valueChanged;

            public int Total
            {
                get => total;
                set
                {
                    total = value;
                    // when the value changes, fire the event
                    valueChanged(total);
                }
            }
        }

        static void Main(string[] args)
        {
            PiggyBankEventHandler piggybank = new PiggyBankEventHandler();
            piggybank.valueChanged += Piggybank_ValueChanged;

            string str;
            do
            {                                
                Console.WriteLine("Enter the amount you which to put in the bank:");
                str = Console.ReadLine();
                if (!str.Equals("exit"))
                {
                    piggybank.Total += int.Parse(str);
                }
            } while (!str.Equals("exit"));

        }

        static void Piggybank_ValueChanged(int value)
        {
            int savingsGoal = 500;
            if (value >= savingsGoal)
            {
                Console.WriteLine("You have reach your savings goal!!");
            }

            Console.WriteLine($"Total in the piggybank: {value}");
        }
    }
}

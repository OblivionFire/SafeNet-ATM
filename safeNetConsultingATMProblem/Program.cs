using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace safeNetConsultingATMProblem
{
    class Program
    {
        static void Main(string[] args)
        {
			string UI;
			bool exit = false;
			ATM test = new ATM();
			Console.WriteLine("Welcome to the ATM");

			do
			{
				Console.WriteLine(" ");
				Console.WriteLine("W <amount> will withdraw said ammount of cash from the machine, you will be given a warning if there is insufficient funds");
				Console.WriteLine("R will reset the ammount of money in the machine");
				Console.WriteLine("I <denominations> will tell you how many of each bill is in the machine");
				Console.WriteLine("Q will quite the program.");
				Console.WriteLine(" ");

				UI = Console.ReadLine();
				
				switch(UI[0])
				{
					case 'W':
						{
							string subString = UI.Substring(1);
							Console.WriteLine(test.W(subString));
							break;
						}

					case 'R':
						{
							test.R();
							break;
						}

					case 'I':
						{
							string subString = UI.Substring(1);
							test.I(subString);
							break;
						}

					case 'Q':
						{
							exit = true;
							break;
						}

					default:
						{
							Console.WriteLine("Please input a valid entry");
							break;
						}
				}

			} while (exit == false);
        }
    }

    class ATM
    {
        // Finalized count used for bill restock
        private readonly int fB100 = 10;
        private readonly int fB50 = 10;
        private readonly int fB20 = 10;
        private readonly int fB10 = 10;
		private readonly int fB5 = 10;
		private readonly int fB1 = 10;

        // current running total of bills in machine, restock will be called and instation of program, thus base value is 0
        private int b100 = 0;
        private int b50 = 0;
        private int b20 = 0;
        private int b10 = 0;
        private int b5 = 0;
        private int b1 =  0;

        public ATM()
        {
			R(); 
        }

		public string W(string withdraw)
		{
			int wDV = 0;
			bool noFunds = false;

			int tB100 = b100;
			int tB50 = b50;
			int tB20 = b20;
			int tB10 = b10;
			int tB5 = b5;
			int tB1 = b1;

			string withDrawTrim = withdraw.Substring(2);
			if(Int32.TryParse(withDrawTrim, out wDV))
			{
				while(noFunds == false)
				{
					if(wDV - 100 >= 0)
					{
						if (b100 >= 1)
						{
							b100 -= 1;
							wDV -= 100;
						}

						else
						{
							noFunds = true;
						}

					}

					else if(wDV - 50 >= 0)
					{

						if (b50 >= 1)
						{
							b50 -= 1;
							wDV -= 50;
						}

						else
						{
							noFunds = true;
						}

					}

					else if (wDV - 20 >= 0)
					{
						if (b20 >= 1)
						{
							b20 -= 1;
							wDV -= 20;
						}

						else
						{
							noFunds = true;
						}
					}

					else if (wDV - 10 >= 0)
					{
						if (b10 >= 1)
						{
							b10 -= 1;
							wDV -= 10;
						}

						else
						{
							noFunds = true;
						}
					}

					else if (wDV - 5 >= 0)
					{
						if (b5 >= 1)
						{
							b5 -= 1;
							wDV -= 5;
						}

						else
						{
							noFunds = true;
						}
					}

					else if (wDV - 1 >= 0)
					{
						if (b1 >= 1)
						{
							b1 -= 1;
							wDV -= 1;
						}

						else
						{
							noFunds = true;
						}
					}

					else if (wDV == 0)
					{
						return "Transaction Complete";
					}

					else if(wDV < 0)
					{
						return "Error I";
					}

				}


				b100 = tB100;
				b50 = tB50;
				b20 = tB20;
				b10 = tB10;
				b5 = tB5;
				b1 = tB1;

				return "Failure: insufficient funds to complete trasaction";
			}

			else
			{
				return "Input error, plese eneter a valid ammout for withdrawal";
			}
		}

        public string R()
        {
            //Resets current count of bills to that of finalised storage ammounts
            b100 = fB100;
            b50 = fB50;
            b20 = fB20;
            b10 = fB10;
			b5 = fB5;
			b1 = fB1;

            return "Sccessful restock of equipment";
        }

        public void I(String requested)
        {
            //Returns the current count of requested denominations

            string[] splitRe = requested.Split('$');

            foreach (var x in splitRe)
            {
                if(x.Trim().Equals("100"))
                {
					Console.WriteLine("$100 - " + b100);
                }

                else if(x.Trim().Equals("50"))
                {
					Console.WriteLine("$50 - " + b50);
				}

                else if(x.Trim().Equals("20"))
                {
					Console.WriteLine("$20 - " + b20);
				}

                else if(x.Trim().Equals("10"))
                {
					Console.WriteLine("$10 - " + b10);
				}

                else if(x.Trim().Equals("5"))
                {
					Console.WriteLine("$5 - " + b5);
				}

                else if(x.Trim().Equals("1"))
                {
					Console.WriteLine("$1 - " + b1);
				}

            }

        }

    }
}

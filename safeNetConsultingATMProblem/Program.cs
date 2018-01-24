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
            ATM test = new ATM();
            test.I("$100 $50 $20");
            while(true)
            {

            }
        }
    }

    class ATM
    {
        // Finalized count used for bill restock
        private readonly int fB100 = 10;
        private readonly int fB50 = 10;
        private readonly int fB20 = 10;
        private readonly int fB10 = 10;
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
            
        }

        public string R()
        {
            //Resets current count of bills to that of finalised storage ammounts
            b100 = fB100;
            b50 = fB50;
            b20 = fB20;
            b10 = fB10;
            b1 = fB1;

            return "Sccessful restock of equipment";
        }

        public string I(String requested)
        {
            //Returns the current count of requested denominations

            string[] splitRe = requested.Split('$');

            foreach (var x in splitRe)
            {
                if(x.Equals("100"))
                {

                }

                else if(x.Equals("50"))
                {

                }

                else if(x.Equals("20"))
                {

                }

                else if(x.Equals("10"))
                {

                }

                else if(x.Equals("5"))
                {

                }

                else if(x.Equals("1"))
                {

                }

            }

            return "";
        }

    }
}

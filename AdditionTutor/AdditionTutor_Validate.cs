using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdditionTutor
{
    class AdditionTutor_Validate
    {
        public Random r = new Random();
        public int[] myNums = new int[3];
        


        public String str_yourSum
        {
            get { return str_yourSum; }

            set { str_yourSum = value; }
        }

        public int[] Rands_and_mySum()
        {
            myNums[0] = r.Next(100, 500);
            myNums[1] = r.Next(100, 500);
            myNums[2] = myNums[0] + myNums[1];

            return myNums;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Project_V4
{
    class Calculate
    {
        public Calculate()
        {

        }

        public double Calculator(double previousInput, double curentInput, string previousOperator)
        {

            switch (previousOperator)
            {
                case "+":
                    return previousInput + curentInput; //if the + is pressed add previous and current input together and return the awnser
                case "-":
                    return previousInput - curentInput; //if the - is pressed subtract current input off previous input and return the awnser 
                case "*":
                    return previousInput * curentInput; //if the * is resssed multiply current input by prvious input and return the awnser 
                case "/":
                    return previousInput / curentInput; //if the / is pressed divide previous input by current input and retur the awnser  
                default:
                    throw new Exception();





            }




        }



    }
}

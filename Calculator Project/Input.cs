using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Project_V4
{
    class Input
    {
        
        //initialse Variables 

        bool erase = false;
        double MC = 0;
        double currentInput = 0;
        double previousInput = 0;
        string currentOperator = "";
        
        Label label1;
        Label label2;

        //return values from calculate class
        Calculate calculator;
     
        //assign labels 
        public Input(Label lbl1, Label lbl2)
        {
            label1 = lbl1;
            label2 = lbl2;
            calculator = new Calculate();
        }


        public void NumberBtn_Click(object sender, EventArgs e) //When the user clicks any of the number buttons 
        {
            if (erase)
            {
                Clear();    // if erase is true then clear the label
            }
            if (label2.Text == "0")
            {
                label2.Text = "";
            }
            Button btn = (sender as Button);     
            label2.Text +=  btn.Tag as string;               //send button Variable as string to label 2
            currentInput = Convert.ToDouble(label2.Text);    //convert label 2 to a double 

        }


        public void OperatorBtn_Click(object sender, EventArgs e)
        {
            if (erase)
            {
                label1.Text = "";
                erase = false;
            }
            var btn = (Button)sender;    //send vutton variable to label 1 
            if (label1.Text == "")
            {
                if (label2.Text == "") return; //if label 2 is blank previous input and current input are equal  
                previousInput = currentInput;
            }
            else if (label2.Text != "")
            {
                previousInput = calculator.Calculator(previousInput, currentInput, currentOperator); //call calculate values from calculate class
            }
            currentInput = 0;
            currentOperator = btn.Text;
            label1.Text = previousInput + currentOperator;
            label2.Text = "";
        }


        public void McBtn_Click(object sender, EventArgs e)    //When the user clicks the MC Buttons 
        {
            var btn = (Button)sender;
            switch (btn.Text)
            {
                case "M+": // if the M+ is pressed then ...
                    if(label2.Text != "")
                    {
                        Calculate();
                        MC += currentInput;
                        label2.Text = "M+" + currentInput + "=" + MC;
                    }
                    break;
                case "M-": //if the M- is pressed then...
                    if(label2.Text != "")
                    {
                        Calculate();   //call the calculate class
                        MC -= currentInput;
                        label2.Text = "M-" + currentInput + "=" + MC;
                    }
                    break;

                case "MR":  //if the MR is pressed then...
                    currentInput = MC;
                    label2.Text = MC.ToString();
                    break;

                case "MC":   //if the MC is pressed then...
                    Clear();
                    MC = 0;
                    label2.Text = "M=" + MC;
                    break;
            }
        }


        public void DecimalBtn_Click(object sender, EventArgs e) //When the user clicks the Decimal button 
        {
            if (erase)
            {
                Clear();
            }
            if (!label2.Text.Contains('.'))
            {
                if (label2.Text == "") label2.Text = "0.";
                else label2.Text += ".";
            }

        }
        

        public void EqualsBtn_Click(object sender, EventArgs e) //When the user clicks the Equals button 
        {
            Calculate();
        }


        public void ClearBtn_Click(object sender, EventArgs e) //When the user clicks the Clear button 
        {
            Clear(); //call the Clear method 
            currentInput = 0;  //set the curent input value to 0
            label2.Text = ""; 
        }


        public void Calculate() // call the calculate class
        {
            if (label1.Text != "" && label2.Text != "" && currentOperator != "")
            {
                double result = calculator.Calculator(previousInput, currentInput, currentOperator);
                label1.Text = previousInput + currentOperator + currentInput;
                label2.Text = result.ToString();
                previousInput = 0;
                currentInput = result;
            }
            erase = true;
        }


        public void Clear() //When the Clear button is pressed clear all labels and set all variables to 0 
        {
            previousInput = 0;
            currentInput = 0;
            currentOperator = "";
            erase = false;
            label1.Text = "";
            label2.Text = "";
        }
    }
}

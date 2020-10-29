using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Project_V4
{

    public partial class Form1 : Form
    {
        List<Button> ListNumberButtons = new List<Button>();   //Create Lists
        List<Button> ListOperatorButtons = new List<Button>();
        List<Button> ListMcButtons = new List<Button>();
        List<Button> ListOtherButtons = new List<Button>();

        string CalculateOperators = "+-*/";  //Create Strings 
        string Memory2 = "CR+-";
        string Memory1 = "MMMM";
        int gap = 50;                //Set gap to 50


        Label label1 = new Label();    //Create Display Labels
        Label label2 = new Label();

       
  
        Input input;

        public Form1()
        {
            this.Height = 500;   //Set form size
            this.Width = 295;
            this.Text = "Nathans Calculator";
            this.HelpButton = true;

            label1.Font = new Font("Arial", 12, FontStyle.Bold);
            label2.Font = new Font("Arial", 12, FontStyle.Bold);

            //Call Methods
            Buildlabel1();
            Buildlabel2();

     
            CreateInput();
            InitializeComponent();
            BuildNumberButtons1();
            BuildNumberButtons2();
            BuildNumberButtons3();
            BuildMcButtons();
            BuildOperatorButtons();
            BuildEqualsButtons();
            BuildClearButton();
            BuildzeroButton();
            BuildDecimalButton();
        }

        private void CreateInput()
        {
            input = new Input(label1, label2); //asign Input class to label 1 and 2
        }



        private void BuildNumberButtons1()
        {
            int i = 0; // To number the buttons


            for (int j = 1; j <= 3; j++) // loop 0 - 3
            {
                var btnNumberButtons1 = new Button();     //Create Button
                //Set Button Properties
                btnNumberButtons1.Location = new Point(20 + i, 130); // x, y
                btnNumberButtons1.Size = new Size(40, 40);
                btnNumberButtons1.Name = "NumberButton" + j.ToString();
                btnNumberButtons1.Tag = btnNumberButtons1.Text = j.ToString();
                btnNumberButtons1.Click += new EventHandler(input.NumberBtn_Click);
                ListNumberButtons.Add(btnNumberButtons1);
                i = i + gap;

                foreach (Button b in ListNumberButtons)   //for every button in the listNumberButtons3 list 
                {
                    this.Controls.AddRange(new Button[] { b });
                }

            }
        }

        private void BuildNumberButtons2()
        {
            int i = 0;

            for (int j = 4; j <= 6; j++) // loop 4 - 6
            {
                var btnNumberButtons2 = new Button();     //Create Button
                //Set Button Properties
                btnNumberButtons2.Location = new Point(20 + i, 180); // x, y
                btnNumberButtons2.Size = new Size(40, 40);
                btnNumberButtons2.Name = "NumberButton" + j.ToString();
                btnNumberButtons2.Tag = btnNumberButtons2.Text = j.ToString();
                btnNumberButtons2.Click += new EventHandler(input.NumberBtn_Click);
                ListNumberButtons.Add(btnNumberButtons2);
                i = i + gap;

                foreach (Button b in ListNumberButtons)   //for every button in the listNumberButtons2 list 
                {
                    this.Controls.AddRange(new Button[] { b });
                }

            }
        }

        private void BuildNumberButtons3()
        {
            int i = 0;

            for (int j = 7; j <= 9; j++) // loop 7 - 9
            {
                var btnNumberButtons3 = new Button();   //Create Button 
                //Set Button Properties
                btnNumberButtons3.Location = new Point(20 + i, 230); // x, y
                btnNumberButtons3.Size = new Size(40, 40);
                btnNumberButtons3.Name = "NumberButton" + j.ToString();
                btnNumberButtons3.Tag = btnNumberButtons3.Text = j.ToString();
                btnNumberButtons3.Click += new EventHandler(input.NumberBtn_Click);
                ListNumberButtons.Add(btnNumberButtons3);
                i = i + gap;

                foreach (Button b in ListNumberButtons)   //for every button in the listNumberButtons list 
                {
                    this.Controls.AddRange(new Button[] { b });
                }
            }
        }

        private void BuildMcButtons()
        {
            int i = 0;

            for (int j = 0; j <= 3; j++) // loop 0 - 3
            {
                //Set Properties
                var btnMcButtons = new Button();  //Create Button
                btnMcButtons.Location = new Point(20 + i, 90); // x, y
                btnMcButtons.Size = new Size(40, 25);
                btnMcButtons.Name = "NumberButton" + j.ToString();
                btnMcButtons.Text = (Memory1.ElementAt(j).ToString()) + (Memory2.ElementAt(j).ToString());
                btnMcButtons.Click += new EventHandler(input.McBtn_Click);
                ListNumberButtons.Add(btnMcButtons);
                i = i + gap;

                foreach (Button b in ListMcButtons)   //for every button in the listMCbuttons list 
                {
                    this.Controls.AddRange(new Button[] { b }); 
                }
            }
        }

        private void BuildOperatorButtons()
        {
            int i = 0;

            for (int j = 0; j < 4; j++) // loop 0 - 4
            {
                //set properties
                var btnOperatorButtons = new Button();
                btnOperatorButtons.Location = new Point(170, 130 + i); // x, y
                btnOperatorButtons.Size = new Size(90, 40);
                btnOperatorButtons.Name = "NumberButton" + j.ToString();
                btnOperatorButtons.Text = CalculateOperators.ElementAt(j).ToString();
                btnOperatorButtons.Click += new EventHandler(input.OperatorBtn_Click);
                ListNumberButtons.Add(btnOperatorButtons);
                i = i + gap;
  
                foreach (Button b in ListNumberButtons)  //for every button in the listnumberbuttons lit 
                {
                    this.Controls.AddRange(new Button[] { b });
                }
            }
        }


        private void BuildDecimalButton() //Create Decimal Button 
        {
            //set properties
            Button DecimalButton = new Button();
            DecimalButton.Location = new Point(70, 280);
            DecimalButton.Size = new Size(40, 40);
            DecimalButton.Name = ".";
            DecimalButton.Text = ".";
            DecimalButton.Click += new EventHandler(input.DecimalBtn_Click);
            this.Controls.Add(DecimalButton);
        }


        private void BuildEqualsButtons() //Create Equals Button 
        {
            //set properties
            Button EqualsButton = new Button();
            EqualsButton.Location = new Point(20, 280); // x, y
            EqualsButton.Size = new Size(40, 40);
            EqualsButton.Name = "=";
            EqualsButton.Text = "=";
            EqualsButton.Click += new EventHandler(input.EqualsBtn_Click);
            this.Controls.Add(EqualsButton);
        }


        private void BuildzeroButton() //Create 0 button 
        {
            //set properties
            Button zeroButton = new Button();
            zeroButton.Location = new Point(120, 280);
            zeroButton.Size = new Size(40, 40);
            zeroButton.Tag = "0";
            zeroButton.Text = "0";
            zeroButton.Click += new EventHandler(input.NumberBtn_Click);
            this.Controls.Add(zeroButton); 
        }


        private void BuildClearButton() //ceate Clear Button 
        {
            //Set prtoperties 
            var btnClearbutton = new Button();
            btnClearbutton.Location = new Point(220, 90);
            btnClearbutton.Size = new Size(40, 25);
            btnClearbutton.Text = "CE";
            btnClearbutton.Click += new EventHandler(input.ClearBtn_Click);
            this.Controls.Add(btnClearbutton);
        }


        private void Buildlabel1() //create label1
        {
            //set properties
            label1.Location = new Point(20, 20);
            label1.Size = new Size(240, 25);
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(label1);
            label1.Text = "";
        }


        private void Buildlabel2() //Create label2
        {
            //set properties
            label2.Location = new Point(20, 50);
            label2.Size = new Size(240, 25);
            label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(label2);
            label2.Text = "";
        }
    }

}



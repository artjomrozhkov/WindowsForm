using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsrakendusteloomine
{
    public class MathQuiz : Form
    {
        
        Random rnd = new Random();
        string[] Maths = { "Add", "Subtract", "Multiply" };
        int total;
        int score;
        private int counter = 60;
        private Timer timer1;
        private Label lblScore;
        private Label lblSymbol, lblSymbol2, lblSymbol3, lblSymbol4, lblTimer;
        private Label lblNumB, lblNumB2, lblNumB3, lblNumB4;
        private Label lblEquals, lblEquals2, lblEquals3, lblEquals4;
        private Label lblAnswer;
        private TextBox txtAnswer, txtAnswer2, txtAnswer3, txtAnswer4;
        private Button button1, buttonTimer;
        private Label lblNumA, lblNumA2, lblNumA3, lblNumA4;
        TableLayoutPanel tableLayoutPanel;
        TextBox[] Answer = {};
        Label[] labelSymArray = { }, lblNumArrayA = { }, lblNumArrayB = { }, lblEqualsArray = { };

        public MathQuiz()
        {
            InitializeComponent();
            SetUpGame();
        }
        internal void InitializeComponent()
        {
            lblNumArrayA = new Label[] { lblNumA, lblNumA2, lblNumA3, lblNumA4 };
            lblNumArrayB = new Label[] { lblNumB, lblNumB2, lblNumB3, lblNumB4 };
            labelSymArray = new Label[] { lblSymbol, lblSymbol2, lblSymbol3, lblSymbol4 };
            lblEqualsArray = new Label[] { lblEquals, lblEquals2, lblEquals3, lblEquals4 };
            txtAnswerArray = new TextBox[] { txtAnswer, txtAnswer2, txtAnswer3, txtAnswer4 };
            totalArray = new int[] { total1, total2, total3, total4 };
            
            int i = 0;


            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 5,
                RowCount = 5,
                Location = new Point(0, 0),
                Size = new Size(534, 311),
                TabIndex = 0,
                BackColor = Color.White,
            };
            Controls.Add(tableLayoutPanel);

            lblScore = new Label()
            {
                AutoSize = true,
                ForeColor = Color.Maroon,
                Location = new Point(12, 9),
                Name = "lblScore",
                Size = new Size(47, 13),
                TabIndex = 0,
                Text = "Skoor: 0"
            };
            tableLayoutPanel.Controls.Add(this.lblScore);

            lblTimer = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Name = "lblAnswer",
                Size = new Size(50, 15),
                TabIndex = 5,
                Text = "--:--:--"
            };
            timer1 = new Timer
            {
                Interval = 1000
            };

            timer1.Tick += timer1_Tick;
            timer1.Tick += timer1_Tick1;
            timer1.Tick += timer1_Tick2;
            timer1.Tick += timer1_Tick3;

            foreach (Label sym in lblNumArrayA)
            {
                lblNumArrayA[i] = new Label
                {
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204),
                    Location = new Point(14, 40),
                    Name = "lblNumA",
                    Size = new Size(49, 33),
                    TabIndex = 1,
                    Text = "00",
                };
                i++;
            }
            i = 0;
            
            foreach (Label sym in lblNumArrayB)
            {
                lblNumArrayB[i] = new Label
                {
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204),
                    Location = new Point(108, 40),
                    Name = "lblNumB",
                    Size = new Size(49, 33),
                    TabIndex = 3,
                    Text = "00",
                };
                i++;
            }
            i = 0;

            foreach (Label sym in labelSymArray)
            {
                labelSymArray[i] = new Label
                {
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204),
                    Location = new Point(69, 40),
                    Name = "lblSymbol",
                    Size = new Size(33, 33),
                    TabIndex = 2,
                    Text = "+",
                };
                i++;
            }
            i = 0;

            foreach (Label sym in lblEqualsArray)
            {
                lblEqualsArray[i] = new Label
                {
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204),
                    Location = new Point(163, 40),
                    Name = "label4",
                    Size = new Size(33, 33),
                    TabIndex = 4,
                    Text = "=",
                };
                i++;
            }
            i = 0;

            lblAnswer = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204),
                ForeColor = Color.DarkGreen,
                Location = new Point(13, 102),
                Name = "lblAnswer",
                Size = new Size(47, 13),
                TabIndex = 5,
                Text = "Õige",
            };

            foreach (TextBox sym in txtAnswerArray)
            {
                txtAnswerArray[i] = new TextBox
                {
                    Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204),
                    Location = new Point(202, 40),
                    Multiline = true,
                    Size = new Size(82, 33),
                    TabIndex = 6,
                };
                i++;
            }
            i = 0;

            buttonTimer = new Button
            {
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Location = new Point(290, 40),
                Name = "button1",
                Size = new Size(75, 35),
                TabIndex = 7,
                Text = "Alusta",
                UseVisualStyleBackColor = true
            };

            //txtAnswer
            tableLayoutPanel.Controls.Add(txtAnswer, 4, 1);
            tableLayoutPanel.Controls.Add(txtAnswer2, 4, 2);
            tableLayoutPanel.Controls.Add(txtAnswer3, 4, 3);
            tableLayoutPanel.Controls.Add(txtAnswer4, 4, 4);
            //lblNumA
            tableLayoutPanel.Controls.Add(lblNumA, 0, 1);
            tableLayoutPanel.Controls.Add(lblNumA2, 0, 2);
            tableLayoutPanel.Controls.Add(lblNumA3,0, 3);
            tableLayoutPanel.Controls.Add(lblNumA4, 0, 4);
            //lblNumB
            tableLayoutPanel.Controls.Add(lblNumB, 2, 1);
            tableLayoutPanel.Controls.Add(lblNumB2, 2, 2);
            tableLayoutPanel.Controls.Add(lblNumB3, 2, 3);
            tableLayoutPanel.Controls.Add(lblNumB4, 2, 4);
            //lblSymbol
            tableLayoutPanel.Controls.Add(lblSymbol, 1, 1);
            tableLayoutPanel.Controls.Add(lblSymbol2, 1, 2);
            tableLayoutPanel.Controls.Add(lblSymbol3, 1, 3);
            tableLayoutPanel.Controls.Add(lblSymbol4, 1, 4);
            //label4
            tableLayoutPanel.Controls.Add(label4, 3, 1);
            tableLayoutPanel.Controls.Add(label42, 3, 2);
            tableLayoutPanel.Controls.Add(label43, 3, 3);
            tableLayoutPanel.Controls.Add(label44, 3, 4);

            tableLayoutPanel.Controls.Add(lblAnswer, 5, 5);

            tableLayoutPanel.Controls.Add(lblTimer, 4, 5);

            tableLayoutPanel.Controls.Add(buttonTimer, 4, 5);


            button1 = new Button()
            {
                Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204),
                Location = new Point(290, 40),
                Name = "button1",
                Size = new Size(75, 33),
                TabIndex = 7,
                Text = "Kontrollima",
                UseVisualStyleBackColor = true,
            };

            buttonTimer.Click += ButtonTimer_Click;
            //button1Handler
            button1.Click += new EventHandler(CheckButtonClickEvent);
            button1.Click += new EventHandler(CheckButtonClickEvent1);
            button1.Click += new EventHandler(CheckButtonClickEvent2);
            button1.Click += new EventHandler(CheckButtonClickEvent3);
            //txtAnswerHandler
            txtAnswer.TextChanged += new EventHandler(CheckAnswer);
            txtAnswer2.TextChanged += new EventHandler(CheckAnswer1);
            txtAnswer3.TextChanged += new EventHandler(CheckAnswer2);
            txtAnswer4.TextChanged += new EventHandler(CheckAnswer3);
            tableLayoutPanel.Controls.Add(button1, 5, 5);
            ClientSize = new Size(385, 300);
            Name = "Matemaatikaviktoriin";
            Text = "Matemaatika viktoriinimäng";
            Load += new EventHandler(MathQuiz_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private void ButtonTimer_Click(object sender, EventArgs e)
        {
            SetUpGame();
            buttonTimer.Enabled = false;
            button1.Enabled = true;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                counter = counter - 1;
                lblTimer.Text = counter + " sekundit";
            }
            else
            {
                timer1.Stop();
                lblTimer.Text = "Rohkem aega ei ole!";
                txtAnswer.Enabled = false;
                ClientSize = new Size(370, 300);
            }
        }

        private void timer1_Tick1(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                lblTimer.Text = counter + " sekundit";
            }
            else
            {
                timer1.Stop();
                lblTimer.Text = "Rohkem aega ei ole!";
                txtAnswer2.Enabled = false;
                ClientSize = new Size(370, 300);
            }
        }

        private void timer1_Tick2(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                lblTimer.Text = counter + " sekundit";
            }
            else
            {
                timer1.Stop();
                lblTimer.Text = "Rohkem aega ei ole!";
                txtAnswer3.Enabled = false;
                ClientSize = new Size(370, 300);
            }
        }

        private void timer1_Tick3(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                lblTimer.Text = counter + " sekundit";
            }
            else
            {
                timer1.Stop();
                lblTimer.Text = "Rohkem aega ei ole!";
                txtAnswer4.Enabled = false;
                ClientSize = new Size(370, 300);
            }
        }

        private void CheckAnswer(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswer.Text, "[^0-9]"))
            {
                MessageBox.Show("Palun sisestage ainult numbrid!");
                txtAnswer.Text = txtAnswer.Text.Remove(txtAnswer.Text.Length - 1);
            }
        }
        private void CheckButtonClickEvent(object sender, EventArgs e)
        {
            for (int i=0; i < 4; i++)
            {
                int userEntered = 0;
                try
                {
                    userEntered = Convert.ToInt32(txtAnswer.Text);
                }
                catch (FormatException)
                {

                }
                if (userEntered == total)
                {
                    lblAnswer.Text = "Õige";
                    lblAnswer.ForeColor = Color.Green;
                    score += 1;
                    lblScore.Text = "Skoor: " + score;
                    SetUpGame();

                }
                else
                {
                    lblAnswer.Text = "Vale";
                    lblAnswer.ForeColor = Color.Red;
                }

            }
        }
        private void CheckAnswer1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswer2.Text, "[^0-9]"))
            {
                MessageBox.Show("Palun sisestage ainult numbrid!");
                txtAnswer2.Text = txtAnswer2.Text.Remove(txtAnswer2.Text.Length - 1);
            }
        }
        private void CheckButtonClickEvent1(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                int userEntered = 0;
                try
                {
                    userEntered = Convert.ToInt32(txtAnswer2.Text);
                }
                catch (FormatException)
                {

                }
                if (userEntered == total)
                {
                    lblAnswer.Text = "Õige";
                    lblAnswer.ForeColor = Color.Green;
                    score += 1;
                    lblScore.Text = "Skoor: " + score;
                    SetUpGame();

                }
                else
                {
                    lblAnswer.Text = "Vale";
                    lblAnswer.ForeColor = Color.Red;
                }
            }
        }

        private void CheckAnswer2(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswer3.Text, "[^0-9]"))
            {
                MessageBox.Show("Palun sisestage ainult numbrid!");
                txtAnswer3.Text = txtAnswer3.Text.Remove(txtAnswer3.Text.Length - 1);
            }
        }
        private void CheckButtonClickEvent2(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                int userEntered = 0;
                try
                {
                    userEntered = Convert.ToInt32(txtAnswer3.Text);
                }
                catch (FormatException)
                {

                }
                if (userEntered == total)
                {
                    lblAnswer.Text = "Õige";
                    lblAnswer.ForeColor = Color.Green;
                    score += 1;
                    lblScore.Text = "Skoor: " + score;
                    SetUpGame();

                }
                else
                {
                    lblAnswer.Text = "Vale";
                    lblAnswer.ForeColor = Color.Red;
                }
            }

        }
        private void CheckAnswer3(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswer4.Text, "[^0-9]"))
            {
                MessageBox.Show("Palun sisestage ainult numbrid!");
                txtAnswer4.Text = txtAnswer4.Text.Remove(txtAnswer4.Text.Length - 1);
            }
        }
        private void CheckButtonClickEvent3(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                int userEntered = 0;
                try
                {
                    userEntered = Convert.ToInt32(txtAnswer4.Text);
                }
                catch (FormatException)
                {

                }
                if (userEntered == total)
                {
                    lblAnswer.Text = "Õige";
                    lblAnswer.ForeColor = Color.Green;
                    score += 1;
                    lblScore.Text = "Skoor: " + score;
                    SetUpGame();

                }
                else
                {
                    lblAnswer.Text = "Vale";
                    lblAnswer.ForeColor = Color.Red;
                }
            }
        }

        private void SetUpGame()
        {
            int numA = rnd.Next(10, 20);
            int numB = rnd.Next(0, 9);
            int numA1 = rnd.Next(10, 20);
            int numB1 = rnd.Next(0, 9);
            int numA2 = rnd.Next(10, 20);
            int numB2 = rnd.Next(0, 9);
            int numA3 = rnd.Next(10, 20);
            int numB3 = rnd.Next(0, 9);

            txtAnswer.Text = null;
            txtAnswer2.Text = null;
            txtAnswer3.Text = null;
            txtAnswer4.Text = null;

            switch (Maths[rnd.Next(0, Maths.Length)])
            {
                case "Add":
                    total = numA + numB;
                    lblSymbol.Text = "+";
                    lblSymbol.ForeColor = Color.Green;
                    txtAnswer.Text = total.ToString();
                    break;

                case "Subtract":
                    total = numA - numB;
                    lblSymbol.Text = "-";
                    lblSymbol.ForeColor = Color.Maroon;
                    txtAnswer.Text = total.ToString();
                    break;

                case "Multiply":
                    total = numA * numB;
                    lblSymbol.Text = "x";
                    lblSymbol.ForeColor = Color.Purple;
                    txtAnswer.Text = total.ToString();
                    break;
            }

            switch (Maths[rnd.Next(0, Maths.Length)])
            {
                case "Add":
                    total = numA1 + numB1;
                    lblSymbol2.Text = "+";
                    lblSymbol2.ForeColor = Color.Green;
                    txtAnswer2.Text = total.ToString();
                    break;

                case "Subtract":
                    total = numA1 - numB1;
                    lblSymbol2.Text = "-";
                    lblSymbol2.ForeColor = Color.Maroon;
                    txtAnswer2.Text = total.ToString();
                    break;

                case "Multiply":
                    total = numA1 * numB1;
                    lblSymbol2.Text = "x";
                    lblSymbol2.ForeColor = Color.Purple;
                    txtAnswer2.Text = total.ToString();
                    break;
            }

            switch (Maths[rnd.Next(0, Maths.Length)])
            {
                case "Add":
                    total = numA2 + numB2;
                    lblSymbol3.Text = "+";
                    lblSymbol3.ForeColor = Color.Green;
                    txtAnswer3.Text = total.ToString();
                    break;

                case "Subtract":
                    total = numA2 - numB2;
                    lblSymbol3.Text = "-";
                    lblSymbol3.ForeColor = Color.Maroon;
                    txtAnswer3.Text = total.ToString();
                    break;

                case "Multiply":
                    total = numA2 * numB2;
                    lblSymbol3.Text = "x";
                    lblSymbol3.ForeColor = Color.Purple;
                    txtAnswer3.Text = total.ToString();
                    break;
            }

            switch (Maths[rnd.Next(0, Maths.Length)])
            {
                case "Add":
                    total = numA3 + numB3;
                    lblSymbol4.Text = "+";
                    lblSymbol4.ForeColor = Color.Green;
                    txtAnswer4.Text = total.ToString();
                    break;

                case "Subtract":
                    total = numA3 - numB3;
                    lblSymbol4.Text = "-";
                    lblSymbol4.ForeColor = Color.Maroon;
                    txtAnswer4.Text = total.ToString();
                    break;

                case "Multiply":
                    total = numA3 * numB3;
                    lblSymbol4.Text = "x";
                    lblSymbol4.ForeColor = Color.Purple;
                    txtAnswer4.Text = total.ToString();
                    break;
            }

            lblNumA.Text = numA.ToString();
            lblNumA2.Text = numA1.ToString();
            lblNumA3.Text = numA2.ToString();
            lblNumA4.Text = numA3.ToString();
            lblNumB.Text = numB.ToString();
            lblNumB2.Text = numB1.ToString();
            lblNumB3.Text = numB2.ToString();
            lblNumB4.Text = numB3.ToString();
        }

        private void MathQuiz_Load(object sender, EventArgs e)
        {

        }
    }
}

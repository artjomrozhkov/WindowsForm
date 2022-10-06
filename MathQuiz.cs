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
        string[] Maths = { "Lisa", "Lahuta", "Korruta" };
        int total;
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
        TextBox[] txtAnswerArray = { };
        int[] totalArray = { };
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

            //NumA
            tableLayoutPanel.Controls.Add(lblNumArrayA[0], 0, 0);
            tableLayoutPanel.Controls.Add(lblNumArrayA[1], 0, 1);
            tableLayoutPanel.Controls.Add(lblNumArrayA[2], 0, 2);
            tableLayoutPanel.Controls.Add(lblNumArrayA[3], 0, 3);
            
            //NumB
            tableLayoutPanel.Controls.Add(lblNumArrayB[0], 1, 0);
            tableLayoutPanel.Controls.Add(lblNumArrayB[1], 1, 1);
            tableLayoutPanel.Controls.Add(lblNumArrayB[2], 1, 2);
            tableLayoutPanel.Controls.Add(lblNumArrayB[3], 1, 3);
            
            //Symbol
            tableLayoutPanel.Controls.Add(labelSymArray[0], 1, 0);
            tableLayoutPanel.Controls.Add(labelSymArray[1], 1, 1);
            tableLayoutPanel.Controls.Add(labelSymArray[2], 1, 2);
            tableLayoutPanel.Controls.Add(labelSymArray[3], 1, 3);

            //Answer
            tableLayoutPanel.Controls.Add(txtAnswerArray[0], 4, 0);
            tableLayoutPanel.Controls.Add(txtAnswerArray[1], 4, 1);
            tableLayoutPanel.Controls.Add(txtAnswerArray[2], 4, 2);
            tableLayoutPanel.Controls.Add(txtAnswerArray[3], 4, 3);


            //Equals
            tableLayoutPanel.Controls.Add(lblEqualsArray[0], 3, 0);
            tableLayoutPanel.Controls.Add(lblEqualsArray[1], 3, 1);
            tableLayoutPanel.Controls.Add(lblEqualsArray[2], 3, 2);
            tableLayoutPanel.Controls.Add(lblEqualsArray[3], 3, 3);

            //Others
            tableLayoutPanel.Controls.Add(lblAnswer, 4, 4);
            tableLayoutPanel.Controls.Add(lblScore, 4, 4);
            tableLayoutPanel.Controls.Add(button1, 4, 4);
            tableLayoutPanel.Controls.Add(buttonTimer, 4, 5);
            tableLayoutPanel.Controls.Add(lblTimer);


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
            //txtAnswerHandler
            txtAnswer.TextChanged += new EventHandler(CheckAnswer);
            tableLayoutPanel.Controls.Add(button1, 5, 5);
            ClientSize = new Size(385, 300);
            Name = "Matemaatikaviktoriin";
            Text = "Matemaatika viktoriinimäng";
            Load += new EventHandler(MathQuiz_Load);
            ResumeLayout(false);
            PerformLayout();
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
                foreach (var item in txtAnswerArray)
                {
                    item.Enabled = false;
                }
                ClientSize = new Size(370, 300);
            }
        }
        private void ButtonTimer_Click(object sender, EventArgs e)
        {
            Game();
            buttonTimer.Enabled = false;
            button1.Enabled = true;

            timer1.Start();
        }

        private void CheckAnswer(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswerArray[i].Text, "[^0-9]"))
            {
                MessageBox.Show("Ainult numbrid palun!");
                txtAnswerArray[i].Text = txtAnswerArray[i].Text.Remove(txtAnswerArray[i].Text.Length - 1);
            }
            }
        }

        private void CheckButtonClickEvent(object sender, EventArgs e)
        {

            for (int i = 0; i < 4; i++) 
            {
                int userEntered = 0;
                try
                {
                    userEntered = Convert.ToInt32(txtAnswerArray[i].Text);
                }
                catch (FormatException)
                {
                    //MessageBox.Show("Kõik numbrid kirjuta!");
                }

                if (userEntered == totalArray[i])
                {
                    correct += 1;
                }
                else
                {
                }

            }

            if (correct>=4)
            {
                lblAnswer.Text = "Õige!";
                lblAnswer.ForeColor = Color.Green;
                score += 1;
                lblScore.Text = "Punktid: " + score;
                Game();
            }
            else
            {
                lblAnswer.Text = "Vale!";
                lblAnswer.ForeColor = Color.Red;
            }
            correct = 0;
        }

        private void Game()
        {
            for (int ii = 0; ii < 4; ii++)
            {

                int numA = rnd.Next(10, 20);
                int numB = rnd.Next(0, 9);

                txtAnswerArray[ii].Text = null;


                string Tsym = "";
                Color colorSym = Color.Black;
                    switch (Maths[rnd.Next(0, Maths.Length)])
                    {
                        case "Lisa":
                            totalArray[ii] = numA + numB;
                            Tsym = "+";
                            colorSym = Color.Green;
                            break;

                        case "Lahuta":
                            totalArray[ii] = numA - numB;
                            Tsym = "-";
                            colorSym = Color.Maroon;
                            break;

                        case "Korruta":
                            totalArray[ii] = numA * numB;
                            Tsym = "x";
                            colorSym = Color.Purple;
                            break;
                    }
                    labelSymArray[ii].Text = Tsym;
                

                lblNumArrayA[ii].Text = numA.ToString();
                lblNumArrayB[ii].Text = numB.ToString();

            }
        }

    }
}

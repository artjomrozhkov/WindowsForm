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
        int score, correct, total1, total2, total3, total4;
        TableLayoutPanel tableLayoutPanel;
        TextBox[] Answer = { };
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
            SuspendLayout();
            ClientSize = new Size(320, 300);
            Name = "MathQuiz";
            Text = "Maths Quiz Game";
            ResumeLayout(false);
            PerformLayout();
            lblNumArrayA = new Label[] { lblNumA, lblNumA2, lblNumA3, lblNumA4 };
            lblNumArrayB = new Label[] { lblNumB, lblNumB2, lblNumB3, lblNumB4 };
            lblEqualsArray = new Label[] { lblEquals, lblEquals2, lblEquals3, lblEquals4 };
            labelSymArray = new Label[] { lblSymbol, lblSymbol2, lblSymbol3, lblSymbol4 };
            txtAnswerArray = new TextBox[] { txtAnswer, txtAnswer2, txtAnswer3, txtAnswer4 };
            totalArray = new int[] { total1, total2, total3, total4 };

            int i = 0;


            tableLayoutPanel = new TableLayoutPanel //Looming tableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 5,
                RowCount = 5,
                Location = new Point(0, 0),
                Size = new Size(534, 311),
                TabIndex = 0,
                BackColor = Color.White,
            };
            Controls.Add(tableLayoutPanel); //Lisa paneelile tableLayoutPanel

            lblScore = new Label() //Looming lblScore
            {
                AutoSize = true,
                ForeColor = Color.Maroon,
                Location = new Point(12, 9),
                Name = "lblScore",
                Size = new Size(47, 13),
                TabIndex = 0,
                Text = "Skoor: 0"
            };
            tableLayoutPanel.Controls.Add(lblScore); //Lisa paneelile lblScore

            lblTimer = new Label //Looming lblTimer
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Name = "lblAnswer",
                Size = new Size(50, 15),
                TabIndex = 5,
                Text = "00:00:00"
            };
            timer1 = new Timer
            {
                Interval = 1000
            };


            foreach (Label sym in lblNumArrayA) //lblNumArrayA parameetrid
            {
                lblNumArrayA[i] = new Label //Looming lblNumArrayA
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

            foreach (Label sym in lblNumArrayB) //lblNumArrayB parameetrid
            {
                lblNumArrayB[i] = new Label //Looming lblNumArrayB
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

            foreach (Label sym in labelSymArray) //labelSymArray parameetrid
            {
                labelSymArray[i] = new Label //Looming labelSymArray 
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

            foreach (Label sym in lblEqualsArray) //lblEqualsArray parameetrid
            {
                lblEqualsArray[i] = new Label //Looming lblEqualsArray
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

            lblAnswer = new Label //Looming lblAnswer
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

            foreach (TextBox sym in txtAnswerArray) //txtAnswerArray parameetrid
            {
                txtAnswerArray[i] = new TextBox //Looming txtAnswerArray
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

            buttonTimer = new Button //Looming buttonTimer
            {
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Location = new Point(290, 40),
                Name = "button1",
                Size = new Size(75, 35),
                TabIndex = 7,
                Text = "Alusta",
                UseVisualStyleBackColor = true
            };

            button1 = new Button() //Looming button1 
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
            timer1.Tick += timer1_Tick;
            button1.Click += new EventHandler(CheckButtonClickEvent);

            txtAnswerArray[0].TextChanged += new EventHandler(CheckAnswer); //kontrollib vastust txtAnswerArray[0]
            txtAnswerArray[1].TextChanged += new EventHandler(CheckAnswer); //kontrollib vastust txtAnswerArray[1]
            txtAnswerArray[2].TextChanged += new EventHandler(CheckAnswer); //kontrollib vastust txtAnswerArray[2]
            txtAnswerArray[3].TextChanged += new EventHandler(CheckAnswer); //kontrollib vastust txtAnswerArray[3]

            //NumA
            tableLayoutPanel.Controls.Add(lblNumArrayA[0], 0, 0); //Paneb tabelisse lblNumArrayA[0]
            tableLayoutPanel.Controls.Add(lblNumArrayA[1], 0, 1); //Paneb tabelisse lblNumArrayA[1]
            tableLayoutPanel.Controls.Add(lblNumArrayA[2], 0, 2); //Paneb tabelisse lblNumArrayA[2]
            tableLayoutPanel.Controls.Add(lblNumArrayA[3], 0, 3); //Paneb tabelisse lblNumArrayA[3]

            //NumB
            tableLayoutPanel.Controls.Add(lblNumArrayB[0], 2, 0); //Paneb tabelisse lblNumArrayB[0]
            tableLayoutPanel.Controls.Add(lblNumArrayB[1], 2, 1); //Paneb tabelisse lblNumArrayB[1]
            tableLayoutPanel.Controls.Add(lblNumArrayB[2], 2, 2); //Paneb tabelisse lblNumArrayB[2]
            tableLayoutPanel.Controls.Add(lblNumArrayB[3], 2, 3); //Paneb tabelisse lblNumArrayB[3]

            //Symbol
            tableLayoutPanel.Controls.Add(labelSymArray[0], 1, 0); //Paneb tabelisse labelSymArray[0]
            tableLayoutPanel.Controls.Add(labelSymArray[1], 1, 1); //Paneb tabelisse labelSymArray[1]
            tableLayoutPanel.Controls.Add(labelSymArray[2], 1, 2); //Paneb tabelisse labelSymArray[2]
            tableLayoutPanel.Controls.Add(labelSymArray[3], 1, 3); //Paneb tabelisse labelSymArray[3]

            //Answer
            tableLayoutPanel.Controls.Add(txtAnswerArray[0], 4, 0); //Paneb tabelisse txtAnswerArray[0]
            tableLayoutPanel.Controls.Add(txtAnswerArray[1], 4, 1); //Paneb tabelisse txtAnswerArray[1]
            tableLayoutPanel.Controls.Add(txtAnswerArray[2], 4, 2); //Paneb tabelisse txtAnswerArray[2]
            tableLayoutPanel.Controls.Add(txtAnswerArray[3], 4, 3); //Paneb tabelisse txtAnswerArray[3]


            //Equals
            tableLayoutPanel.Controls.Add(lblEqualsArray[0], 3, 0); //Paneb tabelisse lblEqualsArray[0]
            tableLayoutPanel.Controls.Add(lblEqualsArray[1], 3, 1); //Paneb tabelisse lblEqualsArray[1]
            tableLayoutPanel.Controls.Add(lblEqualsArray[2], 3, 2); //Paneb tabelisse lblEqualsArray[2]
            tableLayoutPanel.Controls.Add(lblEqualsArray[3], 3, 3); //Paneb tabelisse lblEqualsArray[3]

            //Others
            tableLayoutPanel.Controls.Add(lblAnswer, 4, 4); //Paneb tabeliise lblAnswer
            tableLayoutPanel.Controls.Add(lblScore, 4, 4); //Paneb tabeliise lblScore
            tableLayoutPanel.Controls.Add(button1, 4, 4); //Paneb tabeliise button1
            tableLayoutPanel.Controls.Add(buttonTimer, 4, 5); //Paneb tabeliise buttonTimer
            tableLayoutPanel.Controls.Add(lblTimer); //Paneb tabeliise lblTimer
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
            SetUpGame();
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
                    MessageBox.Show("Ainult numbrid!");
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
                }

                if (userEntered == totalArray[i])
                {
                    correct += 1;
                }
                else
                {
                }

            }

            if (correct >= 4)
            {
                lblAnswer.Text = "Õige!";
                lblAnswer.ForeColor = Color.Green;
                score += 1;
                lblScore.Text = "Punktid: " + score;
                SetUpGame();
            }
            else
            {
                lblAnswer.Text = "Vale!";
                lblAnswer.ForeColor = Color.Red;
            }
            correct = 0;
        }

        private void SetUpGame()
        {
            for (int ii = 0; ii < 4; ii++)
            {
                int numA = rnd.Next(10, 20); //juhuslik väärtus numA vahemikus 10 kuni 20
                int numB = rnd.Next(0, 9); //juhuslik väärtus numB vahemikus 0 kuni 9

                txtAnswerArray[ii].Text = null; //nullväärtus

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

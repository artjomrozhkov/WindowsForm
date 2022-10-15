using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsrakendusteloomine
{
    public class MatchingGame : Form
    {
            Random rnd = new Random();
            TableLayoutPanel tableLayoutPanel;
            Label firstClicked = null;
            Label secondClicked = null;
            Timer timer1 = new Timer { Interval = 750 };
            Timer timer = new Timer { Interval = 1000 };
            int score = 0;
            int tik = 0;
            Label difficult;
            public MatchingGame()
            {
                CenterToScreen();
                Text = "Matching game";
                ClientSize = new Size(550, 550);
                BackColor = Color.White;
                difficult = new Label
                {
                    Text = "Mängu raskusaste",
                    Location = new Point(110, 100),
                    Size = new Size(400, 100),
                    Font = new Font("Arial", 28, FontStyle.Bold)
                };
                this.Controls.Add(difficult);
                string[] buttonstext = { "Tavaline raskusaste", "Keskmise raskusastmega", "Kõrge raskusaste" };
                int y = 200;
                for (int i = 0; i < buttonstext.Length; i++)
                {

                    Button button = new Button
                    {
                        Text = buttonstext[i],
                        Location = new Point(210, y),
                        Size = new Size(100, 80)
                    };
                    button.Click += Button_Click;
                    this.Controls.Add(button);
                    y += 100;
                }


            }
            public MatchingGame(int x, int y, List<string> icons, TableLayoutPanel tableLayoutPanel)
            {
                timer.Tick += Timer_Tick;
                timer1.Tick += timer1_Tick;
                for (int i = 0; i < x; i++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                    for (int j = 0; j < y; j++)
                    {

                        Label lbl = new Label
                        {
                            BackColor = Color.White,
                            AutoSize = false,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Webdings", 48, FontStyle.Bold),
                        };


                        tableLayoutPanel.Controls.Add(lbl, i, j);
                    };

                }
                foreach (Control control in tableLayoutPanel.Controls)
                {
                    Label iconLabel = control as Label;
                    if (iconLabel != null)
                    {
                        int randomNumber = rnd.Next(icons.Count); 
                        iconLabel.Text = icons[randomNumber];
                        icons.RemoveAt(randomNumber); 
                    }
                    iconLabel.ForeColor = iconLabel.BackColor;
                    iconLabel.Click += label1_Click;
                }
                void Timer_Tick(object sender, EventArgs e)
                {
                    tik++;
                }

                void label1_Click(object sender, EventArgs e)
                {
                    timer.Start();
                    if (timer1.Enabled == true) 
                        return;

                    Label clickedLabel = sender as Label;

                    if (clickedLabel != null) 
                    {
                        if (clickedLabel.ForeColor == Color.Black) 
                            return;

                        if (firstClicked == null)
                        {
                            firstClicked = clickedLabel;
                            firstClicked.ForeColor = Color.Black;
                            return;
                        }

                        secondClicked = clickedLabel; 
                        secondClicked.ForeColor = Color.Black;
                        timer1.Start();
                    }
                }

                void timer1_Tick(object sender, EventArgs e)
                {
                    
                    if (firstClicked.Text == secondClicked.Text) 
                    {
                        firstClicked.ForeColor = firstClicked.ForeColor;
                        secondClicked.ForeColor = secondClicked.ForeColor;
                    }
                    else 
                    {
                        firstClicked.ForeColor = firstClicked.BackColor;
                        secondClicked.ForeColor = secondClicked.BackColor;
                        score++;
                    }
                    firstClicked = null;
                    secondClicked = null;
                    timer1.Stop(); 
                    CheckForWinner();
                }

                void CheckForWinner()
                {
                    foreach (Control control in tableLayoutPanel.Controls) 
                    {
                        Label iconLabel = control as Label;

                        if (iconLabel != null)
                        {
                            if (iconLabel.ForeColor == iconLabel.BackColor)
                                return;
                        }
                    }
                    timer.Stop(); 
                    System.Threading.Thread.Sleep(1000);
                    MessageBox.Show("Sa sobitasid kõik ikoonid!", "Palju õnne"); 
                    restarGame(); 
                }
                void restarGame() 
                {
                    this.Controls.Clear();
                    if (MessageBox.Show($"Vead: {score.ToString()}\nAeg sekundid: {tik.ToString()}!\nKas soovite uuesti mängida?", "Tulemus!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Controls.Clear();
                        Application.Restart();
                        Environment.Exit(0);
                    }
                    else
                    {
                        this.Controls.Clear();
                        Application.Exit();
                    }

                }
            }

            //Ikoonidega loendid
            List<string> icons = new List<string>()
            {
            "l", "l", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
            };
            List<string> icons2 = new List<string>()
            {
            "l", "l", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
            };
            List<string> icons3 = new List<string>()
            {
            "l", "l", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
            };
            private void Button_Click(object sender, EventArgs e) 
            {
                Button nupp_sender = (Button)sender;
                this.Controls.Clear(); 
                tableLayoutPanel = new TableLayoutPanel
                {
                    BackColor = Color.White,
                    Dock = DockStyle.Fill,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                };
                Controls.Add(tableLayoutPanel);
                if (nupp_sender.Text == "Tavaline raskusaste")
                {

                    new MatchingGame(4, 3, icons, tableLayoutPanel);

                }
                else if (nupp_sender.Text == "Keskmise raskusastmega")
                {

                    new MatchingGame(4, 4, icons2, tableLayoutPanel);

                }
                else if (nupp_sender.Text == "Kõrge raskusaste")
                {

                    new MatchingGame(5, 4, icons3, tableLayoutPanel);
                }
            }
        }
    }

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
            //Taimerite ja nende intervallide loomine
            Timer timer1 = new Timer { Interval = 750 };
            Timer timer = new Timer { Interval = 1000 };
            int score = 0;
            int tik = 0;
            Label difficult;
            public MatchingGame()
            {
                CenterToScreen(); //Tsentreerib vormi  
                Text = "Matching game";
                ClientSize = new Size(550, 550);
                BackColor = Color.White;
                difficult = new Label //Sildi loomine
                {
                    Text = "Mängu raskusaste",
                    Location = new Point(110, 100),
                    Size = new Size(400, 100),
                    Font = new Font("Arial", 28, FontStyle.Bold)
                };
                this.Controls.Add(difficult);
                string[] buttonstext = { "Tavaline raskusaste", "Keskmise raskusastmega", "Kõrge raskusaste" }; //Massiiv nupul oleva tekstiga
                int y = 200;
                for (int i = 0; i < buttonstext.Length; i++) //Nuppude loomine
                {

                    Button button = new Button
                    {
                        Text = buttonstext[i],
                        Location = new Point(210, y),
                        Size = new Size(100, 80)
                    };
                    button.Click += Button_Click; //Nuppude lisamise meetod
                    this.Controls.Add(button);
                    y += 100;
                }


            }
            public MatchingGame(int x, int y, List<string> icons, TableLayoutPanel tableLayoutPanel) //Mänguklassi loomine
            {
                //Taimerite meetodi lisamine
                timer.Tick += Timer_Tick;
                timer1.Tick += timer1_Tick;
                for (int i = 0; i < x; i++) //Sildi loomine
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
                foreach (Control control in tableLayoutPanel.Controls) //Sirvib läbi kõik tabelisLayoutPanel olevad komponendid
                {
                    Label iconLabel = control as Label;
                    if (iconLabel != null) //Kui silt on olemas, siis
                    {
                        int randomNumber = rnd.Next(icons.Count); //Genereerib juhusliku arvu
                        iconLabel.Text = icons[randomNumber]; //Võrdleb sildi teksti indeksi järgi massiivi väärtusega
                        icons.RemoveAt(randomNumber); //Eemaldab selle väärtuse massiivist
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
                    if (timer1.Enabled == true) //Kontrollib, kas taimer on käivitatud, kontrollides atribuudi Enabled väärtust.
                        return;

                    Label clickedLabel = sender as Label;

                    if (clickedLabel != null) //Kui mängija valib esimese ja teise sildielemendi ning taimer käivitub
                    {
                        if (clickedLabel.ForeColor == Color.Black) //Kui klõpsate juba nähtaval sildil, siis ei juhtu midagi
                            return;

                        if (firstClicked == null)
                        {
                            firstClicked = clickedLabel;
                            firstClicked.ForeColor = Color.Black;
                            return;
                        }

                        secondClicked = clickedLabel; //Jälgib teist klõpsu ja määrab sildi mustaks
                        secondClicked.ForeColor = Color.Black;
                        timer1.Start(); //Käivitab taimeri
                    }
                }

                void timer1_Tick(object sender, EventArgs e)
                {
                    //Kontrollib iga taimeri linnukest
                    if (firstClicked.Text == secondClicked.Text) //Kui see sobib, muudab see sildi värvi mustaks
                    {
                        firstClicked.ForeColor = firstClicked.ForeColor;
                        secondClicked.ForeColor = secondClicked.ForeColor;
                    }
                    else //Muidu peidab
                    {
                        firstClicked.ForeColor = firstClicked.BackColor;
                        secondClicked.ForeColor = secondClicked.BackColor;
                        score++;
                    }
                    firstClicked = null;
                    secondClicked = null;
                    timer1.Stop(); //Peatab taimeri
                    CheckForWinner(); //Käivitab funktsiooni
                }

                void CheckForWinner()
                {
                    foreach (Control control in tableLayoutPanel.Controls) //Sirvib läbi kõik tabelisLayoutPanel olevad komponendid
                    {
                        //Kui silmus läbib kõik oksad ja ei naase, siis on mäng läbi
                        Label iconLabel = control as Label;

                        if (iconLabel != null)
                        {
                            if (iconLabel.ForeColor == iconLabel.BackColor)
                                return;
                        }
                    }
                    timer.Stop(); //Peatab taimeri
                    System.Threading.Thread.Sleep(1000);
                    MessageBox.Show("Sa sobitasid kõik ikoonid!", "Palju õnne"); //Kuvab teate mängu lõppemise kohta
                    restarGame(); //Peatab taimeri
                }
                void restarGame() //Taaskäivitab vormi sõltuvalt vastusest
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
            private void Button_Click(object sender, EventArgs e) //Meetod raskete mängude valimiseks
            {
                Button nupp_sender = (Button)sender;
                this.Controls.Clear(); //Tühjendab vormi
                tableLayoutPanel = new TableLayoutPanel
                {
                    BackColor = Color.White,
                    Dock = DockStyle.Fill,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                };
                Controls.Add(tableLayoutPanel);
                //Kontrollib, millist nuppu vajutati
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

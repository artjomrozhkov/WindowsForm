using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsrakendusteloomine
{
    public class Koikvorm : Form
    {
        Button button1, button2, button3;

        public Koikvorm()
        {
            this.Text = "Esimene Vorm";
            this.Size = new Size(580, 200);
            this.BackColor = Color.White;

            button1 = new Button
            {
                Text = "Matemaatika viktoriin",
                Location = new Point(100, 50),
                BackColor = Color.White,
                Size = new Size(120, 70)
            };

            button2 = new Button
            {
                Text = "Pildivaatur",
                Location = new Point(230, 50),
                BackColor = Color.White,
                Size = new Size(120, 70)
            };

            button3 = new Button
            {
                Text = "Sobiv mäng",
                Location = new Point(360, 50),
                BackColor = Color.White,
                Size = new Size(120, 70),
            };

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;

            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var vastus = MessageBox.Show("Kas sa tahad joosta Sobiv mäng?", "Küsimus", MessageBoxButtons.YesNo);

            if (vastus == DialogResult.Yes)
            {
                MatchingGame game = new MatchingGame();
                game.Show();
            }
            else
            {
                MessageBox.Show(":(");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var vastus = MessageBox.Show("Kas sa tahad joosta Pildivaatur?", "Küsimus", MessageBoxButtons.YesNo);

            if (vastus == DialogResult.Yes)
            {
                PictureViewer mathquiz = new PictureViewer();
                mathquiz.Show();
            }
            else
            {
                MessageBox.Show(":(");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var vastus = MessageBox.Show("Kas sa tahad joosta Matemaatika viktoriin?", "Küsimus", MessageBoxButtons.YesNo);

            if (vastus == DialogResult.Yes)
            {
                MathQuiz pildid = new MathQuiz();
                pildid.Show();
            }
            else
            {
                MessageBox.Show(":(");
            }
        }
    }
}



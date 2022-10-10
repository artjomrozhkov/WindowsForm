using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsrakendusteloomine
{
    public partial class PictureViewer : Form
    {

        private List<Bitmap> _bitmaps;
        TableLayoutPanel tableLayoutPanel;
        PictureBox picturebox;
        CheckBox checkBox;
        Button close, backgroundcolor, clear, showapicture,buttonSave;
        ColorDialog colordialog;
        OpenFileDialog openfiledialog1;
        FlowLayoutPanel flowlayoutpanel;
        TrackBar trackbar;

        public PictureViewer()
        {
            Size = new System.Drawing.Size(700, 360);
            Text = "Pildivaatur";
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 2,
                Location = new Point(0, 0),
                Size = new Size(800, 340),
                TabIndex = 0,
                BackColor = Color.White,
            };
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
                (SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle
                (SizeType.Percent, 85F));
            tableLayoutPanel.ColumnStyles.Add(new RowStyle
                (SizeType.Percent, 90F));
            tableLayoutPanel.ColumnStyles.Add(new RowStyle
                (SizeType.Percent, 5F));
            tableLayoutPanel.ResumeLayout(false);

            this.Controls.Add(tableLayoutPanel);


            picturebox = new System.Windows.Forms.PictureBox
            {
                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(2, 2),
                Size = new System.Drawing.Size(600, 269),
                TabIndex = 0,
                TabStop = false,
            };
            tableLayoutPanel.Controls.Add(picturebox, 0,0);
            tableLayoutPanel.SetCellPosition(picturebox, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel.SetColumnSpan(picturebox, 2);


            checkBox = new CheckBox
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 278),
                Size = new System.Drawing.Size(117, 30),
                TabIndex = 1,
                UseVisualStyleBackColor = true,
                Text = "Venitada",
                Dock= System.Windows.Forms.DockStyle.Fill,
            };
            checkBox.CheckedChanged += new System.EventHandler(checkBox_CheckedChanged);
            tableLayoutPanel.Controls.Add(checkBox, 0, 1);




            this.Controls.Add(tableLayoutPanel);


            close = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 3),
                Size = new System.Drawing.Size(75, 23),
                TabIndex=0,
                Text= "Sulge",
                UseVisualStyleBackColor = true,


            };
            this.close.Click += new System.EventHandler(this.close_Click);
            tableLayoutPanel.Controls.Add(close);



            colordialog = new ColorDialog
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color=Color.Red,
            };



            backgroundcolor = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(84, 3),
                Size = new System.Drawing.Size(121, 23),
                TabIndex = 1,
                Text = "Taustavärvi määramine",
                UseVisualStyleBackColor = true,

            };
            tableLayoutPanel.Controls.Add(backgroundcolor);
            this.backgroundcolor.Click += new System.EventHandler(this.backgroundcolor_Click);


            clear = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(211, 3),
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 2,
                Text= "Kustuta",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(clear);
            this.clear.Click += new System.EventHandler(this.clear_Click);

            showapicture = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(292, 3),
                Size = new System.Drawing.Size(102, 23),
                TabIndex = 3,
                Text = "Näita pilti",
                UseVisualStyleBackColor = true,

            };
            tableLayoutPanel.Controls.Add(showapicture);
            this.showapicture.Click += new System.EventHandler(this.showapicture_Click);

            buttonSave = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(84, 3),
                Size = new System.Drawing.Size(121, 23),
                TabIndex = 1,
                Text = "Salvesta pilti",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(buttonSave);
            buttonSave.Click += ButtonSave_Click;


            trackbar = new TrackBar
            {
                Orientation = Orientation.Vertical,
                Dock = DockStyle.Left,
                Minimum = 1,
                Maximum = 100,
                Size = new System.Drawing.Size(15, 200),
            };
            tableLayoutPanel.Controls.Add(trackbar, 1, 0);
            trackbar.Scroll += Trackbar_Scroll;

            openfiledialog1 = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = "Sirvige tekstifaile",
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",
            };
            
            Button[] buttons = { clear, showapicture, close, backgroundcolor, buttonSave };
            flowlayoutpanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection=FlowDirection.LeftToRight,
                Size= new Size(250,50),
            };
            flowlayoutpanel.Controls.AddRange(buttons);
            tableLayoutPanel.Controls.Add(flowlayoutpanel, 1,1);
            this.Controls.Add(tableLayoutPanel);
        }

        private void Trackbar_Scroll(object sender, EventArgs e)
        {
            if (_bitmaps == null || _bitmaps.Count == 0)
                return;


            picturebox.Image = _bitmaps[trackbar.Value - 1];
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (picturebox.Image != null) //kui pictureBoxis on pilt
            {
                //looge pildi salvestamiseks dialoogiboks "Salvesta kui...".
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //kas kuvada hoiatust, kui kasutaja määrab juba olemasoleva faili nime
                savedialog.OverwritePrompt = true;
                //kas kuvada hoiatust, kui kasutaja määrab olematu tee
                savedialog.CheckPathExists = true;
                //väljal "Failitüüp" kuvatavate failivormingute loend
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //on dialoogiboksis kuvatav nupp "Abi".
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //kui dialoogiboksis vajutatakse nuppu "OK".
                {
                    try
                    {
                        picturebox.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            picturebox.Image = null;
        }

        private void backgroundcolor_Click(object sender, EventArgs e)
        {
            if (colordialog.ShowDialog() == DialogResult.OK)
            {
                picturebox.BackColor = colordialog.Color;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PictureViewer
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "PictureViewer";
            this.Load += new System.EventHandler(this.PictureViewer_Load);
            this.ResumeLayout(false);

        }

        private void PictureViewer_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showapicture_Click(object sender, EventArgs e)
        {
            if(openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                picturebox.Load(openfiledialog1.FileName);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                picturebox.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}



//youtube.com/watch?v=JXnyaI0rbns

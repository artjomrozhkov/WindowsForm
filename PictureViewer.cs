using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsrakendusteloomine
{
    public partial class PictureViewer : Form
    {




        private List<Bitmap> _bitmaps = new List<Bitmap>();
        private Random _random = new Random();
        TableLayoutPanel tableLayoutPanel;
        PictureBox picturebox;
        CheckBox checkBox;
        Button close, backgroundcolor, clear, showapicture, buttonSave, greyButton, rotateButton, SlideShowButton;
        ColorDialog colordialog;
        OpenFileDialog openfiledialog1;
        FlowLayoutPanel flowlayoutpanel;
        TrackBar trackbar;
        Timer timer;
        FolderBrowserDialog slide;

        public PictureViewer()
        {

            Size = new System.Drawing.Size(800, 380);
            Text = "Pildivaatur";
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 2,
                Location = new Point(0, 0),
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



            SlideShowButton = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 3),
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 5,
                Text = "SlideShow",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(SlideShowButton, 0, 3);
            SlideShowButton.Click += SlideShowButton_Click;

            rotateButton = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(454, 3),
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 5,
                Text = "Laienda",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(rotateButton);
            rotateButton.Click += RotateButton_Click;

            picturebox = new System.Windows.Forms.PictureBox
            {
                BorderStyle = BorderStyle.Fixed3D,
                Dock = DockStyle.Fill,
                Location = new Point(2, 2),
                Size = new Size(528, 269),
                TabIndex = 0,
                TabStop = false,
            };
            tableLayoutPanel.Controls.Add(picturebox, 0, 0);
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
                Dock = System.Windows.Forms.DockStyle.Fill,
            };
            checkBox.CheckedChanged += new System.EventHandler(checkBox_CheckedChanged);
            tableLayoutPanel.Controls.Add(checkBox, 1, 0);




            this.Controls.Add(tableLayoutPanel);


            close = new Button
            {
                AutoSize = true,
                Location = new System.Drawing.Point(3, 3),
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 0,
                Text = "Sulge",
                UseVisualStyleBackColor = true,


            };
            this.close.Click += new System.EventHandler(this.close_Click);
            tableLayoutPanel.Controls.Add(close);



            colordialog = new ColorDialog
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Color.Red,
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
                Text = "Kustuta",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(clear);
            this.clear.Click += new System.EventHandler(this.clear_Click);

            showapicture = new Button
            {
                AutoSize = true,
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
                TabIndex = 4,
                Text = "Salvesta pilti",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(buttonSave);
            buttonSave.Click += ButtonSave_Click;


            trackbar = new TrackBar
            {
                Orientation = Orientation.Vertical,
                Dock = DockStyle.Left,
                Minimum = 0,
                Maximum = 255,
                Value = 255,
                Size = new System.Drawing.Size(15, 200),
            };
            tableLayoutPanel.Controls.Add(trackbar, 1, 0);
            trackbar.Scroll += Trackbar_Scroll;

            greyButton = new Button
            {
                AutoSize = true,
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 5,
                Text = "Must",
                UseVisualStyleBackColor = true,
            };
            tableLayoutPanel.Controls.Add(greyButton);
            greyButton.Click += GreyButton_Click;

            openfiledialog1 = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = "Sirvige tekstifaile",
                Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*",
            };

            Button[] buttons = { clear, showapicture, close, backgroundcolor, buttonSave, rotateButton, greyButton, SlideShowButton };
            flowlayoutpanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Size = new Size(200, 60),
            };
            flowlayoutpanel.Controls.AddRange(buttons);
            tableLayoutPanel.Controls.Add(flowlayoutpanel, 1, 1);
            this.Controls.Add(tableLayoutPanel);

            timer = new Timer
            {
                Interval = 1000,
            };
            timer.Tick += Timer_Tick;
        }
        int imgNum = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            picturebox.ImageLocation = string.Format(slide.SelectedPath + "\\img{0}.jpg", imgNum);
            imgNum++;
            if (imgNum == 5)
                imgNum = 1;
        }

        private void SlideShowButton_Click(object sender, EventArgs e)
        {
            slide = new FolderBrowserDialog();
            slide.ShowDialog();
            timer.Enabled = true;
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            Bitmap rotate = new Bitmap(picturebox.Image);
            if (rotate != null)
            {
                rotate.RotateFlip(RotateFlipType.Rotate180FlipY);
                picturebox.Image = rotate;
            }
        }

        private void GreyButton_Click(object sender, EventArgs e)
        {
            if (picturebox.Image != null) // если изображение в pictureBox1 имеется
            {
                // создаём Bitmap из изображения, находящегося в pictureBox1
                Bitmap input = new Bitmap(picturebox.Image);
                // создаём Bitmap для черно-белого изображения
                Bitmap output = new Bitmap(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем (i, j) пиксель
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                        // получаем компоненты цветов пикселя
                        float R = (float)((pixel & 0x00FF0000) >> 16); // красный
                        float G = (float)((pixel & 0x0000FF00) >> 8); // зеленый
                        float B = (float)(pixel & 0x000000FF); // синий
                                                               // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое
                        R = G = B = (R + G + B) / 3.0f;
                        // собираем новый пиксель по частям (по каналам)
                        UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                        // добавляем его в Bitmap нового изображения
                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                    }
                // выводим черно-белый Bitmap в pictureBox2
                picturebox.Image = output;
            }
        }

        static Bitmap SetAlpha(Bitmap bmpIn, int alpha)
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            float a = alpha / 255f;
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, a, 0},
            new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
                g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
        }

        Image original = null;
        private void Trackbar_Scroll(object sender, EventArgs e)
        {
            if (original == null) original = (Bitmap)picturebox.Image.Clone();
            picturebox.BackColor = Color.Transparent;
            picturebox.Image = SetAlpha((Bitmap)original, trackbar.Value);
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
            if (openfiledialog1.ShowDialog() == DialogResult.OK)
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

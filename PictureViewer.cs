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
        TableLayoutPanel tableLayoutPanel;
        PictureBox picturebox;
        CheckBox checkBox;
        Button close, backgroundcolor, clear, showapicture;
        ColorDialog colordialog;
        OpenFileDialog openfiledialog1;
        FlowLayoutPanel flowlayoutpanel;

        public PictureViewer()
        {
            Size = new System.Drawing.Size(560, 360);
            Text = "Pildivaatur";
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Location = new Point(0, 0),
                Size = new Size(534, 311),
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
                Size = new System.Drawing.Size(528, 269),
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
            tableLayoutPanel.Controls.Add(checkBox, 1, 0);




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

            openfiledialog1 = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = "Sirvige tekstifaile",
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",
            };
            
            Button[] buttons = { clear, showapicture, close, backgroundcolor };
            flowlayoutpanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection=FlowDirection.LeftToRight,
                Size= new Size(200,50),
            };
            flowlayoutpanel.Controls.AddRange(buttons);
            tableLayoutPanel.Controls.Add(flowlayoutpanel, 1,1);
            this.Controls.Add(tableLayoutPanel);
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

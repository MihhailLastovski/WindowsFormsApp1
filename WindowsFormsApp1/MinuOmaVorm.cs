using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MinuOmaVorm : Form
    {
        TreeView puu;
        Button nupp, nupp1, nupp2;
        Label silt, label2;
        CheckBox mruut1,mruut2;
        RadioButton rnupp1, rnupp2, rnupp3, rnupp4;
        PictureBox pilt;
        ProgressBar riba;
        Timer aeg;
        TextBox tekst;
        
        public MinuOmaVorm()
        {
            Height = 700;
            Width = 1400;
            Text = "Minu oma vorm koos elementidega";
            BackColor = Color.FloralWhite;
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad= new TreeNode("Elemendid");
            oksad.Nodes.Add(new TreeNode("Nupp"));
            oksad.Nodes.Add(new TreeNode("Silt"));
            oksad.Nodes.Add(new TreeNode("Dialog aken"));
            oksad.Nodes.Add(new TreeNode("Märkeruut"));
            oksad.Nodes.Add(new TreeNode("Radionupp"));
            oksad.Nodes.Add(new TreeNode("Edenemisriba-ProgressBar"));
            oksad.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            oksad.Nodes.Add(new TreeNode("MinuVorm-MyForm"));
            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
        }


        Random rnd = new Random();
        Font LargeFont = new Font("Arial", 20);
        Font MediumFont = new Font("Arial", 11);
        Font fontTest = new Font("Arial", 30);
        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {


            silt = new Label
            {
                Text = "Minu esimene vorm",
                Size = new Size(300, 100),
                Location = new Point(200, 10),
                ForeColor = Color.Navy,
                BorderStyle = BorderStyle.FixedSingle
            };
            mruut1 = new CheckBox
            {
                Checked = false,
                Text = "Üks",
                Location = new Point(silt.Left + silt.Width, 0),
                Width = 60,
                Height = 25
            };
            mruut2 = new CheckBox
            {
                Checked = false,
                Text = "Kaks",
                Location = new Point(silt.Left + silt.Width, mruut1.Height),
                Width = 60,
                Height = 25
            };
            if (e.Node.Text == "Nupp")
            {
                nupp = new Button();
                nupp.Text = "Vajuta siia";
                nupp.Height = 30;
                nupp.Width = 100;
                nupp.Location = new Point(200, 200);
                nupp.Click += Nupp_Click;
                this.Controls.Add(nupp);
            }
            else if (e.Node.Text == "Silt")
            {
                silt.Font = LargeFont;
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if (e.Node.Text == "Dialog aken")
            {
                MessageBox.Show("Siia kirjuta lause", "Kõike lihtne aken");
                var vastus = MessageBox.Show("Kas paneme aken kinni?", "Valik", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (vastus == DialogResult.Yes)
                {
                    this.Close();
                }
                else if (vastus == DialogResult.No)
                {
                    MessageBox.Show("Yo, Big Smoke, my N-bro");
                    BackColor = Color.Black;
                }

            }
            else if (e.Node.Text == "Märkeruut")
            {
                Label label = new Label
                {
                    Text = "Värvide segamine",
                    Size = new Size(200, 30),
                    Location = new Point(560, 0)
                };
                mruut1.CheckedChanged += new EventHandler(Mruut_CheckedChanged);
                mruut2.CheckedChanged += new EventHandler(Mruut_CheckedChanged);
                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);
                this.Controls.Add(label);
            }
            else if (e.Node.Text == "Radionupp")
            {
                rnupp1 = new RadioButton
                {
                    Text = "Vasakule",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height)
                };
                rnupp2 = new RadioButton
                {
                    Text = "Paremale",
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width, mruut1.Height + mruut2.Height)
                };
                rnupp3 = new RadioButton
                {
                    Text = "Ülesse",
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width + rnupp2.Width, mruut1.Height + mruut2.Height)
                };
                rnupp4 = new RadioButton
                {
                    Text = "Alla",
                    Location = new Point(mruut2.Left + mruut2.Width + rnupp1.Width + rnupp2.Width + rnupp3.Width, mruut1.Height + mruut2.Height)
                };
                pilt = new PictureBox
                {
                    Image = new Bitmap("../../tthk.png"),
                    Location = new Point(300, 300),
                    Size = new Size(100, 100),
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                rnupp1.CheckedChanged += new EventHandler(Rnupp_CheckedChanged);
                rnupp2.CheckedChanged += new EventHandler(Rnupp_CheckedChanged);
                rnupp3.CheckedChanged += new EventHandler(Rnupp_CheckedChanged);
                rnupp4.CheckedChanged += new EventHandler(Rnupp_CheckedChanged);
                this.Controls.Add(rnupp1);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);
                this.Controls.Add(pilt);

            }
            else if (e.Node.Text == "Edenemisriba-ProgressBar")
            {
                riba = new ProgressBar
                {
                    Width = 400,
                    Height = 30,
                    Location = new Point(550, 600),
                    Value = 0,
                    Minimum = 0,
                    Maximum = 100,
                    Step = 1,

                };
                nupp1 = new Button
                {
                    Text = "Да",
                    Height = 30,
                    Width = 50,
                    Location = new Point(550, 550),
                };
                nupp2 = new Button
                {
                    Text = "Нет",
                    Height = 30,
                    Width = 50,
                    Location = new Point(700, 550),
                };

                label2 = new Label
                {
                    Text = "1. Можно ли выбрать больше одной радиокнопки?",
                    Size = new Size(800, 30),
                    Location = new Point(550, 500),
                    Font = MediumFont
                };
                aeg = new Timer();
                aeg.Enabled = true;
                nupp1.Click += new EventHandler(Nupp1_Click);
                nupp2.Click += new EventHandler(Nupp2_Click);
                this.Controls.Add(label2);
                this.Controls.Add(riba);
                this.Controls.Add(nupp1);
                this.Controls.Add(nupp2);
            }
            else if (e.Node.Text == "Tekstkast-TextBox")
            {
                tekst = new TextBox
                {
                    Font = new Font("Arial", 34, FontStyle.Italic),
                    Location = new Point(800, 530),
                    Enabled = false
                };
                puu.MouseDoubleClick += Tekst_MouseDoubleClick;
                this.Controls.Add(tekst);
            }
            else if (e.Node.Text == "MinuVorm-MyForm")
            {
                MinuVorm minu = new MinuVorm("Kuulane muusikat");
                minu.ShowDialog();
            }

        }

        private void Tekst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tekst.Enabled == false) { tekst.Enabled = true; }
            else { tekst.Enabled = false; }
        }


        private async void Nupp1_Click(object sender, EventArgs e)
        {
            if(nupp1.Enabled == true && label2.Text == "1. Можно ли выбрать больше одной радиокнопки?")
            {
                label2.Text = "Неверно";
                riba.Value = 0;
                await Task.Delay(1000);
                label2.Text = "1. Можно ли выбрать больше одной радиокнопки?";
            }
            else if (nupp1.Enabled == true && label2.Text == "2. Верно ли это написание Label label = new Label{Text = \"Text\",Size = new Size(200, 30),Location = new Point(0, 0)};?")
            {
                label2.Text = "Верно";
                riba.Value = 66;
                await Task.Delay(1000);
                label2.Text = "3. Понравился ли, Вам, тест?";
            }
            else if(nupp1.Enabled == true && label2.Text == "3. Понравился ли, Вам, тест?") 
            {
                label2.Text = "Верно";
                riba.Value = 100;
                await Task.Delay(1000);
                label2.Text = "Поздравляю! Вы прошли тест!";
                this.Controls.Remove(nupp1);
                this.Controls.Remove(nupp2);
            }
            
        }
        private async void Nupp2_Click(object sender, EventArgs e)
        {
            if (nupp2.Enabled == true && label2.Text == "1. Можно ли выбрать больше одной радиокнопки?")
            {
                label2.Text = "Верно";
                riba.Value = 33;
                await Task.Delay(1000);
                label2.Text = "2. Верно ли это написание Label label = new Label{Text = \"Text\",Size = new Size(200, 30),Location = new Point(0, 0)};?";
            }
            else if (nupp2.Enabled == true && label2.Text == "2. Верно ли это написание Label label = new Label{Text = \"Text\",Size = new Size(200, 30),Location = new Point(0, 0)};?")
            {
                label2.Text = "Неверно";
                riba.Value = 0;
                await Task.Delay(1000);
                label2.Text = "1. Можно ли выбрать больше одной радиокнопки?";
            }
            else if (nupp2.Enabled == true && label2.Text == "3. Понравился ли, Вам, тест?") 
            {
                label2.Text = "Неверно";
                riba.Value = 0;
                await Task.Delay(1000);
                label2.Text = "1. Можно ли выбрать больше одной радиокнопки?";
            }
        }
        private void Rnupp_CheckedChanged(object sender, EventArgs e)
        {
            if (rnupp1.Checked)
            {
                pilt.Location = new Point(pilt.Left - 10, pilt.Top);
                rnupp1.Checked = false;
            }
            if (rnupp2.Checked)
            {
                pilt.Location = new Point(pilt.Left + 10, pilt.Top);
                rnupp2.Checked = false;
            }
            if (rnupp3.Checked)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top - 10);
                rnupp3.Checked = false;
            }
            if (rnupp4.Checked)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top + 10);
                rnupp4.Checked = false;
            }
        }

        private void Mruut_CheckedChanged(object sender, EventArgs e)
        {
            if (mruut1.Checked == true && mruut2.Checked == false)
            {
                ForeColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("Punane");
            }
            else if (mruut2.Checked == true && mruut1.Checked == false) 
            {
                ForeColor = Color.FromArgb(255, 255, 0);
                MessageBox.Show("Kollane");
            }
            else if (mruut2.Checked == true && mruut1.Checked == true)
            {
                ForeColor = Color.FromArgb(255, 255, 255);
                MessageBox.Show("Valge");
            }
            else if (mruut2.Checked == false && mruut1.Checked == false)
            {
                ForeColor = Color.FromArgb(0, 0, 255);
                MessageBox.Show("Sinine");
            }
        }

        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            silt.Font = LargeFont;
        }

        private void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.Font = fontTest;
        }

        private void Nupp_Click(object sender, EventArgs e)
        {
            nupp.Height = rnd.Next(20, 500);
            nupp.Width = rnd.Next(20, 500);
            nupp.Location = new Point(rnd.Next(150, 500), rnd.Next(150,450));
            int red, green, blue;
            red = rnd.Next(0, 255);
            green = rnd.Next(0, 255);
            blue = rnd.Next(0, 255);
            this.BackColor = Color.FromArgb(red, green, blue);

        }
    }
}

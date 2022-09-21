using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public class MinuVorm : Form
    {
        ComboBox mybox;
        public MinuVorm() { }
        public MinuVorm(string Pealkiri, string Nupp, string Fail)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(50,50),
                Size = new System.Drawing.Size(50,50),
                BackColor = System.Drawing.Color.White,

            };
            nupp.Click += Nupp_Click;
            Label failinimi = new Label
            {
                Text = Fail,
                Location = new System.Drawing.Point(50, 150),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.White,
            };
            TextBox txt = new TextBox
            {
                Font = new Font("Arial", 16, FontStyle.Italic),
                Location = new Point(150, 200),
                Enabled = true
            };
            ComboBox mybox = new ComboBox
            {
                Name = "mybox",
                Location = new Point(100, 150),
                Size = new Size(100, 50),
                DropDownStyle = ComboBoxStyle.DropDown 
            };
            Button nupp1 = new Button
            {
                Text = "ok",
                Height = 30,
                Width = 30,
                Location = new Point(200, 200),
            };
            mybox.Items.Add(@"..\..\zhestphonk.wav");
            nupp1.Click += Nupp1_Click;
            this.Controls.Add(nupp1);
            this.Controls.Add(txt);
            this.Controls.Add(mybox);
            this.Controls.Add(nupp);
            this.Controls.Add(failinimi);
        }


        private void Nupp1_Click(object sender, EventArgs e)
        {
            string selectedItem = mybox.Items[mybox.SelectedIndex].ToString();

        }

        private void Nupp_Click(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            var vastus = MessageBox.Show("Kas tahad muusikat kuulata?", "Küsimus", MessageBoxButtons.YesNo);
            if (vastus == DialogResult.Yes)
            {
                using (var muusika = new SoundPlayer())
                {
                    muusika.Play();
                }
            }
            else { MessageBox.Show(":("); }
        }
    }
}

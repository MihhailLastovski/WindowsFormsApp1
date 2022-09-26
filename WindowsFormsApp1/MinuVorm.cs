using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using WMPLib;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public class MinuVorm : Form //Для работы требуется WMPLib
    {
        ComboBox mybox;
        public MinuVorm() { }
        public MinuVorm(string Pealkiri)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;

            Label volumelbl = new Label
            {
                Text = "volume",
                Location = new System.Drawing.Point(75, 100),
                Size = new System.Drawing.Size(150, 50),
                BackColor = System.Drawing.Color.White,
                Font = new Font("Arial", 27, FontStyle.Bold)
            };
            Label musiklbl = new Label
            {
                Text = "Choose song",
                Location = new System.Drawing.Point(75, 10),
                Size = new System.Drawing.Size(150, 50),
                BackColor = System.Drawing.Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold)
            };
            Button nuppvol1 = new Button
            {
                Text = "-",
                Height = 30,
                Width = 30,
                Location = new Point(75,150),

            };
            Button nuppvol2 = new Button
            {
                Text = "+",
                Height = 30,
                Width = 30,
                Location = new Point(200, 150),
            };
            mybox = new ComboBox
            {
                Name = "mybox",
                Location = new Point(75, 50),
                Size = new Size(150, 50),
                DropDownStyle = ComboBoxStyle.DropDown 
            };
            Button nupp1 = new Button
            {
                Text = "play",
                Height = 30,
                Width = 30,
                Location = new Point(103, 150),
                Size = new Size(100, 50),
            };
            Button nupp2 = new Button
            {
                Text = "stop",
                Height = 30,
                Width = 30,
                Location = new Point(103, 200),
                Size = new Size(100, 50),
            };

            string[] files = Directory.GetFiles(@"..\..\musiks", "*.wav");
            foreach (var item in files)
            {
                string[] abc = item.Split('\\');
                mybox.Items.Add(abc[abc.Length - 1]);
            }

            nuppvol1.Click += Nuppvol1_Click;
            nuppvol2.Click += Nuppvol2_Click;
            nupp1.Click += Nupp1_Click;
            nupp2.Click += Nupp2_Click;
            this.Controls.Add(nupp1);
            this.Controls.Add(mybox);
            this.Controls.Add(volumelbl);
            this.Controls.Add(nuppvol1);
            this.Controls.Add(nuppvol2);
            this.Controls.Add(musiklbl);
            this.Controls.Add(nupp2);
        }

        private void Nupp2_Click(object sender, EventArgs e)
        {
            muusika.controls.stop();
        }

        WindowsMediaPlayer muusika = new WindowsMediaPlayer();
        private void Nuppvol2_Click(object sender, EventArgs e)
        {
            if (muusika.settings.volume <= 90)
            {
                muusika.settings.volume += 10;
            }
        }

        private void Nuppvol1_Click(object sender, EventArgs e)
        {
            if (muusika.settings.volume >= 10)
            {
                muusika.settings.volume -= 10;
            }
        }

        private void Nupp1_Click(object sender, EventArgs e)
        {
            var ind = Directory.GetCurrentDirectory().ToString()
                .IndexOf("bin", StringComparison.Ordinal);
            string binFolder =
                Directory.GetCurrentDirectory().ToString().Substring(0, ind)
                .ToString();
            string resourcesFoler = binFolder + "musiks\\";
            muusika.URL = resourcesFoler+ mybox.Items[mybox.SelectedIndex].ToString(); 
            muusika.controls.play();
        }

      
    }
}

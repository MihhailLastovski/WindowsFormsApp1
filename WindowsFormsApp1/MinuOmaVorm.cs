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
        Button nupp;
        Label silt;
        public MinuOmaVorm()
        {
            Height = 600;
            Width = 900;
            Text = "Minu oma vorm koos elementidega";
            BackColor = Color.FloralWhite;
            puu = new TreeView();
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad= new TreeNode("Elemendid");
            oksad.Nodes.Add(new TreeNode("Nupp"));
            oksad.Nodes.Add(new TreeNode("Silt"));
            oksad.Nodes.Add(new TreeNode("Dialog aken"));
            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
        }


        Random rnd = new Random();
        Font LargeFont = new Font("Arial", 20);
        Font fontTest = new Font("Arial", 30);
        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
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
                silt = new Label{Text = "Minu esimene vorm",
                    Size=new Size(300,100),
                    Location = new Point(200, 10),
                    ForeColor = Color.Navy,
                    BorderStyle = BorderStyle.FixedSingle
            };
                silt.Font = LargeFont;
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if(e.Node.Text == "Dialog aken")
            {
                MessageBox.Show("Siia kirjuta lause", "Kõike lihtne aken");
                var vastus = MessageBox.Show("Kas paneme aken kinni?", "Valik",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (vastus == DialogResult.Yes)
                {
                    this.Close();
                }
                else if(vastus == DialogResult.No)
                {
                    MessageBox.Show("Oh, Big Smoke, my N-bro");
                    BackColor = Color.Black;
                }
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

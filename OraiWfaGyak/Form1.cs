using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OraiWfaGyak
{
    public partial class Form1 : Form
    {
        List<TextBox> txtBoxList = new List<TextBox>();


        public Form1()
        {
            InitializeComponent();
            this.Text = "Pogram 4Head";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int db = (int)sorokSzama.Value;
            for (int i = 0; i < db; i++)
            {
                TextBox dynamicTxtBox = new TextBox();
                dynamicTxtBox.SetBounds(10, 50 + i * 25, 100, dynamicTxtBox.Height);
                this.Controls.Add(dynamicTxtBox);
                this.txtBoxList.Add(dynamicTxtBox);

                Button b = new Button();
                b.SetBounds(125, 50 + i * 25, 100, b.Height);
                b.Text = "Button " + (i + 1);
                this.Controls.Add(b);
                b.MouseUp += (sndr1, args1) =>
                {
                    if (args1.Button == MouseButtons.Right)
                    {
                        MessageBox.Show("JobbKlikkeltél!");


                    }
                    if (args1.Button == MouseButtons.Left)
                    {
                        MessageBox.Show("Tartalom: " + dynamicTxtBox.Text);
                    }
                };
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string szoveg = "";
            foreach (var tb in txtBoxList)
            {
                szoveg += tb.Text + Environment.NewLine;
            }
            MessageBox.Show(szoveg);
            if (File.Exists("gyak.txt"))
            {
                File.AppendAllText("gyak.txt", DateTime.Now + Environment.NewLine + szoveg + Environment.NewLine);
            }
            else
            {
                File.WriteAllText("gyak.txt", DateTime.Now + Environment.NewLine + szoveg + Environment.NewLine);
            }

        }
    }
}

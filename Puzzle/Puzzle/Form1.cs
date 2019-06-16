using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            }


        private void Form1_Load(object sender, EventArgs e)
            {
            timer1.Start();
           
            }

        private void timer1_Tick(object sender, EventArgs e)
            {
            metroProgressBar1.Increment(1);
         //   metroProgressBar1.
            if (metroProgressBar1.Value == 100)
                {
                timer1.Stop();
                MainMenu fom = new MainMenu();
                this.Hide();
                fom.ShowDialog();
                this.Close();
              //  timer1.Stop();
                }
            }

        private void button1_Click(object sender, EventArgs e)
            {
           DialogResult res= MessageBox.Show("Do You Want To Exit The Game Application?", "Puzzle Gaming Application", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
                {
                Application.Exit();
                }
            else
                {

                }
            }
        }
    }

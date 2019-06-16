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
    public partial class MainMenu : Form
        {
        public MainMenu()
            {
            InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            Form2 fom = new Form2();
           //Form3 fom = new Form3();
            this.Hide();
            fom.ShowDialog();
            this.Close();
            }
       
private void button6_Click(object sender, EventArgs e)
            {
            DialogResult res = MessageBox.Show("Do You Want To Exit The Game Application?", "Puzzle Gaming Application", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
                {
                Application.Exit();
                }
            else
                {

                }
            }

        private void button4_Click(object sender, EventArgs e)
            {
            MessageBox.Show("Puzzle Gaming Application Developed By Adebayo Mayowa Michael", "Puzzle Gaming Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

    }
    }

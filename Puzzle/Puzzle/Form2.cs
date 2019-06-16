using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Puzzle
    {
    public partial class Form2 : Form
        {
        Point EmptyPoint;
        ArrayList imagery= new ArrayList();
        public Form2()
            {
            EmptyPoint.X = 180;
            EmptyPoint.Y = 180;
            InitializeComponent();
        
            }

        private void Buttons_Click(object sender, EventArgs e)
            {
             MoveButton((Button)sender);
            }

        private void MoveButton(Button sender)
            {

             if (((sender.Location.X == EmptyPoint.X-90 || sender.Location.X==EmptyPoint.X+90)&& sender.Location.Y == EmptyPoint.Y)|| (sender.Location.Y == EmptyPoint.Y - 90 || sender.Location.Y == EmptyPoint.Y + 90) && sender.Location.X == EmptyPoint.X)
                {
                Point swap = sender.Location;
                sender.Location = EmptyPoint;
                EmptyPoint = swap;
                }
            if (EmptyPoint.X == 180 && EmptyPoint.Y == 180)
                CheckValid();
            }
        private void CheckValid()
            {
            try
                {
                int count = 0, index;
                foreach (Button btn in panel1.Controls)
                    {
                    index = (btn.Location.Y / 90) * 3 + btn.Location.X / 90;
                    if (imagery[index] == btn.Image)
                        count++;
                    }
                if (count == 8)
                    {
                    MessageBox.Show("Yay! Puzzle Has Been Completed Successfully", "Puzzle Gaming Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            catch (Exception ex)
                {

                }
            }

        private void button17_Click(object sender, EventArgs e)
            {

            OpenFileDialog opener = new OpenFileDialog();
            opener.Title = "Upload Image";
            opener.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (opener.ShowDialog() == DialogResult.OK)
                {
                string picloc = opener.FileName.ToString();
                OriginalImage.ImageLocation = picloc;
            }
            foreach (Button b in panel1.Controls)
                {
                b.Enabled = true;
                Image original = Image.FromFile(opener.FileName);
             // Image original = Image.FromFile(@"C:\Users\Great\Downloads\5.png");
             cropImageToImages(original, 270, 270);
                AddImagesToButtons(imagery);
                }
            }

        private void AddImagesToButtons(ArrayList imagery)
            {
            try
                {
                int i = 0;
                int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
                arr = suffle(arr);
                foreach (Button b in panel1.Controls)
                    {
                    if (i < arr.Length)
                        {
                        b.Image = (Image)imagery[arr[i]];
                        i++;
                        }
                    }
                }
            catch (Exception ex)
                {

                }
            }

        private int[] suffle(int[] arr)
            {
            Random rand = new Random();
            arr = arr.OrderBy(x => rand.Next()).ToArray();
            return arr;
            }

        private void cropImageToImages(Image original, int w, int h)
            {
            Bitmap bmp = new Bitmap(w,h);
            Graphics graphic = Graphics.FromImage(bmp);
            graphic.DrawImage(original, 0, 0, w, h);
            graphic.Dispose();
            int movr = 0, movd = 0;
            for(int x=0;x<8; x++)
                {
                Bitmap piece = new Bitmap(90, 90);
                for (int i = 0; i < 90; i++)
                    for (int j = 0; j < 90; j++)
                        piece.SetPixel(i, j, bmp.GetPixel(i + movr, j + movd));
                imagery.Add(piece);
                movr += 90;
                if(movr == 270)
                    {
                    movr = 0;
                    movd += 90;
                    }
                }
            }

        private void OriginalImage_Click(object sender, EventArgs e)
            {

            }

        private void button1_Click(object sender, EventArgs e)
            {
            MainMenu me = new MainMenu();
            this.Hide();
            me.ShowDialog();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    }


///
//public void comment()
  //  {
    //ToBeResize = Image.FromFile(Application.StartupPath);
    //OriginalImage.BackgroundImage = ToBeResize;
    //   EmptyPoint.X = 213;
    // EmptyPoint.Y = 212;
    //initial value is 210;
    //     Point EmptyPoint;
    //   Image ToBeResize;
    //   AddImagesToButtons(ReturnCroppedLisy(Resize(ToBeResize)));
    /*
      private void MoveButton(Button button)
    {
    int x = EmptyPoint.X - button.Location.X;
    int px = x < 0 ? -x : x;

    int y = EmptyPoint.Y - button.Location.Y;
    int py = y < 0 ? -y : y;

    //In order to move Right & Left

    if(button.Location.Y.Equals(EmptyPoint.Y) && px.Equals(button.Size.Width))
        {
        button.Location = new Point(button.Location.X + x, button.Location.Y);
        EmptyPoint.X -= x;
        }
    // moving top and bottom
    if(button.Location.X.Equals(EmptyPoint.X) && py.Equals(button.Size.Width))
        {
        button.Location = new Point(button.Location.X, button.Location.Y+y);
            EmptyPoint.Y -= y;
        }
    }

    //////
      /*   OpenFileDialog open = new OpenFileDialog();
    open.Filter = "Image Files(JPEG,GIF,BMP,PNG,JPG)|*.jpeg;*.bmp;*.png;*.gif;*.jpg";
    open.RestoreDirectory = true;
    if(open.ShowDialog() == DialogResult.OK)
        {
        ToBeResize = Image.FromFile(open.FileName);
        OriginalImage.Image = Resize(ToBeResize);
        AddImageToButtons(ReturnCroppedList((Resize(ToBeResize), 70, 70));
        } 
    }
private Bitmap Resize(Image img)
    {
    int w = 280;
    int h = 280;
    //Create a new bitmap the size of the new image
    Bitmap bmp = new Bitmap(w, h);
    // create graphic from the bitmap
    Graphics graphic = Graphics.FromImage((Image)bmp);
    graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    //drawing the newl    y size*/
   // }

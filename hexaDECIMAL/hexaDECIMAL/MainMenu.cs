using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hexaDECIMAL
{
    public partial class MainMenu : Form
    {

        private bool mouseDown;
        private Point location;

        public MainMenu()
        {
            InitializeComponent();
            sidePanel.Height = button1.Height;
            sidePanel.Top = button1.Top;
            //teamProfileUC1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button1.Height;
            sidePanel.Top = button1.Top;
            //teamProfileUC1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button2.Height;
            sidePanel.Top = button2.Top;
            //currentSquadUC1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button3.Height;
            sidePanel.Top = button3.Top;
            accounts1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            databaseOperations.onlineCheck = false;
            databaseOperations.errorMsg = false;
            login.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //***Window dragging code
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            location = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {

            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - location.X) + e.X, (this.Location.Y - location.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

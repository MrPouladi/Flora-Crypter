using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flora
{
    public partial class Form1 : Form
    {
        private Form activeform;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;

            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;

            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;

            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;

            Form activeform = new Form();
            

            

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void OpenChildForm(Form childform, object btnSender)
        {

            if (activeform != null)
            {
                Invoke(new Action(() => activeform.Hide()));
            }
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;

            Invoke(new Action(() => this.panel4.Controls.Add(childform)));
            Invoke(new Action(() => this.panel4.Tag = childform));
            Invoke(new Action(() => childform.BringToFront()));
            Invoke(new Action(() => childform.Show()));
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Invoke(new Action(() => OpenChildForm(new Form2(), sender)));
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Invoke(new Action(() => OpenChildForm(new Form3(), sender)));
            });
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Invoke(new Action(() => OpenChildForm(new Form4(), sender)));
            });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Builder.BUILDER();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Flora
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                OpenFileDialog lex = new OpenFileDialog();
                lex.InitialDirectory = @"C:\";
                lex.Title = "Select ico to add";
                lex.DefaultExt = ".ico";
                lex.Filter = "ICO Files (*.ico)|*.ico";
                lex.CheckFileExists = true;
                lex.CheckPathExists = true;
                lex.ShowDialog();

                Settings1.Default.ico = lex.FileName;
                Settings1.Default.Save();
                textBox1.Text = Settings1.Default.ico;
                

                try
                {
                    pictureBox1.Load(Settings1.Default.ico);
                }
                catch
                {

                }


            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            //Loads the saved ICO path that the user has into TextBox
            textBox1.Text = Settings1.Default.ico;
            //the Used Ico that determines the compile type for with ICO or without.
            rjToggleButton1.Checked = Settings1.Default.USEICO;
            try
            {
                pictureBox1.Load(Settings1.Default.ico);
            }
            catch
            {

            }
        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            //saves the icon toggle option.
            if (rjToggleButton1.Checked)
            {
                Settings1.Default.USEICO = true;
            } 
            else
            Settings1.Default.USEICO = false;
            
        }
    }
}

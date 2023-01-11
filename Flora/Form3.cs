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

namespace Flora
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //Opens File Dialog for Exe Selection (32bit atm)
                OpenFileDialog lex = new OpenFileDialog();
                lex.InitialDirectory = @"C:\";
                lex.Title = "Select .exe to bind";
                lex.DefaultExt = ".exe";
                lex.Filter = "EXE Files (*.exe)|*.exe";
                lex.CheckFileExists = true;
                lex.CheckPathExists = true;
                lex.ShowDialog();

                textBox1.Text = lex.FileName;
                Settings1.Default.EXEdata = textBox1.Text;
                Settings1.Default.Save();
                
                
                
                
            }
            catch
            {

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Loads paths from settings aka autosave
            textBox1.Text = Settings1.Default.EXEdata;
            textBox2.Text = Settings1.Default.Timbox;
            

            
            

        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //saves the path and bin data into settings file.
            Settings1.Default.Timbox = textBox2.Text;
            Settings1.Default.Save();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_echo_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NamedPipeClientStream pipe;
        private void button1_Click(object sender, EventArgs e)
        {
            pipe = new NamedPipeClientStream("myPipe");
            pipe.Connect();            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter wr = new StreamWriter(pipe);
            StreamReader rd = new StreamReader(pipe);
            wr.AutoFlush = true;
            wr.WriteLine(textBox1.Text);
            textBox1.Text = "";
            string str = rd.ReadLine();
            textBox2.Text += str;            
        }
    }
}

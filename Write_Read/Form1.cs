using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Write_Read
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            FileInfo info;
            StreamReader streamReader;
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                info = new FileInfo(openFile.FileName);
                streamReader = info.OpenText();
                richTextBox1.Text = streamReader.ReadToEnd();
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter writer;
            FileInfo info;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "TEXT|*.txt|JSON|*.json|HTML|*.html|CSS|*.css|Javascript|*.js";
            if (save.ShowDialog() == DialogResult.OK)
            {
                info = new FileInfo(save.FileName);
                writer = info.CreateText();
                writer.Write(richTextBox1.Text);
                writer.Close();
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringReader reader = new StringReader(richTextBox1.Text);
            PrintDocument document = new PrintDocument();
            PrintDialog print = new PrintDialog();
            print.Document = document;
            if (print.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }
    }
}

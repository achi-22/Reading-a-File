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

namespace Reading_a_File
{
    public partial class FrmStudentRecord : Form
    {
        public FrmStudentRecord()
        {
            InitializeComponent();
        }

        public void DisplayToList()
        {
            string path;

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            using (StreamReader streamReader = File.OpenText(path))
            {
                string _getText = "";
                while ((_getText = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(_getText);
                    listView1.Items.Add(_getText);
                }
            }
        }
        private void FrmStudentRecord_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegistration frmRegistration = new FrmRegistration();
            frmRegistration.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            MessageBox.Show("Successfully Uploaded!", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

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
    public partial class FrmFileName : Form
    {
        public static string SetFileName;
        public FrmFileName()
        {
            InitializeComponent();
        }

        private void FrmFileName_Load(object sender, EventArgs e)
        { }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string fileNameInput = txtInput.Text.Trim();
            SetFileName = fileNameInput.EndsWith(".txt") ? fileNameInput : fileNameInput + ".txt";

            string projectRoot = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            string folderPath = Path.Combine(projectRoot, "Files");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, SetFileName);

            MessageBox.Show($"File created successfully in:\n{filePath}");


            FrmStudentRecord frmStudentRecord = new FrmStudentRecord();
            frmStudentRecord.Show();
            this.Hide();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        { }
    }
}

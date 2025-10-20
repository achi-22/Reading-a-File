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
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            cbProgram.Items.AddRange(new string[]
            {
                "BS Computer Science",
                "BS Information Technology",
                "BS Information Systems",
                "BS Software Engineering",
                "BS Data Science",
                "BS Civil Engineering",
                "BS Electrical Engineering",
                "BS Mechanical Engineering",
                "BS Architecture",
                "BS Accountancy",
                "BS Business Administration",
                "BS Marketing Management",
                "BS Psychology",
                "BS Nursing",
                "BS Medical Technology",
                "BS Pharmacy",
                "BS Biology",
                "BS Mathematics",
                "BA Communication",
                "BA Political Science",
                "BA Economics",
                "BA English Language Studies",
                "Bachelor of Elementary Education",
                "Bachelor of Secondary Education"
            });

            if (cbProgram.Items.Count > 0)
                cbProgram.SelectedIndex = 0;

            cbGender.Items.AddRange(new string[]
             {
                "Male",
                "Famale"
             });

            if (cbGender.Items.Count > 0)
                cbGender.SelectedIndex = 0;
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        { }

        private void Register_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text;
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string middleInitial = txtMiddleName.Text;
            string program = cbProgram.Text;
            string gender = cbGender.Text;
            string age = txtAge.Text;
            string birthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");
            string contactNo = txtContactNo.Text;

            string fullName = $"{lastName}, {firstName}, {middleInitial}.";

            string[] lines = {
            $"Student No.: {studentNo}",
            $"Full Name: {fullName}",
            $"Program: {program}",
            $"Gender: {gender}",
            $"Age: {age}",
            $"Birthday: {birthday}",
            $"Contact No.: {contactNo}"
    };

            try
            {

                string projectRoot = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string folderPath = Path.Combine(projectRoot, "Files");


                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, FrmFileName.SetFileName);


                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }

                MessageBox.Show("Registration saved successfully to:\n" + filePath,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving registration: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void Records_Click(object sender, EventArgs e)
        {
            FrmStudentRecord frmStudentRecord = new FrmStudentRecord();
            frmStudentRecord.Show();
            this.Hide();
        }
    }
}

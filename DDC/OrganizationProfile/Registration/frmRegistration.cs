using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Registration
{
    public partial class frmRegistration: Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < ListOfProgram.Length; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            string[] ListOfGender = new string[]
            {
                "Male",
                "Female"
            };
            for (int i = 0; i < ListOfGender.Length; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }
        }
        public long StudentNumber(string studNum)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(studNum) && Regex.IsMatch(studNum, @"^[0-9]+$"))
                {
                    _StudentNo = long.Parse(studNum);
                }
                else
                {
                    throw new ArgumentNullException("Student Number is invalid or empty.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid format for Student Number.\n" + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Number is too large for Student Number.\n" + ex.Message);
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Contact) && Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new FormatException("Contact number must be 10–11 digits.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid Contact Number.\n" + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Contact Number too large.\n" + ex.Message);
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z ]+$") &&
                    Regex.IsMatch(FirstName, @"^[a-zA-Z ]+$") &&
                    Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = $"{LastName}, {FirstName}, {MiddleInitial}";
                }
                else
                {
                    throw new FormatException("Full name must only contain letters.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid Full Name.\n" + ex.Message);
            }
            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(age) && Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
                else
                {
                    throw new FormatException("Age must be a number between 0–999.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid Age.\n" + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Age is too large.\n" + ex.Message);
            }
            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred.\n" + ex.Message);
            }
        }
    }
}

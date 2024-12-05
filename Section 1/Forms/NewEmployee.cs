using System;
using System.Windows.Forms;
using Section1.Code;

namespace Section1.Forms
{
    public partial class NewEmployee : Form
    {
        public NewEmployee()
        {
            InitializeComponent();
            InitializeRoleComboBox();
            InitializeDepartmentComboBox();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            txtBoxName.Focus();
            txtBoxName.Select();
        }

        private void InitializeRoleComboBox()
        {
            comboBoxRole.DataSource = Enum.GetValues(typeof(Role));
        }

        private void InitializeDepartmentComboBox()
        {
            comboBoxDepartment.DataSource = Company.GetDepartmentsNames();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out string name, out int age, out string email, out string phone, out Role role, out int departmentID))
            {
                return;
            }

            var newEmployee = new Employee(name, age, email, phone, role, departmentID, string.Empty);
            Company.AddEmployee(newEmployee);
            MessageBox.Show("Employee created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private bool ValidateInputs(out string name, out int age, out string email, out string phone, out Role role, out int departmentID)
        {
            name = txtBoxName.Text.Trim();
            email = txtBoxEmail.Text.Trim();
            phone = txtBoxPhone.Text.Trim();
            age = 0;
            role = default;
            departmentID = -1;

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowError("Name cannot be empty.");
                return false;
            }

            if (!int.TryParse(txtBoxAge.Text, out age) || age <= 0)
            {
                ShowError("Please enter a valid age.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                ShowError("Please enter a valid email address.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(phone) || phone.Length < 10)
            {
                ShowError("Please enter a valid phone number.");
                return false;
            }

            if (!Enum.TryParse(comboBoxRole.SelectedItem?.ToString(), true, out role))
            {
                ShowError("Please select a valid role.");
                return false;
            }

            departmentID = comboBoxDepartment.SelectedIndex;
            if (departmentID < 0)
            {
                ShowError("Please select a valid department.");
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
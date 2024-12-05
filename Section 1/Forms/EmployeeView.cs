using System;
using System.Windows.Forms;
using Section1.Code;

namespace Section1.Forms
{
    public partial class EmployeeView : Form
    {
        private readonly Employee _currentEmployee;
        private readonly bool _isInSubDepartment;

        public EmployeeView(int employeeID, bool isInSubDepartment)
        {
            InitializeComponent();

            _currentEmployee = Company.GetEmployee(employeeID) ?? throw new ArgumentException("Invalid employee ID.");
            _isInSubDepartment = isInSubDepartment;

            InitializeRoleComboBox();
            InitializeDepartmentComboBox();
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {
            LoadEmployeeDetails();
        }

        private void LoadEmployeeDetails()
        {
            txtBoxID.Text = _currentEmployee.GetID().ToString();
            txtBoxName.Text = _currentEmployee.GetName();
            txtBoxAge.Text = _currentEmployee.GetAge().ToString();
            txtBoxEmail.Text = _currentEmployee.GetEmail();
            txtBoxPhone.Text = _currentEmployee.GetPhone();
            comboBoxRole.SelectedItem = _currentEmployee.GetRole();
            comboBoxDepartment.SelectedItem = Company.GetDepartmentNameByID(_currentEmployee.GetDepartmentID());
        }

        private void InitializeRoleComboBox()
        {
            comboBoxRole.DataSource = Enum.GetValues(typeof(Role));
        }

        private void InitializeDepartmentComboBox()
        {
            comboBoxDepartment.DataSource = Company.GetDepartments();
            comboBoxDepartment.DisplayMember = "Name";
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out string name, out int age, out string email, out string phone, out Role role, out Department department))
            {
                return;
            }

            string subDepartmentID = _currentEmployee.GetSubDepartmentID();
            bool isInSubDepartment = !string.IsNullOrEmpty(subDepartmentID);

            _currentEmployee.ChangeParameters(name, age, email, phone, role, department.GetID(), isInSubDepartment, subDepartmentID);
            Close();
        }

        private bool ValidateInputs(out string name, out int age, out string email, out string phone, out Role role, out Department department)
        {
            name = txtBoxName.Text.Trim();
            email = txtBoxEmail.Text.Trim();
            phone = txtBoxPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || !int.TryParse(txtBoxAge.Text, out age) || age <= 0)
            {
                MessageBox.Show("Please enter a valid name and age.");
                ResetOutputs(out name, out age, out email, out phone, out role, out department);
                return false;
            }

            if (!Enum.TryParse(comboBoxRole.SelectedItem.ToString(), true, out role))
            {
                MessageBox.Show("Please select a valid role.");
                ResetOutputs(out name, out age, out email, out phone, out role, out department);
                return false;
            }

            department = comboBoxDepartment.SelectedItem as Department;
            if (department == null)
            {
                MessageBox.Show("Please select a valid department.");
                ResetOutputs(out name, out age, out email, out phone, out role, out department);
                return false;
            }

            return true;
        }

        private void ResetOutputs(out string name, out int age, out string email, out string phone, out Role role, out Department department)
        {
            name = email = phone = string.Empty;
            age = 0;
            role = default;
            department = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "Are you sure you want to delete this employee?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                Company.RemoveEmployee(_currentEmployee.GetID(), _currentEmployee.GetDepartmentID());
                Close();
            }
        }

        private void btnMoveToSubDepartment_Click(object sender, EventArgs e)
        {
            var moveForm = new MoveToSubDepartment(_currentEmployee.GetDepartmentID(), _currentEmployee.GetID());
            moveForm.ShowDialog();
        }
    }
}
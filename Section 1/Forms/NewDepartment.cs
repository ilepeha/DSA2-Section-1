using System;
using System.Windows.Forms;
using Section1.Code;

namespace Section1.Forms
{
    public partial class NewDepartment : Form
    {
        private readonly bool _isSubDepartment;
        private readonly int _departmentID;

        public NewDepartment(bool isSubDepartment, int departmentID)
        {
            InitializeComponent();
            _isSubDepartment = isSubDepartment;
            _departmentID = departmentID;
        }

        private void NewDepartment_Load(object sender, EventArgs e)
        {
            txtBoxName.Focus();
            txtBoxName.Select();

            comboBoxManager.DataSource = Company.GetManagers();
            comboBoxManager.DisplayMember = "Name";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxName.Text))
            {
                MessageBox.Show("The department name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isSubDepartment)
            {
                CreateSubDepartment();
            }
            else
            {
                CreateDepartment();
            }
        }

        private void CreateSubDepartment()
        {
            string name = txtBoxName.Text.Trim();
            var newSubDepartment = new SubDepartment(name, 0, _departmentID);

            Company.AddSubDepartment(newSubDepartment);
            MessageBox.Show("Sub-department created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void CreateDepartment()
        {
            if (comboBoxManager.SelectedItem is not Employee manager)
            {
                MessageBox.Show("Please select a valid manager for the department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtBoxName.Text.Trim();
            var newDepartment = new Department(name, manager.GetID());

            Company.CreateDepartment(newDepartment);
            MessageBox.Show("Department created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
 using System;
using System.Windows.Forms;
using Section1.Code;

namespace Section1.Forms
{
    public partial class MoveToSubDepartment : Form
    {
        private readonly int _headDepartmentID;
        private readonly int _employeeID;

        public MoveToSubDepartment(int headDepartmentID, int employeeID)
        {
            InitializeComponent();

            _headDepartmentID = headDepartmentID;
            _employeeID = employeeID;

            InitializeSubDepartmentComboBox();
        }

        private void InitializeSubDepartmentComboBox()
        {
            var subDepartments = Company.GetSubDepartments(_headDepartmentID);
            if (subDepartments == null || !subDepartments.Any())
            {
                MessageBox.Show("No sub-departments available for this department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            comboBoxSubDepartments.DataSource = subDepartments;
            comboBoxSubDepartments.DisplayMember = "Name";
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (comboBoxSubDepartments.SelectedItem is SubDepartment selectedSubDepartment)
            {
                Company.MoveEmployeeToSubDepartment(_employeeID, selectedSubDepartment.GetID(), true);
                MessageBox.Show("Employee moved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Please select a valid sub-department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
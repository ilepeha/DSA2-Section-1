using Section1.Code;
using System;
using System.Windows.Forms;

namespace Section1.Forms
{
    public partial class Employees : Form
    {
        private readonly BindingSource _employeeSource;

        public Employees()
        {
            InitializeComponent();
            _employeeSource = new BindingSource(Company.GetEmployees(), null);
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewEmployees.AutoGenerateColumns = true;
            dataGridViewEmployees.DataSource = _employeeSource;

            ConfigureColumn("ID", "ID", 50);
            ConfigureColumn("Name", "Name", 150);
            ConfigureColumn("Age", "Age", 50);
            ConfigureColumn("Role", "Role", 120);
            ConfigureColumn("Department", "Department", 100);
        }

        private void ConfigureColumn(string propertyName, string headerText, float fillWeight)
        {
            var column = dataGridViewEmployees.Columns[propertyName];
            if (column != null)
            {
                column.HeaderText = headerText;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.FillWeight = fillWeight;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ShowNewEmployeeForm();
        }

        private void ShowNewEmployeeForm()
        {
            var newEmployeeForm = new NewEmployee();
            newEmployeeForm.ShowDialog();
            RefreshEmployeeData();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedEmployeeID(out int employeeID)) return;

            var employeeViewForm = new EmployeeView(employeeID, false);
            employeeViewForm.ShowDialog();
            RefreshEmployeeData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetSelectedEmployeeID(out int employeeID)) return;

            var employee = Company.GetEmployee(employeeID);
            if (employee == null)
            {
                MessageBox.Show("The selected employee does not exist.");
                return;
            }

            Company.RemoveEmployee(employeeID, employee.GetDepartmentID());
            RefreshEmployeeData();
        }

        private void dataGridViewEmployees_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!TryGetSelectedEmployeeID(out int employeeID)) return;

            var employeeViewForm = new EmployeeView(employeeID, false);
            employeeViewForm.ShowDialog();
            RefreshEmployeeData();
        }

        private bool TryGetSelectedEmployeeID(out int employeeID)
        {
            employeeID = 0;
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee.");
                return false;
            }

            if (int.TryParse(dataGridViewEmployees.SelectedRows[0].Cells["ID"].Value?.ToString(), out employeeID))
            {
                return true;
            }

            MessageBox.Show("Invalid employee selection.");
            return false;
        }

        private void RefreshEmployeeData()
        {
            Globals.form.RefreshEmployees();
        }
    }
}
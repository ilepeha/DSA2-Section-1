using System;
using System.Linq;
using System.Windows.Forms;
using Section1.Code;

namespace Section1.Forms
{
    public partial class Departments : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource(Company.GetDepartments(), null);

        public Departments()
        {
            InitializeComponent();
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            ConfigureDataGrid();
        }

        private void ConfigureDataGrid()
        {
            dataGridViewDepartments.AutoGenerateColumns = true;
            dataGridViewDepartments.DataSource = _bindingSource;

            ConfigureColumn("ID", "ID", 50);
            ConfigureColumn("name", "Name", 150);
            ConfigureColumn("manager", "Manager", 100);
            ConfigureColumn("numOfSubDepartments", "SubDepartments", 120);
            ConfigureColumn("numOfEmployees", "Employees", 100);
        }

        private void ConfigureColumn(string propertyName, string headerText, float fillWeight)
        {
            var column = dataGridViewDepartments.Columns[propertyName];
            if (column != null)
            {
                column.HeaderText = headerText;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.FillWeight = fillWeight;
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            int? departmentID = GetSelectedDepartmentID();
            if (departmentID.HasValue)
            {
                ShowDepartmentDetails(departmentID.Value);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var newDepartmentForm = new NewDepartment(false, 0);
            newDepartmentForm.ShowDialog();
            RefreshDepartments();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? departmentID = GetSelectedDepartmentID();
            if (!departmentID.HasValue) return;

            var department = Company.GetDepartment(departmentID.Value);

            if (department.numOfEmployees > 0)
            {
                MessageBox.Show("Cannot delete this department! There are employees inside!");
                return;
            }

            if (department.numOfSubDepartments > 0)
            {
                MessageBox.Show("Cannot delete this department! There are sub-departments inside!");
                return;
            }

            Company.DestroyDepartment(department.ID);
            RefreshDepartments();
        }

        private void dataGridViewDepartments_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int? departmentID = GetSelectedDepartmentID();
            if (departmentID.HasValue)
            {
                ShowDepartmentDetails(departmentID.Value);
            }
        }

        private int? GetSelectedDepartmentID()
        {
            if (dataGridViewDepartments.SelectedRows.Count == 0) return null;

            if (int.TryParse(dataGridViewDepartments.SelectedRows[0].Cells["ID"].Value?.ToString(), out int departmentID))
            {
                return departmentID;
            }

            MessageBox.Show("Invalid department selection!");
            return null;
        }

        private void ShowDepartmentDetails(int departmentID)
        {
            var departmentViewForm = new DepartmentView(departmentID, false, string.Empty);
            departmentViewForm.ShowDialog();
            RefreshDepartments();
        }

        private void RefreshDepartments()
        {
            Globals.form.RefreshDepartments();
        }
    }
}
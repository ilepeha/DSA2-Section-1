using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Section1.Code;

namespace Section1.Forms
{
    public partial class DepartmentView : Form
    {
        private Department currentDepartment;
        private SubDepartment currentSubDepartment;
        private BindingSource subDepartmentSource;
        private BindingSource employeeSource;
        private readonly bool isSubDepartmentView;

        public DepartmentView(int departmentID, bool isSubDepartment, string subDepartmentID)
        {
            InitializeComponent();
            isSubDepartmentView = isSubDepartment;

            if (isSubDepartment)
            {
                currentSubDepartment = Company.GetSubDepartment(subDepartmentID);
                currentDepartment = Company.GetDepartment(departmentID);
            }
            else
            {
                currentDepartment = Company.GetDepartment(departmentID);
            }
        }

        private void DepartmentView_Load(object sender, EventArgs e)
        {
            if (isSubDepartmentView)
            {
                InitializeSubDepartmentView();
            }
            else
            {
                InitializeDepartmentView();
            }
        }

        private void InitializeSubDepartmentView()
        {
            txtBoxID.Text = currentSubDepartment.ID;
            txtBoxName.Text = currentSubDepartment.Name;

            PopulateComboBox(comboBoxManagers, Company.GetManagers(), "Name", currentSubDepartment.Manager);
            PopulateComboBox(comboBoxHeadDepartment, Company.GetDepartments(), "Name", Company.GetDepartment(currentSubDepartment.GetHeadDepartment()));

            LoadEmployees(currentSubDepartment.GetEmployeeDataSource());

            dataGridViewSubDepartments.Visible = false;
            btnAddSubDepartment.Visible = false;
        }

        private void InitializeDepartmentView()
        {
            txtBoxID.Text = currentDepartment.ID.ToString();
            txtBoxName.Text = currentDepartment.Name;

            PopulateComboBox(comboBoxManagers, Company.GetManagers(), "Name", currentDepartment.Manager);

            LoadSubDepartments();
            LoadEmployees(currentDepartment.GetEmployeeDataSource());

            comboBoxHeadDepartment.Visible = false;
            lblHeadDepartment.Visible = false;
        }

        private void PopulateComboBox(ComboBox comboBox, IEnumerable<object> dataSource, string displayMember, object selectedItem)
        {
            comboBox.DataSource = dataSource;
            comboBox.DisplayMember = displayMember;
            comboBox.SelectedItem = selectedItem;
        }

        private void LoadEmployees(BindingList<Employee> source)
        {
            employeeSource = new BindingSource(source, null);
            ConfigureDataGridView(dataGridViewEmployees, employeeSource, new List<(string, string, int)>
            {
                ("ID", "ID", 50),
                ("Name", "Name", 150),
                ("Age", "Age", 50),
                ("Role", "Role", 120),
                ("Department", "Department", 100)
            });
        }

        private void LoadSubDepartments()
        {
            subDepartmentSource = new BindingSource(currentDepartment.GetSubDepartments(), null);
            ConfigureDataGridView(dataGridViewSubDepartments, subDepartmentSource, new List<(string, string, int)>
            {
                ("ID", "ID", 50),
                ("Name", "Name", 150),
                ("Manager", "Manager", 100),
                ("numOfEmployees", "Employees", 100)
            });
            dataGridViewSubDepartments.Columns["numOfSubDepartments"].Visible = false;
        }

        private void ConfigureDataGridView(DataGridView dataGridView, BindingSource source, List<(string PropertyName, string HeaderText, int FillWeight)> columns)
        {
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = source;

            foreach (var column in columns)
            {
                var gridCol = dataGridView.Columns[column.PropertyName];
                if (gridCol != null)
                {
                    gridCol.HeaderText = column.HeaderText;
                    gridCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gridCol.FillWeight = column.FillWeight;
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            var newName = txtBoxName.Text;

            if (isSubDepartmentView)
            {
                var newManager = comboBoxManagers.SelectedIndex;
                var newHeadDepartment = comboBoxHeadDepartment.SelectedItem as Department;
                if (newHeadDepartment != null)
                {
                    Company.UpdateSubDepartment(newName, newManager, currentSubDepartment.ID,
                        currentSubDepartment.GetHeadDepartment(), newHeadDepartment.ID);
                }
            }
            else
            {
                var newManager = comboBoxManagers.SelectedItem as Employee;
                currentDepartment.ChangeParams(newName, newManager?.ID ?? currentDepartment.Manager);
            }

            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isSubDepartmentView)
            {
                DeleteSubDepartment();
            }
            else
            {
                DeleteDepartment();
            }
        }

        private void DeleteSubDepartment()
        {
            if (currentSubDepartment.GetNumberOfEmployees() > 0)
            {
                MessageBox.Show("You cannot delete this sub-department! There are employees inside!");
                return;
            }

            Company.RemoveSubDepartment(currentSubDepartment.ID, currentDepartment.ID);
            Close();
        }

        private void DeleteDepartment()
        {
            if (currentDepartment.numOfEmployees > 0)
            {
                MessageBox.Show("You cannot delete this department! There are employees inside!");
                return;
            }

            if (currentDepartment.numOfSubDepartments > 0)
            {
                MessageBox.Show("You cannot delete this department! There are sub-departments inside!");
                return;
            }

            Company.DestroyDepartment(currentDepartment.ID);
            Close();
        }

        private void dataGridViewEmployees_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReloadEmployeeData(e.RowIndex);
        }

        private void ReloadEmployeeData(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridViewEmployees.RowCount) return;

            var employeeID = int.Parse(dataGridViewEmployees.Rows[rowIndex].Cells["ID"].Value.ToString());
            var employeeViewForm = new EmployeeView(employeeID, isSubDepartmentView);
            employeeViewForm.ShowDialog();

            RefreshEmployeeData();
        }

        private void RefreshEmployeeData()
        {
            if (isSubDepartmentView)
            {
                LoadEmployees(currentSubDepartment.GetEmployeeDataSource());
            }
            else
            {
                LoadEmployees(currentDepartment.GetEmployeeDataSource());
                LoadSubDepartments();
            }
        }

        private void dataGridViewSubDepartments_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewSubDepartments.RowCount) return;

            var subDepartmentID = dataGridViewSubDepartments.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            var subDepartmentViewForm = new DepartmentView(currentDepartment.ID, true, subDepartmentID);
            subDepartmentViewForm.ShowDialog();

            LoadSubDepartments();
        }

        private void btnAddSubDepartment_Click(object sender, EventArgs e)
        {
            var newSubDepartmentForm = new NewDepartment(true, currentDepartment.ID)
            {
                Text = "Create a new subdepartment!"
            };
            newSubDepartmentForm.ShowDialog();

            LoadSubDepartments();
        }

        private void btnDeleteSubDepartment_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubDepartments.SelectedRows.Count == 0) return;

            var subDepartmentID = dataGridViewSubDepartments.SelectedRows[0].Cells["ID"].Value.ToString();
            var subDepartment = Company.GetSubDepartment(subDepartmentID);

            if (subDepartment.GetNumberOfEmployees() > 0)
            {
                MessageBox.Show("You cannot delete this sub-department! There are employees inside!");
                return;
            }

            Company.RemoveSubDepartment(subDepartmentID, subDepartment.GetHeadDepartment());
            Globals.form.RefreshEmployees();
        }
    }
}
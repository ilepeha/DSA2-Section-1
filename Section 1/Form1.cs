using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Section1.Forms;
using Section1.Code;

namespace Section1
{
    public class Globals
    {
        public static BaseForm form;
    }

    public partial class BaseForm : Form
    {
        private static Form currentView;
        public BaseForm()
        {
            InitializeComponent();
        }
        private void loadForm(object Form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            BaseForm.currentView = f;
            f.Show();
        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
            Company.LoadData();
            Globals.form = this;
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            loadForm(new Departments());
        }
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            loadForm(new Employees());
        }
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Remove(BaseForm.currentView);
        }
        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Company.SaveData();
        }
        public void RefreshEmployees()
        {
            mainPanel.Controls.Remove(BaseForm.currentView);
            loadForm(new Employees());
        }
        public void RefreshDepartments()
        {
            mainPanel.Controls.Remove(BaseForm.currentView);
            loadForm(new Departments());
        }
    }
}
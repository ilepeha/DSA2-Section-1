namespace Section1.Forms
{
    partial class DepartmentView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            var dataGridViewCellStyleHeader = new System.Windows.Forms.DataGridViewCellStyle
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                BackColor = System.Drawing.Color.LightGray,
                Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.SystemColors.WindowText,
                SelectionBackColor = System.Drawing.Color.LightGray,
                SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                WrapMode = System.Windows.Forms.DataGridViewTriState.True
            };

            var dataGridViewCellStyleRows = new System.Windows.Forms.DataGridViewCellStyle
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                BackColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Century Gothic", 8.25F),
                ForeColor = System.Drawing.SystemColors.ControlText,
                SelectionBackColor = System.Drawing.SystemColors.Highlight,
                SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                WrapMode = System.Windows.Forms.DataGridViewTriState.False
            };

            this.btnDelete = CreateButton("DELETE", new System.Drawing.Point(430, 7), this.btnDelete_Click);
            this.btnChange = CreateButton("CHANGE", new System.Drawing.Point(430, 43), this.btnChange_Click);
            this.btnAddSubDepartment = CreateButton("ADD SUB-DEPARTMENT", new System.Drawing.Point(430, 79), this.btnAddSubDepartment_Click);
            this.btnDeleteSubDepartment = CreateButton("DELETE SUB-DEPARTMENT", new System.Drawing.Point(430, 115), this.btnDeleteSubDepartment_Click);

            this.lblD = CreateLabel("ID", new System.Drawing.Point(12, 9));
            this.lblName = CreateLabel("NAME", new System.Drawing.Point(12, 43));
            this.lblManager = CreateLabel("MANAGER", new System.Drawing.Point(12, 77));
            this.lblHeadDepartment = CreateLabel("HEAD DEPARTMENT", new System.Drawing.Point(12, 113));

            this.txtBoxID = CreateTextBox(new System.Drawing.Point(274, 9), readOnly: true);
            this.txtBoxName = CreateTextBox(new System.Drawing.Point(274, 43), readOnly: false);

            this.comboBoxManagers = CreateComboBox(new System.Drawing.Point(274, 77));
            this.comboBoxHeadDepartment = CreateComboBox(new System.Drawing.Point(274, 113));

            this.dataGridViewSubDepartments = CreateDataGridView(new System.Drawing.Point(12, 153), new System.Drawing.Size(618, 578), dataGridViewCellStyleHeader, dataGridViewCellStyleRows);
            this.dataGridViewSubDepartments.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSubDepartments_RowHeaderMouseClick);

            this.dataGridViewEmployees = CreateDataGridView(new System.Drawing.Point(636, 9), new System.Drawing.Size(600, 722), dataGridViewCellStyleHeader, dataGridViewCellStyleRows);
            this.dataGridViewEmployees.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEmployees_RowHeaderMouseClick);

            // Form properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1248, 743);
            this.Controls.Add(this.btnDeleteSubDepartment);
            this.Controls.Add(this.comboBoxManagers);
            this.Controls.Add(this.comboBoxHeadDepartment);
            this.Controls.Add(this.lblHeadDepartment);
            this.Controls.Add(this.btnAddSubDepartment);
            this.Controls.Add(this.dataGridViewEmployees);
            this.Controls.Add(this.dataGridViewSubDepartments);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnDelete);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DepartmentView";
            this.Text = "DepartmentView";
            this.Load += new System.EventHandler(this.DepartmentView_Load);
        }

        private System.Windows.Forms.Button CreateButton(string text, System.Drawing.Point location, EventHandler onClick)
        {
            return new System.Windows.Forms.Button
            {
                Text = text,
                BackColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ForeColor = System.Drawing.Color.Black,
                Location = location,
                Size = new System.Drawing.Size(200, 30),
                UseVisualStyleBackColor = false,
                Click += onClick
            };
        }

        private System.Windows.Forms.Label CreateLabel(string text, System.Drawing.Point location)
        {
            return new System.Windows.Forms.Label
            {
                Text = text,
                Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold),
                Location = location,
                AutoSize = true
            };
        }

        private System.Windows.Forms.TextBox CreateTextBox(System.Drawing.Point location, bool readOnly)
        {
            return new System.Windows.Forms.TextBox
            {
                Location = location,
                Size = new System.Drawing.Size(143, 28),
                Font = new System.Drawing.Font("Century Gothic", 10.2F),
                BackColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                ReadOnly = readOnly,
                ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            };
        }

        private System.Windows.Forms.ComboBox CreateComboBox(System.Drawing.Point location)
        {
            return new System.Windows.Forms.ComboBox
            {
                Location = location,
                Size = new System.Drawing.Size(143, 29),
                Font = new System.Drawing.Font("Century Gothic", 10.2F),
                FormattingEnabled = true
            };
        }

        private System.Windows.Forms.DataGridView CreateDataGridView(System.Drawing.Point location, System.Drawing.Size size, System.Windows.Forms.DataGridViewCellStyle headerStyle, System.Windows.Forms.DataGridViewCellStyle rowStyle)
        {
            return new System.Windows.Forms.DataGridView
            {
                Location = location,
                Size = size,
                BackgroundColor = System.Drawing.Color.LightGray,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                AutoGenerateColumns = false,
                ColumnHeadersDefaultCellStyle = headerStyle,
                DefaultCellStyle = rowStyle,
                EnableHeadersVisualStyles = false,
                RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing,
                SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            };
        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.DataGridView dataGridViewSubDepartments;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.Button btnAddSubDepartment;
        private System.Windows.Forms.Label lblHeadDepartment;
        private System.Windows.Forms.ComboBox comboBoxHeadDepartment;
        private System.Windows.Forms.ComboBox comboBoxManagers;
        private System.Windows.Forms.Button btnDeleteSubDepartment;
    }
}
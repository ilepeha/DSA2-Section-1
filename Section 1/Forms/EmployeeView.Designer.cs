namespace Section1.Forms
{
    partial class EmployeeView
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
            this.txtBoxID = CreateTextBox(new System.Drawing.Point(260, 15), readOnly: true);
            this.txtBoxName = CreateTextBox(new System.Drawing.Point(260, 53));
            this.txtBoxAge = CreateTextBox(new System.Drawing.Point(260, 87));
            this.txtBoxEmail = CreateTextBox(new System.Drawing.Point(260, 121));
            this.txtBoxPhone = CreateTextBox(new System.Drawing.Point(260, 155));

            this.lblD = CreateLabel("ID", new System.Drawing.Point(27, 9));
            this.lblName = CreateLabel("NAME", new System.Drawing.Point(26, 47));
            this.lblAge = CreateLabel("AGE", new System.Drawing.Point(27, 81));
            this.lblEmail = CreateLabel("EMAIL", new System.Drawing.Point(27, 115));
            this.lblPhone = CreateLabel("PHONE", new System.Drawing.Point(27, 149));
            this.lblRole = CreateLabel("ROLE", new System.Drawing.Point(27, 183));
            this.lblDepartment = CreateLabel("DEPARTMENT", new System.Drawing.Point(27, 220));

            this.comboBoxRole = CreateComboBox(new System.Drawing.Point(260, 188));
            this.comboBoxDepartment = CreateComboBox(new System.Drawing.Point(260, 225));

            this.btnChange = CreateButton("CHANGE", new System.Drawing.Point(260, 271), new System.Drawing.Size(143, 29), this.btnChange_Click);
            this.btnDelete = CreateButton("DELETE", new System.Drawing.Point(111, 271), new System.Drawing.Size(143, 29), this.btnDelete_Click);
            this.btnMoveToSubDepartment = CreateButton("MOVE TO SUBDEPARTMENT", new System.Drawing.Point(111, 316), new System.Drawing.Size(292, 29), this.btnMoveToSubDepartment_Click);

            // Form properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 357);
            this.Controls.Add(this.btnMoveToSubDepartment);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtBoxPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtBoxEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtBoxAge);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblD);
            this.Name = "EmployeeView";
            this.Text = "EmployeeView";
            this.Load += new System.EventHandler(this.EmployeeView_Load);
        }

        private System.Windows.Forms.TextBox CreateTextBox(System.Drawing.Point location, bool readOnly = false)
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

        private System.Windows.Forms.Label CreateLabel(string text, System.Drawing.Point location)
        {
            return new System.Windows.Forms.Label
            {
                Text = text,
                Location = location,
                Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                TextAlign = System.Drawing.ContentAlignment.TopCenter
            };
        }

        private System.Windows.Forms.ComboBox CreateComboBox(System.Drawing.Point location)
        {
            return new System.Windows.Forms.ComboBox
            {
                Location = location,
                Size = new System.Drawing.Size(143, 29),
                Font = new System.Drawing.Font("Century Gothic", 10.2F),
                AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems,
                FormattingEnabled = true
            };
        }

        private System.Windows.Forms.Button CreateButton(string text, System.Drawing.Point location, System.Drawing.Size size, EventHandler onClick)
        {
            return new System.Windows.Forms.Button
            {
                Text = text,
                Location = location,
                Size = size,
                Font = new System.Drawing.Font("Century Gothic", 7.8F),
                BackColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ForeColor = System.Drawing.Color.Black,
                UseVisualStyleBackColor = false,
                Click += onClick
            };
        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxAge;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMoveToSubDepartment;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
    }
}
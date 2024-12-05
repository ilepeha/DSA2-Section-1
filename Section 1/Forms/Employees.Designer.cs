namespace Section1.Forms
{
    partial class Employees
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
                BackColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.SystemColors.WindowText,
                SelectionBackColor = System.Drawing.Color.White,
                SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                WrapMode = System.Windows.Forms.DataGridViewTriState.True
            };

            var dataGridViewCellStyleRows = new System.Windows.Forms.DataGridViewCellStyle
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter,
                BackColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Century Gothic", 11F),
                ForeColor = System.Drawing.SystemColors.ControlText,
                SelectionBackColor = System.Drawing.SystemColors.Highlight,
                SelectionForeColor = System.Drawing.SystemColors.HighlightText,
                WrapMode = System.Windows.Forms.DataGridViewTriState.False
            };

            this.btnNew = CreateButton("CREATE NEW EMPLOYEE", new System.Drawing.Point(19, 671), new System.Drawing.Size(599, 33), this.btnNew_Click);
            this.btnDetails = CreateButton("DETAILS", new System.Drawing.Point(804, 671), new System.Drawing.Size(174, 33), this.btnDetails_Click);
            this.btnDelete = CreateButton("DELETE", new System.Drawing.Point(624, 671), new System.Drawing.Size(174, 33), this.btnDelete_Click);

            this.dataGridViewEmployees = CreateDataGridView(new System.Drawing.Point(19, 12), new System.Drawing.Size(959, 653), dataGridViewCellStyleHeader, dataGridViewCellStyleRows);
            this.dataGridViewEmployees.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewEmployees_RowHeaderMouseClick);

            // Form properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 716);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.dataGridViewEmployees);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Employees";
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.Employees_Load);
        }

        private System.Windows.Forms.Button CreateButton(string text, System.Drawing.Point location, System.Drawing.Size size, EventHandler onClick)
        {
            return new System.Windows.Forms.Button
            {
                Text = text,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black,
                Location = location,
                Size = size,
                UseVisualStyleBackColor = true,
                Click += onClick
            };
        }

        private System.Windows.Forms.DataGridView CreateDataGridView(System.Drawing.Point location, System.Drawing.Size size,
            System.Windows.Forms.DataGridViewCellStyle headerStyle, System.Windows.Forms.DataGridViewCellStyle rowStyle)
        {
            return new System.Windows.Forms.DataGridView
            {
                Location = location,
                Size = size,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                BackgroundColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None,
                ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None,
                ColumnHeadersDefaultCellStyle = headerStyle,
                DefaultCellStyle = rowStyle,
                EnableHeadersVisualStyles = false,
                GridColor = System.Drawing.Color.LightGray,
                ReadOnly = true,
                RowHeadersWidth = 25,
                RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing,
                SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            };
        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
    }
}
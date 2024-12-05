namespace Section1.Forms
{
    partial class Departments
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
                Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
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

            this.dataGridViewDepartments = new System.Windows.Forms.DataGridView();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).BeginInit();
            this.SuspendLayout();

            // dataGridViewDepartments
            this.dataGridViewDepartments.AllowUserToAddRows = false;
            this.dataGridViewDepartments.AllowUserToDeleteRows = false;
            this.dataGridViewDepartments.AllowUserToResizeColumns = false;
            this.dataGridViewDepartments.AllowUserToResizeRows = false;
            this.dataGridViewDepartments.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDepartments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDepartments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewDepartments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewDepartments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyleHeader;
            this.dataGridViewDepartments.ColumnHeadersHeight = 35;
            this.dataGridViewDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewDepartments.DefaultCellStyle = dataGridViewCellStyleRows;
            this.dataGridViewDepartments.EnableHeadersVisualStyles = false;
            this.dataGridViewDepartments.GridColor = System.Drawing.Color.LightGray;
            this.dataGridViewDepartments.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDepartments.MultiSelect = false;
            this.dataGridViewDepartments.Name = "dataGridViewDepartments";
            this.dataGridViewDepartments.ReadOnly = true;
            this.dataGridViewDepartments.RowHeadersWidth = 25;
            this.dataGridViewDepartments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDepartments.RowTemplate.DividerHeight = 2;
            this.dataGridViewDepartments.RowTemplate.Height = 25;
            this.dataGridViewDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDepartments.Size = new System.Drawing.Size(959, 653);
            this.dataGridViewDepartments.TabIndex = 0;
            this.dataGridViewDepartments.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDepartments_RowHeaderMouseClick);

            // btnDetails
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.ForeColor = System.Drawing.Color.Black;
            this.btnDetails.Location = new System.Drawing.Point(797, 671);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(174, 33);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.Text = "DETAILS";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);

            // btnNew
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.Location = new System.Drawing.Point(12, 671);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(599, 33);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "CREATE NEW DEPARTMENT";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            // btnDelete
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(617, 671);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(174, 33);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Departments
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 716);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.dataGridViewDepartments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Departments";
            this.Text = "Departments";
            this.Load += new System.EventHandler(this.Departments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDepartments;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
    }
}
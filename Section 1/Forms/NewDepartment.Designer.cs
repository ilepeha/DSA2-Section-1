namespace Section1.Forms
{
    partial class NewDepartment
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
            this.txtBoxName = CreateTextBox(new System.Drawing.Point(388, 120));
            this.lblName = CreateLabel("NAME", new System.Drawing.Point(244, 114));
            this.lblManager = CreateLabel("MANAGER", new System.Drawing.Point(244, 148));
            this.comboBoxManager = CreateComboBox(new System.Drawing.Point(388, 157));
            this.btnCreate = CreateButton("CREATE", new System.Drawing.Point(250, 202), new System.Drawing.Size(281, 30), this.btnCreate_Click);

            // Form properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxManager);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblName);
            this.Name = "NewDepartment";
            this.Text = "Create a New Department";
            this.Load += new System.EventHandler(this.NewDepartment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox CreateTextBox(System.Drawing.Point location)
        {
            return new System.Windows.Forms.TextBox
            {
                Location = location,
                Size = new System.Drawing.Size(143, 28),
                Font = new System.Drawing.Font("Century Gothic", 10.2F),
                BackColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                RightToLeft = System.Windows.Forms.RightToLeft.No,
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
                Size = new System.Drawing.Size(143, 24),
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
                Font = new System.Drawing.Font("Century Gothic", 12F),
                BackColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                ForeColor = System.Drawing.Color.Black,
                UseVisualStyleBackColor = false,
                Click += onClick
            };
        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox comboBoxManager;
    }
}
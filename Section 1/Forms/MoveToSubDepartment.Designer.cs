namespace Section1.Forms
{
    partial class MoveToSubDepartment
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
            this.comboBoxSubDepartments = CreateComboBox(new System.Drawing.Point(259, 152), new System.Drawing.Size(254, 35));
            this.btnMove = CreateButton("MOVE", new System.Drawing.Point(259, 207), new System.Drawing.Size(254, 35), this.btnMove_Click);

            // Form properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.comboBoxSubDepartments);
            this.Name = "MoveToSubDepartment";
            this.Text = "Move to Sub-Department";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox CreateComboBox(System.Drawing.Point location, System.Drawing.Size size)
        {
            return new System.Windows.Forms.ComboBox
            {
                Font = new System.Drawing.Font("Century Gothic", 13.8F),
                FormattingEnabled = true,
                Location = location,
                Size = size
            };
        }

        private System.Windows.Forms.Button CreateButton(string text, System.Drawing.Point location, System.Drawing.Size size, EventHandler onClick)
        {
            return new System.Windows.Forms.Button
            {
                Text = text,
                Font = new System.Drawing.Font("Century Gothic", 12F),
                ForeColor = System.Drawing.Color.Black,
                BackColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Location = location,
                Size = size,
                UseVisualStyleBackColor = false,
                Click += onClick
            };
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSubDepartments;
        private System.Windows.Forms.Button btnMove;
    }
}
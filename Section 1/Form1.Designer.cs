namespace Section1
{
    partial class BaseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.sideBarPanel = CreatePanel(System.Drawing.SystemColors.ControlDarkDark, new System.Drawing.Size(200, 716), DockStyle.Left);
            this.mainPanel = CreatePanel(System.Drawing.Color.White, new System.Drawing.Size(996, 716), DockStyle.Fill);

            this.btnEmployees = CreateButton("EMPLOYEES", global::Section1.Properties.Resources.user_24px, new System.Drawing.Point(0, 292), this.btnEmployees_Click);
            this.btnDepartments = CreateButton("DEPARTMENTS", global::Section1.Properties.Resources.report_card_24px, new System.Drawing.Point(0, 245), this.btnDepartments_Click);
            this.btnDashBoard = CreateButton("DASHBOARD", global::Section1.Properties.Resources.monitor_24px, new System.Drawing.Point(0, 198), this.btnDashBoard_Click);

            this.pictureBox1 = new System.Windows.Forms.PictureBox
            {
                Image = global::Section1.Properties.Resources.staff_96px,
                Location = new System.Drawing.Point(31, 12),
                Name = "pictureBox1",
                Size = new System.Drawing.Size(115, 112),
                TabIndex = 1,
                TabStop = false
            };

            this.sideBarPanel.Controls.Add(this.btnEmployees);
            this.sideBarPanel.Controls.Add(this.btnDepartments);
            this.sideBarPanel.Controls.Add(this.btnDashBoard);
            this.sideBarPanel.Controls.Add(this.pictureBox1);

            // Form properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 716);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sideBarPanel);
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel CreatePanel(System.Drawing.Color backColor, System.Drawing.Size size, DockStyle dockStyle)
        {
            return new System.Windows.Forms.Panel
            {
                BackColor = backColor,
                Size = size,
                Dock = dockStyle
            };
        }

        private System.Windows.Forms.Button CreateButton(string text, System.Drawing.Image image, System.Drawing.Point location, EventHandler onClick)
        {
            return new System.Windows.Forms.Button
            {
                Text = text,
                Image = image,
                ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Location = location,
                Size = new System.Drawing.Size(200, 41),
                Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.SystemColors.ControlDark,
                ForeColor = System.Drawing.SystemColors.Info,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                UseVisualStyleBackColor = false,
                Click += onClick
            };
        }

        #endregion

        private System.Windows.Forms.Panel sideBarPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnDepartments;
    }
}
namespace UnivPersonnel.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.Button buttonAddEmployee;
        private System.Windows.Forms.Button buttonEditEmployee;
        private System.Windows.Forms.Button buttonDeleteEmployee;
        private System.Windows.Forms.Button buttonDetailsEmployee;
        private System.Windows.Forms.Button buttonLookups;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.buttonAddEmployee = new System.Windows.Forms.Button();
            this.buttonEditEmployee = new System.Windows.Forms.Button();
            this.buttonDeleteEmployee = new System.Windows.Forms.Button();
            this.buttonDetailsEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                      | System.Windows.Forms.AnchorStyles.Left)
                                      | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.RowHeadersWidth = 51;
            this.dataGridViewEmployees.RowTemplate.Height = 24;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(880, 390);
            this.dataGridViewEmployees.TabIndex = 0;
            // 
            // buttonAddEmployee
            // 
            this.buttonAddEmployee.Location = new System.Drawing.Point(12, 12);
            this.buttonAddEmployee.Name = "buttonAddEmployee";
            this.buttonAddEmployee.Size = new System.Drawing.Size(150, 30);
            this.buttonAddEmployee.TabIndex = 1;
            this.buttonAddEmployee.Text = "Добавить сотрудника";
            this.buttonAddEmployee.UseVisualStyleBackColor = true;
            this.buttonAddEmployee.Click += new System.EventHandler(this.buttonAddEmployee_Click);
            // 
            // buttonEditEmployee
            // 
            this.buttonEditEmployee.Location = new System.Drawing.Point(170, 12);
            this.buttonEditEmployee.Name = "buttonEditEmployee";
            this.buttonEditEmployee.Size = new System.Drawing.Size(150, 30);
            this.buttonEditEmployee.TabIndex = 2;
            this.buttonEditEmployee.Text = "Редактировать";
            this.buttonEditEmployee.UseVisualStyleBackColor = true;
            this.buttonEditEmployee.Click += new System.EventHandler(this.buttonEditEmployee_Click);
            // 
            // buttonDeleteEmployee
            // 
            this.buttonDeleteEmployee.Location = new System.Drawing.Point(330, 12);
            this.buttonDeleteEmployee.Name = "buttonDeleteEmployee";
            this.buttonDeleteEmployee.Size = new System.Drawing.Size(150, 30);
            this.buttonDeleteEmployee.TabIndex = 3;
            this.buttonDeleteEmployee.Text = "Удалить";
            this.buttonDeleteEmployee.UseVisualStyleBackColor = true;
            this.buttonDeleteEmployee.Click += new System.EventHandler(this.buttonDeleteEmployee_Click);
            // 
            // buttonDetailsEmployee
            // 
            this.buttonDetailsEmployee.Location = new System.Drawing.Point(490, 12);
            this.buttonDetailsEmployee.Name = "buttonDetailsEmployee";
            this.buttonDetailsEmployee.Size = new System.Drawing.Size(150, 30);
            this.buttonDetailsEmployee.TabIndex = 4;
            this.buttonDetailsEmployee.Text = "Доп. информация";
            this.buttonDetailsEmployee.UseVisualStyleBackColor = true;
            this.buttonDetailsEmployee.Click += new System.EventHandler(this.buttonDetailsEmployee_Click);
            // 
            // buttonLookups
            // 
            this.buttonLookups = new System.Windows.Forms.Button();
            this.buttonLookups.Location = new System.Drawing.Point(650, 12);
            this.buttonLookups.Name = "buttonLookups";
            this.buttonLookups.Size = new System.Drawing.Size(120, 30);
            this.buttonLookups.TabIndex = 5;
            this.buttonLookups.Text = "Справочники";
            this.buttonLookups.UseVisualStyleBackColor = true;
            this.buttonLookups.Click += new System.EventHandler(this.buttonLookups_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(920, 461);
            this.Controls.Add(this.buttonAddEmployee);
            this.Controls.Add(this.buttonEditEmployee);
            this.Controls.Add(this.buttonDeleteEmployee);
            this.Controls.Add(this.buttonDetailsEmployee);
            this.Controls.Add(this.buttonLookups);
            this.Controls.Add(this.dataGridViewEmployees);
            this.Name = "MainForm";
            this.Text = "Сотрудники университета";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

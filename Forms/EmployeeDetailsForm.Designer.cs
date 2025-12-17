namespace UnivPersonnel.Forms
{
    partial class EmployeeDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TabControl tabControlDetails;
        private System.Windows.Forms.TabPage tabPrev;
        private System.Windows.Forms.TabPage tabPos;
        private System.Windows.Forms.TabPage tabSan;
        private System.Windows.Forms.TabPage tabRew;
        private System.Windows.Forms.ListBox listPrev;
        private System.Windows.Forms.ListBox listPos;
        private System.Windows.Forms.ListBox listSan;
        private System.Windows.Forms.ListBox listRew;
        private System.Windows.Forms.Button buttonClose;

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
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.tabControlDetails = new System.Windows.Forms.TabControl();
            this.tabPrev = new System.Windows.Forms.TabPage();
            this.tabPos = new System.Windows.Forms.TabPage();
            this.tabSan = new System.Windows.Forms.TabPage();
            this.tabRew = new System.Windows.Forms.TabPage();
            this.listPrev = new System.Windows.Forms.ListBox();
            this.listPos = new System.Windows.Forms.ListBox();
            this.listSan = new System.Windows.Forms.ListBox();
            this.listRew = new System.Windows.Forms.ListBox();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.tabControlDetails.SuspendLayout();
            this.tabPrev.SuspendLayout();
            this.tabPos.SuspendLayout();
            this.tabSan.SuspendLayout();
            this.tabRew.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(200, 250);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 0;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(230, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(46, 17);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "ФИО";
            // 
            // tabControlDetails
            // 
            this.tabControlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.tabControlDetails.Controls.Add(this.tabPrev);
            this.tabControlDetails.Controls.Add(this.tabPos);
            this.tabControlDetails.Controls.Add(this.tabSan);
            this.tabControlDetails.Controls.Add(this.tabRew);
            this.tabControlDetails.Location = new System.Drawing.Point(233, 50);
            this.tabControlDetails.Name = "tabControlDetails";
            this.tabControlDetails.SelectedIndex = 0;
            this.tabControlDetails.Size = new System.Drawing.Size(540, 300);
            this.tabControlDetails.TabIndex = 2;
            // 
            // tabPrev
            // 
            this.tabPrev.Controls.Add(this.listPrev);
            this.tabPrev.Location = new System.Drawing.Point(4, 25);
            this.tabPrev.Name = "tabPrev";
            this.tabPrev.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrev.Size = new System.Drawing.Size(532, 271);
            this.tabPrev.TabIndex = 0;
            this.tabPrev.Text = "Предыдущие места";
            this.tabPrev.UseVisualStyleBackColor = true;
            // 
            // tabPos
            // 
            this.tabPos.Controls.Add(this.listPos);
            this.tabPos.Location = new System.Drawing.Point(4, 25);
            this.tabPos.Name = "tabPos";
            this.tabPos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPos.Size = new System.Drawing.Size(532, 271);
            this.tabPos.TabIndex = 1;
            this.tabPos.Text = "Перемещения";
            this.tabPos.UseVisualStyleBackColor = true;
            // 
            // tabSan
            // 
            this.tabSan.Controls.Add(this.listSan);
            this.tabSan.Location = new System.Drawing.Point(4, 25);
            this.tabSan.Name = "tabSan";
            this.tabSan.Padding = new System.Windows.Forms.Padding(3);
            this.tabSan.Size = new System.Drawing.Size(532, 271);
            this.tabSan.TabIndex = 2;
            this.tabSan.Text = "Взыскания";
            this.tabSan.UseVisualStyleBackColor = true;
            // 
            // tabRew
            // 
            this.tabRew.Controls.Add(this.listRew);
            this.tabRew.Location = new System.Drawing.Point(4, 25);
            this.tabRew.Name = "tabRew";
            this.tabRew.Padding = new System.Windows.Forms.Padding(3);
            this.tabRew.Size = new System.Drawing.Size(532, 271);
            this.tabRew.TabIndex = 3;
            this.tabRew.Text = "Поощрения";
            this.tabRew.UseVisualStyleBackColor = true;
            // 
            // listPrev
            // 
            this.listPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPrev.FormattingEnabled = true;
            this.listPrev.ItemHeight = 16;
            this.listPrev.Location = new System.Drawing.Point(3, 3);
            this.listPrev.Name = "listPrev";
            this.listPrev.Size = new System.Drawing.Size(526, 264);
            this.listPrev.TabIndex = 0;
            // 
            // listPos
            // 
            this.listPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPos.FormattingEnabled = true;
            this.listPos.ItemHeight = 16;
            this.listPos.Location = new System.Drawing.Point(3, 3);
            this.listPos.Name = "listPos";
            this.listPos.Size = new System.Drawing.Size(526, 264);
            this.listPos.TabIndex = 0;
            // 
            // listSan
            // 
            this.listSan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSan.FormattingEnabled = true;
            this.listSan.ItemHeight = 16;
            this.listSan.Location = new System.Drawing.Point(3, 3);
            this.listSan.Name = "listSan";
            this.listSan.Size = new System.Drawing.Size(526, 264);
            this.listSan.TabIndex = 0;
            // 
            // listRew
            // 
            this.listRew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRew.FormattingEnabled = true;
            this.listRew.ItemHeight = 16;
            this.listRew.Location = new System.Drawing.Point(3, 3);
            this.listRew.Name = "listRew";
            this.listRew.Size = new System.Drawing.Size(526, 264);
            this.listRew.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(693, 363);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 30);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // EmployeeDetailsForm
            // 
            this.ClientSize = new System.Drawing.Size(785, 405);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.tabControlDetails);
            this.Controls.Add(this.buttonClose);
            this.Name = "EmployeeDetailsForm";
            this.Text = "Дополнительная информация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.tabControlDetails.ResumeLayout(false);
            this.tabPrev.ResumeLayout(false);
            this.tabPos.ResumeLayout(false);
            this.tabSan.ResumeLayout(false);
            this.tabRew.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

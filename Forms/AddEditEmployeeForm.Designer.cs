namespace UnivPersonnel.Forms
{
    partial class AddEditEmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.TextBox textBoxDepartment;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;
        private System.Windows.Forms.TextBox textBoxBirthPlace;
        private System.Windows.Forms.TextBox textBoxHomeAddress;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxEducation;
        private System.Windows.Forms.TextBox textBoxUniversity;
        private System.Windows.Forms.NumericUpDown numericUpDownGradYear;
        private System.Windows.Forms.Label labelGradYear;
        private System.Windows.Forms.TextBox textBoxSpeciality;
        private System.Windows.Forms.TextBox textBoxEducationDoc;
        private System.Windows.Forms.TextBox textBoxPhotoPath;
        private System.Windows.Forms.TextBox textBoxDegree;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.TextBox textBoxPassportNumber;
        private System.Windows.Forms.DateTimePicker dateTimePickerPassportIssue;
        private System.Windows.Forms.TextBox textBoxPassportIssuedBy;
        private System.Windows.Forms.DateTimePicker dateTimePickerEmploymentStart;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControlCollections;
        private System.Windows.Forms.DataGridView dataGridPrevWork;
        private System.Windows.Forms.Button btnAddPrev;
        private System.Windows.Forms.Button btnEditPrev;
        private System.Windows.Forms.Button btnDelPrev;

        private System.Windows.Forms.DataGridView dataGridPositionChanges;
        private System.Windows.Forms.Button btnAddPos;
        private System.Windows.Forms.Button btnEditPos;
        private System.Windows.Forms.Button btnDelPos;

        private System.Windows.Forms.DataGridView dataGridSanctions;
        private System.Windows.Forms.Button btnAddSan;
        private System.Windows.Forms.Button btnEditSan;
        private System.Windows.Forms.Button btnDelSan;

        private System.Windows.Forms.DataGridView dataGridRewards;
        private System.Windows.Forms.Button btnAddRew;
        private System.Windows.Forms.Button btnEditRew;
        private System.Windows.Forms.Button btnDelRew;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.textBoxDepartment = new System.Windows.Forms.TextBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxBirthPlace = new System.Windows.Forms.TextBox();
            this.textBoxHomeAddress = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxEducation = new System.Windows.Forms.TextBox();
            this.textBoxUniversity = new System.Windows.Forms.TextBox();
            this.numericUpDownGradYear = new System.Windows.Forms.NumericUpDown();
            this.textBoxSpeciality = new System.Windows.Forms.TextBox();
            this.textBoxEducationDoc = new System.Windows.Forms.TextBox();
            this.textBoxPhotoPath = new System.Windows.Forms.TextBox();
            this.textBoxDegree = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.textBoxPassportNumber = new System.Windows.Forms.TextBox();
            this.dateTimePickerPassportIssue = new System.Windows.Forms.DateTimePicker();
            this.textBoxPassportIssuedBy = new System.Windows.Forms.TextBox();
            this.dateTimePickerEmploymentStart = new System.Windows.Forms.DateTimePicker();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGradYear)).BeginInit();
            this.SuspendLayout();
            // 
            // Настройка элементов формы
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(12, 12);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.PlaceholderText = "ФИО";
            this.textBoxFullName.Size = new System.Drawing.Size(300, 27);

            this.textBoxDepartment.Location = new System.Drawing.Point(12, 45);
            this.textBoxDepartment.Name = "textBoxDepartment";
            this.textBoxDepartment.PlaceholderText = "Подразделение";
            this.textBoxDepartment.Size = new System.Drawing.Size(300, 27);

            this.comboBoxGender.Location = new System.Drawing.Point(12, 78);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(100, 28);
            this.comboBoxGender.Items.AddRange(new object[] { "M", "F" });

            this.dateTimePickerBirthDate.Location = new System.Drawing.Point(12, 112);
            this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            this.dateTimePickerBirthDate.Size = new System.Drawing.Size(200, 27);

            this.textBoxBirthPlace.Location = new System.Drawing.Point(12, 145);
            this.textBoxBirthPlace.PlaceholderText = "Место рождения";
            this.textBoxBirthPlace.Size = new System.Drawing.Size(300, 27);

            this.textBoxHomeAddress.Location = new System.Drawing.Point(12, 178);
            this.textBoxHomeAddress.PlaceholderText = "Адрес";
            this.textBoxHomeAddress.Size = new System.Drawing.Size(300, 27);

            this.textBoxPhone.Location = new System.Drawing.Point(12, 211);
            this.textBoxPhone.PlaceholderText = "Телефон";
            this.textBoxPhone.Size = new System.Drawing.Size(200, 27);

            this.textBoxEducation.Location = new System.Drawing.Point(12, 244);
            this.textBoxEducation.PlaceholderText = "Образование";
            this.textBoxEducation.Size = new System.Drawing.Size(200, 27);

            this.textBoxUniversity.Location = new System.Drawing.Point(12, 277);
            this.textBoxUniversity.PlaceholderText = "Учебное заведение";
            this.textBoxUniversity.Size = new System.Drawing.Size(200, 27);

            this.numericUpDownGradYear.Location = new System.Drawing.Point(120, 310);
            this.numericUpDownGradYear.Maximum = 2100;
            this.numericUpDownGradYear.Minimum = 1900;
            this.numericUpDownGradYear.Value = 2020;
            // label for graduation year (left aligned)
            this.labelGradYear = new System.Windows.Forms.Label();
            this.labelGradYear.AutoSize = true;
            this.labelGradYear.Location = new System.Drawing.Point(12, 312);
            this.labelGradYear.Name = "labelGradYear";
            this.labelGradYear.Text = "Год выпуска:";

            this.textBoxSpeciality.Location = new System.Drawing.Point(12, 343);
            this.textBoxSpeciality.PlaceholderText = "Специальность";
            this.textBoxSpeciality.Size = new System.Drawing.Size(200, 27);

            this.textBoxEducationDoc.Location = new System.Drawing.Point(12, 376);
            this.textBoxEducationDoc.PlaceholderText = "Документ об образовании";
            this.textBoxEducationDoc.Size = new System.Drawing.Size(300, 27);

            this.textBoxPhotoPath.Location = new System.Drawing.Point(12, 409);
            this.textBoxPhotoPath.PlaceholderText = "Путь к фото";
            this.textBoxPhotoPath.Size = new System.Drawing.Size(300, 27);

            this.textBoxDegree.Location = new System.Drawing.Point(350, 52);
            this.textBoxDegree.PlaceholderText = "Учёная степень";
            this.textBoxDegree.Size = new System.Drawing.Size(200, 27);

            this.textBoxTitle.Location = new System.Drawing.Point(350, 85);
            this.textBoxTitle.PlaceholderText = "Учёное звание";
            this.textBoxTitle.Size = new System.Drawing.Size(200, 27);

            this.textBoxPosition.Location = new System.Drawing.Point(350, 118);
            this.textBoxPosition.PlaceholderText = "Должность";
            this.textBoxPosition.Size = new System.Drawing.Size(200, 27);
            // passport block: labels above controls, right column moved down to give space
            var labelPassportNumber = new System.Windows.Forms.Label();
            labelPassportNumber.AutoSize = true;
            labelPassportNumber.Location = new System.Drawing.Point(350, 111);
            labelPassportNumber.Name = "labelPassportNumber";
            labelPassportNumber.Text = "Данные паспорта:";

            this.textBoxPassportNumber.Location = new System.Drawing.Point(350, 150);
            this.textBoxPassportNumber.PlaceholderText = "Данные паспорта(ХХХХ ХХХХХХ)";
            this.textBoxPassportNumber.Size = new System.Drawing.Size(200, 27);

            var labelPassportIssue = new System.Windows.Forms.Label();
            labelPassportIssue.AutoSize = true;
            labelPassportIssue.Location = new System.Drawing.Point(350, 192);
            labelPassportIssue.Name = "labelPassportIssue";
            labelPassportIssue.Text = "Дата выдачи паспорта:";

            this.dateTimePickerPassportIssue.Location = new System.Drawing.Point(350, 220);
            this.dateTimePickerPassportIssue.Name = "dateTimePickerPassportIssue";
            this.dateTimePickerPassportIssue.Size = new System.Drawing.Size(200, 27);



            this.textBoxPassportIssuedBy.Location = new System.Drawing.Point(350, 260);
            this.textBoxPassportIssuedBy.PlaceholderText = "Кем выдан";
            this.textBoxPassportIssuedBy.Size = new System.Drawing.Size(200, 27);

            var labelEmploymentStart = new System.Windows.Forms.Label();
            labelEmploymentStart.AutoSize = true;
            labelEmploymentStart.Location = new System.Drawing.Point(350, 300);
            labelEmploymentStart.Name = "labelEmploymentStart";
            labelEmploymentStart.Text = "Дата приёма:";

            this.dateTimePickerEmploymentStart.Location = new System.Drawing.Point(350, 330);
            this.dateTimePickerEmploymentStart.Name = "dateTimePickerEmploymentStart";
            this.dateTimePickerEmploymentStart.Size = new System.Drawing.Size(200, 27);

            this.buttonSave.Location = new System.Drawing.Point(12, 450);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            this.buttonCancel.Location = new System.Drawing.Point(130, 450);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // TabControl for collections
            this.tabControlCollections = new System.Windows.Forms.TabControl();
            this.tabControlCollections.Location = new System.Drawing.Point(12, 500);
            this.tabControlCollections.Name = "tabControlCollections";
            this.tabControlCollections.Size = new System.Drawing.Size(560, 240);

            var tabPrev = new System.Windows.Forms.TabPage("Предыдущие места");
            this.dataGridPrevWork = new System.Windows.Forms.DataGridView();
            this.btnAddPrev = new System.Windows.Forms.Button();
            this.btnEditPrev = new System.Windows.Forms.Button();
            this.btnDelPrev = new System.Windows.Forms.Button();
            // prev controls
            this.dataGridPrevWork.Location = new System.Drawing.Point(6, 6);
            this.dataGridPrevWork.Size = new System.Drawing.Size(520, 160);
            this.btnAddPrev.Location = new System.Drawing.Point(6, 172);
            this.btnAddPrev.Size = new System.Drawing.Size(80, 28);
            this.btnAddPrev.Text = "Добавить";
            this.btnAddPrev.Click += new System.EventHandler(this.btnAddPrev_Click);
            this.btnEditPrev.Location = new System.Drawing.Point(92, 172);
            this.btnEditPrev.Size = new System.Drawing.Size(80, 28);
            this.btnEditPrev.Text = "Редактировать";
            this.btnEditPrev.Click += new System.EventHandler(this.btnEditPrev_Click);
            this.btnDelPrev.Location = new System.Drawing.Point(178, 172);
            this.btnDelPrev.Size = new System.Drawing.Size(80, 28);
            this.btnDelPrev.Text = "Удалить";
            this.btnDelPrev.Click += new System.EventHandler(this.btnDelPrev_Click);
            tabPrev.Controls.Add(this.dataGridPrevWork);
            tabPrev.Controls.Add(this.btnAddPrev);
            tabPrev.Controls.Add(this.btnEditPrev);
            tabPrev.Controls.Add(this.btnDelPrev);

            var tabPos = new System.Windows.Forms.TabPage("Перемещения");
            this.dataGridPositionChanges = new System.Windows.Forms.DataGridView();
            this.btnAddPos = new System.Windows.Forms.Button();
            this.btnEditPos = new System.Windows.Forms.Button();
            this.btnDelPos = new System.Windows.Forms.Button();
            this.dataGridPositionChanges.Location = new System.Drawing.Point(6, 6);
            this.dataGridPositionChanges.Size = new System.Drawing.Size(520, 160);
            this.btnAddPos.Location = new System.Drawing.Point(6, 172);
            this.btnAddPos.Size = new System.Drawing.Size(80, 28);
            this.btnAddPos.Text = "Добавить";
            this.btnAddPos.Click += new System.EventHandler(this.btnAddPos_Click);
            this.btnEditPos.Location = new System.Drawing.Point(92, 172);
            this.btnEditPos.Size = new System.Drawing.Size(80, 28);
            this.btnEditPos.Text = "Редактировать";
            this.btnEditPos.Click += new System.EventHandler(this.btnEditPos_Click);
            this.btnDelPos.Location = new System.Drawing.Point(178, 172);
            this.btnDelPos.Size = new System.Drawing.Size(80, 28);
            this.btnDelPos.Text = "Удалить";
            this.btnDelPos.Click += new System.EventHandler(this.btnDelPos_Click);
            tabPos.Controls.Add(this.dataGridPositionChanges);
            tabPos.Controls.Add(this.btnAddPos);
            tabPos.Controls.Add(this.btnEditPos);
            tabPos.Controls.Add(this.btnDelPos);

            var tabSan = new System.Windows.Forms.TabPage("Взыскания");
            this.dataGridSanctions = new System.Windows.Forms.DataGridView();
            this.btnAddSan = new System.Windows.Forms.Button();
            this.btnEditSan = new System.Windows.Forms.Button();
            this.btnDelSan = new System.Windows.Forms.Button();
            this.dataGridSanctions.Location = new System.Drawing.Point(6, 6);
            this.dataGridSanctions.Size = new System.Drawing.Size(520, 160);
            this.btnAddSan.Location = new System.Drawing.Point(6, 172);
            this.btnAddSan.Size = new System.Drawing.Size(80, 28);
            this.btnAddSan.Text = "Добавить";
            this.btnAddSan.Click += new System.EventHandler(this.btnAddSan_Click);
            this.btnEditSan.Location = new System.Drawing.Point(92, 172);
            this.btnEditSan.Size = new System.Drawing.Size(80, 28);
            this.btnEditSan.Text = "Редактировать";
            this.btnEditSan.Click += new System.EventHandler(this.btnEditSan_Click);
            this.btnDelSan.Location = new System.Drawing.Point(178, 172);
            this.btnDelSan.Size = new System.Drawing.Size(80, 28);
            this.btnDelSan.Text = "Удалить";
            this.btnDelSan.Click += new System.EventHandler(this.btnDelSan_Click);
            tabSan.Controls.Add(this.dataGridSanctions);
            tabSan.Controls.Add(this.btnAddSan);
            tabSan.Controls.Add(this.btnEditSan);
            tabSan.Controls.Add(this.btnDelSan);

            var tabRew = new System.Windows.Forms.TabPage("Поощрения");
            this.dataGridRewards = new System.Windows.Forms.DataGridView();
            this.btnAddRew = new System.Windows.Forms.Button();
            this.btnEditRew = new System.Windows.Forms.Button();
            this.btnDelRew = new System.Windows.Forms.Button();
            this.dataGridRewards.Location = new System.Drawing.Point(6, 6);
            this.dataGridRewards.Size = new System.Drawing.Size(520, 160);
            this.btnAddRew.Location = new System.Drawing.Point(6, 172);
            this.btnAddRew.Size = new System.Drawing.Size(80, 28);
            this.btnAddRew.Text = "Добавить";
            this.btnAddRew.Click += new System.EventHandler(this.btnAddRew_Click);
            this.btnEditRew.Location = new System.Drawing.Point(92, 172);
            this.btnEditRew.Size = new System.Drawing.Size(80, 28);
            this.btnEditRew.Text = "Редактировать";
            this.btnEditRew.Click += new System.EventHandler(this.btnEditRew_Click);
            this.btnDelRew.Location = new System.Drawing.Point(178, 172);
            this.btnDelRew.Size = new System.Drawing.Size(80, 28);
            this.btnDelRew.Text = "Удалить";
            this.btnDelRew.Click += new System.EventHandler(this.btnDelRew_Click);
            tabRew.Controls.Add(this.dataGridRewards);
            tabRew.Controls.Add(this.btnAddRew);
            tabRew.Controls.Add(this.btnEditRew);
            tabRew.Controls.Add(this.btnDelRew);

            this.tabControlCollections.Controls.Add(tabPrev);
            this.tabControlCollections.Controls.Add(tabPos);
            this.tabControlCollections.Controls.Add(tabSan);
            this.tabControlCollections.Controls.Add(tabRew);

            // 
            // AddEditEmployeeForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 760);
            this.Controls.Add(this.textBoxFullName);
            this.Controls.Add(this.textBoxDepartment);
            this.Controls.Add(this.comboBoxGender);
            this.Controls.Add(this.dateTimePickerBirthDate);
            this.Controls.Add(this.textBoxBirthPlace);
            this.Controls.Add(this.textBoxHomeAddress);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxEducation);
            this.Controls.Add(this.textBoxUniversity);
            this.Controls.Add(this.numericUpDownGradYear);
            this.Controls.Add(this.textBoxSpeciality);
            this.Controls.Add(this.textBoxEducationDoc);
            this.Controls.Add(this.textBoxPhotoPath);
            this.Controls.Add(this.textBoxDegree);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.textBoxPassportNumber);
            this.Controls.Add(this.dateTimePickerPassportIssue);
            this.Controls.Add(this.textBoxPassportIssuedBy);
            this.Controls.Add(this.dateTimePickerEmploymentStart);
            this.Controls.Add(this.labelGradYear);
            this.Controls.Add(labelPassportIssue);
            this.Controls.Add(labelEmploymentStart);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControlCollections);
            this.Text = "Добавить / Редактировать сотрудника";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGradYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

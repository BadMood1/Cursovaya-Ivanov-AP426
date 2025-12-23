using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UnivPersonnel.Models;
using UnivPersonnel.Data;

namespace UnivPersonnel.Forms
{
    public partial class AddEditEmployeeForm : Form
    {
        public Employee Employee { get; private set; }
        private System.Windows.Forms.BindingSource bsPrev;
        private System.Windows.Forms.BindingSource bsPos;
        private System.Windows.Forms.BindingSource bsSan;
        private System.Windows.Forms.BindingSource bsRew;

        public AddEditEmployeeForm(Employee employee = null)
        {
            InitializeComponent();

            // Load lookup lists first so ComboBoxes contain items before selecting values
            RefreshLookupItems();

            bsPrev = new System.Windows.Forms.BindingSource();
            bsPos = new System.Windows.Forms.BindingSource();
            bsSan = new System.Windows.Forms.BindingSource();
            bsRew = new System.Windows.Forms.BindingSource();

            ConfigureDataGrid(dataGridPrevWork, bsPrev, new[] { ("CompanyName", "Название"), ("CompanyAddress", "Адрес"), ("CompanyPhone", "Телефон"), ("StartDate", "Дата начала"), ("EndDate", "Дата окончания"), ("LastPosition", "Должность при увольнении"), ("DismissalReason", "Причина увольнения") });

            ConfigureDataGrid(dataGridPositionChanges, bsPos, new[] { ("Reason", "Причина"), ("OrderDate", "Дата приказа"), ("OrderNumber", "Номер приказа"), ("NewPosition", "Новая должность") });

            ConfigureDataGrid(dataGridSanctions, bsSan, new[] { ("Type", "Вид взыскания"), ("OrderDate", "Дата приказа"), ("OrderNumber", "Номер приказа"), ("Notes", "Примечания") });

            ConfigureDataGrid(dataGridRewards, bsRew, new[] { ("Type", "Вид поощрения"), ("OrderDate", "Дата приказа"), ("OrderNumber", "Номер приказа"), ("Notes", "Примечания") });

            if (employee != null)
            {
                Employee = employee;
                LoadEmployeeData();
            }
            else
            {
                Employee = new Employee();
            }
        }

        private void LoadEmployeeData()
        {
            textBoxFullName.Text = Employee.FullName;
            SetComboValue(comboBoxDepartment, Employee.Department);
            comboBoxGender.Text = Employee.Gender;
            dateTimePickerBirthDate.Value = Employee.BirthDate;
            textBoxBirthPlace.Text = Employee.BirthPlace;
            textBoxHomeAddress.Text = Employee.HomeAddress;
            textBoxPhone.Text = Employee.PhoneNumber;
            SetComboValue(comboBoxEducation, Employee.Education);
            textBoxUniversity.Text = Employee.GraduatedUniversity;
            numericUpDownGradYear.Value = Employee.GraduationYear;
            textBoxSpeciality.Text = Employee.Speciality;
            textBoxEducationDoc.Text = Employee.EducationDocument;
            textBoxPhotoPath.Text = Employee.PhotoPath;
            SetComboValue(comboBoxDegree, Employee.AcademicDegree);
            SetComboValue(comboBoxTitle, Employee.AcademicTitle);
            SetComboValue(comboBoxPosition, Employee.Position);
            textBoxPassportNumber.Text = Employee.PassportNumber;
            dateTimePickerPassportIssue.Value = Employee.PassportIssueDate;
            textBoxPassportIssuedBy.Text = Employee.PassportIssuedBy;
            dateTimePickerEmploymentStart.Value = Employee.EmploymentStartDate;

            bsPrev.DataSource = Employee.PreviousWorkplaces;
            bsPos.DataSource = Employee.PositionChanges;
            bsSan.DataSource = Employee.Sanctions;
            bsRew.DataSource = Employee.Rewards;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Validate fields before saving
            if (!ValidateEmployee(out var error))
            {
                MessageBox.Show(error, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Employee.FullName = textBoxFullName.Text;
            Employee.Department = comboBoxDepartment.Text;
            Employee.Gender = comboBoxGender.Text;
            Employee.BirthDate = dateTimePickerBirthDate.Value;
            Employee.BirthPlace = textBoxBirthPlace.Text;
            Employee.HomeAddress = textBoxHomeAddress.Text;
            Employee.PhoneNumber = textBoxPhone.Text;
            Employee.Education = comboBoxEducation.Text;
            Employee.GraduatedUniversity = textBoxUniversity.Text;
            Employee.GraduationYear = (int)numericUpDownGradYear.Value;
            Employee.Speciality = textBoxSpeciality.Text;
            Employee.EducationDocument = textBoxEducationDoc.Text;
            Employee.PhotoPath = textBoxPhotoPath.Text;
            Employee.AcademicDegree = comboBoxDegree.Text;
            Employee.AcademicTitle = comboBoxTitle.Text;
            Employee.Position = comboBoxPosition.Text;
            Employee.PassportNumber = textBoxPassportNumber.Text;
            Employee.PassportIssueDate = dateTimePickerPassportIssue.Value;
            Employee.PassportIssuedBy = textBoxPassportIssuedBy.Text;
            Employee.EmploymentStartDate = dateTimePickerEmploymentStart.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateEmployee(out string error)
        {
            error = null;
            var fullName = textBoxFullName.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(fullName)) { error = "Поле 'ФИО' не должно быть пустым."; return false; }
            if (fullName.Any(char.IsDigit)) { error = "ФИО не должно содержать цифр."; return false; }

            var dept = comboBoxDepartment.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(dept)) { error = "Поле 'Подразделение' не должно быть пустым."; return false; }

            var pos = comboBoxPosition.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(pos)) { error = "Поле 'Должность' не должно быть пустым."; return false; }

            var education = comboBoxEducation.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(education)) { error = "Поле 'Образование' не должно быть пустым."; return false; }

            var phone = textBoxPhone.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(phone)) { error = "Поле 'Телефон' не должно быть пустым."; return false; }
            // Normalize phone: keep digits only
            var digits = new string(phone.Where(ch => char.IsDigit(ch)).ToArray());
            // Accept formats like +7XXXXXXXXXX or 8XXXXXXXXXX (convert 8->7)
            if (digits.Length == 11 && digits.StartsWith("8")) digits = "7" + digits.Substring(1);
            if (!(digits.Length == 11 && digits.StartsWith("7"))) { error = "Телефон должен быть в формате +7XXXXXXXXXX."; return false; }

            // Birth date should not be in the future
            if (dateTimePickerBirthDate.Value.Date >= DateTime.Today) { error = "Дата рождения не может быть в будущем."; return false; }

            // Passport number required and must match format XXXX XXXXXX
            var passport = textBoxPassportNumber.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(passport)) { error = "Поле 'Данные паспорта' не должно быть пустым."; return false; }
            // expected format: 4 digits, space, 6 digits
            if (!Regex.IsMatch(passport, "^\\d{4}\\s\\d{6}$")) { error = "Данные паспорта должны быть в формате 'XXXX XXXXXX' (4 цифры, пробел, 6 цифр)."; return false; }
            // 'Кем выдан' must not be empty
            var issuedBy = textBoxPassportIssuedBy.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(issuedBy)) { error = "Поле 'Кем выдан' не должно быть пустым."; return false; }
            // Passport issue date must not be in the future
            if (dateTimePickerPassportIssue.Value.Date > DateTime.Today) { error = "Дата выдачи паспорта не может быть в будущем."; return false; }

            // Employment start date not in future
            if (dateTimePickerEmploymentStart.Value.Date > DateTime.Today) { error = "Дата приёма на работу не может быть в будущем."; return false; }

            return true;
        }

        private void RefreshLookupItems()
        {
            try
            {
                comboBoxEducation.Items.Clear();
                comboBoxEducation.Items.AddRange(LookupService.GetList("Образование").ToArray());
                comboBoxDepartment.Items.Clear();
                comboBoxDepartment.Items.AddRange(LookupService.GetList("Подразделение").ToArray());
                comboBoxPosition.Items.Clear();
                comboBoxPosition.Items.AddRange(LookupService.GetList("Должность").ToArray());
                comboBoxDegree.Items.Clear();
                comboBoxDegree.Items.AddRange(LookupService.GetList("Учёная степень").ToArray());
                comboBoxTitle.Items.Clear();
                comboBoxTitle.Items.AddRange(LookupService.GetList("Учёное звание").ToArray());
            }
            catch { }
        }

        private void SetComboValue(ComboBox cb, string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) { cb.SelectedIndex = -1; return; }
            var val = value.Trim();
            var idx = cb.FindStringExact(val);
            if (idx >= 0)
            {
                cb.SelectedIndex = idx;
                return;
            }
            // try trimming items or adding the trimmed value
            foreach (var item in cb.Items)
            {
                if (item is string s && s.Trim() == val)
                {
                    cb.SelectedItem = item;
                    return;
                }
            }
            cb.Items.Add(val);
            cb.SelectedItem = val;
        }

        private void buttonManageLookups_Click(object sender, EventArgs e)
        {
            var form = new ManageLookupsForm();
            form.ShowDialog();
            RefreshLookupItems();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RefreshBindings()
        {
            bsPrev.ResetBindings(false);
            bsPos.ResetBindings(false);
            bsSan.ResetBindings(false);
            bsRew.ResetBindings(false);
        }

        // PreviousWorkplace handlers
        private void btnAddPrev_Click(object sender, EventArgs e)
        {
            var form = new EditPreviousWorkplaceForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var item = form.Workplace;
                if (string.IsNullOrWhiteSpace(item.CompanyName)) return; // Ignore empty
                item.Id = Employee.PreviousWorkplaces.Count > 0 ? Employee.PreviousWorkplaces.Max(x => x.Id) + 1 : 1;
                Employee.PreviousWorkplaces.Add(item);
                RefreshBindings();
            }
        }

        private void btnEditPrev_Click(object sender, EventArgs e)
        {
            if (bsPrev.Current is PreviousWorkplace pw)
            {
                var copy = new PreviousWorkplace
                {
                    Id = pw.Id,
                    CompanyName = pw.CompanyName,
                    CompanyAddress = pw.CompanyAddress,
                    CompanyPhone = pw.CompanyPhone,
                    StartDate = pw.StartDate,
                    EndDate = pw.EndDate,
                    LastPosition = pw.LastPosition,
                    DismissalReason = pw.DismissalReason
                };
                var form = new EditPreviousWorkplaceForm(copy);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // update
                    pw.CompanyName = form.Workplace.CompanyName;
                    pw.CompanyAddress = form.Workplace.CompanyAddress;
                    pw.CompanyPhone = form.Workplace.CompanyPhone;
                    pw.StartDate = form.Workplace.StartDate;
                    pw.EndDate = form.Workplace.EndDate;
                    pw.LastPosition = form.Workplace.LastPosition;
                    pw.DismissalReason = form.Workplace.DismissalReason;
                    RefreshBindings();
                }
            }
        }

        private void btnDelPrev_Click(object sender, EventArgs e)
        {
            if (bsPrev.Current is PreviousWorkplace pw)
            {
                if (MessageBox.Show("Удалить выбранное предыдущее место работы?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Employee.PreviousWorkplaces.Remove(pw);
                    RefreshBindings();
                }
            }
        }

        // PositionChange handlers
        private void btnAddPos_Click(object sender, EventArgs e)
        {
            var form = new EditPositionChangeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var item = form.Change;
                if (string.IsNullOrWhiteSpace(item.Reason)) return; // Ignore empty
                item.Id = Employee.PositionChanges.Count > 0 ? Employee.PositionChanges.Max(x => x.Id) + 1 : 1;
                Employee.PositionChanges.Add(item);
                RefreshBindings();
            }
        }

        private void btnEditPos_Click(object sender, EventArgs e)
        {
            if (bsPos.Current is PositionChange pc)
            {
                var copy = new PositionChange { Id = pc.Id, Reason = pc.Reason, OrderDate = pc.OrderDate, OrderNumber = pc.OrderNumber, NewPosition = pc.NewPosition };
                var form = new EditPositionChangeForm(copy);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    pc.Reason = form.Change.Reason;
                    pc.OrderDate = form.Change.OrderDate;
                    pc.OrderNumber = form.Change.OrderNumber;
                    pc.NewPosition = form.Change.NewPosition;
                    RefreshBindings();
                }
            }
        }

        private void btnDelPos_Click(object sender, EventArgs e)
        {
            if (bsPos.Current is PositionChange pc)
            {
                if (MessageBox.Show("Удалить выбранное перемещение?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Employee.PositionChanges.Remove(pc);
                    RefreshBindings();
                }
            }
        }

        // Sanction handlers
        private void btnAddSan_Click(object sender, EventArgs e)
        {
            var form = new EditSanctionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var item = form.Sanction;
                if (string.IsNullOrWhiteSpace(item.Type)) return; // Ignore empty
                item.Id = Employee.Sanctions.Count > 0 ? Employee.Sanctions.Max(x => x.Id) + 1 : 1;
                Employee.Sanctions.Add(item);
                RefreshBindings();
            }
        }

        private void btnEditSan_Click(object sender, EventArgs e)
        {
            if (bsSan.Current is Sanction s)
            {
                var copy = new Sanction { Id = s.Id, Type = s.Type, OrderDate = s.OrderDate, OrderNumber = s.OrderNumber, Notes = s.Notes };
                var form = new EditSanctionForm(copy);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    s.Type = form.Sanction.Type;
                    s.OrderDate = form.Sanction.OrderDate;
                    s.OrderNumber = form.Sanction.OrderNumber;
                    s.Notes = form.Sanction.Notes;
                    RefreshBindings();
                }
            }
        }

        private void btnDelSan_Click(object sender, EventArgs e)
        {
            if (bsSan.Current is Sanction s)
            {
                if (MessageBox.Show("Удалить выбранное взыскание?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Employee.Sanctions.Remove(s);
                    RefreshBindings();
                }
            }
        }

        // Reward handlers
        private void btnAddRew_Click(object sender, EventArgs e)
        {
            var form = new EditRewardForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var item = form.Reward;
                if (string.IsNullOrWhiteSpace(item.Type)) return; // Ignore empty
                item.Id = Employee.Rewards.Count > 0 ? Employee.Rewards.Max(x => x.Id) + 1 : 1;
                Employee.Rewards.Add(item);
                RefreshBindings();
            }
        }

        private void btnEditRew_Click(object sender, EventArgs e)
        {
            if (bsRew.Current is Reward r)
            {
                var copy = new Reward { Id = r.Id, Type = r.Type, OrderDate = r.OrderDate, OrderNumber = r.OrderNumber, Notes = r.Notes };
                var form = new EditRewardForm(copy);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    r.Type = form.Reward.Type;
                    r.OrderDate = form.Reward.OrderDate;
                    r.OrderNumber = form.Reward.OrderNumber;
                    r.Notes = form.Reward.Notes;
                    RefreshBindings();
                }
            }
        }

        private void btnDelRew_Click(object sender, EventArgs e)
        {
            if (bsRew.Current is Reward r)
            {
                if (MessageBox.Show("Удалить выбранное поощрение?", "Подтвердить", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Employee.Rewards.Remove(r);
                    RefreshBindings();
                }
            }
        }

        private void ConfigureDataGrid(DataGridView grid, BindingSource bs, (string PropertyName, string DisplayName)[] columnConfig)
        {
            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToAddRows = false;
            grid.DataSource = bs;

            grid.Columns.Clear();
            foreach (var (propName, dispName) in columnConfig)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = propName,
                    HeaderText = dispName,
                    Name = propName,
                    Width = 120,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                grid.Columns.Add(col);
            }
        }
    }
}

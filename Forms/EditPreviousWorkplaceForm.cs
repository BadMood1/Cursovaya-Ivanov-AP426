using System;
using System.Windows.Forms;
using UnivPersonnel.Models;

namespace UnivPersonnel.Forms
{
    public class EditPreviousWorkplaceForm : Form
    {
        public PreviousWorkplace Workplace { get; private set; }

        private TextBox tbName, tbAddress, tbPhone, tbLastPos, tbDismissal;
        private DateTimePicker dtStart, dtEnd;
        private Button btnSave, btnCancel;

        public EditPreviousWorkplaceForm(PreviousWorkplace wp = null)
        {
            Workplace = wp ?? new PreviousWorkplace();
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.tbName = new TextBox() { Left = 10, Top = 10, Width = 370, PlaceholderText = "Название предприятия" };
            this.tbAddress = new TextBox() { Left = 10, Top = 44, Width = 370, PlaceholderText = "Адрес" };
            this.tbPhone = new TextBox() { Left = 10, Top = 78, Width = 370, PlaceholderText = "Телефон" };
            var labelStart = new Label() { Left = 10, Top = 112, AutoSize = true, Text = "Дата начала:" };
            this.dtStart = new DateTimePicker() { Left = 10, Top = 140, Width = 180 };
            var labelEnd = new Label() { Left = 200, Top = 112, AutoSize = true, Text = "Дата окончания:" };
            this.dtEnd = new DateTimePicker() { Left = 200, Top = 140, Width = 180 };
            this.tbLastPos = new TextBox() { Left = 10, Top = 180, Width = 370, PlaceholderText = "Должность при увольнении" };
            this.tbDismissal = new TextBox() { Left = 10, Top = 210, Width = 370, PlaceholderText = "Причина увольнения" };
            this.btnSave = new Button() { Left = 10, Top = 300, Text = "Сохранить", Width = 100 };
            this.btnCancel = new Button() { Left = 120, Top = 300, Text = "Отмена", Width = 100 };
            this.btnSave.Click += (s, e) => { if (TrySave(out var err)) { DialogResult = DialogResult.OK; Close(); } else MessageBox.Show(err, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning); };
            this.btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            this.ClientSize = new System.Drawing.Size(420, 340);
            this.Controls.AddRange(new Control[] { tbName, tbAddress, tbPhone, labelStart, dtStart, labelEnd, dtEnd, tbLastPos, tbDismissal, btnSave, btnCancel });
            this.Text = "Предыдущее место работы";
        }

        private void LoadData()
        {
            tbName.Text = Workplace.CompanyName;
            tbAddress.Text = Workplace.CompanyAddress;
            tbPhone.Text = Workplace.CompanyPhone;
            dtStart.Value = Workplace.StartDate == default ? DateTime.Today : Workplace.StartDate;
            dtEnd.Value = Workplace.EndDate == default ? DateTime.Today : Workplace.EndDate;
            tbLastPos.Text = Workplace.LastPosition;
            tbDismissal.Text = Workplace.DismissalReason;
        }

        private bool TrySave(out string error)
        {
            error = null;
            var name = tbName.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(name)) { error = "Название предприятия не должно быть пустым."; return false; }
            // dates
            if (dtStart.Value.Date > dtEnd.Value.Date) { error = "Дата начала не может быть позже даты окончания."; return false; }
            // optional phone: if provided, check digits
            var phone = tbPhone.Text?.Trim() ?? "";
            if (!string.IsNullOrEmpty(phone))
            {
                var digits = new string(phone.Where(char.IsDigit).ToArray());
                if (digits.Length < 6) { error = "Неверный формат телефона для места работы."; return false; }
            }

            Workplace.CompanyName = tbName.Text;
            Workplace.CompanyAddress = tbAddress.Text;
            Workplace.CompanyPhone = tbPhone.Text;
            Workplace.StartDate = dtStart.Value;
            Workplace.EndDate = dtEnd.Value;
            Workplace.LastPosition = tbLastPos.Text;
            Workplace.DismissalReason = tbDismissal.Text;
            return true;
        }
    }
}

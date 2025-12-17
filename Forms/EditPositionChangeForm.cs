using System;
using System.Windows.Forms;
using UnivPersonnel.Models;

namespace UnivPersonnel.Forms
{
    public class EditPositionChangeForm : Form
    {
        public PositionChange Change { get; private set; }

        private TextBox tbReason, tbOrderNumber, tbNewPosition;
        private DateTimePicker dtOrderDate;
        private Button btnSave, btnCancel;

        public EditPositionChangeForm(PositionChange pc = null)
        {
            Change = pc ?? new PositionChange();
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            tbReason = new TextBox() { Left = 10, Top = 10, Width = 360, PlaceholderText = "Причина перемещения" };
            var labelOrderDate = new Label() { Left = 10, Top = 44, AutoSize = true, Text = "Дата приказа:" };
            dtOrderDate = new DateTimePicker() { Left = 10, Top = 72, Width = 200 };
            tbOrderNumber = new TextBox() { Left = 220, Top = 72, Width = 150, PlaceholderText = "Номер приказа" };
            tbNewPosition = new TextBox() { Left = 10, Top = 104, Width = 360, PlaceholderText = "Новая должность" };
            btnSave = new Button() { Left = 10, Top = 138, Text = "Сохранить", Width = 100 };
            btnCancel = new Button() { Left = 120, Top = 138, Text = "Отмена", Width = 100 };
            btnSave.Click += (s, e) => { if (TrySave(out var err)) { DialogResult = DialogResult.OK; Close(); } else MessageBox.Show(err, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning); };
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            this.ClientSize = new System.Drawing.Size(390, 180);
            this.Controls.AddRange(new Control[] { tbReason, labelOrderDate, dtOrderDate, tbOrderNumber, tbNewPosition, btnSave, btnCancel });
            this.Text = "Перемещение по должности";
        }

        private void LoadData()
        {
            tbReason.Text = Change.Reason;
            dtOrderDate.Value = Change.OrderDate == default ? DateTime.Today : Change.OrderDate;
            tbOrderNumber.Text = Change.OrderNumber;
            tbNewPosition.Text = Change.NewPosition;
        }

        private bool TrySave(out string error)
        {
            error = null;
            var reason = tbReason.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(reason)) { error = "Поле 'Причина' не должно быть пустым."; return false; }
            var newpos = tbNewPosition.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(newpos)) { error = "Поле 'Новая должность' не должно быть пустым."; return false; }
            var num = tbOrderNumber.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(num)) { error = "Поле 'Номер приказа' не должно быть пустым."; return false; }
            if (dtOrderDate.Value.Date > DateTime.Today) { error = "Дата приказа не может быть в будущем."; return false; }

            Change.Reason = tbReason.Text;
            Change.OrderDate = dtOrderDate.Value;
            Change.OrderNumber = tbOrderNumber.Text;
            Change.NewPosition = tbNewPosition.Text;
            return true;
        }
    }
}

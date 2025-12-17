using System;
using System.Windows.Forms;
using UnivPersonnel.Models;

namespace UnivPersonnel.Forms
{
    public class EditRewardForm : Form
    {
        public Reward Reward { get; private set; }

        private TextBox tbType, tbOrderNumber, tbNotes;
        private DateTimePicker dtOrderDate;
        private Button btnSave, btnCancel;

        public EditRewardForm(Reward r = null)
        {
            Reward = r ?? new Reward();
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            tbType = new TextBox() { Left = 10, Top = 10, Width = 360, PlaceholderText = "Вид поощрения" };
            var labelOrderDate = new Label() { Left = 10, Top = 44, AutoSize = true, Text = "Дата приказа:" };
            dtOrderDate = new DateTimePicker() { Left = 10, Top = 72, Width = 200 };
            tbOrderNumber = new TextBox() { Left = 220, Top = 72, Width = 150, PlaceholderText = "Номер приказа" };
            tbNotes = new TextBox() { Left = 10, Top = 104, Width = 360, PlaceholderText = "Примечания" };
            btnSave = new Button() { Left = 10, Top = 138, Text = "Сохранить", Width = 100 };
            btnCancel = new Button() { Left = 120, Top = 138, Text = "Отмена", Width = 100 };
            btnSave.Click += (s, e) => { if (TrySave(out var err)) { DialogResult = DialogResult.OK; Close(); } else MessageBox.Show(err, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning); };
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            this.ClientSize = new System.Drawing.Size(390, 180);
            this.Controls.AddRange(new Control[] { tbType, labelOrderDate, dtOrderDate, tbOrderNumber, tbNotes, btnSave, btnCancel });
            this.Text = "Поощрение";
        }

        private void LoadData()
        {
            tbType.Text = Reward.Type;
            dtOrderDate.Value = Reward.OrderDate == default ? DateTime.Today : Reward.OrderDate;
            tbOrderNumber.Text = Reward.OrderNumber;
            tbNotes.Text = Reward.Notes;
        }

        private bool TrySave(out string error)
        {
            error = null;
            var type = tbType.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(type)) { error = "Поле 'Вид поощрения' не должно быть пустым."; return false; }
            var num = tbOrderNumber.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(num)) { error = "Поле 'Номер приказа' не должно быть пустым."; return false; }
            if (dtOrderDate.Value.Date > DateTime.Today) { error = "Дата приказа не может быть в будущем."; return false; }

            Reward.Type = tbType.Text;
            Reward.OrderDate = dtOrderDate.Value;
            Reward.OrderNumber = tbOrderNumber.Text;
            Reward.Notes = tbNotes.Text;
            return true;
        }
    }
}

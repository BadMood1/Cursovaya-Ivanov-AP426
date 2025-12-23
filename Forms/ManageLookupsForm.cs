using System;
using System.Linq;
using System.Windows.Forms;
using UnivPersonnel.Data;

namespace UnivPersonnel.Forms
{
    public class ManageLookupsForm : Form
    {
        private ComboBox comboProfiles;
        private Button btnNewProfile;
        private Button btnDeleteProfile;
        private ComboBox comboTypes;
        private ListBox listItems;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        public ManageLookupsForm()
        {
            Text = "Управление справочниками";
            Width = 600;
            Height = 400;

            comboProfiles = new ComboBox { Left = 10, Top = 10, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
            btnNewProfile = new Button { Left = 320, Top = 10, Width = 80, Text = "Новый" };
            btnDeleteProfile = new Button { Left = 410, Top = 10, Width = 80, Text = "Удалить" };

            comboTypes = new ComboBox { Left = 10, Top = 50, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            comboTypes.Items.AddRange(new object[] { "Образование", "Подразделение", "Должность", "Учёная степень", "Учёное звание" });
            comboTypes.SelectedIndex = 0;

            listItems = new ListBox { Left = 10, Top = 90, Width = 400, Height = 220 };

            var lblType = new Label { Left = 10, Top = 75, AutoSize = true, Text = "Тип списка:" };
            Controls.Add(lblType);

            btnAdd = new Button { Left = 420, Top = 90, Width = 120, Text = "Добавить" };
            btnEdit = new Button { Left = 420, Top = 130, Width = 120, Text = "Редактировать" };
            btnDelete = new Button { Left = 420, Top = 170, Width = 120, Text = "Удалить" };

            Controls.Add(comboProfiles);
            Controls.Add(btnNewProfile);
            Controls.Add(btnDeleteProfile);
            Controls.Add(comboTypes);
            Controls.Add(listItems);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);

            Load += ManageLookupsForm_Load;
            comboProfiles.SelectedIndexChanged += ComboProfiles_SelectedIndexChanged;
            comboTypes.SelectedIndexChanged += ComboTypes_SelectedIndexChanged;
            btnNewProfile.Click += BtnNewProfile_Click;
            btnDeleteProfile.Click += BtnDeleteProfile_Click;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void ManageLookupsForm_Load(object? sender, EventArgs e)
        {
            RefreshProfiles();
            RefreshItems();
        }

        private void RefreshProfiles()
        {
            comboProfiles.Items.Clear();
            foreach (var p in LookupService.GetProfiles()) comboProfiles.Items.Add(p);
            var active = LookupService.GetActiveProfile();
            comboProfiles.SelectedItem = active;
        }

        private void RefreshItems()
        {
            var type = comboTypes.SelectedItem?.ToString() ?? "Education";
            listItems.Items.Clear();
            var items = LookupService.GetList(type);
            foreach (var it in items) listItems.Items.Add(it);
        }

        private void ComboProfiles_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboProfiles.SelectedItem == null) return;
            LookupService.SetActiveProfile(comboProfiles.SelectedItem.ToString() ?? "По умолчанию");
            RefreshItems();
        }

        private void ComboTypes_SelectedIndexChanged(object? sender, EventArgs e)
        {
            RefreshItems();
        }

        private void BtnNewProfile_Click(object? sender, EventArgs e)
        {
            var name = Microsoft.VisualBasic.Interaction.InputBox("Имя профиля (напр. НГТУ НЭТИ", "Новый профиль", "");
            if (string.IsNullOrWhiteSpace(name)) return;
            LookupService.CreateProfile(name);
            RefreshProfiles();
            comboProfiles.SelectedItem = name;
        }

        private void BtnDeleteProfile_Click(object? sender, EventArgs e)
        {
            if (comboProfiles.SelectedItem == null) return;
            var name = comboProfiles.SelectedItem.ToString();
            if (name == null) return;
            if (name == "По умолчанию")
            {
                MessageBox.Show("Профиль 'По умолчанию' нельзя удалить.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Удалить профиль '{name}'?", "Подтвердить", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            LookupService.DeleteProfile(name);
            RefreshProfiles();
            RefreshItems();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var val = Microsoft.VisualBasic.Interaction.InputBox("Новая запись:", "Добавить", "");
            var type = comboTypes.SelectedItem?.ToString() ?? "Образование";
            try
            {
                LookupService.AddItem(type, val);
                RefreshItems();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (listItems.SelectedItem == null) return;
            var old = listItems.SelectedItem.ToString() ?? "";
            var val = Microsoft.VisualBasic.Interaction.InputBox("Редактировать:", "Редактировать", old);
            var type = comboTypes.SelectedItem?.ToString() ?? "Образование";
            try
            {
                LookupService.UpdateItem(type, old, val);
                RefreshItems();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (listItems.SelectedItem == null) return;
            var val = listItems.SelectedItem.ToString() ?? "";
            var type = comboTypes.SelectedItem?.ToString() ?? "Education";
            if (MessageBox.Show($"Удалить '{val}'?", "Подтвердить", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            LookupService.RemoveItem(type, val);
            RefreshItems();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UnivPersonnel.Data;
using UnivPersonnel.Models;

namespace UnivPersonnel.Forms
{
    public partial class MainForm : Form
    {
        private List<Employee> _employees;

        public MainForm()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            _employees = JsonDataService.LoadEmployees();
            dataGridViewEmployees.DataSource = null;
            dataGridViewEmployees.AutoGenerateColumns = false;
            dataGridViewEmployees.DataSource = _employees;
            dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Настроить колонки с русскими названиями (покрываем все свойства Employee)
            dataGridViewEmployees.Columns.Clear();
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Width = 50 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "ФИО", Width = 150 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Department", HeaderText = "Подразделение", Width = 120 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Position", HeaderText = "Должность", Width = 120 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Пол", Width = 60 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BirthDate", HeaderText = "Дата рождения", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" } });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BirthPlace", HeaderText = "Место рождения", Width = 150 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HomeAddress", HeaderText = "Адрес", Width = 200 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhoneNumber", HeaderText = "Телефон", Width = 100 });
            // Дополнительные поля по ТЗ: образование и связанные данные
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Education", HeaderText = "Образование", Width = 120 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GraduatedUniversity", HeaderText = "ВУЗ", Width = 150 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GraduationYear", HeaderText = "Год выпуска", Width = 80 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Speciality", HeaderText = "Специальность", Width = 150 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EducationDocument", HeaderText = "Документ об образовании", Width = 150 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AcademicDegree", HeaderText = "Ученая степень", Width = 120 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AcademicTitle", HeaderText = "Ученое звание", Width = 120 });
            // Паспорт и связанные поля
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PassportNumber", HeaderText = "№ паспорта", Width = 110 });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PassportIssueDate", HeaderText = "Дата выдачи паспорта", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" } });
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PassportIssuedBy", HeaderText = "Кем выдан", Width = 180 });
            // Дата приёма на работу
            dataGridViewEmployees.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmploymentStartDate", HeaderText = "Дата приёма", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" } });
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            var form = new AddEditEmployeeForm(); // открываем форму
            if (form.ShowDialog() == DialogResult.OK) // ждём, пока пользователь нажмёт Сохранить
            {
                var employee = form.Employee; // забираем введённые данные
                                              // ставим уникальный Id
                employee.Id = _employees.Count > 0 ? _employees.Max(emp => emp.Id) + 1 : 1;
                _employees.Add(employee); // добавляем в список
                JsonDataService.SaveEmployees(_employees); // сохраняем JSON
                LoadEmployees(); // обновляем DataGridView
            }
        }

        private void buttonEditEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var emp = dataGridViewEmployees.SelectedRows[0].DataBoundItem as Employee;
            if (emp == null) return;
            var before = CreateSnapshot(emp);
            var form = new AddEditEmployeeForm(emp);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var after = CreateSnapshot(emp);
                var changes = GetChanges(before, after);
                var msg = changes.Count > 0 ? string.Join("\n", changes) : "Изменений не обнаружено.";
                MessageBox.Show("Редактирование завершено.\n" + msg, "Окно изменений", MessageBoxButtons.OK, MessageBoxIcon.Information);
                JsonDataService.SaveEmployees(_employees);
                LoadEmployees();
            }
        }

        private System.Collections.Generic.Dictionary<string, string> CreateSnapshot(Employee e)
        {
            var d = new System.Collections.Generic.Dictionary<string, string>();
            d["FullName"] = e.FullName ?? "";
            d["Department"] = e.Department ?? "";
            d["Gender"] = e.Gender ?? "";
            d["BirthDate"] = e.BirthDate.ToString("o");
            d["BirthPlace"] = e.BirthPlace ?? "";
            d["HomeAddress"] = e.HomeAddress ?? "";
            d["PhoneNumber"] = e.PhoneNumber ?? "";
            d["Education"] = e.Education ?? "";
            d["GraduatedUniversity"] = e.GraduatedUniversity ?? "";
            d["GraduationYear"] = e.GraduationYear.ToString();
            d["Speciality"] = e.Speciality ?? "";
            d["EducationDocument"] = e.EducationDocument ?? "";
            d["PhotoPath"] = e.PhotoPath ?? "";
            d["AcademicDegree"] = e.AcademicDegree ?? "";
            d["AcademicTitle"] = e.AcademicTitle ?? "";
            d["Position"] = e.Position ?? "";
            d["PassportNumber"] = e.PassportNumber ?? "";
            d["PassportIssueDate"] = e.PassportIssueDate.ToString("o");
            d["PassportIssuedBy"] = e.PassportIssuedBy ?? "";
            d["EmploymentStartDate"] = e.EmploymentStartDate.ToString("o");
            d["PrevCount"] = e.PreviousWorkplaces?.Count.ToString() ?? "0";
            d["PosChangeCount"] = e.PositionChanges?.Count.ToString() ?? "0";
            d["SanctionsCount"] = e.Sanctions?.Count.ToString() ?? "0";
            d["RewardsCount"] = e.Rewards?.Count.ToString() ?? "0";
            return d;
        }

        private System.Collections.Generic.List<string> GetChanges(System.Collections.Generic.Dictionary<string, string> before, System.Collections.Generic.Dictionary<string, string> after)
        {
            var list = new System.Collections.Generic.List<string>();
            foreach (var kv in before)
            {
                var key = kv.Key;
                var b = kv.Value ?? "";
                after.TryGetValue(key, out var a);
                a = a ?? "";
                if (b != a)
                    list.Add($"{key}: '{b}' -> '{a}'");
            }
            return list;
        }

        private void buttonDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var emp = dataGridViewEmployees.SelectedRows[0].DataBoundItem as Employee;
            if (emp == null) return;

            if (MessageBox.Show($"Удалить сотрудника '{emp.FullName}'?", "Подтвердить", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _employees.Remove(emp);
                JsonDataService.SaveEmployees(_employees);
                LoadEmployees();
            }
        }

        private void buttonDetailsEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var emp = dataGridViewEmployees.SelectedRows[0].DataBoundItem as Employee;
            if (emp == null) return;

            using var form = new EmployeeDetailsForm(emp);
            form.ShowDialog(this);
        }
    }
}

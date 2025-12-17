using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UnivPersonnel.Models;

namespace UnivPersonnel.Forms
{
    public partial class EmployeeDetailsForm : Form
    {
        private readonly Employee _employee;

        public EmployeeDetailsForm(Employee employee)
        {
            InitializeComponent();
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
            LoadData();
        }

        private void LoadData()
        {
            labelName.Text = _employee.FullName ?? "(без имени)";

            // Load photo if exists
            try
            {
                if (!string.IsNullOrWhiteSpace(_employee.PhotoPath))
                {
                    var photoPath = _employee.PhotoPath;
                    // If relative path (Photos/...), try to resolve relative to application folder
                    if (!Path.IsPathRooted(photoPath))
                    {
                        var appDir = AppDomain.CurrentDomain.BaseDirectory;
                        var candidate = Path.Combine(appDir, photoPath.Replace('/', Path.DirectorySeparatorChar));
                        if (File.Exists(candidate)) photoPath = candidate;
                    }

                    if (File.Exists(photoPath))
                    {
                        pictureBoxPhoto.Image = System.Drawing.Image.FromFile(photoPath);
                    }
                }
            }
            catch
            {
                // ignore image load errors
            }

            // Fill lists with readable strings
            listPrev.Items.Clear();
            foreach (var p in _employee.PreviousWorkplaces ?? Enumerable.Empty<PreviousWorkplace>())
            {
                var range = $"{p.StartDate:dd.MM.yyyy} - {p.EndDate:dd.MM.yyyy}";
                var txt = $"{p.CompanyName} ({range}) — Должность: {p.LastPosition}; Причина увольнения: {p.DismissalReason}";
                listPrev.Items.Add(txt);
            }

            listPos.Items.Clear();
            foreach (var pc in _employee.PositionChanges ?? Enumerable.Empty<PositionChange>())
            {
                var txt = $"{pc.OrderDate:dd.MM.yyyy} №{pc.OrderNumber} — {pc.Reason} -> {pc.NewPosition}";
                listPos.Items.Add(txt);
            }

            listSan.Items.Clear();
            foreach (var s in _employee.Sanctions ?? Enumerable.Empty<Sanction>())
            {
                var txt = $"{s.OrderDate:dd.MM.yyyy} №{s.OrderNumber} — {s.Type}; {s.Notes}";
                listSan.Items.Add(txt);
            }

            listRew.Items.Clear();
            foreach (var r in _employee.Rewards ?? Enumerable.Empty<Reward>())
            {
                var txt = $"{r.OrderDate:dd.MM.yyyy} №{r.OrderNumber} — {r.Type}; {r.Notes}";
                listRew.Items.Add(txt);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

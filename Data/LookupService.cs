using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using UnivPersonnel.Models;

namespace UnivPersonnel.Data
{
    public class LookupStore
    {
        public Dictionary<string, Dictionary<string, List<string>>> Profiles { get; set; } = new();
        public string ActiveProfile { get; set; } = "По умолчанию";
    }

    public static class LookupService
    {
        private static readonly string runtimePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "lookups.json");
        private static readonly string? projectPath = FindProjectDataPath();
        private static LookupStore store = null!;

        private static string? FindProjectDataPath()
        {
            try
            {
                var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                while (dir != null)
                {
                    var csproj = dir.GetFiles("*.csproj").FirstOrDefault();
                    if (csproj != null)
                    {
                        var dataDir = Path.Combine(dir.FullName, "Data");
                        if (!Directory.Exists(dataDir)) Directory.CreateDirectory(dataDir);
                        return Path.Combine(dataDir, "lookups.json");
                    }
                    dir = dir.Parent;
                }
            }
            catch { }
            return null;
        }

        public static void EnsureLoaded()
        {
            if (store != null) return;
            var runtimeDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(runtimeDir)) Directory.CreateDirectory(runtimeDir);

            string? loadPath = null;
            if (projectPath != null && File.Exists(projectPath)) loadPath = projectPath;
            else if (File.Exists(runtimePath)) loadPath = runtimePath;

            if (loadPath == null)
            {
                store = CreateDefaultStore();
                Save();
                return;
            }

            var json = File.ReadAllText(loadPath);
            try
            {
                store = JsonSerializer.Deserialize<LookupStore>(json) ?? CreateDefaultStore();
            }
            catch
            {
                store = CreateDefaultStore();
            }
        }

        private static LookupStore CreateDefaultStore()
        {
            var s = new LookupStore();
            var profile = "По умолчанию";
            s.Profiles[profile] = new Dictionary<string, List<string>>();
            s.Profiles[profile]["Образование"] = new List<string>
            {
                "Среднее общее",
                "Среднее профессиональное",
                "Высшее - бакалавриат",
                "Высшее - специалитет",
                "Высшее - магистратура",
                "Аспирантура",
                "Докторантура",
                "Дополнит. профессиональное"
            };
            s.Profiles[profile]["Подразделение"] = new List<string>
            {
                "Кафедра прикладной математики",
                "Кафедра информатики",
                "Кафедра программирования",
                "Кафедра электротехники",
                "Кафедра физики",
                "Кафедра иностранных языков"
            };

            s.Profiles[profile]["Должность"] = new List<string>
            {
                "Ассистент",
                "Старший преподаватель",
                "Инженер",
                "Лаборант"
            };

            s.Profiles[profile]["Учёная степень"] = new List<string>
            {
                "Не имеется",
                "Кандидат наук",
                "Доктор наук",
            };

            s.Profiles[profile]["Учёное звание"] = new List<string>
            {
                "Не имеется",
                "Доцент",
                "Профессор",
                "Старший научный сотрудник",
                "Ведущий научный сотрудник",
                "Главный научный сотрудник",
            };

            s.ActiveProfile = profile;
            return s;
        }

        public static void Save()
        {
            EnsureLoaded();
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(store, options);
            try
            {
                if (projectPath != null)
                {
                    var projDir = Path.GetDirectoryName(projectPath) ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
                    if (!Directory.Exists(projDir)) Directory.CreateDirectory(projDir);
                    File.WriteAllText(projectPath, json);
                }
            }
            catch { }
            try
            {
                var runDir = Path.GetDirectoryName(runtimePath)!;
                if (!Directory.Exists(runDir)) Directory.CreateDirectory(runDir);
                File.WriteAllText(runtimePath, json);
            }
            catch { }
        }

        public static IEnumerable<string> GetProfiles()
        {
            EnsureLoaded();
            return store.Profiles.Keys;
        }

        public static string GetActiveProfile()
        {
            EnsureLoaded();
            return store.ActiveProfile;
        }

        public static void SetActiveProfile(string profile)
        {
            EnsureLoaded();
            if (!store.Profiles.ContainsKey(profile))
            {
                CreateProfile(profile);
            }
            store.ActiveProfile = profile;
            Save();
        }

        public static List<string> GetList(string type)
        {
            EnsureLoaded();
            if (!store.Profiles.ContainsKey(store.ActiveProfile))
                store.Profiles[store.ActiveProfile] = new Dictionary<string, List<string>>();
            var profile = store.Profiles[store.ActiveProfile];
            if (!profile.ContainsKey(type))
            {
                if (store.Profiles.TryGetValue("По умолчанию", out var defProfile) && defProfile != null && defProfile.TryGetValue(type, out var defList))
                {
                    profile[type] = new List<string>(defList);
                }
                else
                {
                    profile[type] = new List<string>();
                }
                Save();
            }
            return profile[type];
        }

        public static void AddItem(string type, string value)
        {
            EnsureLoaded();
            if (value == null) throw new ArgumentException("Значение не может быть пустым", nameof(value));
            var v = value.Trim();
            if (string.IsNullOrWhiteSpace(v)) throw new ArgumentException("Значение не может быть пустым", nameof(value));
            if (type == "Образование" || type == "Учёная степень")
                throw new ArgumentException("Этот список нельзя изменять.", nameof(type));
            var list = GetList(type);
            if (!list.Contains(v))
            {
                list.Add(v);
                Save();
            }
        }

        public static void RemoveItem(string type, string value)
        {
            EnsureLoaded();
            if (type == "Образование" || type == "Учёная степень")
                throw new ArgumentException("Этот список нельзя изменять.", nameof(type));
            var list = GetList(type);
            if (list.Contains(value))
            {
                list.Remove(value);
                try { UpdateEmployeesForLookup(type, value, "-"); } catch { }
                Save();
            }
        }

        public static void UpdateItem(string type, string oldValue, string newValue)
        {
            EnsureLoaded();
            if (newValue == null) throw new ArgumentException("Новое значение не может быть пустым", nameof(newValue));
            var nv = newValue.Trim();
            if (string.IsNullOrWhiteSpace(nv)) throw new ArgumentException("Новое значение не может быть пустым", nameof(newValue));
            if (type == "Образование" || type == "Учёная степень")
                throw new ArgumentException("Этот список нельзя изменять.", nameof(type));
            var list = GetList(type);
            var idx = list.IndexOf(oldValue);
            if (idx >= 0)
            {
                list[idx] = nv;
                try { UpdateEmployeesForLookup(type, oldValue, nv); } catch { }
                Save();
            }
        }

        // Update all employees: replace occurrences of oldValue for given lookup type with newValue
        private static void UpdateEmployeesForLookup(string type, string oldValue, string newValue)
        {
            try
            {
                var employees = JsonDataService.LoadEmployees();
                var changed = false;
                foreach (var e in employees)
                {
                    switch (type)
                    {
                        case "Подразделение":
                            if (e.Department == oldValue) { e.Department = newValue; changed = true; }
                            break;
                        case "Должность":
                            if (e.Position == oldValue) { e.Position = newValue; changed = true; }
                            break;
                        case "Учёная степень":
                            if (e.AcademicDegree == oldValue) { e.AcademicDegree = newValue; changed = true; }
                            break;
                        case "Учёное звание":
                            if (e.AcademicTitle == oldValue) { e.AcademicTitle = newValue; changed = true; }
                            break;
                        case "Образование":
                            if (e.Education == oldValue) { e.Education = newValue; changed = true; }
                            break;
                        default:
                            break;
                    }
                }
                if (changed)
                {
                    JsonDataService.SaveEmployees(employees);
                }
            }
            catch
            {
                // non-fatal
            }
        }

        public static void CreateProfile(string name)
        {
            EnsureLoaded();
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя профиля не может быть пустым", nameof(name));
            if (!store.Profiles.ContainsKey(name))
            {
                var newProfile = new Dictionary<string, List<string>>();
                if (store.Profiles.TryGetValue("По умолчанию", out var def) && def != null)
                {
                    foreach (var kv in def)
                    {
                        newProfile[kv.Key] = new List<string>(kv.Value);
                    }
                }
                store.Profiles[name] = newProfile;
                Save();
            }
        }

        public static void DeleteProfile(string name)
        {
            EnsureLoaded();
            if (name == "По умолчанию")
            {
                return;
            }
            if (store.Profiles.ContainsKey(name))
            {
                store.Profiles.Remove(name);
                if (store.ActiveProfile == name)
                    store.ActiveProfile = store.Profiles.Keys.FirstOrDefault() ?? "По умолчанию";
                Save();
            }
        }
    }
}

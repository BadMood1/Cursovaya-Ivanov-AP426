using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

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
                    // ищем .csproj в родительских папках
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
            // убеждаемся, что runtime-папка существует
            var runtimeDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(runtimeDir)) Directory.CreateDirectory(runtimeDir);

            string? loadPath = null;
            // приоритет — проектная копия (чтобы правки сохранялись в исходниках)
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
                "Дополнительное профессиональное"
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
                "Доцент",
                "Профессор",
                "Инженер",
                "Лаборант"
            };

            s.Profiles[profile]["Учёная степень"] = new List<string>
            {
                "Кандидат наук",
                "Доктор наук",
            };

            s.Profiles[profile]["Учёное звание"] = new List<string>
            {
                "Старший преподаватель",
                "Ведущий научный сотрудник",
            };

            s.ActiveProfile = profile;
            return s;
        }

        public static void Save()
        {
            EnsureLoaded();
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(store, options);
            // Сохраняем в projectPath (если есть), и в runtimePath — чтобы приложение использовало актуальную копию
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
                // create empty profile with basic education list
                store.Profiles[profile] = new Dictionary<string, List<string>>();
                store.Profiles[profile]["Образование"] = new List<string>
                {
                    "Среднее общее",
                    "Среднее профессиональное",
                    "Высшее - бакалавриат",
                    "Высшее - специалитет",
                    "Высшее - магистратура",
                    "Аспирантура",
                    "Докторантура",
                    "Дополнительное профессиональное"
                };
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
                // если запрошен список, которого нет — создаём пустой
                profile[type] = new List<string>();
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
            var list = GetList(type);
            if (list.Contains(value))
            {
                list.Remove(value);
                Save();
            }
        }

        public static void UpdateItem(string type, string oldValue, string newValue)
        {
            EnsureLoaded();
            if (newValue == null) throw new ArgumentException("Новое значение не может быть пустым", nameof(newValue));
            var nv = newValue.Trim();
            if (string.IsNullOrWhiteSpace(nv)) throw new ArgumentException("Новое значение не может быть пустым", nameof(newValue));
            var list = GetList(type);
            var idx = list.IndexOf(oldValue);
            if (idx >= 0) { list[idx] = nv; Save(); }
        }

        public static void CreateProfile(string name)
        {
            EnsureLoaded();
            if (!store.Profiles.ContainsKey(name))
            {
                store.Profiles[name] = new Dictionary<string, List<string>>();
                Save();
            }
        }

        public static void DeleteProfile(string name)
        {
            EnsureLoaded();
            if (name == "По умолчанию")
            {
                // Нельзя удалять профиль по умолчанию
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

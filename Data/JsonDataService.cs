using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using UnivPersonnel.Models;

namespace UnivPersonnel.Data
{
    public static class JsonDataService
    {
        private static string runtimePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "employees.json");

        private static string? FindProjectEmployeesPath()
        {
            try
            {
                var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                while (dir != null)
                {
                    var csproj = dir.GetFiles("*.csproj").FirstOrDefault();
                    if (csproj != null)
                    {
                        return Path.Combine(dir.FullName, "employees.json");
                    }
                    dir = dir.Parent;
                }
            }
            catch { }
            return null;
        }

        public static List<Employee> LoadEmployees()
        {
            var projectPath = FindProjectEmployeesPath();
            string? loadPath = null;

            if (projectPath != null && File.Exists(projectPath)) loadPath = projectPath;
            else if (File.Exists(runtimePath)) loadPath = runtimePath;

            if (loadPath == null)
                return new List<Employee>();

            var json = File.ReadAllText(loadPath);
            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
        }

        public static void SaveEmployees(List<Employee> employees)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(employees, options);
            var projectPath = FindProjectEmployeesPath();

            try
            {
                if (projectPath != null)
                {
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
    }
}

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using UnivPersonnel.Models;

namespace UnivPersonnel.Data
{
    public static class JsonDataService
    {
        private static string filePath = "employees.json";

        public static List<Employee> LoadEmployees()
        {
            if (!File.Exists(filePath))
                return new List<Employee>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
        }

        public static void SaveEmployees(List<Employee> employees)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(employees, options);
            File.WriteAllText(filePath, json);
        }
    }
}

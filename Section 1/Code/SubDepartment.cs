using Section1.Forms;
using System;
using System.Collections.Generic;
using System.IO;

namespace Section1.Code
{
    internal class SubDepartment : Department
    {
        private static int idCounter = 0;

        private readonly int headDepartmentID;
        private readonly string uniqueID;

        public new string ID => uniqueID;
        public new string Name => base.Name;
        public new string Manager => Company.GetEmployeeName(managerID);
        public new int EmployeeCount => employees.Count;

        public SubDepartment(string name, int managerID, int headDepartmentID) 
            : base(name, managerID)
        {
            this.headDepartmentID = headDepartmentID;
            this.uniqueID = $"{headDepartmentID}:{idCounter++}";
        }

        private static SubDepartment CreateFromData(string line)
        {
            var args = line.Split(Separator);
            if (args.Length < 4) throw new FormatException("Invalid sub-department data format.");

            var selfID = int.Parse(args[0]);
            var headDepartmentID = int.Parse(args[1]);
            var name = args[2];
            var managerID = int.Parse(args[3]);

            idCounter = Math.Max(idCounter, selfID + 1);
            return new SubDepartment(name, managerID, headDepartmentID);
        }

        public void UpdateInfo(string name, int managerID, int headDepartmentID)
        {
            this.name = name;
            this.managerID = managerID;
            string[] ids = uniqueID.Split(':');
            uniqueID = $"{headDepartmentID}:{ids[1]}";
        }

        private new string Serialize()
        {
            string[] ids = uniqueID.Split(':');
            return string.Join(Separator, ids[1], headDepartmentID, name, managerID);
        }

        public static void SaveToFile(Dictionary<string, SubDepartment> subDepartments, string filePath, string employeeFilePath)
        {
            using var writer = new StreamWriter(filePath);
            File.Delete(employeeFilePath); // Ensure employee file is reset before appending new data.

            foreach (var subDepartment in subDepartments.Values)
            {
                writer.WriteLine(subDepartment.Serialize());
            }
        }

        public static void LoadFromFile(string filePath, string employeeFilePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("Sub-department data file not found.");

            foreach (var line in File.ReadLines(filePath))
            {
                var subDepartment = CreateFromData(line);
                Company.AddSubDepartment(subDepartment);
            }
        }

        public int GetHeadDepartmentID() => headDepartmentID;
    }
}
using Section1.Forms;
using System;
using System.Collections.Generic;
using System.IO;

namespace Section1.Code
{
    internal class Employee
    {
        private static int idCounter;
        private static readonly char Separator = ';';

        private int id;
        private string name;
        private int age;
        private string email;
        private string phone;
        private Role role;
        private int departmentID;
        private string subDepartmentID;

        public int ID => id;
        public string Name => name;
        public int Age => age;
        public string Email => email;
        public string Phone => phone;
        public Role Role => role;
        public int DepartmentID => departmentID;
        public string SubDepartmentID => subDepartmentID;
        public string DepartmentName => Company.GetDepartmentNameFormated(departmentID);

        public Employee(string name, int age, string email, string phone, Role role, int departmentID, string subDepartmentID = "")
        {
            id = idCounter++;
            this.name = name;
            this.age = age;
            this.email = email;
            this.phone = phone;
            this.role = role;
            this.departmentID = departmentID;
            this.subDepartmentID = subDepartmentID;
        }

        public static Employee CreateFromData(string data)
        {
            var args = data.Split(Separator);
            if (args.Length < 8) throw new FormatException("Invalid employee data format.");

            var id = int.Parse(args[0]);
            var name = args[1];
            var age = int.Parse(args[2]);
            var email = args[3];
            var phone = args[4];
            if (!Enum.TryParse(args[5], out Role role))
            {
                throw new ArgumentException("Invalid role value.");
            }
            var departmentID = int.Parse(args[6]);
            var subDepartmentID = args[7];

            var employee = new Employee(name, age, email, phone, role, departmentID, subDepartmentID)
            {
                id = id
            };
            idCounter = Math.Max(idCounter, id + 1);
            return employee;
        }

        public void UpdateInfo(string name, int age, string email, string phone, Role role, int departmentID, string subDepartmentID)
        {
            this.name = name;
            this.age = age;
            this.email = email;
            this.phone = phone;
            this.role = role;
            ChangeDepartment(departmentID);
            this.subDepartmentID = subDepartmentID;
        }

        public void ChangeDepartment(int newDepartmentID)
        {
            if (departmentID != newDepartmentID)
            {
                Company.MoveEmployee(id, departmentID, newDepartmentID);
                departmentID = newDepartmentID;
            }
        }

        private string Serialize()
        {
            return string.Join(Separator, id, name, age, email, phone, role, departmentID, subDepartmentID);
        }

        public static void SaveToFile(List<Employee> employees, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var employee in employees)
            {
                writer.WriteLine(employee.Serialize());
            }
        }

        public static void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("Employee data file not found.");

            foreach (var line in File.ReadLines(filePath))
            {
                var employee = CreateFromData(line);
                Company.AddEmployee(employee);
            }
        }
    }
}
using Section1.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Section1.Code
{
    internal class Department
    {
        private static readonly char Separator = ';';
        private static int idCounter = 0;

        private readonly int id;
        private string name;
        private int managerID;
        private readonly Dictionary<string, SubDepartment> subDepartments;
        private readonly Dictionary<int, Employee> employees;

        public int ID => id;
        public string Name => name;
        public string ManagerName => Company.GetEmployeeName(managerID);
        public int SubDepartmentCount => subDepartments.Count;
        public int EmployeeCount => employees.Count;

        public Department(string name, int managerID)
        {
            this.id = idCounter++;
            this.name = name;
            this.managerID = managerID;
            this.subDepartments = new Dictionary<string, SubDepartment>();
            this.employees = new Dictionary<int, Employee>();
        }

        private static Department CreateFromData(string line)
        {
            var args = line.Split(Separator);
            if (args.Length < 2) throw new ArgumentException("Invalid department data format.");
            var name = args[0];
            var managerID = int.Parse(args[1]);
            return new Department(name, managerID);
        }

        public void CreateSubDepartment(string name, int managerID)
        {
            var subDepartment = new SubDepartment(name, managerID, id);
            subDepartments[subDepartment.GetID()] = subDepartment;
        }

        public void AddSubDepartment(SubDepartment subDepartment)
        {
            subDepartments[subDepartment.GetID()] = subDepartment;
        }

        public bool TryGetSubDepartment(string subDepartmentID, out SubDepartment subDepartment)
        {
            return subDepartments.TryGetValue(subDepartmentID, out subDepartment);
        }

        public void RemoveSubDepartment(string subDepartmentID)
        {
            if (!subDepartments.Remove(subDepartmentID))
                throw new KeyNotFoundException($"SubDepartment with ID {subDepartmentID} not found.");
        }

        public void AddEmployee(Employee employee)
        {
            employees[employee.GetID()] = employee;
        }

        public bool TryGetEmployee(int employeeID, out Employee employee)
        {
            return employees.TryGetValue(employeeID, out employee);
        }

        public void RemoveEmployee(int employeeID)
        {
            if (!employees.Remove(employeeID))
                throw new KeyNotFoundException($"Employee with ID {employeeID} not found.");
        }

        public void UpdateDepartment(string newName, int newManagerID)
        {
            this.name = newName;
            this.managerID = newManagerID;
        }

        public List<Employee> GetEmployees() => employees.Values.ToList();

        public List<SubDepartment> GetSubDepartments() => subDepartments.Values.ToList();

        public BindingList<Employee> GetEmployeeBindingList()
        {
            return new BindingList<Employee>(employees.Values.ToList());
        }

        protected string Serialize()
        {
            return $"{name}{Separator}{managerID}";
        }

        public static void SaveDepartments(List<Department> departments, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var department in departments)
            {
                writer.WriteLine(department.Serialize());
            }
        }

        public static void LoadDepartments(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("Department data file not found.");

            foreach (var line in File.ReadLines(filePath))
            {
                var department = CreateFromData(line);
                Company.CreateDepartment(department);
            }
        }
    }
}
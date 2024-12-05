using Section1.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Section1.Code
{
    enum Role
    {
        CEO,
        CFO,
        COO,
        Manager,
        Engineer,
        Designer,
        Accountant,
        FinancialAnalyst,
        Recruiter,
        DataScientist,
        LegalCounsel,
        SalesAssociate,
        Developer,
        LogisticsCoordinator,
        RDScientist,
        CustomerSupportAgent,
        PublicRelationsCoordinator,
        QAEngineer,
        ProcurementSpecialist,
        EHSOfficer
    }

    internal static class Company
    {
        private static readonly string BasePath = @"C:\Users\Alihan\source\repos\Assignment1\Assignment1\Data";
        private static readonly string EmployeePath = $"{BasePath}\\employees.txt";
        private static readonly string DepartmentPath = $"{BasePath}\\departments.txt";
        private static readonly string SubDepartmentPath = $"{BasePath}\\subdepartments.txt";
        private static readonly string SubDepEmployeePath = $"{BasePath}\\subDepartmentEmployees.txt";

        private static readonly Dictionary<int, Employee> Employees = new();
        private static readonly Dictionary<int, Department> Departments = new();
        private static readonly Dictionary<string, SubDepartment> SubDepartments = new();

        public static void CreateDepartment(Department department)
        {
            Departments[department.GetID()] = department;
        }

        public static void DestroyDepartment(int departmentID)
        {
            if (Departments.TryGetValue(departmentID, out var department) &&
                department.GetNumberOfEmployees() == 0 &&
                department.GetNumOfSubDepartments() == 0)
            {
                Departments.Remove(departmentID);
            }
        }

        public static void AddSubDepartment(SubDepartment subDepartment)
        {
            Departments[subDepartment.GetHeadDepartment()].CreateSubDepartment(subDepartment);
            SubDepartments[subDepartment.GetID()] = subDepartment;
        }

        public static void RemoveSubDepartment(string subDepartmentID, int departmentID)
        {
            if (Departments.TryGetValue(departmentID, out var department))
            {
                department.DestroySubDepartment(subDepartmentID);
                SubDepartments.Remove(subDepartmentID);
            }
        }

        public static void AddEmployee(Employee employee)
        {
            Employees[employee.GetID()] = employee;
            var department = Departments[employee.GetDepartmentID()];

            department.AddEmployee(employee);
            if (!string.IsNullOrEmpty(employee.GetSubDepartmentID()) && SubDepartments.TryGetValue(employee.GetSubDepartmentID(), out var subDepartment))
            {
                subDepartment.AddEmployee(employee);
            }
        }

        public static void RemoveEmployee(int employeeID, int departmentID)
        {
            Employees.Remove(employeeID);
            if (Departments.TryGetValue(departmentID, out var department))
            {
                department.RemoveEmployee(employeeID);
            }
        }

        public static void MoveEmployee(int employeeID, int oldDepartmentID, int newDepartmentID)
        {
            if (Departments.TryGetValue(oldDepartmentID, out var oldDepartment) &&
                Departments.TryGetValue(newDepartmentID, out var newDepartment) &&
                oldDepartment.GetEmployee(employeeID) is Employee employee)
            {
                oldDepartment.RemoveEmployee(employeeID);
                employee.ChangeDepartment(newDepartmentID);
                newDepartment.AddEmployee(employee);
            }
        }

        public static void MoveEmployeeToSubDepartment(int employeeID, string subDepartmentID, bool inSubDepartment)
        {
            if (Employees.TryGetValue(employeeID, out var employee))
            {
                var department = Departments[employee.GetDepartmentID()];
                if (inSubDepartment && department.GetSubDepartment(subDepartmentID) is SubDepartment subDepartment)
                {
                    employee.UpdateSubDepartmentInfo(subDepartmentID);
                    subDepartment.AddEmployee(employee);
                }
                else
                {
                    department.RemoveEmployeeFromSubDepartment(subDepartmentID, employeeID);
                }
            }
        }

        public static void UpdateSubDepartment(string name, int managerID, string subDepartmentID, int oldDepartmentID, int newDepartmentID)
        {
            if (Departments.TryGetValue(oldDepartmentID, out var oldDepartment) &&
                oldDepartment.GetSubDepartment(subDepartmentID) is SubDepartment subDepartment)
            {
                subDepartment.ChangeParameters(name, managerID, newDepartmentID);

                oldDepartment.DestroySubDepartment(subDepartmentID);
                Departments[newDepartmentID].CreateSubDepartment(subDepartment);

                SubDepartments[subDepartmentID] = subDepartment;
            }
        }

        public static string GetEmployeeName(int employeeID) => Employees.TryGetValue(employeeID, out var employee) ? employee.GetName() : string.Empty;

        public static List<Employee> GetManagers() => Employees.Values.Where(e => e.Role == Role.Manager).ToList();

        public static int GetDepartmentID(string departmentName) =>
            Departments.FirstOrDefault(kvp => kvp.Value.GetName() == departmentName).Key;

        public static string GetDepartmentName(int departmentID) => Departments.TryGetValue(departmentID, out var department) ? department.GetName() : string.Empty;

        public static string GetDepartmentNameFormatted(int departmentID)
        {
            var nameParts = GetDepartmentName(departmentID).Split();
            return nameParts.Length == 1
                ? nameParts[0]
                : string.Join("&", nameParts.Select(part => part[0]));
        }

        public static List<Department> GetDepartments() => Departments.Values.ToList();

        public static List<Employee> GetEmployees() => Employees.Values.ToList();

        public static List<SubDepartment> GetSubDepartments(int departmentID) =>
            Departments.TryGetValue(departmentID, out var department) ? department.GetSubDepartments() : new List<SubDepartment>();

        public static string GetDepartmentManager(int departmentID) =>
            Departments.TryGetValue(departmentID, out var department) &&
            Employees.TryGetValue(department.GetManager(), out var manager)
                ? manager.GetName()
                : string.Empty;

        public static string GetSubDepartmentManager(string subDepartmentID) =>
            SubDepartments.TryGetValue(subDepartmentID, out var subDepartment) &&
            Employees.TryGetValue(subDepartment.GetManager(), out var manager)
                ? manager.GetName()
                : string.Empty;

        public static List<string> GetDepartmentNames() => Departments.Values.Select(dep => dep.GetName()).ToList();

        public static void SaveData()
        {
            Employee.SaveData(Employees.Values.ToList(), EmployeePath);
            Department.SaveData(Departments.Values.ToList(), DepartmentPath);
            SubDepartment.SaveData(SubDepartments, SubDepartmentPath, SubDepEmployeePath);
        }

        public static void LoadData()
        {
            Departments.Clear();
            SubDepartments.Clear();
            Employees.Clear();

            Department.LoadData(DepartmentPath);
            SubDepartment.LoadData(SubDepartmentPath, SubDepEmployeePath);
            Employee.LoadData(EmployeePath);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_notebook
{
    class NotebookControl
    {
        JsonFileHandler fileHandler = new JsonFileHandler("notebook.json");
        List<StaffMember> staff;
        Validator validator = new Validator();
        int IDPointer;
        public NotebookControl()
        {
            staff = fileHandler.GetStaffMembers();
            IDPointer = staff.Max(x => x.ID)+1;

        }
        public void Save()
        {
            fileHandler.SaveStuffMembers(staff);
        }
        public List<StaffMember> GetAll()
        {
            return staff;
        }
        public List<StaffMember> GetByName(string name)
        {
            List<StaffMember> result = staff.FindAll(x => x.Name == name);
            if (result.Count==0)
            {
                throw new Exception($"There is no record with name {name}");
            }
            return result;
        }
        public List<StaffMember> GetByLastName(string lastName)
        {
            List<StaffMember> result = staff.FindAll(x => x.LastName == lastName);
            if (result.Count == 0)
            {
                throw new Exception($"There is no record with last name {lastName}");
            }
            return result;
        }
        public List<StaffMember> GetByPhoneNumber(string phoneNumber)
        {
            List<StaffMember> result = staff.FindAll(x => x.PhoneNumber == phoneNumber);
            if (result.Count == 0)
            {
                throw new Exception($"There is no record with phoneNumber {phoneNumber}");
            }
            return result;
        }
        public void AddManager(Manager manager)
        {
            if (staff.Contains(manager))
            {
                throw new Exception("This record already exist");
            }
            List<String> failedFields = new List<String>();
            bool isFailed = false; 
            if (!validator.isValidName(manager.Name))
            {
                failedFields.Add("name");
                isFailed = true;
            }
            if (!validator.isValidName(manager.LastName))
            {
                failedFields.Add("last name");
                isFailed = true;
            }
            if (!validator.isValidYearOfBirth(manager.YearOfBirth))
            {
                failedFields.Add("year of birth");
                isFailed = true;
            }
            if (!validator.isValidPhoneNumber(manager.PhoneNumber))
            {
                failedFields.Add("phone number");
                isFailed = true;
            }
            if (!validator.isValidName(manager.DepartmentName))
            {
                failedFields.Add("departament name");
                isFailed = true;
            }
            if (isFailed)
            {
                String failedFieldsPart = "";
                for(int i = 0;i<failedFields.Count-1;i++)
                {
                    failedFieldsPart += failedFields[i] + ", ";
                }
                failedFieldsPart += failedFields[failedFields.Count - 1];
                throw new Exception("Invalid " + failedFieldsPart + " provided");
            }
            manager.ID = IDPointer;
            IDPointer++;
            staff.Add(manager);
        }
        public void AddEmployee(Employee employee)
        {
            if (staff.Contains(employee))
            {
                throw new Exception("This record already exist");
            }
            List<String> failedFields = new List<String>();
            bool isFailed = false;
            if (!validator.isValidName(employee.Name))
            {
                failedFields.Add("name");
                isFailed = true;
            }
            if (!validator.isValidName(employee.LastName))
            {
                failedFields.Add("last name");
                isFailed = true;
            }
            if (!validator.isValidYearOfBirth(employee.YearOfBirth))
            {
                failedFields.Add("year of birth");
                isFailed = true;
            }
            if (!validator.isValidPhoneNumber(employee.PhoneNumber))
            {
                failedFields.Add("phone number");
                isFailed = true;
            }
            if (!validator.isValidName(employee.ManagerName))
            {
                failedFields.Add("manager name");
                isFailed = true;
            }
            if (isFailed)
            {
                String failedFieldsPart = "";
                for (int i = 0; i < failedFields.Count - 1; i++)
                {
                    failedFieldsPart += failedFields[i] + ", ";
                }
                failedFieldsPart += failedFields[failedFields.Count - 1];
                throw new Exception("Invalid " + failedFieldsPart + " provided");
            }
            employee.ID = IDPointer;
            IDPointer++;
            staff.Add(employee);
        } 
        public void DeleteByID(int ID)
        {
            StaffMember member = staff.Find(x => x.ID == ID);
            if (member == null)
            {
                throw new Exception("No record found for id");
            }
            staff.Remove(member);
        }
        public void SortByLastName()
        {
            staff = staff.OrderBy(x => x.LastName).ToList();
        }
        public void SortByName()
        {
            staff = staff.OrderBy(x => x.Name).ToList();
        }
        public void SortByNumber()
        {
            staff = staff.OrderBy(x => x.PhoneNumber).ToList();
        }
        public void SortByYearOfBirth()
        {
            staff = staff.OrderBy(x => x.YearOfBirth).ToList();
        }
    }
}

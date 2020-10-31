using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_1_notebook.Exceptions;

namespace Task_1_notebook
{
    /// <summary>
    /// Implements methods for validation
    /// </summary>
    class NotebookControl
    {
        JsonFileHandler fileHandler = new JsonFileHandler("notebook.json");
        List<StaffMember> staff;
        Validator validator = new Validator();
        int IDPointer;
        public NotebookControl()
        {
            staff = fileHandler.GetStaffMembers();
            if (staff.Count==0)
            {
                IDPointer = 0;
            }
            else
            {
                IDPointer = staff.Max(x => x.ID) + 1;
            }
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
            return result;
        }
        public List<StaffMember> GetByLastName(string lastName)
        {
            List<StaffMember> result = staff.FindAll(x => x.LastName == lastName);
            return result;
        }
        public List<StaffMember> GetByPhoneNumber(string phoneNumber)
        {
            List<StaffMember> result = staff.FindAll(x => x.PhoneNumber == phoneNumber);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        public void AddManager(Manager manager)
        {
            if (staff.Find(x => (x.Name == manager.Name && x.LastName == manager.LastName)) != null)
            {
                throw new ValidationException("This record already exist");
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
                throw new ValidationException("Invalid " + failedFieldsPart + " provided");
            }
            manager.ID = IDPointer;
            IDPointer++;
            staff.Add(manager);
        }
        public void AddEmployee(Employee employee)
        {
            if (staff.Find(x=>(x.Name==employee.Name && x.LastName == employee.LastName))!=null)
            {
                throw new ValidationException("This record already exist");
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
            if (!validator.isValidNameAndLastName(employee.ManagerName))
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
                throw new ValidationException("Invalid " + failedFieldsPart + " provided");
            }
            Manager manager = new Manager();
            manager = (Manager)staff.Find(x => x.GetType().Name == "Manager"
            && (((Manager)x).LastName + " " + ((Manager)x).Name == employee.ManagerName));
            if (manager==null)
            {
                throw new IntegrityViolationException("There is no manager record with this name");
            }
            employee.ID = IDPointer;
            manager.AssignedEmployees.Add(employee.ID);
            IDPointer++;
            staff.Add(employee);
        } 
        public StaffMember FindByID(int ID)
        {
            return staff.Find(x=>x.ID==ID);
        }
        public void DeleteByID(int ID)
        {
            StaffMember member = staff.Find(x => x.ID == ID);
            if (member == null)
            {
                throw new ValidationException("No record found for id");
            }
            if((member.GetType().Name=="Manager") && (((Manager)member).AssignedEmployees.Count!=0))
            {
                throw new IntegrityViolationException("There are employees assigned to this manager", ((Manager)member).AssignedEmployees);
            }
            staff.Remove(member);
        }
        public void SortByLastName()
        {
            staff = staff.OrderBy(x => x.LastName).ToList();
            staff.Reverse();
        }
        public void SortByName()
        {
            staff = staff.OrderBy(x => x.Name).ToList();
            staff.Reverse();
        }
        public void SortByYearOfBirth()
        {
            staff = staff.OrderBy(x => x.YearOfBirth).ToList();
        }
    }
}

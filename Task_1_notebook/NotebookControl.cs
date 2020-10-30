using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_notebook
{
    class NotebookControl
    {
        JsonFileHandler fileHandler = new JsonFileHandler("notebook.json");
        List<StaffMember> staff;
        Validator validator = new Validator();
        public NotebookControl()
        {
            staff = fileHandler.GetStaffMembers();
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
        public List<StaffMember> GetBylastName(string lastName)
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
            staff.Add(manager);
        }
    }
}

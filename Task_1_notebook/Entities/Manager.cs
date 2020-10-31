using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task_1_notebook
{
    [DataContract]
    class Manager : StaffMember
    {
        [DataMember]
        public List<int> AssignedEmployees { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
        public Manager()
        {
            AssignedEmployees = new List<int>();
        }

        public Manager(string lastName, string name, string phoneNumber, string departmentName, int yearOfBirth) : base(lastName, name, phoneNumber, yearOfBirth)
        {
            this.DepartmentName = departmentName;
            AssignedEmployees = new List<int>();
        }
        
        public override string ToString()
        {
            return base.ToString() + $" {DepartmentName}";
        }
    }
}

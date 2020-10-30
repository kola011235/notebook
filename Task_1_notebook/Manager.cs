using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task_1_notebook
{
    [DataContract]
    class Manager : StaffMember
    {
        public Manager()
        {
        }

        public Manager(string lastName, string name, string phoneNumber, string departmentName, int yearOfBirth) : base(lastName, name, phoneNumber, yearOfBirth)
        {
            this.DepartmentName = departmentName;
        }
        [DataMember]
        public string DepartmentName { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" {DepartmentName}";
        }
    }
}

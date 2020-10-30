using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task_1_notebook
{
    [DataContract]
    class Employee : StaffMember
    {

        public Employee(string lastName, string name, string phoneNumber, string managerName):base(lastName,name,phoneNumber)
        {
            ManagerName = managerName;
        }
        [DataMember]
        public string ManagerName { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" {ManagerName}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task_1_notebook
{
    [KnownType(typeof(Manager))]
    [KnownType(typeof(Employee))]
    [DataContract]
    abstract class StaffMember
    {
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        protected StaffMember()
        {
        }
        protected StaffMember(string lastName, string name, string phoneNumber)
        {
            this.LastName = lastName;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $"{Name} {LastName} {PhoneNumber}";
        }
    }
}

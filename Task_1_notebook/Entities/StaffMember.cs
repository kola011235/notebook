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
        public int ID { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int YearOfBirth { get; set; }
        protected StaffMember()
        {
        }
        protected StaffMember(string lastName, string name, string phoneNumber, int yearOfBirth)
        {
            this.LastName = lastName;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.YearOfBirth = yearOfBirth;
        }
        public override string ToString()
        {
            return $"{ID} {this.GetType().Name} {Name} {LastName} {YearOfBirth} {PhoneNumber}";
        }
    }
}

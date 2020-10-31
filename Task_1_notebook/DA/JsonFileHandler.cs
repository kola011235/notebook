using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Task_1_notebook
{
    /// <summary>
    /// Implements methods for load and save a list of records via json file
    /// </summary>
    class JsonFileHandler
    {
        private string fileName;

        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<StaffMember>));

        public JsonFileHandler(string fileName)
        {
            this.fileName = fileName;
        }

        public List<StaffMember> GetStaffMembers()
        {
            var file = new FileStream(fileName, FileMode.OpenOrCreate);
            List<StaffMember> staff;
            if (file.Length==0)
            {
                staff = new List<StaffMember>();
            }
            else
            {
                staff = (List<StaffMember>)jsonFormatter.ReadObject(file);
            }
            file.Close();
            return staff;
        }
        public void SaveStuffMembers(List<StaffMember> staff)
        {
            var file = new FileStream(fileName, FileMode.Create);
            jsonFormatter.WriteObject(file, staff);
            file.Close();
        }
    }
}

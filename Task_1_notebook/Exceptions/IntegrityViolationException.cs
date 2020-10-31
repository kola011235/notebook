using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_notebook.Exceptions
{
    class IntegrityViolationException : Exception
    {
        public List<int> AffectedRowsIDs;
        public IntegrityViolationException(string message) : base(message) { }
        public IntegrityViolationException(string message, List<int> affectedRowsIDs) : base(message) 
        {
            AffectedRowsIDs = affectedRowsIDs;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_notebook
{
    class ValidationException :Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}

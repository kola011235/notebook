using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_notebook.Exceptions
{
    class WrongAmountOfArgumentsException : Exception
    {
        public WrongAmountOfArgumentsException(string message) : base(message) { }
    }
}

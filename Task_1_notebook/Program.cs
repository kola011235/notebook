using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Task_1_notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NotebookControl notebook = new NotebookControl();
            notebook.AddManager(new Manager("last2", "name", "+71111111111", "departament"));
        }
    }
}

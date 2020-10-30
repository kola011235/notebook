using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace Task_1_notebook
{
    class Program
    {
        static NotebookControl notebook = new NotebookControl();
        static void LoadShowPart()
        {
            bool k = true;
            while (k)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to show all, 2 to find by name, 3 to find by last name, 4 to find by phone number, 0 to go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        if (notebook.GetAll() == null)
                        {
                            Console.WriteLine("Notebook is empty");
                        }
                        else
                        {
                            foreach (var item in notebook.GetAll())
                            {
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine("Press Enter to go back...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.Clear();
                        if (notebook.GetByName(name) == null)
                        {
                            Console.WriteLine("There is no record with this name");
                        }
                        else
                        {
                            foreach (var item in notebook.GetByName(name))
                            {
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine("Press Enter to go back...");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Enter last name:");
                        name = Console.ReadLine();
                        Console.ReadLine();
                        if (notebook.GetByLastName(name) == null)
                        {
                            Console.WriteLine("There is no record with this last name");
                        }
                        else
                        {
                            foreach (var item in notebook.GetByLastName(name))
                            {
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine("Press Enter to go back...");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Enter phone number:");
                        string number = Console.ReadLine();
                        Console.Clear();
                        if (notebook.GetByPhoneNumber(number) == null)
                        {
                            Console.WriteLine("There is no record with this phone number");
                        }
                        else
                        {
                            foreach (var item in notebook.GetByLastName(number))
                            {
                                Console.WriteLine(item);
                            }
                        }
                        Console.WriteLine("Press Enter to go back...");
                        Console.ReadLine();
                        break;
                    case "0":
                        {
                            k = false;
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input provided, try again...");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
        static void LoadSortPart()
        {
            bool k = true;
            while (k)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to sort by name, 2 to sort by year of birth, 0 to go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        notebook.SortByLastName();
                        Console.WriteLine("Successfully sorted!");
                        Console.WriteLine("Press Enter to go back...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        notebook.SortByNumber();
                        Console.WriteLine("Successfully sorted!");
                        Console.WriteLine("Press Enter to go back...");
                        Console.ReadLine();
                        break;
                    case "0":
                        {
                            k = false;
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input provided, try again...");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }
        static void LoadEditPart()
        {
            bool k = true;
            while (k)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to add, 2 to delete, 0 to go back");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        bool p = true;
                        while (p)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter member type (employee or manager)");
                            try
                            {
                                string input = Console.ReadLine();
                                if (input == "employee")
                                {
                                    Employee employee;
                                    Console.Clear();
                                    Console.WriteLine("Enter last name, name, phone number, manager name and year of birth");
                                    string[] info = Console.ReadLine().Split(' ');
                                    if (info.Length != 5)
                                    {
                                        throw new Exception("wrong amount of arguments provided");
                                    }
                                    employee = new Employee(info[0], info[1], info[2], info[3], int.Parse(info[4]));
                                    notebook.AddEmployee(employee);
                                    Console.WriteLine("Successfuly added!");
                                    Console.WriteLine("Press Enter to go back...");
                                    p = false;
                                }
                                else if (input == "manager")
                                {
                                    Manager manager;
                                    Console.Clear();
                                    Console.WriteLine("Enter last name, name, phone number, departament name and year of birth");
                                    string[] info = Console.ReadLine().Split(' ');
                                    if (info.Length != 5)
                                    {
                                        throw new Exception("wrong amount of arguments provided");
                                    }
                                    manager = new Manager(info[0], info[1], info[2], info[3], int.Parse(info[4]));
                                    notebook.AddManager(manager);
                                    Console.WriteLine("Successfuly added!");
                                    Console.WriteLine("Press Enter to go back...");
                                    p = false;
                                }
                                else
                                {
                                    Console.WriteLine("wrong type provided");
                                    Console.WriteLine("Press enter to go back...");
                                    Console.ReadLine();
                                }
                            }
                            catch (System.FormatException e)
                            {
                                Console.WriteLine("wrong year format");
                                Console.WriteLine("Press enter to go back...");
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press enter to go back...");
                                Console.ReadLine();
                            }
                        }
                        
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        notebook.SortByNumber();
                        Console.WriteLine("Successfully sorted!");
                        Console.WriteLine("Press Enter to go back...");
                        Console.ReadLine();
                        break;
                    case "0":
                        {
                            k = false;
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input provided, try again...");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }//not finished
        static void Main(string[] args)
        {
            bool k = true;
            while (k)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to show or find, 2 to sort, 3 to edit, 0 to save and exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        LoadShowPart();
                        break;
                    case "2":
                        Console.Clear();
                        LoadSortPart();
                        break;
                    case "3":
                        Console.Clear();
                        LoadEditPart();
                        break;
                    case "0":
                        Console.Clear();
                        notebook.Save();
                        Console.WriteLine("Successfully saved!");
                        Console.WriteLine("Shutting down...");
                        Thread.Sleep(1500);
                        k = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong iput provided, try again...");
                        Thread.Sleep(1500);
                        break;

                }
            }  
        }
    }
}

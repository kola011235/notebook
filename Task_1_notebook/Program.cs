using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using Task_1_notebook.Exceptions;

namespace Task_1_notebook
{
    class Program
    {
        static NotebookControl notebook = new NotebookControl();
        static private void LoadShowPart()
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
                        if (notebook.GetAll().Count==0)
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
                        if (notebook.GetByName(name).Count == 0)
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
                        if (notebook.GetByLastName(name).Count == 0)
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
                        if (notebook.GetByPhoneNumber(number).Count == 0)
                        {
                            Console.WriteLine("There is no record with this phone number");
                        }
                        else
                        {
                            foreach (var item in notebook.GetByPhoneNumber(number))
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
                        Console.WriteLine("Wrong input provided, press Enter and try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static private void LoadSortPart()
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
                        notebook.SortByYearOfBirth();
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
                        Console.WriteLine("Wrong input provided, press Enter try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static private void LoadEditPart()
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
                            Console.WriteLine("Enter member type (employee or manager) or enter 0 to go back");
                            try
                            {
                                string input = Console.ReadLine();
                                switch (input)
                                {
                                    case "employee":
                                        Employee employee;
                                        Console.Clear();
                                        Console.WriteLine("Enter last name, name, phone number, manager last name, name and employee year of birth");
                                        string[] info = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                                        if (info.Length != 6)
                                        {
                                            throw new WrongAmountOfArgumentsException("wrong amount of arguments provided");
                                        }
                                        employee = new Employee(info[0], info[1], info[2], info[3] + " " + info[4], int.Parse(info[5]));
                                        notebook.AddEmployee(employee);
                                        Console.WriteLine("Successfuly added!");
                                        Console.WriteLine("Press Enter to go back...");
                                        Console.ReadLine();
                                        p = false;
                                        break;
                                    case "manager":
                                        Manager manager;
                                        Console.Clear();
                                        Console.WriteLine("Enter last name, name, phone number, departament name and year of birth");
                                        info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                        if (info.Length != 5)
                                        {
                                            throw new WrongAmountOfArgumentsException("wrong amount of arguments provided");
                                        }
                                        manager = new Manager(info[0], info[1], info[2], info[3], int.Parse(info[4]));
                                        notebook.AddManager(manager);
                                        Console.WriteLine("Successfuly added!");
                                        Console.WriteLine("Press Enter to go back...");
                                        p = false;
                                        Console.ReadLine();
                                        break;
                                    case "0":
                                        p = false;
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.WriteLine("wrong type provided");
                                        Console.WriteLine("Press enter to go back...");
                                        Console.ReadLine();
                                        break;
                                }
                            }
                            catch (System.FormatException e)
                            {
                                Console.WriteLine("wrong year format");
                                Console.WriteLine("Press enter to go back...");
                                Console.ReadLine();
                            }
                            catch (WrongAmountOfArgumentsException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press enter to go back...");
                                Console.ReadLine();
                            }
                            catch (IntegrityViolationException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("You must add manager first");
                                Console.WriteLine("Press enter to go back...");
                                Console.ReadLine();
                            }
                            catch(ValidationException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Press enter to go back...");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter ID:");
                        try
                        {
                            int ID = int.Parse(Console.ReadLine());
                            Console.WriteLine("Are you sure you want to delete this record? y/n");
                            Console.WriteLine(notebook.FindByID(ID));
                            if (Console.ReadLine() == "y")
                            {
                                notebook.DeleteByID(ID);
                                Console.WriteLine("Successfully deleted!");
                            }
                            else
                            {
                                Console.WriteLine("deletion canceled");
                            }                       
                            Console.WriteLine("Press Enter to go back...");
                            Console.ReadLine();
                        }
                        catch (System.FormatException e)
                        {
                            Console.WriteLine("wrong ID format provided");
                            Console.WriteLine("Press enter to go back...");
                            Console.ReadLine();
                        }
                        catch(ValidationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch(IntegrityViolationException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine($"{e.AffectedRowsIDs.Count} affected:");
                            foreach(var item in e.AffectedRowsIDs)
                            {
                                Console.WriteLine(notebook.FindByID(item));
                            }
                            Console.WriteLine("You must delete this employees first");
                            Console.WriteLine("Press enter to go back...");
                            Console.ReadLine();

                        }
                        break;
                    case "0":
                        {
                            k = false;
                            Console.Clear();
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input provided, press Enter and try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        
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
                        Console.WriteLine("Wrong iput provided, press Enter and try again...");
                        Console.ReadLine();
                        break;

                }
            }  
        }
    }
}

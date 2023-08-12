using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker
{

    class Programmer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Level { get; set; }
    }

    class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Dependency { get; set; }
        public string Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public int ProgrammerId { get; set; }
        public Status Status { get; set; } = Status.New;
    }

    enum Status
    {
        New,
        OnHold,
        InProgress,
        Completed,
        Recurring
    }

    internal class Program
    {
       static List<Programmer> programmers = new List<Programmer>();
       static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add Programmer");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. View Programmer's Tasks");
                Console.WriteLine("4. Update Task Status");
                Console.WriteLine("5. View All Tasks");
                Console.WriteLine("6. View All Programmers");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");


                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProgrammer();
                        break;
                    case 2:
                        AddTask();
                        break;
                    case 6:
                        ViewProgrammers();
                        break;
                    case 7:
                        exit = true; 
                        break;
                    default:
                        Console.WriteLine("Invalid Choice. Please Try Again");
                        break;

                }

            }
        }

        private static void AddTask()
        {

            // take user inputs
            Console.Write("Enter Task Name: ");
            string taskName = Console.ReadLine();

            Console.Write("Enter Dependency: ");
            string dependency = Console.ReadLine();

            Console.Write("Enter Comment: ");
            string comment = Console.ReadLine();

            Console.Write("Enter Start Date (yyyy-MM-dd): "); 
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Expected End Date (yyyy-MM-dd): ");
            DateTime expectedEndDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Programmer Id: ");
            int programmerId = int.Parse(Console.ReadLine());

            ///Check is programmer exist

            if (!ProgrammerExists(programmerId))
            {
                Console.WriteLine("Programmer does not exist.");
                return;
            }

            //Generate TaskID
            int taskId = tasks.Count + 1;

            //Create new task object
            var taskToAdd = new Task
            {
                TaskId = taskId,
                TaskName = taskName,
                Dependency = dependency,
                Comment = comment,
                StartDate = startDate,
                ExpectedEndDate = expectedEndDate,
                ProgrammerId = programmerId,
                Status = Status.New
            };

            //add created task to Task List
            tasks.Add(taskToAdd);

            Console.WriteLine("Task added successfully.");


        }

        private static void ViewProgrammers()
        {
            if (programmers.Count < 1)
            {
                Console.WriteLine("List is Empty");
            }
            else
            {
                Console.WriteLine("List of Programmer");
                Console.WriteLine("________________________________________________________");
                Console.WriteLine();
                foreach (var item in programmers)
                {
                    Console.WriteLine("Id : " + item.Id + " Name : " + item.Name + " Role: " + item.Role);
                }
                Console.WriteLine("________________________________________________________");
                Console.WriteLine();
            }
            
        }

        private static void AddProgrammer()
        {
            //collect user input
            Console.Write("Enter Programmer Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Role: ");
            string role = Console.ReadLine();
            Console.Write("Enter Level: ");
            string level = Console.ReadLine();

            int Id = programmers.Count + 1;

            var programmmerData = new Programmer { Id = Id, Name = name, Level = level, Role = role };

            programmers.Add(programmmerData);

            Console.WriteLine("Programmer added successfully.");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine();
            //save
        }


        static bool ProgrammerExists(int programmerId)
        {
            return programmers.Any(p => p.Id == programmerId);

            //foreach (var item in programmers)
            //{
            //    if (item.Id != programmerId)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        return true;
            //    }

            //}

            //return false;
        }

    }
}

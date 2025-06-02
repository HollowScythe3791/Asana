using Asana.Library.Models;
using System;

namespace Asana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var toDos = new List<ToDo>();
            var projects = new List<Project>();
            int choiceInt;
            int priorityChoiceInt;
            var todoCount = 0;
            
            var projectCount = 0;
            var todoChoice = 0;
            var projectChoice = 0;

            Console.WriteLine("Welcome to AsanaLike!");
            Console.WriteLine("To add Todos to Project, Create a ToDo, " +
                "Create a Project, then add the Todo to a project\n");
            do
            {
                Console.WriteLine("Choose a menu option:");
                Console.WriteLine("1. Create a ToDo");
                Console.WriteLine("2. List all ToDos");
                Console.WriteLine("3. List all outstanding ToDos");
                Console.WriteLine("4. Delete a ToDo");
                Console.WriteLine("5. Update a ToDo\n");

                Console.WriteLine("6. Create a Project");
                Console.WriteLine("7. Delete a Project");
                Console.WriteLine("8. Update a Project");
                Console.WriteLine("9. List all Projects");
                Console.WriteLine("10. Exit");

                var choice = Console.ReadLine() ?? "10";

                if (int.TryParse(choice, out choiceInt))
                {
                    switch (choiceInt)
                    {
                        case 1: // Create a ToDo
                            Console.Write("Name:");
                            var todoName = Console.ReadLine();
                            Console.Write("Description:");
                            var todoDescription = Console.ReadLine();
                            Console.Write("Priority:\n");
                            Console.Write(" 0. None\n");
                            Console.Write(" 1. Low\n");
                            Console.Write(" 2. Medium\n");
                            Console.Write(" 3. High\n");
                            var priorityChoice = Console.ReadLine() ?? "0";
                            if (!(int.TryParse(priorityChoice, out priorityChoiceInt)))
                            {
                                priorityChoiceInt = 0;
                            }

                            toDos.Add(new ToDo 
                            { 
                                Name = todoName,
                                Description = todoDescription,
                                Priority = priorityChoiceInt,
                                IsComplete = false,
                                Id = ++todoCount,
                                ProjectId = null,
                            });
                            break;
                        case 2: // List all ToDos
                            toDos.ForEach(Console.WriteLine);
                            break;
                        case 3: // List all outstanding Todos
                            toDos.Where(t => (t != null) && !(t?.IsComplete ?? false))
                                .ToList()
                                .ForEach(Console.WriteLine);
                            break;
                        case 4: // Delete a Todo
                            toDos.ForEach(Console.WriteLine);
                            Console.Write("ToDo to Delete: ");
                            todoChoice = int.Parse(Console.ReadLine() ?? "0");

                            var reference = toDos.FirstOrDefault(t => t.Id == todoChoice);
                            if (reference != null)
                            {
                                toDos.Remove(reference);
                            }
                            
                            break;
                        case 5: // Update a ToDo
                            toDos.ForEach(Console.WriteLine);
                            Console.Write("ToDo to Update: ");
                            todoChoice = int.Parse(Console.ReadLine() ?? "0");
                            var updateReference = toDos.FirstOrDefault(t => t.Id == todoChoice);

                            if(updateReference != null)
                            {
                                Console.Write("Name:");
                                updateReference.Name = Console.ReadLine();
                                Console.Write("Description:");
                                updateReference.Description = Console.ReadLine();
                            }
                            break;
                        case 6: // Create a Project
                            Console.Write("Name:");
                            var projectName = Console.ReadLine();
                            Console.Write("Description:");
                            var projectDescription = Console.ReadLine();

                            projects.Add(new Project { 
                                Name = projectName,
                                Description = projectDescription,
                                Id = ++projectCount});
                      
                            break;
                        case 7: // Delete a Project

                            projects.ForEach(Console.WriteLine);
                            Console.Write("Project to Delete: ");
                            projectChoice = int.Parse(Console.ReadLine() ?? "0");

                            var projectReference = projects.FirstOrDefault(t => t.Id == projectChoice);
                            if (projectReference != null)
                            {
                                projects.Remove(projectReference);
                            }
                            
                            break;
                        case 8: // Update a Project
                            projects.ForEach(Console.WriteLine);
                            Console.Write("Project to Update: ");
                            projectChoice = int.Parse(Console.ReadLine() ?? "0");
                            var projectUpdateReference = projects.FirstOrDefault(t => t.Id == projectChoice);

                            if(projectUpdateReference != null)
                            {
                                Console.Write("Name:");
                                projectUpdateReference.Name = Console.ReadLine();
                                Console.Write("Description:");
                                projectUpdateReference.Description = Console.ReadLine();
                            }
                            break;

                        case 9: // List all Project
                            projects.ForEach(Console.WriteLine);
                            break;
                        case 10:
                            break;
                        default:
                            Console.WriteLine("ERROR: Unknown menu selection");
                            break;
                    }
                } else
                {
                    Console.WriteLine($"ERROR: {choice} is not a valid menu selection");
                }

            } while (choiceInt != 10);

        }
    }
}
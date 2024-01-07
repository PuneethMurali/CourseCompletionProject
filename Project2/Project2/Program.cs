using System;
using System.IO;

namespace Project2
{
    class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassSection { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "teachers.txt";

            
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. View Teachers");
                Console.WriteLine("3. Update Teacher");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher(filePath);
                        break;
                    case 2:
                        ViewTeachers(filePath);
                        break;
                    case 3:
                        UpdateTeacher(filePath);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void AddTeacher(string filePath)
        {
            
            Teacher teacher = new Teacher();
            Console.WriteLine("Enter Teacher ID:");
            teacher.ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Teacher Name:");
            teacher.Name = Console.ReadLine();
            Console.WriteLine("Enter Teacher Class and Section:");
            teacher.ClassSection = Console.ReadLine();

            
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{teacher.ID},{teacher.Name},{teacher.ClassSection}");
            }

            Console.WriteLine("Added successfully");
        }

        static void ViewTeachers(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File is empty");
                return;
            }

            
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                Console.WriteLine($"ID: {data[0]}, Name: {data[1]}, Class & Section: {data[2]}");
            }
        }

        static void UpdateTeacher(string filePath)
        {
            Console.WriteLine("Enter Teacher ID to update:");
            int teacherId = int.Parse(Console.ReadLine());

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Data is empty");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            bool found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                if (int.Parse(data[0]) == teacherId)
                {
                    Console.WriteLine("Enter updated details:");
                    Console.WriteLine("Enter Teacher Name:");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Enter Teacher Class and Section:");
                    string newClassSection = Console.ReadLine();

                    lines[i] = $"{teacherId},{newName},{newClassSection}";
                    found = true;
                    break;
                }
            }

            if (found)
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Updated successfully");
            }
            else
            {
                Console.WriteLine("No data");
            }
        }
    }
}

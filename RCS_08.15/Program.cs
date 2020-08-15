using System;
using System.Collections.Generic;

namespace RCS_08._15
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskEx();
        }

        static void TaskEx()
        {
            List<string> a = new List<string>();
            string fileName = "Test.txt";
            UserMenu(a, fileName);
        }
       
        static void PrintList(List<string> a)
        {        
            if (a != null)
            {
                Console.WriteLine("No     | Text");
                for (int i = 0; i < a.Count; i++)
                {
                    Console.WriteLine("{0}      | {1}", (i+1), a[i]);
                }    
            }                       
        }

        static void UserMenu(List<string> a, string fileName)
        {
            string userChoice = null;
            while (userChoice != "Q")
            {
                userChoice = UserAction();

                switch (userChoice)
                {
                    case "1":
                        AddString(a);
                        break;
                    case "2":
                        EditString(a);
                        break;
                    case "3":
                        DeleteString(a);
                        break;
                    case "4":
                        Console.Write("Input file name:");
                        fileName = Console.ReadLine() + ".txt";
                        a = null;
                        a = FileIO.Read(fileName);
                        break;
                    case "5":
                        FileIO.Write(a, fileName);
                        break;
                    case "6":
                        SaveAs(a, ref fileName);
                        break;
                    case "7":
                        a = null;
                        break;
                    case "Q":
                        //FileIO.Write(a, fileName);
                        break;
                    default:
                        Console.WriteLine("Incorrect input.\n");
                        break;
                }
                PrintList(a);
            }
        }

        static string UserAction()
        {
            Console.Write("\nAllowed actions: ");
            Console.WriteLine("\n1 - add string\n" +
                "2 - edit string\n" +
                "3 - delete string\n" +
                "4 - load text\n" +
                "5 - save text\n" +
                "6 - save AS text\n" +
                "7 - new document\n" +
                "q - exit\n");
            Console.Write("Make your choice: ");

            return Console.ReadLine().ToUpper();
        }

        static void AddString(List<string> a)
        {
            Console.Write("Input string: ");
            string textStr = Console.ReadLine();
            a.Add(textStr);
            Console.WriteLine();
        }

        static void EditString(List<string> a)
        {
            int row = InputCheck(a);
            Console.Write("Input new string: ");
            string textStr = Console.ReadLine();
            a[row-1] = textStr;
        }

        static void DeleteString(List<string> a)
        {            
            int row = InputCheck(a);
            a.RemoveAt(row - 1);
        }

        static int InputCheck(List<string> a)
        {
            bool correctInput = false;
            string textStr;
            do
            {
                Console.Write("Input number of menu string to delete / edit: ");
                textStr = Console.ReadLine();

                for (int i = 0; i < a.Count; i++)
                {
                    if (textStr == Convert.ToString(i + 1))
                        correctInput = true;
                }
            }
            while (!correctInput);
            return Convert.ToInt32(textStr);
        }

        static void SaveAs(List<string> a, ref string fileName)
        {
            Console.Write("Input file name:");
            fileName = Console.ReadLine() + ".txt";
            FileIO.Write(a, fileName);
        }

    }
}

using Assignment.Models;
using Assignment.Models.DataModels;
using System;

namespace Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new DataContext();
            int userInput = 1;

            while (userInput != 0) 
            {
                Console.Clear();
                Console.WriteLine("-------------------- Online Payment Gateway ------------------------");
                Console.WriteLine("Please select below option to continue");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice:");
                userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput) 
                {
                    case 1:
                        AccountTrangactions(context);
                        break;

                    case 2:
                        AddUser(context);
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("You entered wrong option.");
                        break;
                }
            }

            
        }

        public static void AccountTrangactions(DataContext context) 
        {
            int userInput = 1;
            if (getConnect(context))
            {
                while (userInput != 0)
                {
                    Console.Clear();
                    Console.WriteLine("-------------- Account Transactions ----------------------------");
                    Console.WriteLine("Please select bolow option to continue");
                    Console.WriteLine("1. Deposite money");
                    Console.WriteLine("2. Withdraw money");
                    Console.WriteLine("3. Transfer money");
                    Console.WriteLine("0. Exit section");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine(userInput);
                            break;
                        case 2:
                            Console.WriteLine(userInput);
                            break;
                        case 3:
                            Console.WriteLine(userInput);
                            break;
                        case 4:
                            Console.WriteLine(userInput);
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("You entered wrong option");
                            break;
                    }
                }
            }
        }

        public static int AddUser(DataContext context)
        {
            string Name = null;
            string Username = null;
            string Password = null;

            Console.Clear();
            Console.WriteLine("----------- Add User Section ------------");
            Console.WriteLine("Enter Your Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Your Username:");
            Username = Console.ReadLine();
            Console.WriteLine("Enter Your Password:");
            Password = Console.ReadLine();

            User user = new User { UserId = context.Users.Count() + 1, Name = Name, UserName = Username, Password = Password };

            context.Add(user);
            return context.SaveChanges();
        }

        public static bool getConnect(DataContext context) 
        {
        startAgain:
            string userName = null;
            string password = null;
            Console.Clear();
            Console.WriteLine("------------------------- User Login --------------------------");
            Console.WriteLine("Enter you username");
            userName = Console.ReadLine();
            Console.WriteLine("Enter you password");
            password = Console.ReadLine();

            var user = context.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            else 
            {
                Console.WriteLine("Username or Password Incorrent");
                Console.WriteLine("Do you want to login again, if yes then press 1 ...");
                if (Convert.ToInt32(Console.ReadLine()) == 1) {
                    goto startAgain;
                 }
            }
            return false;
        }
    }
}
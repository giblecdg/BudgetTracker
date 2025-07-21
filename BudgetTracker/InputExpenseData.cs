using BudgetTracker.Core.Enums;

namespace BudgetTracker
{
    public class InputExpenseData
    {
        public double AskForAmount()
        {
            Console.Clear();

            while (true)
            {
                Console.Write("Enter an amount: ");

                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    return amount;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter an correct amount.");
                }
            }
        }
        public string AskForDescription()
        {
            Console.Clear();

            while (true)
            {
                Console.Write("Enter an description: ");
                string description = Console.ReadLine();

                if (description.Length > 0)
                {
                    return description;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter an description.");
                }
            }
        }
        public ExpenseCategory AskForCategory()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Choose category:");
                Console.WriteLine("1. Food");
                Console.WriteLine("2. Transport");
                Console.WriteLine("3. Entertainment");
                Console.WriteLine("4. Other");

                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        return ExpenseCategory.Food;
                    case "2":
                        return ExpenseCategory.Transport;
                    case "3":
                        return ExpenseCategory.Entertainment;
                    case "4":
                        return ExpenseCategory.Other;
                    default: 
                        Console.Clear();
                        break;
                }
            }
        }
        public DateTime AskForDate()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Please enter a date (press Enter for today)");
                Console.WriteLine("Date should be in format (DD/MM/YYYY)");

                Console.Write("Enter date: ");

                var userDate = Console.ReadLine();

                if (userDate == "")
                {
                    return DateTime.Now;
                }
                else
                {
                    if (DateTime.TryParse(userDate, out var date))
                    {
                        Console.Clear();
                        return date;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a correct date.");
                    }
                }
            }
        }
    }
}

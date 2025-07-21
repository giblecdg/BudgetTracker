using BudgetTracker.Core;
using BudgetTracker.Core.Enums;

namespace BudgetTracker
{
    public class BudgetTrackerApp
    {
        InputExpenseData InputExpenseData = new InputExpenseData();
        BudgetManager BudgetManager = new BudgetManager();
        public void ShowMenu()
        {
            BudgetManager.LoadExpensesData();

            while (true)
            {
                Console.WriteLine("--------------");
                Console.WriteLine("Budget Tracker");
                Console.WriteLine("--------------");

                Console.WriteLine();

                Console.WriteLine("1. Add a new expense");
                Console.WriteLine("2. Display all expenses");
                Console.WriteLine("3. Filter expenses");
                Console.WriteLine("4. Show summary");
                Console.WriteLine("5. Export data");
                Console.WriteLine("6. Save and exit");

                Console.WriteLine();

                Console.Write("Enter your choice: ");

                switch(Console.ReadLine())
                {
                    case "1":
                        AddNewExpense();
                        break;
                    case "2":
                        DisplayAllExpenses();
                        break;
                    case "3":
                        FilterExpenses();
                        break;
                    case "4":
                        ShowSumary();
                        break;
                    case "5":
                        ExportDataToFile();
                        break;
                    case "6":
                        Console.Clear();
                        SaveDataToFile();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter an correct option!");
                        break;
                }
            }
        }
        private void AddNewExpense()
        {
            double amount = InputExpenseData.AskForAmount();
            string description = InputExpenseData.AskForDescription();
            ExpenseCategory category = InputExpenseData.AskForCategory();
            DateTime date = InputExpenseData.AskForDate();

            Console.Clear();

            BudgetManager.AddNewExpenseToList(amount, description, category, date);

            Console.WriteLine($"Added: \nAmount: {amount:F2}$\nDescription: {description}\nCategory: {category}\nDate: {date.ToString("dd/MM/yyyy")}");
            Console.WriteLine();
        }
        private void DisplayAllExpenses()
        {
            Console.Clear();

            if (BudgetManager.expenses.Count > 0)
            {
                int expenseIndex = 1;
                Console.WriteLine("Expenses: ");

                foreach(Expense item in BudgetManager.expenses)
                {
                    Console.WriteLine($"{expenseIndex}. {item}");
                    expenseIndex++;
                }

                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You don't have any expenses to display.");
                return;
            }
        }
        private void FilterExpenses()
        {
            Console.Clear();

            if (BudgetManager.expenses.Count > 0)
            {
                var filteredExpenses = new List<Expense>();
                int expenseIndex = 1;

                while (true)
                {
                    Console.WriteLine("How do you want to filter your expenses?");
                    Console.WriteLine("1. Filter by category");
                    Console.WriteLine("2. Show expenses this month.");

                    Console.Write("Enter your choice: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            while (true)
                            {
                                Console.Clear();

                                Console.WriteLine("1. Filter by food");
                                Console.WriteLine("2. Filter by transport");
                                Console.WriteLine("3. Filter by entertainment");
                                Console.WriteLine("4. Filter by other");

                                Console.Write("Enter your choice: ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Console.Clear();
                                        filteredExpenses = BudgetManager.expenses.Where(e => e.Category == ExpenseCategory.Food).ToList();

                                        if (filteredExpenses.Count > 0)
                                        {
                                            Console.WriteLine("Category: Food");
                                            foreach (Expense item in filteredExpenses)
                                            {
                                                Console.WriteLine($"{expenseIndex}. {item}");
                                                expenseIndex++;
                                            }
                                            return;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("There is no expenses with Food category.");
                                            return;
                                        }
                                    case "2":
                                        filteredExpenses = BudgetManager.expenses.Where(e => e.Category == ExpenseCategory.Transport).ToList();

                                        if (filteredExpenses.Count > 0) {
                                            Console.Clear();

                                            Console.WriteLine("Category: Transport");
                                            foreach (Expense item in filteredExpenses)
                                            {
                                                Console.WriteLine($"{expenseIndex}. {item}");
                                                expenseIndex++;
                                            }
                                            return;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("There is no expenses with Transport category.");
                                            return;
                                        }
                                    case "3":
                                        filteredExpenses = BudgetManager.expenses.Where(e => e.Category == ExpenseCategory.Entertainment).ToList();

                                        if (filteredExpenses.Count > 0)
                                        {
                                            Console.Clear();

                                            Console.WriteLine("Category: Entertainment");
                                            foreach (Expense item in filteredExpenses)
                                            {
                                                Console.WriteLine($"{expenseIndex}. {item}");
                                                expenseIndex++;
                                            }
                                            return;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("There is no expenses with Entertainment category.");
                                            return;
                                        }
                                    case "4":
                                        filteredExpenses = BudgetManager.expenses.Where(e => e.Category == ExpenseCategory.Other).ToList();

                                        if (filteredExpenses.Count > 0)
                                        {
                                            Console.Clear();

                                            Console.WriteLine("Category: Other");
                                            foreach (Expense item in filteredExpenses)
                                            {
                                                Console.WriteLine($"{expenseIndex}. {item}");
                                                expenseIndex++;
                                            }
                                            return;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("There is no expenses with Other category.");
                                            return;
                                        }
                                    default:
                                            Console.Clear();
                                            Console.WriteLine("Please enter an correct option.");
                                            break;
                                        }
                                break;
                            }
                            break;
                        case "2":
                            Console.Clear();
                            filteredExpenses = BudgetManager.expenses.Where(e => e.Date.Month == DateTime.Now.Month && e.Date.Year == DateTime.Now.Year).ToList();

                            if(filteredExpenses.Count > 0)
                            {
                                Console.WriteLine($"Expenses {DateTime.Now.Month}.{DateTime.Now.Year}:");
                                foreach (Expense item in filteredExpenses)
                                {
                                    Console.WriteLine($"{expenseIndex}. {item}");
                                    expenseIndex++;
                                }
                                return;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("You don't have any expenses this month.");
                                return;
                            }
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter an correct option.");
                            break;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You don't have any expenses to filter.");
                return;
            }
        }
        private void ShowSumary()
        {
            Console.Clear();
            Console.WriteLine("Summary: ");
            Console.WriteLine();

            var foodExpenses = BudgetManager.expenses.Where(e => e.Category == ExpenseCategory.Food).ToList();
            var transportExpenses = BudgetManager.expenses.Where(e => e.Category == ExpenseCategory.Transport).ToList();
            var entertainmentExpenses = BudgetManager.expenses.Where(e => e.Category == ExpenseCategory.Entertainment).ToList();
            var OtherExpenses = BudgetManager.expenses.Where(e => e.Category == ExpenseCategory.Other).ToList();
            var thisMonthExpenses = BudgetManager.expenses.Where(e => e.Date.Month == DateTime.Now.Month).ToList();

            double totalAmountSpent = BudgetManager.expenses.Sum(e => e.Amount);
            double totalFoodSpent = foodExpenses.Sum(e => e.Amount);
            double totalTransportSpent = transportExpenses.Sum(e => e.Amount);
            double totalEntertainmentSpent = entertainmentExpenses.Sum(e => e.Amount);
            double totalOtherSpent = OtherExpenses.Sum(e => e.Amount);
            double totalThisMonthExpenses = thisMonthExpenses.Sum(e => e.Amount);

            Console.WriteLine($"Total amount spent: {totalAmountSpent}$");
            Console.WriteLine();
            Console.WriteLine($"Total amount spent on food: {totalFoodSpent}$");
            Console.WriteLine($"Total amount spent on transport: {totalTransportSpent}$");
            Console.WriteLine($"Total amount spent on entertainment: {totalEntertainmentSpent}$");
            Console.WriteLine($"Total amount spent on other: {totalOtherSpent}$");
            Console.WriteLine();
            Console.WriteLine($"Total amount spent this month: {totalThisMonthExpenses}$");
        }
        private void ExportDataToFile()
        {
            Console.Clear();
            if (BudgetManager.expenses.Count > 0)
            {
                while (true)
                {
                    Console.WriteLine("How you want to export your expenses?");
                    Console.WriteLine("1. .json");
                    Console.WriteLine("2. .csv");

                    Console.WriteLine();
                    Console.Write("Enter your choice: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            BudgetManager.SaveIntoJsonFile("expenses.json", "export");
                            Console.WriteLine("Saved into export/expenses.json");
                            return;
                        case "2":
                            Console.Clear();
                            BudgetManager.SaveIntoCsvFile(BudgetManager.expenses, "expenses.csv", "export");
                            Console.WriteLine("Saved into export/expenses.csv");
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter an correct option.");
                            break;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You don't have any expenses to export.");
                return;
            }
        }
        private void SaveDataToFile()
        {
            BudgetManager.SaveIntoJsonFile("expenses.json", "data");
        }
    }
}

using BudgetTracker.Core.Enums;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BudgetTracker.Core
{
    public class BudgetManager
    {
        public List<Expense> expenses = new List<Expense>();

        public void AddNewExpenseToList(double amount, string description, ExpenseCategory category, DateTime date)
        {
            expenses.Add(new Expense(amount, description, category, date));
        }
        public void SaveIntoJsonFile(string filePath, string folderPath)
        {
            Directory.CreateDirectory(folderPath);
            var finalFilePath = Path.Combine(folderPath, filePath);
            string json = JsonSerializer.Serialize(expenses);
            File.WriteAllText(finalFilePath, json);
        }
        public void SaveIntoCsvFile(List<Expense> expenses, string filePath, string folderPath)
        {
            Directory.CreateDirectory(folderPath);
            var finalFilePath = Path.Combine(folderPath, filePath);

            using (StreamWriter writer = new StreamWriter(finalFilePath))
            {
                writer.WriteLine("Amount ($),Description,Category,Date");

                foreach (var expense in expenses)
                {
                    string line = string.Join(",",expense.Amount.ToString("F2", CultureInfo.InvariantCulture),$"\"{expense.Description}\"",expense.Category.ToString(),expense.Date.ToString("dd-MM-yyyy"));

                    writer.WriteLine(line);
                }
            }
        }
        public void LoadExpensesData()
        {
            if (File.Exists("data/expenses.json"))
            {
                FileInfo fileInfo = new FileInfo("data/expenses.json");

                if (fileInfo.Length == 0)
                {
                    return;
                }
                try
                {
                    string json = File.ReadAllText("data/expenses.json");
                    expenses = JsonSerializer.Deserialize<List<Expense>>(json);
                }
                catch
                {
                    return;
                }
            }
        }
    }
}

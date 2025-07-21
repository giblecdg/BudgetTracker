using BudgetTracker.Core.Enums;

namespace BudgetTracker.Core
{
    public class Expense
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public ExpenseCategory Category { get; set; }
        public DateTime Date {  get; set; }

        public Expense()
        {
        }

        public Expense(double Amount, string Description, ExpenseCategory Category, DateTime Date)
        {
            this.Amount = Amount;
            this.Description = Description;
            this.Category = Category;
            this.Date = Date;
        }
        public override string ToString()
        {
            return $"{Amount:F2}$, Description: {Description}, Category: {Category}, Date: {Date.ToString("dd/MM/yyyy")}";
        }
    }
}

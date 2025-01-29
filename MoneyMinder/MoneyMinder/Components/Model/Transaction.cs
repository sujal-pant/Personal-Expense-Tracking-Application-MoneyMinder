public class Transaction
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; } // Must be set during initialization
    public required string Type { get; set; } // "Credit", "Debit", or "Debt"
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Notes { get; set; } = string.Empty; // Default to an empty string
    public string Tag { get; set; } = string.Empty;
    public string DebtSource { get; set; } = string.Empty; // For debts
    public DateTime? DueDate { get; set; } // Optional for debts
    public bool IsCleared { get; set; } = false; // For debts
    public decimal RemainingInflowAmount { get; set; } // New property to store remaining inflow value
    public decimal DebtAmount { get; set; } // New property for storing debt amount

}

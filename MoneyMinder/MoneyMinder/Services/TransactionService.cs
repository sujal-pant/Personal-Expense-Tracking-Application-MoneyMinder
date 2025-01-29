using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoneyMinder.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly string _filePath;
        private List<Transaction> _transactions = new();
        private readonly string _inflowFilePath;

        public TransactionService()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "transactions.json");
            _inflowFilePath = Path.Combine(FileSystem.AppDataDirectory, "cash_inflows.json");
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return _transactions;
        }

        public async Task<decimal> GetTotalInflowsAsync()
        {
            if (File.Exists(_inflowFilePath))
            {
                var json = await File.ReadAllTextAsync(_inflowFilePath);
                var inflows = JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
                return inflows.Sum(t => t.Amount);
            }
            return 0;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            var totalInflows = await GetTotalInflowsAsync();
            if (transaction.Type == "Debit" && transaction.Amount > totalInflows)
            {
                throw new InvalidOperationException("Insufficient funds! Your withdrawal amount exceeds the available inflows.");
            }

            _transactions.Add(transaction);
            await SaveToFileAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            var totalInflows = await GetTotalInflowsAsync();
            if (transaction.Type == "Debit" && transaction.Amount > totalInflows)
            {
                throw new InvalidOperationException("Insufficient funds! Your withdrawal amount exceeds the available inflows.");
            }

            var existing = _transactions.FirstOrDefault(t => t.Id == transaction.Id);
            if (existing != null)
            {
                _transactions.Remove(existing);
                _transactions.Add(transaction);
                await SaveToFileAsync();
            }
        }

        public async Task DeleteTransactionAsync(string id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction != null)
            {
                _transactions.Remove(transaction);
                await SaveToFileAsync();
            }
        }

        public async Task SaveToFileAsync()
        {
            var json = JsonSerializer.Serialize(_transactions);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task LoadFromFileAsync()
        {
            if (File.Exists(_filePath))
            {
                var json = await File.ReadAllTextAsync(_filePath);
                _transactions = JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int ProductId { get; set; }

        public string ActionType { get; set; }
        public int TransactionQuantity { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Transaction ID: {TransactionId}\n" +
                $"Product ID: {ProductId}\n" +
                $"Transaction Type: {ActionType}\n" +
                $"Quantity: {TransactionQuantity}\n" +
                $"Date: {Date}\n";
        }
    }
}

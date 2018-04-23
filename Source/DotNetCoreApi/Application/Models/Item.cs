namespace DotNetCoreApi.Application.Models
{
    using System;

    public class Item
    {
        public Item(string name, string sku, int quantity, decimal amount)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Sku = sku ?? throw new ArgumentNullException(nameof(sku));
            this.Quantity = quantity;
            this.Amount = amount;
        }

        public string Name { get; set; }

        public string Sku { get; set; } 

        public int Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}
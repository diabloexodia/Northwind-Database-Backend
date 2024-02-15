namespace WebApplication2.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }

        public string OrderID {  get; set; }
        public string ShipVia { get; set; }
        public string ShipCountry { get; set; } 
        public string productName {  get; set; }    
        public string Quantity { get; set; }    
        public string ShipName { get; set; }   
        public string UnitPrice { get; set; }   
        public string Total { get; set; }
        public string ProductID { get;  set; }

        public string OrderMonth { get; set; }
        public string OrderYear { get; set; }   
    }
}

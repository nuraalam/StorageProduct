namespace StorageProductApp
{
    class Product
    {
        public int ProductID { get; set; }
        public string code { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }

        public Product(string code, string name, double quantity)
        {
            this.code = code;
            Name = name;
            Quantity = quantity;
        }

        public Product()
        {
        }
    }
}
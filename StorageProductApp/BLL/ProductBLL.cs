using System.Collections.Generic;

namespace StorageProductApp
{
    class ProductBLL
    {
        ProductGateway aProductGateway = new ProductGateway();
        public string Save(Product aProduct)
        {
            if (CheeckLettersOfCode(aProduct))
                return "Code charachers must be three characters";
            if (CheckLettersOfName(aProduct))
                return "Name Character can not be less than five or more than ten";
            if (CheckProductCodeHasIntheStore(aProduct.code))
                return "Product Code is already Exist";
            if (CheckProductNameHasIntheStore(aProduct.Name))
                return "Product Name is already Exist";
            aProductGateway.Save(aProduct);
            return "Saved";

        }

        private bool CheckLettersOfName(Product aProduct)
        {
            int numberOfLettersOfName = 0;
            foreach (char letter in aProduct.Name)
            {
                numberOfLettersOfName++;
            }
            if (numberOfLettersOfName < 5 || numberOfLettersOfName > 10)
                return true;
            return false;

        }

        private bool CheeckLettersOfCode(Product aProduct)
        {
            int numberOfLettersOfCode = 0;
            foreach (char letter in aProduct.code)
            {
                numberOfLettersOfCode++;
            }
            if (numberOfLettersOfCode!=3)
            {
                return true;
            }
            return false;
        }

        private bool CheckProductCodeHasIntheStore(string code)
        {
            List<Product> allProducts = GetAllProduct();
            foreach (Product aProduct in allProducts)
            {
                if (aProduct.code == code)
                {
                    return true;
                }

            }
            return false;
        }
        private bool CheckProductNameHasIntheStore(string name)
        {
            List<Product> allProducts = GetAllProduct();
            foreach (Product aProduct in allProducts)
            {
                if (aProduct.Name == name)
                {
                    return true;
                }

            }
            return false;
        }

        public List<Product> GetAllProduct()
        {
            return aProductGateway.GetAllProduct();
        }

        public string GetTotalQuantity()
        {
            double totalQuantity = 0;
            List<double> quantityList = aProductGateway.GetProductQuantityList();
            foreach (double quantity in quantityList)
            {
               totalQuantity+=quantity;
            }
            return totalQuantity.ToString();
        }
    }
}
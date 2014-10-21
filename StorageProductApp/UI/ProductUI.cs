using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageProductApp
{
    public partial class ProductUI : Form
    {
        ProductBLL aProductBll = new ProductBLL();
        private Product aProduct;

        public ProductUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                aProduct = new Product(productCodeTextBox.Text, productNameTextBox.Text, Convert.ToDouble(quantityTextBox.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please insert the Quantity value accordingly.\nOnly numbers are allowed in this field.");
                return;
            }
           
            string msg=aProductBll.Save(aProduct);
            MessageBox.Show(msg);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            productListView.Items.Clear();
            List<Product>productList=aProductBll.GetAllProduct();
            foreach (Product aProduct in productList)
            {
                ListViewItem item=new ListViewItem(aProduct.code);
                item.SubItems.Add(aProduct.Name);
                item.SubItems.Add(aProduct.Quantity.ToString());
                productListView.Items.Add(item);
            }
            totalQuantityTextBox.Text = aProductBll.GetTotalQuantity();
        }
    }
}

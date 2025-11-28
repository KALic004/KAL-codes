using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;

        private BindingSource showProductList;

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
            {
            "Beverages",
            "Bread/Bakery",
            "Canned/Jarred Goods",
            "Dairy",
            "Frozen Goods",
            "Meat",
            "Personal Care",
            "Other"
            };

            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }
        
        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void btnAddProduct_Click(object sender, System.EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);

                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException sfe)
            {
                MessageBox.Show(sfe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NumberFormatException nfe)
            {
                MessageBox.Show(nfe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CurrencyFormatException cfe)
            {
                MessageBox.Show(cfe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
            {
                throw new StringFormatException("Invalid Product Name. Please enter a name with letters only.");
            }
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]+$"))
            {
                throw new NumberFormatException("Invalid Quantity. Please enter a number.");
            }
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price, @"^(\d*\.)?\d+$"))
            {
                throw new CurrencyFormatException("Invalid Selling Price. Please enter a valid currency format.");
            }
            return Convert.ToDouble(price);
        }

    }
    public class StringFormatException : Exception
    {
        public StringFormatException(string message) : base(message) { }
    }

    public class NumberFormatException : Exception
    {
        public NumberFormatException(string message) : base(message) { }
    }

    public class CurrencyFormatException : Exception
    {
        public CurrencyFormatException(string message) : base(message) { }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Product
    {


        private int _productId;
        public int ProductId
        {
            get => _productId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("ProductId must be greater than 0");
                }
                _productId = value;
            }
        }

        private int _categoryId;
        public int CategoryId
        {
            get => _categoryId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("CategoryId must be greater than 0");
                }
                _categoryId = value;
            }
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ProductName cannot be null or empty");
                }
                _productName = value.Trim();
            }
        }

        private string _weight;
        public string Weight
        {
            get => _weight;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weight cannot be null or empty");
                }
                _weight = value.Trim();
            }
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get => _unitPrice;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("UnitPrice cannot be negative");
                }
                _unitPrice = value;
            }
        }

        private int _unitsInStock;

        public int UnitsInStock
        {
            get => _unitsInStock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("UnitsInStock cannot be negative");
                }
                _unitsInStock = value;
            }
        }
    }
}

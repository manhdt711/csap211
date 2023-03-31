using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetail
    {
        private int _orderId;
        public int OrderId
        {
            get => _orderId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("OrderId must be greater than 0");
                }
                _orderId = value;
            }
        }

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

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity must be greater than 0");
                }
                _quantity = value;
            }
        }

        private decimal _discount;
        public decimal Discount
        {
            get => _discount;
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Discount must be between 0 and 1");
                }
                _discount = value;
            }
        }
    }
}

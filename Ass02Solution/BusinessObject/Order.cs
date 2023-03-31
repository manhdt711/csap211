using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Order
    {
        private int _orderId;
        public int OrderId
        {
            get => _orderId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("OrderId must be greater than 0");
                }
                _orderId = value;
            }
        }

        private int _memberID;
        public int MemberID
        {
            get => _memberID;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("MemberID must be greater than 0");
                }
                _memberID = value;
            }
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get => _orderDate;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("OrderDate cannot be in the future");
                }
                _orderDate = value;
            }
        }

        private DateTime _requiredDate;
        public DateTime RequiredDate
        {
            get => _requiredDate;
            set
            {
                if (value <= OrderDate)
                {
                    throw new ArgumentException("RequiredDate must be after OrderDate");
                }
                _requiredDate = value;
            }
        }

        private DateTime _shippedDate;
        public DateTime ShippedDate
        {
            get => _shippedDate;
            set
            {
                _shippedDate = value;
            }
        }

        private decimal _freight;
        public decimal Freight
        {
            get => _freight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Freight cannot be negative");
                }
                _freight = value;
            }
        }
    }
}

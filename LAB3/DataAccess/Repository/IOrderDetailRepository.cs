using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        void AddNew(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void Remove(int orderDetailId);
    }
}

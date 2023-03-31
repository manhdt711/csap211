using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrderList();
        Order GetOrderByID(int orderId);
        void AddNew(Order order);
        void Update(Order order);
        void Remove(int orderId);
        IEnumerable<Order> GetOrdersByMemberId(int memberId);
        IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId);
    }
}

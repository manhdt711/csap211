using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Order> GetOrderList()
        {
            var orders = new List<Order>();
            try
            {
                using var context = new PRN_Ass2Context();
                orders = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public Order GetOrderByID(int orderId)
        {
            Order order = null;
            try
            {
                using var context = new PRN_Ass2Context();
                order = context.Orders.SingleOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddNew(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order == null)
                {
                    using var context = new PRN_Ass2Context();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order != null)
                {
                    using var context = new PRN_Ass2Context();
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int orderId)
        {
            try
            {
                Order order = GetOrderByID(orderId);
                if (order != null)
                {
                    using var context = new PRN_Ass2Context();
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Order> GetOrdersByMemberId(int memberId)
        {
            var orders = new List<Order>();
            try
            {
                using var context = new PRN_Ass2Context();
                orders = context.Orders.Where(o => o.MemberId == memberId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using var context = new PRN_Ass2Context();
                orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }
    }
}

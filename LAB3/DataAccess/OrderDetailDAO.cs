using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public void AddNew(OrderDetail orderDetail)
        {
            try
            {
                using var context = new PRN_Ass2Context();
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailById(orderDetail.OrderId);
                if (_orderDetail != null)
                {
                    using var context = new PRN_Ass2Context();
                    context.OrderDetails.Update(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int orderDetailId)
        {
            try
            {
                OrderDetail orderDetail = GetOrderDetailById(orderDetailId);
                if (orderDetail != null)
                {
                    using var context = new PRN_Ass2Context();
                    context.OrderDetails.Remove(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderDetail GetOrderDetailById(int orderDetailId)
        {
            OrderDetail orderDetail = null;
            try
            {
                using var context = new PRN_Ass2Context();
                orderDetail = context.OrderDetails.SingleOrDefault(od => od.OrderId == orderDetailId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
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

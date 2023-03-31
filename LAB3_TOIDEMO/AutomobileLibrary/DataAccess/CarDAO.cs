using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDAO
    {
        //using singleton pattern
        private static CarDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CarDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new CarDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Car> GetCarList()
        {
            var cars = new List<Car>();
            try
            {
                using var context = new LAB3_TESTContext();
                cars = context.Cars.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }
        public Car GetCarByID(int carID)
        {
            Car car = null;
            try
            {
                using var context = new LAB3_TESTContext();
                car = context.Cars.SingleOrDefault(c => c.CarId == carID);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }
        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if(_car == null)
                {
                    using var context = new LAB3_TESTContext();
                    context.Cars.Add(car);
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if(_car != null)
                {
                    using var context = new LAB3_TESTContext();
                    context.Cars.Update(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int carID)
        {
            try
            {
                Car car = GetCarByID(carID);
                if(car != null)
                {
                    using var context = new LAB3_TESTContext();
                    context.Cars.Remove(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

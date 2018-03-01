using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sales.Models;

namespace Sales.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> List(); // GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddMultiple(IEnumerable<TEntity> entities); //  AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveMultiple(IEnumerable<TEntity> entities); // RemoveRange(IEnumerable<TEntity> entities);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> List()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddMultiple(IEnumerable<TEntity> entities) // AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveMultiple(IEnumerable<TEntity> entities) // RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }

    public interface ICustomerRepository : IRepository<Customer> 
    {
        IEnumerable<Customer> GetCustomersByName(string Name);
    }

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesDbContext context)
            : base(context)
        {
        }
        public IEnumerable<Customer> GetCustomersByName(string Name)
        {
            return Find(c => c.Name.StartsWith(Name));
        }
    }

    public interface IProductRepository : IRepository<Product> 
    {
        IEnumerable<Product> GetProductsByName(string Name);
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SalesDbContext context)
            : base(context)
        {
        }
        public IEnumerable<Product> GetProductsByName(string Name)
        {
            return Find(c => c.Name.StartsWith(Name));
        }
    }

    public interface IOrderRepository : IRepository<Order> 
    {
        IEnumerable<Order> GetOrdersByDate(DateTime date);
    }

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(SalesDbContext context)
            : base(context)
        {
        }
        public IEnumerable<Order> GetOrdersByDate(DateTime date)
        {
            return Find(c => c.OrderDate == date);
        }
    }

    public interface IOrderDetailRepository : IRepository<OrderDetail> 
    {
    }

    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(SalesDbContext context)
            : base(context)
        {
        }
    }
}
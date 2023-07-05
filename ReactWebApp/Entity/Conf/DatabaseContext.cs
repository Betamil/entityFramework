using Microsoft.EntityFrameworkCore;
using Category = ReactWebApp.Entity.Models.Category;
using Customer = ReactWebApp.Entity.Models.Customer;
using Employee = ReactWebApp.Entity.Models.Employee;
using EmployeeTerritorie = ReactWebApp.Entity.Models.EmployeeTerritorie;
using Order = ReactWebApp.Entity.Models.Order;
using OrderDetail = ReactWebApp.Entity.Models.OrderDetail;
using Product = ReactWebApp.Entity.Models.Product;
using Region = ReactWebApp.Entity.Models.Region;
using Shipper = ReactWebApp.Entity.Models.Shipper;
using Supplier = ReactWebApp.Entity.Models.Supplier;
using Territorie = ReactWebApp.Entity.Models.Territorie;

namespace ReactWebApp.Entity.Conf;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeTerritorie> EmployeeTerritories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<Territorie> Territories { get; set; }

    public string DbPath { get; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DatabaseContext()
    {
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=northwind.db");
}
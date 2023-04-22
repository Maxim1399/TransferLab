using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using TransferCo.Data.Entities;


namespace TransferCo.Data;
internal class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }

    public DbSet<Transporter> Transporters { get; set; }

    public DbSet<Order> Orders { get; set; }

    public AppDbContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data\\storage.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>()
            .HasData(GetInitialClient());

        modelBuilder.Entity<Transporter>()
            .HasData(GetInitialTransporter());

        modelBuilder.Entity<Order>()
            .HasData(GetInitialOrder());
    }

    private IEnumerable<Client> GetInitialClient()
    {
        var clinets = new List<Client>();
        return clinets;
    }

    private IEnumerable<Transporter> GetInitialTransporter()
    {
        var transporters = new List<Transporter>();
        return transporters;
    }

    private IEnumerable<Order> GetInitialOrder()
    {
        var orders = new List<Order>();
        return orders;
    }
}

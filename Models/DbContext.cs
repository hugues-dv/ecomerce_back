using System;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce_back.Models;
public class ProduitContext : DbContext
{

    public ProduitContext(DbContextOptions<ProduitContext> options) : base(options)
    {
    }

    public DbSet<Produit> Produits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=tcp:serveurtrellodb.database.windows.net,1433;Initial Catalog=testSiteEcomerce;Persist Security Info=False;User ID=Hugues;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
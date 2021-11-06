using Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AplicationContext : IdentityDbContext
    {
        public AplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>().HasOne(c => c.Categoria).WithMany(p => p.Produtos).HasForeignKey(c => c.CategoriaId);
            builder.Entity<Produto>().HasMany(v => v.Vendas).WithOne(p => p.Produto);
            builder.Entity<VendaProdutos>().HasKey(x => new { x.idVenda, x.IdProduto });
            builder.Entity<Categoria>().HasMany(p => p.Produtos).WithOne(c => c.Categoria);
            builder.Entity<Endereco>().HasOne(c => c.Cliente).WithOne(c => c.Endereco).HasForeignKey<Cliente>(e => e.EnderecoID);
            builder.Entity<Venda>().HasMany(v => v.Produtos).WithOne(p => p.vendas);
            base.OnModelCreating(builder);
        }


    }
}

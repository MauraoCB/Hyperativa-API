using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hyperativa_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hyperativa_API.Infra
{
    public class CartaoContext : DbContext
    {
        public virtual DbSet<CartaoInfo> CartaoInfo { get; set; }

        public CartaoContext()
        { }
        public CartaoContext(DbContextOptions<CartaoContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

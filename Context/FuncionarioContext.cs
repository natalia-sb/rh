using Microsoft.EntityFrameworkCore;
using rh.Models;

namespace Context
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Ferias> Ferias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ferias>()
                .HasOne(f => f.Funcionario)
                .WithMany()
                .HasForeignKey(f => f.FuncionarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

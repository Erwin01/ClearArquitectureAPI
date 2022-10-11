using CleanArquitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {


        #region [ Constructors ]
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #endregion



        #region [ Properties ]
        public virtual DbSet<Product> Products { get; set; }

        #endregion



        #region [ Method Creating And Configuring A Model ]
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {


            //base.OnModelCreating(modelBuilder)

            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .HasColumnName("Id");

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.Stock)
                      .HasColumnType("int");


                entity.Property(e => e.Price)
                      .HasColumnType("decimal"); ;
                      
            });
        }
        #endregion

    }
}

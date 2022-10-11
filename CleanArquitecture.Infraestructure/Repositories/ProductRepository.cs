using CleanArquitecture.Domain.Entities;
using CleanArquitecture.Domain.Interfaces;
using CleanArquitecture.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Infraestructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}

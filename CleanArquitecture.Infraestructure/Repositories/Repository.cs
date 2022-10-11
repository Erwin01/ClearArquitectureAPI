using CleanArquitecture.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Infraestructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly ApplicationDbContext applicationDbContext;
        protected DbSet<T> table;


        public Repository(ApplicationDbContext applicationDbContext = null)
        {
            this.applicationDbContext = applicationDbContext;
            this.table = applicationDbContext.Set<T>();
        }



        public async Task Save()
        {
            await applicationDbContext.SaveChangesAsync();
        }



        public virtual async Task SaveAsync() 
        {
            await applicationDbContext.SaveChangesAsync();
        }


        public virtual async Task<IEnumerable<T>> GetAll() 
        {
            return await Task.FromResult(table);
        }



        public virtual async Task<T> GetById(int id)
        {
            await Task.FromResult(id);
            return table.Find(id);
            
        }



        public virtual async Task Insert(T entity) 
        {
            await Task.CompletedTask;
            table.Add(entity);

        }




        public virtual async Task Update(T entityUpdate)
        {
            await Task.CompletedTask;
            applicationDbContext.Entry(entityUpdate).State = EntityState.Modified;

        }



        public virtual async Task Delete(object id) 
        {
            T entityDelete = table.Find(id);
            await Delete(entityDelete);
        }



        public virtual async Task Delete(T entityDelete) 
        {

            if (applicationDbContext.Entry(entityDelete).State == EntityState.Detached)
            {
                table.Attach(entityDelete);
            }

            table.Remove(entityDelete);
            await Task.CompletedTask;
        }



        public virtual Task<bool> Exists(object id)
        {

            var entity = table.Find(id);

            if (entity != null)
            {

                applicationDbContext.Entry(entity).State = EntityState.Detached;

                return Task.FromResult(true);

            }

            return Task.FromResult(false);

        }

    }
}

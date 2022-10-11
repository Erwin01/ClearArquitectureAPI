using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitecture.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {

        public Task Save();

        public Task SaveAsync();

        public Task <IEnumerable<T>> GetAll();

        public Task <T>GetById(int id);

        public Task Insert(T entity);

        public Task Update(T entityUpdate);

        public Task <bool>Exists(object id);

        public Task Delete(object id);

        public Task Delete(T entityDelete);


    }
}

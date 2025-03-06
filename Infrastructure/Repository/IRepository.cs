using Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepository
    {
        Task<Product> GetByIdAsync(int id );
        Task<IEnumerable<Product>> GetAllAsync(); 
        Task Add(Product item ); 
    }
}

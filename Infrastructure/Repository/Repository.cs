using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly SampleDB db;

        public Repository(SampleDB db)
        {
            this.db = db;
        }
        public async Task Add(Product item)
        {
             await db.AddAsync(item);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await db.Pruducts.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
          return  await db.Pruducts.FindAsync(id);
        }
    }
}

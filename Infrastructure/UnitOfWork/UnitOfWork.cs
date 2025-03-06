using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleDB _db;
        private  IRepository _repository;

        public UnitOfWork(SampleDB db)
        {
            this._db = db;
        }
        public IRepository repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new Repository.Repository(_db);
                }
                return _repository;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public int save()
        {
            return _db.SaveChanges();
        }
    }
}

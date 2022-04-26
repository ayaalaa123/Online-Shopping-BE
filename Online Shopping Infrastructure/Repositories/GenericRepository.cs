using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain;
using Online_Shopping_Domain.Entities;
using Online_Shopping_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Infrastructure.Repositories
{
   public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _unitOfWork.Context.Set<T>().Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
           
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Set<T>().Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
    }

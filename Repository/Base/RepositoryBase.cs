using LoghanAPI.Data;
using LoghanAPI.Models;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Services.UnitOfWork;
using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoghanAPI.Repository.Base
{
    public abstract class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<T>();
        }

        public async Task<ResultViewModel> Get()
        {
            var result = new ResultViewModel();
            try
            {
                var data = await _dbSet.ToListAsync();

                result.IsSuccess = true;
                result.Data = data;
                result.Message = "Success";

                return result;
            }
            catch (Exception e)
            {

                result.IsSuccess = false;
                result.Message = e.Message;

                return result;
            }
        }
        public async Task<ResultViewModel> Get(int id)
        {
            var result = new ResultViewModel();

            var existingOrder = await _dbSet.FindAsync(id);
            if (existingOrder == null)
            {
                result.IsSuccess = false;
                result.Message = "No matching records";
            }

            try
            { 
                result.IsSuccess = true;
                result.Data = existingOrder;
                result.Message = "Success";
                return result;
            }
            catch (Exception e)
            {

                result.IsSuccess = false;
                result.Message = e.InnerException.Message;
                return result;
            }
        }

        public async Task<ResultViewModel>Create(T entity)
        {
            var result = new ResultViewModel();
            try
            {
                _dbSet.Add(entity);
                await _unitOfWork.SaveChangesAsync();
                result.IsSuccess = true;
                result.Message = "Success Inserting Data";

                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess= false;
                result.Message = e.Message;

                return result;
            }
        }

        public async Task<ResultViewModel> Update(int Id, T entity)
        {
            var result = new ResultViewModel();

            var existingOrder = await _dbSet.FindAsync();
            if (existingOrder == null)
            {
                result.IsSuccess = false;
                result.Message = "No matching records";
            }

            try
            {

                _unitOfWork.Context.Entry(existingOrder).CurrentValues.SetValues(entity);

                try
                {
                    await _unitOfWork.SaveChangesAsync();

                    result.IsSuccess = true;
                    result.Message = "Success Updating Data";
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return result;
            }
            catch (Exception e)
            {

                result.IsSuccess = true;
                result.Message = e.Message;
                return result;
            }

        }

        public async Task<ResultViewModel> Delete(int id)
        {
            var result = new ResultViewModel();

            var existingOrder = await _dbSet.FindAsync(id);
            if (existingOrder == null)
            {
                result.IsSuccess = false;
                result.Message = "No matching records";
            }

            try
            {
                _dbSet.Remove(existingOrder);
                await _unitOfWork.SaveChangesAsync();

                result.IsSuccess = true;
                result.Message = "Success Deleting Records";
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

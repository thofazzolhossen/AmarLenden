﻿using AmarLenden.Interfaces;
using AmarLendenAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AmarLenden.Repositories
{
    public class BasicRepository<T> : IBasicRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BasicRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
    }
}

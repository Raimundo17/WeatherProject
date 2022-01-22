﻿using System.Linq;
using System.Threading.Tasks;

namespace WeatherProject.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(); //devolve uma lista de T, metodo que devolve todas as entidades

        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> ExistAsync(int id);
    }
}

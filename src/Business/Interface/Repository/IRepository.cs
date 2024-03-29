﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : Entity
    {
        Task<TEntity> ObterPorId(int id);
        Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate);
        
        Task<bool> Existe(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> ListarTodos();
        Task<List<TEntity>> Listar(Expression<Func<TEntity, bool>> predicate);

        Task Adicionar(TEntity entity);

        Task Editar(TEntity entity); 

        Task Remover(int id); 
        Task Remover(TEntity entity); 

        Task<int> SaveChanges();

    }
}

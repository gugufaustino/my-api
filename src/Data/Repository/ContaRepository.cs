using Business.Interface;
using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {

        }
    }
}

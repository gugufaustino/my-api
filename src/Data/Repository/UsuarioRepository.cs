using Business.Interface;
using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;

namespace Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {

        }

    }
}

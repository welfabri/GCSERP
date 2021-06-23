using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GCSERP.MVC.Dados
{
    public class DbContextIdentidade : IdentityDbContext
    {
        public DbContextIdentidade(DbContextOptions<DbContextIdentidade> options) : base(options)
        {
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GCS.ERP.Identidade.API.Dados
{
    public class DbContextIdentidade : IdentityDbContext
    {
        public DbContextIdentidade(DbContextOptions<DbContextIdentidade> options) : base(options)
        {
        }
    }
}

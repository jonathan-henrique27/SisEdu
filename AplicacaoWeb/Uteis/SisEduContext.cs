using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoWeb.Models.Model;
using Microsoft.EntityFrameworkCore;
namespace AplicacaoWeb.Uteis
{
    public class SisEduContext : DbContext
    {
        public SisEduContext(DbContextOptions<SisEduContext> options)
            : base(options)
        {
        }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }

    }
}

﻿using SGAL.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.AcessoDados
{
    public class SGALContext : DbContext
    {
        public SGALContext() : base()
        { }

        public SGALContext(string nameOrStringConnection) : base(nameOrStringConnection)
        { }

        public DbSet<LegooZer> LegooZers { get; set; }

        public DbSet<Peca> Pecas { get; set; }

        public DbSet<ItemMontagem> ItensMontagem { get; set; }

        public DbSet<Montagem> Montagens { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
    }
}

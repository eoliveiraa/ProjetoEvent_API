﻿using EventPlus_.Domains;
using EventPlus_.Domains.StringLenght;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Context
{

    public class Eventos_Context : DbContext
    {
        public Eventos_Context() 
        {
        }

        public Eventos_Context(DbContextOptions<Eventos_Context> options) : base(options) 
        {
        }

        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Instituicao> Instituicaos { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = NOTE10-S28\\SQLEXPRESS; Database = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");
            }
        }

    }
}

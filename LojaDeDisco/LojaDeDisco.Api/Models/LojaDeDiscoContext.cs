using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LojaDeDisco.Api.Models
{
	public class LojaDeDiscoContext : DbContext
	{
		public LojaDeDiscoContext()
			: base("LojaDeDisco")
		{
		}
		public DbSet<Autor> Autores { get; set; }
		public DbSet<Faixa> Faixas { get; set; }
		public DbSet<Filme> Filmes { get; set; }
		public DbSet<Genero> Generos { get; set; }
		public DbSet<Show> Shows { get; set; }
		public DbSet<Titulo> Titulos { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Entity<Genero>()
				.HasOptional(g => g.GeneroPai)
				.WithMany()
				.HasForeignKey(g => g.GeneroPaiId);
		}
	}
}
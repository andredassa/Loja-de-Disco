using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LojaDeDisco.Api.Models
{
	public class IniciarLojaDeDisco : System.Data.Entity.DropCreateDatabaseIfModelChanges<LojaDeDiscoContext>
	{
		protected override void Seed(LojaDeDiscoContext context)
		{
			List<Autor> Autores = new List<Autor>
			{
				new Autor{NomeAutor="Stanley Kubrick"},
				new Autor{NomeAutor="Steven Spielberg"},
				new Autor{NomeAutor="Black Sabath"},
				new Autor{NomeAutor="Mc Guime"},
				new Autor{NomeAutor="Ivete Sangalo"},
				new Autor{NomeAutor="Quentin Tarantino"},
				new Autor{NomeAutor="Mamonas Assassinas"},
				new Autor{NomeAutor="Beatles"},
				new Autor{NomeAutor="Rolling Stones"},
				new Autor{NomeAutor="John Whu"}
			};
			context.Autores.AddRange(Autores);
			//Autores.ForEach(s => context.Autores.Add(s));
			context.SaveChanges();

			List<Genero> Generos = new List<Genero>
			{
				new Genero{Nome="Rock"},
				new Genero{Nome="NoMusic"},
				new Genero{Nome="Axé"},
				new Genero{Nome="Ficção Cientifica"},
				new Genero{Nome="Drama"},
				new Genero{Nome="Ação"},
				new Genero{Nome="Comédia"},
				new Genero{Nome="Black Music"}
			};
			context.Generos.AddRange(Generos);
			context.SaveChanges();

			Generos = new List<Genero>
			{
				new Genero{Nome="Punk Rock", GeneroPai = context.Generos.FirstOrDefault(g => g.Nome == "Rock")},

			};
		}

	}
}
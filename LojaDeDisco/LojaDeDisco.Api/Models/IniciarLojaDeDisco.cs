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
				new Autor{NomeAutor="Black Sabbath"},
				new Autor{NomeAutor="Mc Guime"},
				new Autor{NomeAutor="Ivete Sangalo"},
				new Autor{NomeAutor="Quentin Tarantino"},
				new Autor{NomeAutor="Mamonas Assassinas"},
				new Autor{NomeAutor="Beatles"},
				new Autor{NomeAutor="Rolling Stones"},
				new Autor{NomeAutor="John Woo"}
			};
			context.Autores.AddRange(Autores);
			//Autores.ForEach(s => context.Autores.Add(s));
			context.SaveChanges();
			Autor black = context.Autores.FirstOrDefault(a => a.NomeAutor == "Black Sabbath");
			Autor mamonas = context.Autores.FirstOrDefault(a => a.NomeAutor == "Mamonas Assassinas");
			Autor beatles = context.Autores.FirstOrDefault(a => a.NomeAutor == "Beatles");
			Autor rolling = context.Autores.FirstOrDefault(a => a.NomeAutor == "Rolling Stones");
		
			Autores = new List<Autor>
			{
				new Autor{NomeAutor="Ozzy Osbourne, Tony Iommi, Geezer Butler, Bill Ward", AutorPaiId = black.Id},
				new Autor{NomeAutor="Dinho, Samuel Reis de Oliveira, Alberto Hinoto, Julio César Barbosa, Sergio Reis de Oliveira", AutorPaiId = mamonas.Id},
				new Autor{NomeAutor="Paul McCartney, John Lennon, Ringo Starr, George Harrison, Pete Best, Stuart Sutcliffe", AutorPaiId = beatles.Id},
				new Autor{NomeAutor="Mick Jagger, Keith Richards, Ron Wood, Charlie Watts", AutorPaiId = rolling.Id},

			};
				context.Autores.AddRange(Autores);
				context.SaveChanges();
			

			List<Genero> Generos = new List<Genero>
			{
				new Genero{Nome="Rock"},
				new Genero{Nome="NoMusic"},
				new Genero{Nome="Forró"},
				new Genero{Nome="Pop"},
				new Genero{Nome="Ficção Cientifica"},
				new Genero{Nome="Drama"},
				new Genero{Nome="Ação"},
				new Genero{Nome="Comédia"},
				new Genero{Nome="Black Music"}
			};
			context.Generos.AddRange(Generos);
			context.SaveChanges();
			Genero rock = context.Generos.FirstOrDefault(g => g.Nome == "Rock");
			Genero forro = context.Generos.FirstOrDefault(g => g.Nome == "Forró");
			Genero pop = context.Generos.FirstOrDefault(g => g.Nome == "Pop");

			Generos = new List<Genero>
			{
				new Genero{Nome="Punk Rock", GeneroPaiId = rock.Id},
				new Genero{Nome="Metal", GeneroPaiId = rock.Id},
				new Genero{Nome="Forró universitário", GeneroPaiId = forro.Id},
				new Genero{Nome = "Brit pop", GeneroPaiId = pop.Id},
				new Genero{Nome = "Girl Pop", GeneroPaiId = pop.Id},
				new Genero{Nome = "Divas", GeneroPaiId = pop.Id},
				new Genero{Nome = "Coutry pop", GeneroPaiId = pop.Id},
				new Genero{Nome = "Teen pop", GeneroPaiId = pop.Id}
			};
			context.Generos.AddRange(Generos);
			context.SaveChanges();

		}

	}
}
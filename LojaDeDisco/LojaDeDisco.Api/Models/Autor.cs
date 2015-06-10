using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDeDisco.Api.Models
{
	public class Autor
	{
		public int Id { get; set; }
		public string NomeAutor { get; set; }
		public List<Titulo> Titulos { get; set; }
	}
}
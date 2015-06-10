using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDeDisco.Api.Models
{
	public class Genero
	{
		public int id { get; set; }
		public string nome { get; set; }
		public int GeneroID { get; set; }
		public Genero GeneroPai { get; set; }
		public List<Titulo> Titulos { get; set; }
	}
}
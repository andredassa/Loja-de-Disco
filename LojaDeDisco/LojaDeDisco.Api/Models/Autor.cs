using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaDeDisco.Api.Models
{
	public class Autor
	{
		public int Id { get; set; }
		public string NomeAutor { get; set; }
		public int? AutorPaiId { get; set; }
		[ForeignKey("AutorPaiId")]
		public Autor AutorPai { get; set; }
		public List<Titulo> Titulos { get; set; }
		[InverseProperty("AutorPai")]
		public List<Autor> Filhos { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaDeDisco.Api.Models
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class Titulo
	{
		public int Id { get; set; }
		public string NomeTitulo { get; set; }
		public string Descricao { get; set; }
		public int GeneroId { get; set; }
		public Genero Genero { get; set; }
		public int AutorId { get; set; }
		public Autor Autor { get; set; }
	}
}

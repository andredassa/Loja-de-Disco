﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaDeDisco.Api.Models
{
	public class Genero
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int? GeneroPaiId { get; set; }
		[ForeignKey("GeneroPaiId")]
		public Genero GeneroPai { get; set; }
		public List<Titulo> Titulos { get; set; }
		[InverseProperty("GeneroPai")]
		public List<Genero> Filhos { get; set; }
	}
}
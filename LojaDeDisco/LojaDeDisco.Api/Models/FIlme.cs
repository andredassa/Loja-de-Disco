using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDeDisco.Api.Models
{
	public class FIlme : Titulo
	{
		public string Sinopse { get; set; }
		public string Elenco { get; set; }

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaDeDisco.Api.Models
{
	public class Faixa
	{
		public int Id { get; set; }
		public int Inicio { get; set; }
		public int Termino { get; set; }
		public int Numero { get; set; }
		public string Titulo { get; set; }
		public string HoraInicio
		{
			get
			{
				return TratarHorario(Inicio);
			}
		}
		public string HoraTermino
		{
			get
			{
				return TratarHorario(Termino);
			}
		}
		private string TratarHorario(int segundos)
		{
			int hor = segundos/3600;
			int min = (segundos - (hor * 3600)) / 60;
			int seg = segundos - hor * 3600 - min * 60;
			return hor.ToString("00") + ":" + min.ToString("00") + ":" + seg.ToString("00");
		}
	}
}

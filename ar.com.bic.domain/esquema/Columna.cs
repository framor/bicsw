using System;
using System.Collections;

namespace ar.com.bic.domain.esquema
{
	/// <summary>
	/// Descripci�n breve de Columna.
	/// </summary>
	public class Columna
	{
		private string nombre;
		private string tipo;

		public string Tipo
		{
			get {return this.tipo; }
			set {this.tipo = value;}
		}
		public string Nombre
		{
			get {return this.nombre; }
			set {this.nombre = value;}
		}

		public Columna(string nombre, string tipo)
		{
			this.nombre = nombre;
			this.tipo = tipo;
		}
	}
}
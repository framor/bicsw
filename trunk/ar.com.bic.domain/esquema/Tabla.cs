using System;
using System.Collections;

namespace ar.com.bic.domain.esquema
{
	/// <summary>
	/// Descripción breve de Tabla.
	/// </summary>
	public class Tabla
	{
		private string nombre;
		private IList columnas = new ArrayList();

		public IList Columnas
		{
			get {return new ArrayList(this.columnas); }
		}
		public string Nombre
		{
			get {return this.nombre; }
			set {this.nombre = value;}
		}

		public Tabla(string nombre)
		{
			this.nombre = nombre;
		}

		public void AgregarColumna(Columna col)
		{
			this.columnas.Add(col);
		}
	}
}

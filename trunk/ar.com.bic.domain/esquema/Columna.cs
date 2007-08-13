using System;
using System.Collections;

namespace ar.com.bic.domain.esquema
{
	/// <summary>
	/// Descripción breve de Columna.
	/// </summary>
	public class Columna
	{
		private string nombre;
		private string tipo;
		private ArrayList tablas = new ArrayList();

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

		public ArrayList Tablas
		{
			get {return this.tablas;}
		}
		
		public void AgregarTabla(Tabla tabla)
		{
			this.tablas.Add(tabla);
		}


		public Columna(string nombre, string tipo)
		{
			this.nombre = nombre;
			this.tipo = tipo;
		}
	}
}

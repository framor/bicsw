using System;
using System.Collections;
using Bic.Domain.Dao;

namespace Bic.Domain.Catalogo
{
	/// <summary>
	/// Una columna es una representación de una columna de la BD. 
	/// Tiene un nombre, un tipo. 
	/// </summary>
	public class Columna : IComparable
	{
		private long id;
		private string nombre;
		private string tipo;

		private Columna() {}

		public Columna(string nombre, string tipo)
		{
			this.nombre = nombre;
			this.tipo = tipo;
		}

		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public string Nombre
		{
			get {return this.nombre; }
		}

		public string Tipo
		{
			get {return this.tipo; }
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Columna)) return false; 
			return this.nombre.Equals(((Columna) obj).Nombre);
		}

		public override int GetHashCode()
		{
			return this.nombre.GetHashCode();
		}
		
		public int CompareTo(object obj)
		{
			Columna col = (Columna) obj;
			return this.nombre.CompareTo(col.Nombre);
		}
	}
}

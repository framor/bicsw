using System.Collections;
using Bic.Domain.Dao;
using Bic.Domain.Interfaces;
using Iesi.Collections;
using System;

namespace Bic.Domain.Catalogo
{
	/// Una tabla es una representación de una tabla de la BD. 
	/// Tiene un nombre y está compuesta por varias columnas. 
	public class Tabla : IComparable
	{
		private long id;
		private string alias;
		private string nombre;
		private string nombreBD;
		private int peso = 0;
		private Proyecto proyecto;
		private ISet columnas = new HashedSet();

		private Tabla() {}
		
		public Tabla(string alias, string nombre, string nombreBD)
		{
			this.alias = alias;
			this.nombre = nombre;
			this.nombreBD  = nombreBD;
		}
		public Tabla(string nombre, string nombreBD) : this(nombre, nombre, nombreBD) {}

		public Tabla(string alias, string nombre, string nombreBD, long id, Proyecto pr) : this(alias, nombre, nombreBD) 
		{
            this.id = id;
			this.Proyecto = pr;
		}

		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public ISet Columnas
		{
			get { return this.columnas; }
		}
		public void AgregarColumna(Columna col)
		{
			this.columnas.Add(col);
		}
		public string Alias
		{
			get {return this.alias; }
			set {this.alias = value;}
		}

		public string Nombre
		{
			get {return this.nombre; }
			set {this.nombre = value;}
		}

		public string NombreBD
		{
			get {return this.nombreBD; }
			set {this.nombreBD = value;}
		}

		public int Peso
		{
			get {return this.peso; }
			set {this.peso = value; }
		}

		public Proyecto Proyecto
		{
			get { return proyecto; }
			set {proyecto = value; }
		}

		/// <summary>
		/// Busca si tiene la columna
		/// </summary>
		/// <param name="mapeables"></param>
		/// <returns>True si la tabla tiene todos los campos, sino false.</returns>
		public bool Tenes(ICollection mapeables)
		{
			foreach(ITablaMapeable mapeable in mapeables)
			{
				if(!this.Tenes(mapeable))
					return false;
			}
			
			return true;
		}
		
		/// <summary>
		/// Busca la columna en la tabla
		/// </summary>
		/// <param name="mapeable"></param>
		/// <returns>True si tiene alguna columna con el mismo nombre</returns>
		public bool Tenes(ITablaMapeable mapeable)
		{
			return Tenes(mapeable.Columna);
		}

		/// <summary>
		/// Busca la columna en la tabla
		/// </summary>
		/// <param name="col"></param>
		/// <returns>True si tiene alguna columna con el mismo nombre</returns>
		public bool Tenes(Columna col)
		{
			return this.columnas.Contains(col);
		}

		public int CompareTo(object obj)
		{
			Tabla t = (Tabla) obj;
			return this.nombre.CompareTo(t.Nombre);
		}
	}
}

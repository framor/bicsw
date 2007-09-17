using System.Collections;
using ar.com.bic.domain.interfaces;
using Iesi.Collections;

namespace ar.com.bic.domain.catalogo
{
	/// Una tabla es una representación de una tabla de la BD. 
	/// Tiene un nombre y está compuesta por varias columnas. 
	public class Tabla
	{
		private long id;
		private string alias;
		private string nombre;
		private string nombreBD;
		private int peso = 0;
		private Proyecto proyecto;

		private Tabla() {}
		
		public Tabla(string alias, string nombre, string nombreBD)
		{
			this.alias = alias;
			this.nombre = nombre;
			this.nombreBD  = nombreBD;
		}
		public Tabla(string nombre, string nombreBD) : this(nombre, nombre, nombreBD) {}

		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public IList Columnas
		{
			get
			{
				// TODO: return mySQLDAO.GetColumnas()
				return new ArrayList();
			}
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
		public bool Tenes(IList mapeables)
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
			return this.Columnas.Contains(col);
		}
	}
}

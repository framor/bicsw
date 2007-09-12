using System.Collections;
using ar.com.bic.domain.interfaces;

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
		private IList columnas = new ArrayList();
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
			get {return new ArrayList(this.columnas); }
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

		public void AgregarColumna(Columna col)
		{
			this.columnas.Add(col);
		}

		public int Peso
		{
			get {return this.peso; }
			set {this.peso = value; }
		}

		public Proyecto Proyecto
		{
			get { return proyecto; }
			set { proyecto = value; }
		}

		/// <summary>
		/// Busca los campos en la lista de columnas.
		/// </summary>
		/// <param name="campo"></param>
		/// <returns>True si la tabla tiene todos los campos, sino false.</returns>
		public bool Tenes(IList campos)
		{
			foreach(ITablaMapeable campo in campos)
			{
				if(!this.Tenes(campo))
					return false;
			}
			
			return true;
		}
		
		/// <summary>
		/// Busca el campo en la lista de columnas.
		/// </summary>
		/// <param name="campo"></param>
		/// <returns>True si tiene alguna columna con el mismo nombre que
		/// el campo, sino false.</returns>
		public bool Tenes(ITablaMapeable campo)
		{
			
			IList columnas = campo.GetColumnas();

			foreach(Columna columna in columnas)
			{
				if(this.Columnas.Contains(columna))
					return true;
			}

			return false;
		}

	}
}

using System.Collections;

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
	}
}

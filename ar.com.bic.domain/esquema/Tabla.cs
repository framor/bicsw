using System;
using System.Collections;
using ar.com.bic.domain.interfaces;

namespace ar.com.bic.domain.esquema
{
	/// Una tabla es una representación de una tabla de la BD. 
	/// Tiene un nombre y está compuesta por varias columnas. 
	public class Tabla
	{
		private string alias;
		private string nombreTabla;
		private string nombreBD;
		private IList columnas = new ArrayList();

		public Tabla(string alias, string nombreTabla, string nombreBD)
		{
			this.alias = alias;
			this.nombreTabla = nombreTabla;
			this.nombreBD  = nombreBD;
		}
		public Tabla(string nombreTabla, string nombreBD) : this(nombreTabla, nombreTabla, nombreBD) {}

		public IList Columnas
		{
			get {return new ArrayList(this.columnas); }
		}
		public string Alias
		{
			get {return this.alias; }
			set {this.alias = value;}
		}

		public string NombreTabla
		{
			get {return this.nombreTabla; }
			set {this.nombreTabla = value;}
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

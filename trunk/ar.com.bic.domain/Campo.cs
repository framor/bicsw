using System.Collections;
using ar.com.bic.domain.catalogo;
using ar.com.bic.domain.interfaces;
using ar.com.bic.fwk;

namespace ar.com.bic.domain 
{
	/// <summary>
	/// Un campo es la unificación de todas las columnas que tienen el 
	/// mismo nombre en la BD. Por ej. en todo el catálogo pueden existir
	/// varias columnas llamadas nombre_id en distintas tablas, sin embargo
	/// solo existira un Campo para nombre_id. Esto permite que se pueda 
	/// obtener el dato de la tabla más conveniente.
	/// </summary>
	public class Campo : ITablaMapeable
	{
		private long id;
		private string nombre;
		private ArrayList columnas = new ArrayList();

		private Campo() {}

		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public string Nombre
		{
			get {return this.nombre; }
			set {this.nombre = value;}
		}
		/// <summary>
		/// Columnas que corresponden a este campo
		/// </summary>
		public IList Columnas
		{
			get {return new ArrayList(this.columnas);}
		}
		
		public IList Tablas
		{
			get
			{
				IList tablas = new ArrayList();
				foreach (Columna col in this.columnas)
				{
					tablas.Add(col.Tabla);
				}
				return Util.ConvertirSet(tablas);
			}
		}

		public void AgregarColumnas(Columna col)
		{
			this.columnas.Add(col);
		}


		public Campo(Columna col)
		{
			this.nombre = col.Nombre;
			this.columnas.Add(col);
		}

		public override bool Equals(object obj)
		{
			return this.nombre.Equals(((Campo) obj).Nombre);
		}
		public override int GetHashCode()
		{
			return this.nombre.GetHashCode ();
		}

		public IList GetTablas()
		{
			return this.Tablas;
		}

		public IList GetColumnas()
		{
			return this.Columnas;
		}

		public Campo GetCampo()
		{
			return this;
		}

	}
}

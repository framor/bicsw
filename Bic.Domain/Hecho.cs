using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Interfaces;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de Hecho.
	/// </summary>
	public class Hecho : ITablaMapeable
	{
		private long id;		
		private string nombre;
		private Columna columna;
		private Proyecto proyecto;

		public Hecho() {}

		public Hecho(string nombre, Columna columna)
		{
			this.nombre = nombre;
			this.columna = columna;
		}

		
		#region Metodos Publicos
		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public string Nombre
		{
			get { return this.nombre; }
			set { this.nombre = value; }
		}

		public IList ObtenerTablas()
		{
			return this.proyecto.ObtenerTablas(this.columna);
		}

		public Columna Columna
		{
			get { return this.columna; }
		}

		public string NombreColumna
		{
			get { return this.columna.Nombre; }
		}

		public Proyecto Proyecto
		{
			get { return this.proyecto; }
			set { this.proyecto = value; }
		}

		#endregion

	}
}

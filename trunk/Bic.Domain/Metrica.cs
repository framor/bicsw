using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Interfaces;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de Metrica.
	/// </summary>
	public class Metrica : ITablaMapeable
	{

		// TODO: esto esta acoplado con mysql. se podría usar un abstract factory para soportar otros motores...
		public static string PROMEDIO = "AVG({0})";
		public static string CANTIDAD = "COUNT({0})";
		public static string MAXIMO = "MAX({0})";
		public static string MINIMO = "MIN({0})";
		public static string SUMATORIA = "SUM({0})";

		#region Miembros privados
		
		private long id;
		private string nombre;
		private string funcion;
		private Hecho hecho;
		private Proyecto proyecto;
			
		#endregion

		public Metrica() {}

		public Metrica(string nombre, string funcion, Hecho hecho)
		{
			this.nombre = nombre;
			this.funcion = funcion;
			this.hecho = hecho;
		}

		#region Metodos Publicos
			
		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public IList ObtenerTablas()
		{
			return this.hecho.ObtenerTablas();
		}
		
		public Columna Columna
		{
			get { return this.hecho.Columna; }
		}

		public string Funcion
		{
			get { return this.funcion; }
			set { this.funcion = value; }
		}
		public string Nombre
		{
			get { return this.nombre; }
			set { this.nombre = value; }
		}
		public Hecho Hecho
		{
			get { return this.hecho; }
			set { this.hecho = value; }
		}
		public string NombreHecho
		{
			get { return this.hecho.Nombre; }
		}
		public Proyecto Proyecto
		{
			get { return this.proyecto; }
			set { this.proyecto = value; }
		}

		public string SQLExpression(string aliasFact)
		{
			return string.Format(this.funcion, aliasFact + '.' + this.Columna.Nombre);	

		}
		#endregion

	}
}

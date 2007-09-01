using System.Collections;
using ar.com.bic.domain.interfaces;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Metrica.
	/// </summary>
	public class Metrica : ITablaMapeable
	{

		#region Miembros privados
		
		private string nombre;
		private string funcion;
		private Hecho hecho;
			
		#endregion

		public Metrica(string nombre, string funcion, Hecho hecho)
		{
			this.nombre = nombre;
			this.funcion = funcion;
			this.hecho = hecho;
		}

		#region Metodos Publicos
			
		public IList GetTablas()
		{
			return this.hecho.GetTablas();
		}
		
		public Campo GetCampo()
		{
			return this.hecho.GetCampo();
		}

		public IList GetColumnas()
		{
			return this.hecho.GetColumnas();
		}


		#endregion

	}
}

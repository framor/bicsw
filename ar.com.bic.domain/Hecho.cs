using System.Collections;
using ar.com.bic.domain.interfaces;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Hecho.
	/// </summary>
	public class Hecho : ITablaMapeable
	{
		
		private string nombre;
		private Campo CampoHecho;

		public Hecho(string nombre, Campo campo)
		{
			this.nombre = nombre;
			this.CampoHecho = campo;
		}

		#region Metodos Publicos
			
		public IList GetTablas()
		{
			return this.CampoHecho.Tablas;
		}

		public Campo GetCampo()
		{
			return this.CampoHecho;
		}

		public IList GetColumnas()
		{
			return this.CampoHecho.GetColumnas();
		}

		#endregion

	}
}

using System.Collections;
using ar.com.bic.domain.catalogo;

namespace ar.com.bic.domain.interfaces
{
	/// <summary>
	/// Descripción breve de ITablaMapeable.
	/// </summary>
	public interface ITablaMapeable
	{
	
		IList ObtenerTablas();

		Columna Columna
		{
			get;
		}
		
	}
}

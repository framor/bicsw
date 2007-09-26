using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Domain.Interfaces
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

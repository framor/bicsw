using System;
using System.Collections;
using ar.com.bic.domain.esquema;

namespace ar.com.bic.domain.interfaces
{
	/// <summary>
	/// Descripción breve de ITablaMapeable.
	/// </summary>
	public interface ITablaMapeable
	{
	
		ArrayList GetTablas();

		Campo GetCampo();
		
	}
}

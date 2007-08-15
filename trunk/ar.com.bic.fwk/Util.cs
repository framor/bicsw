using System;
using System.Collections;

namespace ar.com.bic.fwk
{
	/// <summary>
	/// Descripción breve de Util.
	/// </summary>
	public class Util
	{	

		static public IList ConvertirSet(IList coleccion)
		{
			ArrayList salida = new ArrayList();
			foreach(Object elemento in coleccion)
			{
				if(!salida.Contains(elemento))
					salida.Add(elemento);
			}
			return salida;
		}
	}
}

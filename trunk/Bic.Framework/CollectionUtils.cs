using System;
using System.Collections;

namespace Bic.Framework
{
	/// <summary>
	/// Descripción breve de Util.
	/// </summary>
	public class CollectionUtils
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

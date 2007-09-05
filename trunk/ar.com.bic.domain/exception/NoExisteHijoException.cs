using System;

namespace ar.com.bic.domain.exception
{
	/// <summary>
	/// Descripción breve de NoExisteHijoException.
	/// </summary>
	public class NoExisteHijoException : Exception
	{
		public NoExisteHijoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public NoExisteHijoException(string mensaje,Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}

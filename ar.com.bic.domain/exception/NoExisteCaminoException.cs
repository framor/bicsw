using System;
using ar.com.bic.domain.catalogo;


namespace ar.com.bic.domain.exception
{
	/// <summary>
	/// Descripción breve de NoExisteCaminoException.
	/// </summary>
	public class NoExisteCaminoException : Exception
	{
		public NoExisteCaminoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public NoExisteCaminoException(string mensaje,Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}

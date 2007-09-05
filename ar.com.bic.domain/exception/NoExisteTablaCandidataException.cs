using System;

namespace ar.com.bic.domain.exception
{
	/// <summary>
	/// Descripción breve de TablaCandidataException.
	/// </summary>
	public class NoExisteTablaCandidataException : Exception
	{
		public NoExisteTablaCandidataException()
		{
		}

		public NoExisteTablaCandidataException(String mensaje): base(mensaje)
		{
			//TODO Escribir en la propiedad message
		}

	}
}

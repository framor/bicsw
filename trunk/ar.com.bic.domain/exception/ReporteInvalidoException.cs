using System;

namespace ar.com.bic.domain.exception
{
	/// <summary>
	/// Descripción breve de ReporteInvalidoException.
	/// </summary>
	public class ReporteInvalidoException : Exception
	{
		public ReporteInvalidoException()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public ReporteInvalidoException(String mensaje): base(mensaje)
		{
			//
			//TODO llamar a la superclase
			//
		}
	}
}

using System;

namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripción breve de ReporteInvalidoException.
	/// </summary>
	public class ReporteInvalidoException : System.Exception
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

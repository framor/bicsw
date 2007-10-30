namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripción breve de FiltroInvalidoException.
	/// </summary>
	public class FiltroInvalidoException : System.Exception
	{
		public FiltroInvalidoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public FiltroInvalidoException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}

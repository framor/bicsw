namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripción breve de NoExisteHijoException.
	/// </summary>
	public class NoExisteHijoException : System.Exception
	{
		public NoExisteHijoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		public NoExisteHijoException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}

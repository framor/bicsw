namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripción breve de NoExisteCaminoException.
	/// </summary>
	public class NoExisteCaminoException : System.Exception
	{
		public NoExisteCaminoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public NoExisteCaminoException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}

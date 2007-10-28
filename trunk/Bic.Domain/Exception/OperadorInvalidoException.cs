namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripción breve de OperadorInvalidoException.
	/// </summary>
	public class OperadorInvalidoException : System.Exception
	{
		public OperadorInvalidoException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public OperadorInvalidoException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}

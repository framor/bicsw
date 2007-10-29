namespace Bic.Domain.Exception
{
	/// <summary>
	/// Descripción breve de NoExisteCaminoException.
	/// </summary>
	public class ReferenciaCircularException : System.Exception
	{
		public ReferenciaCircularException(string mensaje): base(mensaje)
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ReferenciaCircularException(string mensaje, System.Exception ex): base(mensaje,ex)
		{
			//TODO Escribir en la propiedad message
		}
	}
}

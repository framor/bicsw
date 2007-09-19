namespace Bic.Framework.Exception
{
	/// <summary>
	/// Descripción breve de ServiceException.
	/// </summary>
	public class ServiceException : System.Exception
	{
		public ServiceException()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public ServiceException(string mensaje): base(mensaje)
		{}
	}
}

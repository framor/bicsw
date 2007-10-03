using System;

namespace Bic.WebControls
{
	/// <summary>
	/// Summary description for UnableToCreateHeaderException.
	/// </summary>
	public class UnableToCreateHeaderException : Exception
	{
		#region Constructor

		public UnableToCreateHeaderException()
		{}


		public UnableToCreateHeaderException(string mensaje): base(mensaje)
		{}


		#endregion		
	}
}

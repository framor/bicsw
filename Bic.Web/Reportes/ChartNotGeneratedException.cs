using System;

namespace Bic.Web
{
	/// <summary>
	/// Summary description for ChartNotGeneratedException.
	/// </summary>
	public class ChartNotGeneratedException: Exception
	{
		private string errorMessage;

		public ChartNotGeneratedException(string errorMessage)
		{
			this.errorMessage = errorMessage;
		}

		public override string Message
		{
			get
			{
				return "Imposible generar el grafico:" + errorMessage;
			}
		}

	}
}

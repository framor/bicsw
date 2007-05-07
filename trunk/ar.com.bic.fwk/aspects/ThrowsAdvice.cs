using System;
using Spring.Aop;

namespace ar.com.bic.fwk.spring
{
	/// <summary>
	/// Descripción breve de Class1.
	/// </summary>
	public class ThrowsAdvice : IThrowsAdvice
	{

		public void AfterThrowing(Exception ex)
		{
			Console.Error.WriteLine(
				String.Format("Advised method threw this exception : {0}", ex.Message));
		}

	}
}

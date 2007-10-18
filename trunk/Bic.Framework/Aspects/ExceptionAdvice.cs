#region Imports

using System;
using AopAlliance.Intercept;
using log4net;

#endregion

namespace Bic.Framework.Aspects
{
	public class ExceptionAdvice : IMethodInterceptor
	{
		#region Logging

		private static readonly ILog LOG = LogManager.GetLogger(typeof(ExceptionAdvice));

		#endregion


		#region IMethodInterceptor Members

		public object Invoke(IMethodInvocation invocation)
		{
			try 
			{
				return invocation.Proceed();
			} 
			catch (System.Exception ex)
			{
				LOG.Error(ex.Message);
				throw ex;
			}
		}

		#endregion

	}
}
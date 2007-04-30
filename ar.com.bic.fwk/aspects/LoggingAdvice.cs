#region Imports

using System;
using AopAlliance.Intercept;

#endregion

namespace ar.com.bic.fwk.aspects
{
	public class LoggingAdvice : IMethodInterceptor
	{
		#region Logging

		private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(typeof(LoggingAdvice));

		#endregion

		#region Members

		private string level = null;

		#endregion

		#region Properties

		public string Level
		{
			get { return level; }
			set { level = value; }
		}

		#endregion

		#region IMethodInterceptor Members

		public object Invoke(IMethodInvocation invocation)
		{
			Log(String.Format("Intercepted call : about to invoke method '{0}'", invocation.Method.Name));
			object returnValue = invocation.Proceed();
			Log(String.Format("Intercepted call : returned '{0}'", returnValue));
			return returnValue;
		}

		#endregion

		#region Private Methods

		private void Log(string text)
		{
			switch (level.ToLower())
			{
				case "debug":
					if (LOG.IsDebugEnabled) LOG.Debug(text);
					break;
				case "error":
					if (LOG.IsErrorEnabled) LOG.Error(text);
					break;
				case "fatal":
					if (LOG.IsFatalEnabled) LOG.Fatal(text);
					break;
				case "info":
					if (LOG.IsInfoEnabled) LOG.Info(text);
					break;
				case "warn":
					if (LOG.IsWarnEnabled) LOG.Warn(text);
					break;
				default:
					throw new ArgumentException(String.Format("Level '{0}' unknown.", level));
			}
		}

		#endregion
	}
}
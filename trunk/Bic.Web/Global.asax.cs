using System;
using System.ComponentModel;
using System.Web;
using log4net;
using log4net.Config;

namespace Bic.Web 
{
	/// <summary>
	/// Descripción breve de Global.
	/// </summary>
	public class Global : HttpApplication
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			XmlConfigurator.Configure();
			ILog log = LogManager.GetLogger(typeof(Global));
			log.Debug("Application started.");
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Código generado por el Diseñador de Web Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new Container();
		}
		#endregion
	}
}


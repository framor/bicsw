using System;
using Spring.Context;
using Spring.Context.Support;

namespace ar.com.bic.application
{
	/// <summary>
	/// Descripción breve de BICContext.
	/// </summary>
	public class BICContext
	{
		private static BICContext instance = new BICContext();
		public static BICContext Instance 
		{
			get { return instance; }
		}

		private IApplicationContext ctx;
		private BICContext()
		{
			this.ctx = ContextRegistry.GetContext();		
		}

		public UsuarioService UsuarioService 
		{
			get { return (UsuarioService)ctx["usuarioService"]; }
		}
	}
}

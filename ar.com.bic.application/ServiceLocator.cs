using System;

namespace ar.com.bic.application
{
	/// <summary>
	/// Descripción breve de ServiceLocator.
	/// </summary>
	public class ServiceLocator
	{
		private static ServiceLocator instance = new ServiceLocator();
		public static ServiceLocator Instance 
		{
			get { return instance; }
		}

		public ServiceLocator()
		{
			this.usuarioService = new UsuarioService();
		}

		private UsuarioService usuarioService;
		public UsuarioService UsuarioService 
		{
			get {return this.usuarioService; }
		}
	}
}

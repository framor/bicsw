using Spring.Context;
using Spring.Context.Support;

namespace Bic.Application
{
	/// <summary>
	/// BICContext es un service locator que expone los servicios a la capa de presentación.
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
			this.ctx = WebApplicationContext.Current;
		}

		/// <summary>
		/// Obtiene una implementación de UsuarioService
		/// </summary>
		public UsuarioService UsuarioService 
		{
			get { return (UsuarioService)ctx["usuarioService"]; }
		}

		/// <summary>
		/// Obtiene una implementación de ProyectoService
		/// </summary>
		public ProyectoService ProyectoService 
		{
			get { return (ProyectoService)ctx["proyectoService"]; }
		}

		/// <summary>
		/// Obtiene una implementación de AtributoService
		/// </summary>
		public AtributoService AtributoService 
		{
			get { return (AtributoService)ctx["atributoService"]; }
		}

		/// <summary>
		/// Obtiene una implementación de CatalogoService
		/// </summary>
		public CatalogoService CatalogoService 
		{
			get { return (CatalogoService)ctx["catalogoService"]; }
		}

		/// <summary>
		/// Obtiene una implementación de TablaService
		/// </summary>
		public TablaService TablaService 
		{
			get { return (TablaService)ctx["tablaService"]; }
		}

		/// <summary>
		/// Obtiene una implementación de HechoService
		/// </summary>
		public HechoService HechoService 
		{
			get { return (HechoService)ctx["hechoService"]; }
		}
	}
}

using Spring.Context;
using Spring.Context.Support;

namespace Bic.Domain.Dao
{
	/// <summary>
	/// Descripción breve de DAOLocator.
	/// </summary>
	public class DAOLocator
	{
		private static DAOLocator instance = new DAOLocator();
		public static DAOLocator Instance 
		{
			get { return instance; }
		}
		private IApplicationContext ctx;
		private DAOLocator()
		{			
			this.ctx = ContextRegistry.GetContext();
		}

		public ICatalogoDAO CatalogoDAO
		{
			get { return (ICatalogoDAO) ctx["catalogoDAO"]; }
		}

		public IProyectoDAO ProyectoDAO
		{
			get { return (IProyectoDAO) ctx["proyectoDAO"]; }
		}

		public IAtributoDAO AtributoDAO
		{
			get { return (IAtributoDAO) ctx["atributoDAO"]; }
		}

		public ITablaDAO TablaDAO
		{
			get { return (ITablaDAO) ctx["tablaDAO"]; }
		}

	}
}

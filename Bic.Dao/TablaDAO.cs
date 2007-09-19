using System.Collections;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;
using Spring.Data.NHibernate.Support;

namespace Bic.Dao
{
	/// <summary>
	/// Descripción breve de TablaDAO.
	/// </summary>
	public class TablaDAO : HibernateDaoSupport, ITablaDAO
	{
		public TablaDAO()
		{
		}

		/// <summary>
		/// Implementa ITablaDAO.ObtenerByNombre
		/// </summary>
		public Tabla ObtenerByAlias(long idProyecto, string alias)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Tabla).Name + " t where t.proyecto.id = ? and t.alias = ?", 
					new object[]{idProyecto, alias});
			if (ret != null && ret.Count > 0)
			{
				return (Tabla) ret[0];
			}
			return null;
		}

	}
}

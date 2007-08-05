using System;
using System.Collections;
using ar.com.bic.domain;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Support;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Descripción breve de ProyectoDAO.
	/// </summary>
	public class ProyectoDAO : HibernateDaoSupport
	{
		public ProyectoDAO()
		{
		}

		/// <summary>
		/// Obtiene los atributos para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Atributos</returns>
		public IList selectAtributos(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Atributo).Name + " a where a.proyecto.id = ?", proyectoId);
			return ret;
		}
	}
}

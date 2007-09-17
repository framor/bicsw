using System;
using System.Collections;
using ar.com.bic.domain;
using ar.com.bic.domain.catalogo;
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
		public IList SelectAtributos(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Atributo).Name + " a where a.proyecto.id = ?", proyectoId);
			return ret;
		}

		/// <summary>
		/// Obtiene los atributos para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Atributos</returns>
		public IList SelectTablas(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Tabla).Name + " t where t.proyecto.id = ?", proyectoId);
			return ret;
		}

		/// <summary>
		/// Obtiene los hechos para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Hechos</returns>
		public IList SelectHechos(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Hecho).Name + " a where a.proyecto.id = ?", proyectoId);
			return ret;
		}
	}
}

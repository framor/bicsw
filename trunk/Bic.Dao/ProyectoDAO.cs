using System.Collections;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;
using Spring.Data.NHibernate.Support;

namespace Bic.Dao
{
	/// <summary>
	/// Descripción breve de ProyectoDAO.
	/// </summary>
	public class ProyectoDAO : HibernateDaoSupport, IProyectoDAO
	{
		public ProyectoDAO()
		{
		}

		/// <summary>
		/// Implementa IProyectoDAO.SelectAtributos
		/// </summary>
		public IList SelectAtributos(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Atributo).Name + " a where a.proyecto.id = ?", proyectoId);
			return ret;
		}

		/// <summary>
		/// Implementa IProyectoDAO.SelectTablas
		/// </summary>
		public IList SelectTablas(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Tabla).Name + " t where t.proyecto.id = ?", proyectoId);
			return ret;
		}

		/// <summary>
		/// Implementa IProyectoDAO.SelectTablas
		/// </summary>
		public IList SelectTablas(long proyectoId, Columna col)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Tabla).Name + " t where t.proyecto.id = ?", proyectoId);
			return ret;
		}

		/// <summary>
		/// Implementa IProyectoDAO.SelectHechos
		/// </summary>
		public IList SelectHechos(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Hecho).Name + " a where a.proyecto.id = ?", proyectoId);
			return ret;
		}

		/// <summary>
		/// Implementa IProyectoDAO.SelectMetricas
		/// </summary>
		public IList SelectMetricas(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Metrica).Name + " a where a.proyecto.id = ?", proyectoId);
			return ret;
		}

		/// <summary>
		/// Implementa IProyectoDAO.SelectReportes
		/// </summary>
		public IList SelectReportes(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Reporte).Name + " r where r.proyecto.id = ?", proyectoId);
			return ret;
		}

		/// <summary>
		/// Implementa IProyectoDAO.SelectFiltros
		/// </summary>
		public IList SelectFiltros(long proyectoId)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Filtro).Name + " a where a.proyecto.id = ?", proyectoId);
			return ret;
		}

	}
}

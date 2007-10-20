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

		/// <summary>
		/// Implementa ITablaDAO.ObtenerByNombre
		/// </summary>
		public Tabla ObtenerByNombre(long proyId, string nombre)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Tabla).Name + " t where t.proyecto.id = ? and t.nombre = ?", 
				new object[]{proyId, nombre});
			if (ret != null && ret.Count > 0)
			{
				return (Tabla) ret[0];
			}
			return null;
		}

		/// <summary>
		/// Implementa ITablaDAO.ObtenerByNombre
		/// </summary>
		/// <param name="idProyecto"></param>
		/// <returns></returns>
		public IList SelectTablasParaHechos(long idProyecto)
		{			
			string hql = string.Format(
				@"select t from {0} t
					where t.proyecto = ? and t not in (select a.tablaLookup from {1} a where a.proyecto = ?)",
				typeof(Tabla).Name, typeof(Atributo).Name);
			return HibernateTemplate.Find(hql, new object[]{idProyecto, idProyecto});
		}

		/// <summary>
		/// Implementa ITablaDAO.SelectColumnasDisponibles
		/// </summary>
		public IList SelectColumnasParaHecho(long idProyecto)
		{
			IList tablas = SelectTablasParaHechos(idProyecto);
			ArrayList ret = new ArrayList();
			foreach (Tabla t in tablas) 
			{
				ret.AddRange(t.Columnas);
			}
			return ret;
		}

		/// <summary>
		/// Implementa ITablaDAO.SelectTablasDisponibles
		/// </summary>
		public IList SelectTablasDisponibles(long idProyecto)
		{			
			return HibernateTemplate.Find("from " + typeof(Tabla).Name + " t where t.proyecto = ?" , idProyecto);
		}

		/// <summary>
		/// Implementa ITablaDAO.SelectTablasConColumna
		/// </summary>
		public IList SelectTablasConColumna(long idProyecto, Columna col)
		{
			ArrayList ret = new ArrayList();
			//TODO: construir query hql
			IList tablas = SelectTablasDisponibles(idProyecto);
			foreach (Tabla t in tablas)
			{
				if (t.Columnas.Contains(col))
				{
					ret.Add(t);
				}
			}
			return ret;
		}
	}
}

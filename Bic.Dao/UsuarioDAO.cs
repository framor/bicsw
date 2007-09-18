using System.Collections;
using Bic.Domain.Dao;
using Bic.Domain.Usuario;
using Spring.Data.NHibernate.Support;

namespace Bic.Dao
{
	/// <summary>
	/// Descripción breve de UsuarioDAO.
	/// </summary>
	public class UsuarioDAO : HibernateDaoSupport, IUsuarioDAO
	{
		public UsuarioDAO()
		{
		}

		/// <summary>
		/// Implementa IUsuarioDAO.getByNombre
		/// </summary>
		public Usuario getByNombre(string nombre)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Usuario).Name + " where nombre = ?", nombre);
			if (ret != null && ret.Count > 0)
			{
				return (Usuario) ret[0];
			}
			return null;
		}
	}
}

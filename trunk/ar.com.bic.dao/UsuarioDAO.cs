using System.Collections;
using ar.com.bic.domain.usuario;
using Spring.Data.NHibernate.Support;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Descripción breve de UsuarioDAO.
	/// </summary>
	public class UsuarioDAO : HibernateDaoSupport
	{
		public UsuarioDAO()
		{
		}

		/// <summary>
		/// Obtiene un usuario por el nombre
		/// </summary>
		/// <param name="nombre">nombre de usuario</param>
		/// <returns>el usuario o null si no existe</returns>
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

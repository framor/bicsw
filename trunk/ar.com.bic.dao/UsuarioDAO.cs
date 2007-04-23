using System;
using Spring.Data.NHibernate.Support;
using ar.com.bic.domain;

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

		public void save(Usuario unUsuario) 
		{
			HibernateTemplate.SaveOrUpdate(unUsuario);
		}
		public Usuario retrieve(long id) 
		{			
			return (Usuario) HibernateTemplate.Get(typeof(Usuario), id);
		}

	}
}

using System;
using ar.com.bic.domain;
using NHibernate;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Descripción breve de UsuarioDAO.
	/// </summary>
	public class UsuarioDAO
	{
		public UsuarioDAO()
		{
		}

		public void save(Usuario unUsuario) 
		{
			ISession s = HibernateSessionHelper.Instance.Session;
			s.Save(unUsuario);
			s.Close();
		}
		public Usuario retrieve(long id) 
		{
			ISession s = HibernateSessionHelper.Instance.Session;
			Object obj = s.Get(typeof(Usuario), id);
			s.Close();
			return (Usuario) obj;
		}

	}
}

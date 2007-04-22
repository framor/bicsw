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

		public void Save(Usuario unUsuario) 
		{

			ISession s = HibernateSessionHelper.Instance.Session;
			// Tell NHibernate that this object should be saved
			s.Save(unUsuario);

			s.Close();
		}
	}
}

using System;
using ar.com.bic.domain;
using ar.com.bic.dao;

namespace ar.com.bic.application
{
	/// <summary>
	/// Descripción breve de UsuarioService.
	/// </summary>
	public class UsuarioService
	{
		private UsuarioDAO usuarioDAO;

		public UsuarioService()
		{
			this.usuarioDAO = new UsuarioDAO();
		}

		public void Save(Usuario unUsuario) 
		{
			this.usuarioDAO.Save(unUsuario);
		}
	}
}

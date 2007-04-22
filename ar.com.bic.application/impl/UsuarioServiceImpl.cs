using System;
using ar.com.bic.domain;
using ar.com.bic.dao;

namespace ar.com.bic.application.impl
{
	/// <summary>
	/// Descripción breve de UsuarioService.
	/// </summary>
	public class UsuarioServiceImpl : UsuarioService
	{
		private UsuarioDAO usuarioDAO;
		public UsuarioDAO UsuarioDAO 
		{
			set { this.usuarioDAO = value; }
		}

		public UsuarioServiceImpl()
		{
		}

		public void save(Usuario unUsuario) 
		{
			this.usuarioDAO.save(unUsuario);
		}
		public Usuario retrieve(long id) 
		{
			return this.usuarioDAO.retrieve(id); 
		}

	}
}

using System;
using ar.com.bic.domain;
using ar.com.bic.dao;

namespace ar.com.bic.application
{
	/// <summary>
	/// Descripción breve de UsuarioService.
	/// </summary>
	public interface UsuarioService
	{
		void save(Usuario unUsuario); 
		Usuario retrieve(long id);

	}
}

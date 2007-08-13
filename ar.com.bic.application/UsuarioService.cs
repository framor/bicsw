using System;
using System.Collections;
using ar.com.bic.domain;
using ar.com.bic.dao;

namespace ar.com.bic.application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Usuarios.
	/// </summary>
	public interface UsuarioService
	{
		/// <summary>
		/// Persiste un usuario
		/// </summary>
		/// <param name="unUsuario">EL usuario a ser grabado</param>
		void save(Usuario unUsuario); 

		/// <summary>
		/// Obtiene un usuario a trav�s de su id
		/// </summary>
		/// <param name="id">El id de usuario</param>
		/// <returns>El usuario correspondiente</returns>
		Usuario retrieve(long id);

		/// <summary>
		/// Obtiene todos los usuarios
		/// </summary>
		/// <returns>Una coleccion de usuarios</returns>
		ICollection select();

		/// <summary>
		/// Elimina un usuario
		/// </summary>
		/// <param name="id">El id de usuario</param>
		void delete(long id);

		/// <summary>
		/// Valida un usuario y contrase�a
		/// </summary>
		/// <param name="usuario">el nombre de usuario</param>
		/// <param name="contrasena">la contrase�a</param>
		/// <returns>si son v�lidos</returns>
		bool login(string usuario, string contrasena);
	}
}
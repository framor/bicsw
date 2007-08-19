using System;
using System.Collections;
using ar.com.bic.dao;
using ar.com.bic.domain;
using ar.com.bic.domain.catalogo;

namespace ar.com.bic.application.impl
{
	/// <summary>
	/// Implementación de CatalogoService
	/// </summary>
	public class CatalogoServiceImpl : BaseService , CatalogoService
	{

		private MySQLDAO mySQLDAO;
		public MySQLDAO MySQLDAO 
		{
			get { return this.mySQLDAO; }
			set { this.mySQLDAO = value; }
		}

		public CatalogoServiceImpl() {}

		/// <summary>
		/// Implementacion de CatalogoServiceImpl.SelectTablasDisponibles
		/// </summary>
		public IList SelectTablasDisponibles(long idProyecto)
		{
			Proyecto p = (Proyecto) this.GenericDAO.Retrieve(typeof(Proyecto), idProyecto);
			// FIXME: aca en realidad se debéría retornar p.Tablas, 
			// se esta retornando todo el catalogo para probar
			Catalogo c = this.mySQLDAO.GetCatalogo(p.Servidor, p.NombreBD, p.Usuario, p.Password);
			return c.Tablas;
		}
	}
}

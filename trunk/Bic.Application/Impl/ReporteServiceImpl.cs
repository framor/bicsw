using System;
using Bic.Domain;
using System.Collections;
using System.Data;
using Bic.Domain.Dao;
using Bic.Domain.Exception;
using Bic.Framework.Exception;

namespace Bic.Application.Impl
{
	public class ReporteServiceImpl: BaseService, ReporteService 
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}
		private ICatalogoDAO catalogoDAO;
		public ICatalogoDAO CatalogoDAO 
		{
			get { return this.catalogoDAO; }
			set { this.catalogoDAO = value; }
		}


		#region Constructor

		public ReporteServiceImpl()
		{

		}

		#endregion

		#region Inherited methods

		public void Save(Reporte reporte)
		{
			Reporte r = (Reporte) this.GenericDAO.SelectByNombre(typeof(Reporte), reporte.Id, reporte.Nombre);
			if (r != null && !r.Equals(reporte)) 
			{
				throw new ServiceException("No se puede crear el reporte ya que existe uno con el mismo nombre.");
			}

			try
			{
				reporte.GeneraConsulta();
			}
			catch (ReporteInvalidoException rie)
			{
				throw new ServiceException(rie.Message);
			}
			catch (NoExisteTablaCandidataException netce)
			{
				throw new ServiceException(netce.Message);
			}
			this.GenericDAO.Save(reporte);	
		}

		
		public Reporte Retrieve(long id)
		{
			return this.GenericDAO.Retrieve(typeof(Reporte), id) as Reporte;
		}

		
		public ICollection Select(long proyectoId)
		{
			return this.ProyectoDAO.SelectReportes(proyectoId);
		}

		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Reporte), id);
		}

		/// <summary>
		/// Implementacion de ReporteService.Ejecutar
		/// </summary>
		public DataSet Ejecutar(long id)
		{
			Reporte reporte = Retrieve(id);
			return this.catalogoDAO.EjecutarSql(reporte.Proyecto.Conexion, reporte.DameSql());
		}

		public DataSet Ejecutar(Reporte reporte)
		{
			return this.catalogoDAO.EjecutarSql(reporte.Proyecto.Conexion, reporte.DameSql());
		}

		#endregion
	}
}

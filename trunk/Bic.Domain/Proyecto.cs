using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;

namespace Bic.Domain
{
	/// <summary>
	/// Descripci�n breve de Proyecto.
	/// </summary>
	public class Proyecto
	{
		private long id;
		private string nombre;
		private string descripcion;
		private Conexion conexion = new Conexion();

		public Proyecto()
		{
		}

		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		public string Servidor
		{
			get { return this.Conexion.Server; }
			set { this.Conexion.Server = value; }
		}

		public string NombreBD
		{
			get { return this.Conexion.Database; }
			set { this.Conexion.Database = value; }
		}

		public string Usuario
		{
			get { return this.Conexion.User; }
			set { this.Conexion.User = value; }
		}

		public string Password
		{
			get { return this.Conexion.Password; }
			set { this.Conexion.Password = value; }
		}

		public Conexion Conexion
		{
			get { return conexion; }
			set { conexion = value; }
		}

		public IList ObtenerTablas(Columna col)
		{
			ArrayList ret = new ArrayList();

			IProyectoDAO pDao = DAOLocator.Instance.ProyectoDAO;
			IList tablas = pDao.SelectTablas(Id, col);
			foreach (Tabla t in tablas)
			{
				if (t.Columnas.Contains(col))
				{
					ret.Add(t);
				}
			}
			return ret;
		}

		public IList Atributos
		{
			get 
			{
				IProyectoDAO dao = DAOLocator.Instance.ProyectoDAO;
				return dao.SelectAtributos(Id);
			}
		}

		public IList Hechos
		{
			get 
			{
				IProyectoDAO dao = DAOLocator.Instance.ProyectoDAO;
				return dao.SelectHechos(Id);
			}
		}

		public IList Metricas
		{
			get
			{
				IProyectoDAO dao = DAOLocator.Instance.ProyectoDAO;
				return dao.SelectMetricas(this.Id);
			}
		}

		public IList Reportes
		{
			get
			{
				IProyectoDAO dao = DAOLocator.Instance.ProyectoDAO;
				return dao.SelectReportes(this.Id);
			}
		}

		public IList Filtros
		{
			get
			{
				IProyectoDAO dao = DAOLocator.Instance.ProyectoDAO;
				return dao.SelectFiltros(this.Id);
			}
		}

		public bool PuedeEliminarTabla(Tabla unaTabla) 
		{
			foreach (Atributo a in Atributos)
			{
				if (a.UsaTabla(unaTabla)) 
				{
					return false;
				}
			}
			foreach (Hecho h in Hechos) 
			{
				if (h.UsaTabla(unaTabla)) 
				{
					return false;
				}
			}
			return true;
		}

		public bool PuedeEliminarHecho(Hecho unHecho)
		{
			foreach(Metrica m in this.Metricas)
			{
				if (m.Hecho.Equals(unHecho))
				{
					return false;
				}
			}
			return true;
		}

		public bool PuedeEliminarAtributo(Atributo unAtributo)
		{
			foreach(Reporte r in this.Reportes)
			{
				if (r.Atributos.Contains(unAtributo))
				{
					return false;
				}
			}
			foreach(Filtro f in this.Filtros)
			{
				if (f.Atributo.Equals(unAtributo))
				{
					return false;
				}
			}
			return true;
		}

		public bool PuedeEliminarMetrica(Metrica unMetrica)
		{
			foreach(Reporte r in this.Reportes)
			{
				if (r.Metricas.Contains(unMetrica))
				{
					return false;
				}
			}
			return true;
		}

		public Atributo GetAtributoByName(string nombreAtributo)
		{
			foreach(Atributo atributo in this.Atributos)
			{
				if(atributo.Nombre.Equals(nombreAtributo))
				{
					return atributo;
				}
			}
			return null;
		}

		public Filtro GetFiltroByName(string nombreFiltro)
		{
			foreach(Filtro filtro in this.Filtros)
			{
				if(filtro.Nombre.Equals(nombreFiltro))
				{
					return filtro;
				}
			}
			return null;
		}

		public Hecho GetHechoByName(string nombreHecho)
		{
			foreach(Hecho hecho in this.Hechos)
			{
				if(hecho.Nombre.Equals(nombreHecho))
				{
					return hecho;
				}
			}
			return null;
		}
		
		public Metrica GetMetricaByName(string nombreMetrica)
		{
			foreach(Metrica metrica in this.Metricas)
			{
				if(metrica.Nombre.Equals(nombreMetrica))
				{
					return metrica;
				}
			}
			return null;
		}

	}
}
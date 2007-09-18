using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de Proyecto.
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
				ICatalogoDAO cDao = DAOLocator.Instance.CatalogoDAO;
				IList columnasDeLaTabla = cDao.ObtenerColumnas(t);
				if (columnasDeLaTabla.Contains(col))
				{
					ret.Add(t);
				}
			}
			return ret;
		}
	}
}

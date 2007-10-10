using System;
using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Exception;
using Bic.Domain.Interfaces;
using Iesi.Collections;

namespace Bic.Domain
{

	public class Atributo : ITablaMapeable, ICamino
	{
		#region Private methods

		private long id;
		private string nombre;
		private Columna columnaId;
		private ISet columnasDescripciones = new HashedSet();
		private Tabla tablaLookup;
		private Proyecto proyecto;
		private Atributo hijo;

		#endregion

		#region Constructor

		public Atributo() {}


		public Atributo(string nombre, Columna columnaId, Tabla tablaLkp, Proyecto proyecto) 
		{
			this.Nombre = nombre;
			this.columnaId = columnaId;
			this.TablaLookup = tablaLkp;
			this.Proyecto = proyecto;
		}


		#endregion

		#region Properties

		public Atributo Hijo
		{
			get { return this.hijo; }
			set { this.hijo = value; }
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


		public Columna ColumnaId
		{
			get { return this.columnaId; }
			set { this.columnaId = value; }
		}


		public string NombreColumnaId
		{
			get { return this.columnaId.Nombre; }
		}


		public string AliasTablaLookup
		{
			get { return this.tablaLookup.Alias; }
		}


		public ArrayList ColumnasDescripciones
		{
			get { return new ArrayList(columnasDescripciones); }
		}


		public Tabla TablaLookup
		{
			get { return tablaLookup; }
			set { tablaLookup = value; }
		}


		public Proyecto Proyecto
		{
			get { return proyecto; }
			set { proyecto = value; }
		}


		public ICollection AtributosPadres
		{
			get
			{
				return Dao.DAOLocator.Instance.AtributoDAO.ObtenerPadres(this.id);
			}
		}

		#endregion

		#region Public methods

		public void AgregarColumnaDescripcion(Columna value)
		{
			this.columnasDescripciones.Add(value);
		}


		public void RemoverColumnaDescripcion(Columna value)
		{
			this.columnasDescripciones.Remove(value);
		}


		public IList ObtenerTablas()
		{
			return this.proyecto.ObtenerTablas(this.columnaId);
		}


		public Columna Columna
		{
			get { return this.columnaId; }
		}


		public Camino GeneraCamino(Tabla tabla)
		{
			Camino camino;

            
			if(!tabla.Tenes(this.columnaId))
			{
				try
				{
					camino = this.Hijo.GeneraCamino(tabla);
					//camino.AgregarAtributo(this);
				}
					// Si no tiene hijos cancela por referencia nula.
					// Capturo la excepcion.
				catch(NullReferenceException nre)
				{	
					// Subo de nivel de Excepcion a una excepcion del dominio.
					// Mando un excepcion de hijo inexistente.
					throw new NoExisteHijoException("El atributo no tiene hijos, es el ultimo en la jerarquia",nre);
				}
			}	
			else
			{
				camino = new Camino();
			}

			camino.AgregarAtributo(this);

			return camino;
		}


		public bool UsaTabla(Tabla unaTabla)
		{
			return this.TablaLookup.Equals(unaTabla);

		}


		#endregion
	}
}

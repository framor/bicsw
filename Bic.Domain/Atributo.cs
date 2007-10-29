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
		#region Private members

		private long id;
		private string nombre;
		private Columna columnaId;
		private ISet columnasDescripciones = new HashedSet();
		private Tabla tablaLookup;
		private Proyecto proyecto;
		private Atributo hijo;
		// Para controlar las referencias circulares
		private bool flagCircular = false;

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

		public string AliasSql
		{
			get
			{
				return this.TablaLookup.Nombre + this.id;
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

			// Si el Flag de referencia circular es true lanzamos una excepcion de referencia circular.
			if (this.flagCircular)
			{
				throw new ReferenciaCircularException("El Atributo: " + "\"" + this.Nombre + "\" tiene una referencia circular.");
			}
			
			// Seteo que ya pase por aca por la referencia circular.
			this.flagCircular = true;

			if(!tabla.Tenes(this.columnaId))
			{
				try
				{
					camino = this.Hijo.GeneraCamino(tabla);
				}
					// Si no tiene hijos cancela por referencia nula.
					// Capturo la excepcion.
				catch(NullReferenceException nre)
				{	
					// Antes de tirar la excepcion seteo a false la referencia circular
					this.flagCircular = false;
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

			this.flagCircular = false;

			return camino;
		}

		public Camino GeneraCamino()
		{
			Camino camino;
			// Si el Flag de referencia circular es true lanzamos una excepcion de referencia circular.
			if (this.flagCircular)
			{
				throw new ReferenciaCircularException("El Atributo: " + "\"" + this.Nombre + "\" tiene una referencia circular.");
			}

			// Seteo que ya pase por aca por la referencia circular.
			this.flagCircular = true;

			try
			{
				camino = this.Hijo.GeneraCamino();
			}
			// Si no tiene hijos cancela por referencia nula.
			// Capturo la excepcion.
			catch(NullReferenceException)
			{
				// Arranco el Camino porque es el ultimo de la jerarquia.
				camino = new Camino();
			}
			
			camino.AgregarAtributo(this);

			this.flagCircular = false;

			return camino;
		}


		public bool UsaTabla(Tabla unaTabla)
		{
			return this.TablaLookup.Equals(unaTabla);

		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is Atributo)) return false; 
			return this.id.Equals(((Atributo) obj).Id);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
		#endregion
	}
}

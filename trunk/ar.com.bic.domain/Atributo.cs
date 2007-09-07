using System;
using System.Collections;
using ar.com.bic.domain.catalogo;
using ar.com.bic.domain.interfaces;
using ar.com.bic.domain.exception;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Atributo.
	/// </summary>
	public class Atributo : ITablaMapeable, ICamino
	{
		private long id;
		private string nombre;
		private Campo campoId;
		private ArrayList camposDescripciones = new ArrayList();
		private Tabla tablaLookup;
		private Proyecto proyecto;
		private Atributo hijo;
		private IList padres = new ArrayList();

		public Atributo() {}

		public Atributo(string nombre,Campo campoId, Tabla tablaLkp, Proyecto proyecto) 
		{
			this.Nombre = nombre;
			this.CampoId = campoId;
			this.TablaLookup = tablaLkp;
			this.Proyecto = proyecto;
		}

		public Atributo Hijo
		{
			get { return this.hijo; }
			set { this.hijo = value; }
		}

		public void AgregarPadre(Atributo padre)
		{
			this.padres.Add(padre);
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

		public Campo CampoId
		{
			get { return campoId; }
			set { campoId = value; }
		}

		public ArrayList CamposDescripciones
		{
			get { return new ArrayList(camposDescripciones); }
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

		public void AgregarCampoDescripcion(Campo value)
		{
			this.camposDescripciones.Add(value);
		}

		public IList GetTablas()
		{
			return this.campoId.Tablas;
		}

		public Campo GetCampo()
		{
			return this.campoId;
		}

		public IList GetColumnas()
		{
			return this.CampoId.GetColumnas();
		}

		public Camino GeneraCamino(Tabla tabla)
		{
			Camino camino;

            
			if(!tabla.Tenes(this.CampoId))
			{
				try
				{
					camino = this.hijo.GeneraCamino(tabla);
					camino.AgregarAtributo(this);
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
				camino.AtributoFact = this;
			}



			return camino;
		}


	}
}

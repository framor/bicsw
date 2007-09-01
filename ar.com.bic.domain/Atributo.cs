using System;
using System.Collections;
using ar.com.bic.domain.catalogo;
using ar.com.bic.domain.interfaces;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Atributo.
	/// </summary>
	public class Atributo : ITablaMapeable
	{
		private long id;
		private string nombre;
		private Campo campoId;
		private ArrayList camposDescripciones = new ArrayList();
		private Tabla tablaLookup;
		private Proyecto proyecto;

		public Atributo() {}

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

	}
}

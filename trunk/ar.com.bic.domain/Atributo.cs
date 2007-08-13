using System;
using System.Collections;
using ar.com.bic.domain.interfaces;
using ar.com.bic.domain.esquema;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Atributo.
	/// </summary>
	public class Atributo : ITablaMapeable
	{
		private long id;
		private string nombre;
		private Columna campoId;
		private ArrayList camposDescripciones;
		private string tablaLookup;
		private Proyecto proyecto;

		public Atributo()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
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

		public Columna CampoId
		{
			get { return campoId; }
			set { campoId = value; }
		}

		public ArrayList CamposDescripciones
		{
			get { return camposDescripciones; }
			set { camposDescripciones = value; }
		}

		public string TablaLookup
		{
			get { return tablaLookup; }
			set { tablaLookup = value; }
		}

		public Proyecto Proyecto
		{
			get { return proyecto; }
			set { proyecto = value; }
		}

		public ArrayList GetTablas()
		{
			return this.campoId.Tablas;
		}

		public Columna GetColumna()
		{
			return this.campoId;
		}
	}
}

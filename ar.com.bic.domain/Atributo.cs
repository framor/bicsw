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

		public ArrayList GetTablas()
		{
			//return this.campoId.Tablas;
			// TODO: el campo no conoce todas las tablas que tambien tienen un campo igual a el.
			// el campo es una representacion del esquema de la bd.
			// esto lo debería resolver otro objeto.
			return null;
		}

		public Campo GetCampo()
		{
			return this.campoId;
		}
	}
}

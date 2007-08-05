using System;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Atributo.
	/// </summary>
	public class Atributo
	{
		private long id;
		private string nombre;
		private string campoId;
		private string campoDescripcion;
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

		public string CampoId
		{
			get { return campoId; }
			set { campoId = value; }
		}

		public string CampoDescripcion
		{
			get { return campoDescripcion; }
			set { campoDescripcion = value; }
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
	}
}

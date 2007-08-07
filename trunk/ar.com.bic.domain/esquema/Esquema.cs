using System;
using System.Collections;

namespace ar.com.bic.domain.esquema
{
	/// <summary>
	/// Descripción breve de Esquema.
	/// </summary>
	public class Esquema
	{
		private IList tablas = new ArrayList();
		public IList Tablas
		{
			get {return new ArrayList(this.tablas); }
		}

		public Esquema()
		{
		}

		public void AgregarTabla(Tabla tbl)
		{
			this.tablas.Add(tbl);
		}
	}
}

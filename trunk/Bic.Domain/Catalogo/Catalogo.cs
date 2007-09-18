using System.Collections;

namespace Bic.Domain.Catalogo
{
	/// <summary>
	/// Estructura de la Base de Datos. Contiene solo la colección de tablas
	/// que figuran en la metadata de la BD
	/// </summary>
	public class Catalogo
	{
		private IList tablas = new ArrayList();

		/// <summary>
		/// Tablas existentes en la BD
		/// </summary>
		public IList Tablas
		{
			get {return new ArrayList(this.tablas); }
		}

		public Catalogo() {}

		public void AgregarTabla(Tabla tbl)
		{
			this.tablas.Add(tbl);
		}


	}
}

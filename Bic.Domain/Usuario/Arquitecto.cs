namespace Bic.Domain.Usuario
{
	/// <summary>
	/// Descripción breve de Arquitecto.
	/// </summary>
	public class Arquitecto : Rol
	{
		private static Arquitecto INSTANCE;
		public static Arquitecto Instance
		{
			get
			{
				if (INSTANCE == null)
				{
					INSTANCE = new Arquitecto();
				}
				return INSTANCE;
			}
		}

		private Arquitecto()
		{
		}

		protected override string GetId()
		{
			return Rol.ID_ARQUITECTO;
		}

		public override bool PuedeAccederAProyectos()
		{
			return true;
		}

		public override bool PuedeAccederATablas()
		{
			return true;
		}

		public override bool PuedeAccederAHechos()
		{
			return true;
		}

		public override bool PuedeAccederAAtributos()
		{
			return true;
		}

		public override bool PuedeAccederAMetricas()
		{
			return true;
		}

		public override bool PuedeAccederAFiltros()
		{
			return true;
		}

		protected override string GetNombre()
		{
			return "Arquitecto";
		}

		public override bool PuedeEditarProyectos()
		{
			return true;
		}


	}
}

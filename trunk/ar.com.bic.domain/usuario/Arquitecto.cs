namespace ar.com.bic.domain.usuario
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

		protected override string GetNombre()
		{
			return "Arquitecto";
		}

	}
}

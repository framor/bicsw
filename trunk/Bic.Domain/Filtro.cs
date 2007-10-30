using Bic.Domain.Catalogo;
using Bic.Domain.Interfaces;
using Bic.Domain.Exception;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de Filtro.
	/// </summary>
	public class Filtro : ICamino
	{
		public static string EMPIEZA_CON = "LIKE '{0}%'";
		public static string TERMINA_CON = "LIKE '{0}%'";
		public static string CONTIENE = "LIKE '%{0}%'";

		private long id;
		private string nombre;
		private Columna columna;
		private Atributo atributo;
		private string operador;
		private string valor;
		private Proyecto proyecto;

		public Filtro() {}

		public long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		public string Nombre
		{
			get { return this.nombre; }
			set { this.nombre = value; }
		}
		public string Operador
		{
			get { return this.operador; }
			set
			{
				if((value.Equals("Empieza con") || value.Equals("Termina con") || value.Equals("Contiene")) 
					&& !this.Columna.Tipo.Equals("varchar") && !this.Columna.Tipo.Equals("char"))
				{
					throw new OperadorInvalidoException("El operador Seleccionado no se puede aplicar al tipo de dato del filtro");
				}
				this.operador = value; 
			}

			
		}
		public string Valor
		{
			get { return this.valor; }
			set 
			{ 
				try 
				{
					switch (this.Columna.Tipo)
					{
						case "date":
						case "timestamp":
							System.DateTime.Parse(value, new System.Globalization.CultureInfo("es-AR")); break;
						case "int":
						case "decimal":
						case "smallint":
						case "double":
						case "tinyint":
						case "bigint": 
							double.Parse(value,new System.Globalization.CultureInfo("es-AR")); break;
					}
				} 
				catch (System.FormatException fe) 
				{
					throw new FiltroInvalidoException("El valor del filtro no corresponde al tipo de columna utilizado.");
				}
				this.valor = value;
			}
		}
		public Columna Columna
		{
			get { return this.columna; }
			set { this.columna = value; }
		}
		public Atributo Atributo
		{
			get { return this.atributo; }
			set { this.atributo = value; }
		}
		public string NombreColumna
		{
			get { return this.columna.Nombre; }
		}
		public Proyecto Proyecto
		{
			get { return this.proyecto; }
			set { this.proyecto = value; }
		}

		public Camino GeneraCamino(Tabla tabla)
		{
			return this.Atributo.GeneraCamino(tabla);
		}

		public Camino GeneraCamino()
		{
			return this.Atributo.GeneraCamino();
		}

		public string GetSql(string alias)
		{
			string sql = alias + "." + this.Columna.Nombre + " ";
			
			switch (this.Columna.Tipo) 
			{
				case "varchar":
				case "char": 
					if (this.Operador.Equals("Empieza con"))
					{
						sql += string.Format(EMPIEZA_CON, this.valor);
					}
					else if (this.Operador.Equals("Termina con"))
					{
						sql += string.Format(TERMINA_CON, this.valor);
					}
					else if (this.Operador.Equals("Contiene"))
					{
						sql += string.Format(CONTIENE, this.valor);
					}
					else 
					{
						sql += this.Operador + " '" + this.Valor + "' ";
					}
					break;
				case "date":
				case "timestamp":
					System.DateTime val = System.DateTime.Parse(this.Valor, new System.Globalization.CultureInfo("es-AR"));
					sql += this.operador + " cast('" + val.Year + "/" + val.Month + "/" + val.Day +"' as date)"; 
					break;
				default:
					sql += this.Operador + " " + double.Parse(this.Valor, new System.Globalization.CultureInfo("es-AR")).ToString(new System.Globalization.CultureInfo("en-US")) + " ";
					break;
			}				
			return sql;
		}
	}
}

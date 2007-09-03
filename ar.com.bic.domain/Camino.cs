using System;
using System.Collections;
using ar.com.bic.domain.catalogo;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Camino.
	/// </summary>
	public class Camino
	{	
		private long id;
		IList relaciones = new ArrayList();
		IList Atributos = new ArrayList();

		public Camino()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public void AgregarRelacion(Relacion relacion)
		{
			this.relaciones.Add(relacion);
		}

		public void AgregarAtributo(Atributo atributo)
		{
			this.Atributos.Add(atributo);
		}

		public string DameFromClause()
		{
			string fromClause ="";

			foreach(Atributo atributo in this.Atributos)
			{
				// Obtengo la tabla lookup para agregarla al from
				Tabla tabla = atributo.TablaLookup;
				// Le agrego el nombre de la tabla y un alias generado con el nombre
				// de la tabla y el id del camino, para que no se repita con todos 
				// los caminos que conforman un reporte.
				fromClause += tabla.NombreBD + "." + tabla.Nombre + " as " + tabla.Nombre + this.id;
				// Si no es el ultimo elemento le agrego una coma, si es el ultimo no se
				// le agrega.
				if(this.Atributos.IndexOf(atributo) < this.Atributos.Count - 1)
					fromClause += ",";
			}
			
			return fromClause;
		}

		public string DameWhereClause()
		{
			string whereClause = "";

			// Si es un solo atributo en el camino no genero ningun where
			if(this.Atributos.Count == 1)
				return whereClause;

			foreach(Atributo atributo in this.Atributos)
			{
				// Obtengo la tabla lookup para agregarle los alias
				Tabla tabla = atributo.TablaLookup;
				// Si es el primer atributo le agrego un 1=1 para poder continuar con
				// los and, hace la base del where
				if(this.Atributos.IndexOf(atributo) == 0)
					whereClause += "1=1\n";
				else
					//Si no es el primero armo la comparacion
					// ej: campo2 = lkp2.campo2
					whereClause += atributo.CampoId.Nombre + "=" 
						+ tabla.Nombre + this.id + "."
						+ atributo.CampoId.Nombre + "\n";
				// Mientras no sea el ultimo agrego el and y el alias de la tabla
				// ej: and lkp1.
				if(this.Atributos.IndexOf(atributo) < this.Atributos.Count - 1)
					whereClause += "and " + tabla.Nombre + this.id + ".";

				// Termina quedando en 3 pasadas
				// 1=1
				// and lkp1.campo2 = lkp2.campo2
				// and lkp2.campo3 = lkp3.campo3
			}

			return whereClause;
		}
	}
}

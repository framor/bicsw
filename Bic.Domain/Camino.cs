using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de Camino.
	/// </summary>
	public class Camino
	{	
		private long id;
		private IList atributos = new ArrayList();

		public Camino()
		{
			id = this.GetHashCode(); 
		}

		public long Id
		{
			get { return this.id; }
		}

		public void AgregarAtributo(Atributo atributo)
		{
			this.atributos.Add(atributo);
		}

		/// <summary>
		/// Atributo que se relaciona directamente con la tabla Fact.
		/// </summary>
		public Atributo AtributoFact
		{
			get { return (Atributo)this.atributos[0]; }
		}

        /// <summary>
        /// Atributo que origino el Camino
        /// </summary>
		public Atributo AtributoOrigen
		{
			get { return (Atributo)this.atributos[this.atributos.Count - 1]; }
		}

        /// <summary>
        /// Devuelve la condicion where de join entre el atributo de primer nivel
        /// y la tabla de join.
        /// </summary>
        /// <param name="aliasFact">Es el alias que debe tener la tabla fact en el from.</param>
        /// <returns></returns>
		public string DameJoinFact(string aliasFact)
		{
			string nombreCampo = this.AtributoFact.ColumnaId.Nombre;
			//string aliasLkp = this.AtributoFact.AliasSql;
			string aliasLkp = this.AtributoFact.AliasSql + this.Id;
			string sql = aliasFact + "." + nombreCampo + " = " + aliasLkp + "." + nombreCampo;
			return sql;		
		}

		/// <summary>
		/// Genera la clausula from para este camino. O sea las formadas por las 
		/// tablas intermedias.
		/// </summary>
		/// <returns></returns>

		public string DameFromClause()
		{
			string fromClause = "";

			foreach(Atributo atributo in this.atributos)
			{
				// Obtengo la tabla lookup para agregarla al from
				Tabla tabla = atributo.TablaLookup;
				// Le agrego el nombre de la tabla y un alias generado con el nombre
				// de la tabla y el id del camino, para que no se repita con todos 
				// los caminos que conforman un reporte.
				//fromClause += tabla.NombreBD + "." + tabla.Nombre + " as " + atributo.AliasSql;
				fromClause += tabla.NombreBD + "." + tabla.Nombre + " as " + atributo.AliasSql + this.Id;
				// Si no es el ultimo elemento le agrego una coma, si es el ultimo no se
				// le agrega.
				if(this.atributos.IndexOf(atributo) < this.atributos.Count - 1)
					fromClause += ",\n";
			}
			
			return fromClause;
		}

		/// <summary>
		/// Genera la clausula where que joinea las tablas intermedias para este camino.
		/// </summary>
		/// <returns></returns>
		public string DameWhereClause()
		{
			string whereClause = "";

			// Si es un solo atributo en el camino no genero ningun where
			// Ya que solo joinea con el atributo join de la fact
			if(this.atributos.Count == 1)
			{
				return whereClause;
			}
			
            // creo la segunda condicion, que es entre la lkp de primer nivel 
			// y la de segundo nivel.
			

			foreach(Atributo atributo in this.atributos)
			{
				// Obtengo la tabla lookup para agregarle los alias
				Tabla tabla = atributo.TablaLookup;
				// Armo la comparacion ej: campo2 = lkp2.campo2
				if(this.atributos.IndexOf(atributo) > 0)
				{
					whereClause += atributo.ColumnaId.Nombre + " = " 
						+ atributo.AliasSql + this.Id + "." 
						+ atributo.ColumnaId.Nombre ; 
				}
				
				// Mientras no sea el ultimo agrego el and y el alias de la tabla
				// ej: and lkp1.

				if(this.atributos.IndexOf(atributo) > 0 
					&& this.atributos.IndexOf(atributo) < this.atributos.Count - 1)
				{
					whereClause += "\nand ";
				}

				if(this.atributos.IndexOf(atributo) < this.atributos.Count - 1)
				{
					whereClause += atributo.AliasSql + this.Id + ".";
				}

				// Termina quedando en 3 pasadas
				// lkp1.campo2 = lkp2.campo2
				// and lkp2.campo3 = lkp3.campo3
			}

			return whereClause;
		}

		/// <summary>
		/// Se fija en la lista de atributos si figura el pasado por parametro.
		/// TODO. SE ENCUENTRA HARCODEADO PARA QUE MIRE SOLO EL ULTIMO ELEMENTO QUE ES EL 
		/// ATRIBUTO ORIGEN DEL CAMINO, SE DEBE IMPLEMENTAR CORRECTAMENTE CUANDO NO SEA UN CAMINO
		/// POR CADA ATRIBUTO SELECCIONADO.
		/// </summary>
		/// <param name="atrib"></param>
		/// <returns></returns>

		public bool TenesAtributo(Atributo atrib)
		{
			foreach(Atributo atributo in this.atributos)
			{
				if(atributo.Equals(atrib))
				{
					return true;
				}
			}
			return false;
		}
	}
}

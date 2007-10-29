using System;
using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de TablaReporte.
	/// </summary>
	public class TablaReporte : IComparable
	{
		private Tabla tabla;
		private ArrayList caminos;

		public TablaReporte(Tabla tabla,IList listaCaminos)
		{
			this.tabla = tabla;
			this.caminos = new ArrayList(listaCaminos);
		}

		/// <summary>
		/// Necesaria para poder implementar IComparable
		/// y asi ordenar por la tabla de menor peso.
		/// </summary>
		/// <param name="objeto"></param>
		/// <returns></returns>
		public int CompareTo(Object objeto)
		{
			if(objeto is TablaReporte)
			{
				return this.tabla.Peso - ((TablaReporte)objeto).Tabla.Peso;
			}
			throw new ArgumentException(  "El objeto no es una TablaReporte" );
		}

		public Tabla Tabla
		{
			get { return this.tabla; }
		}
		
		public IList Caminos
		{
			get { return new ArrayList(this.caminos); }
		}
		/// <summary>
		/// Genera el SQL necesario para ejecutar.
		/// Compuesto por el from y el where
		/// </summary>
		/// <returns></returns>
		public string DameSql()
		{
			string from = "from\n";
            
			// Primero agrego la tabla Fact.
			if (this.Tabla != null)
			{
				from += this.tabla.NombreBD + "." + this.tabla.Nombre + " as " + this.tabla.Nombre;
			}

			// Si no tiene ningun camino lo retorno.
			if(this.caminos.Count == 0)
			{
				from += ";";
				return from;
			}

			if (this.Tabla != null)
			{
				from += ",\n";
			}

            // Por cada camino le pido que me de su from,
			// o sea las tablas de cada uno de ellos.
			foreach(Camino camino in this.caminos)
			{
				from += camino.DameFromClause();

				// Mientras no sea el ultimo le agrego la coma y el enter
				if (this.caminos.IndexOf(camino) < this.caminos.Count - 1)
					from += ",\n";
			}

			
			// Agrego la clausula where.
			string whereFact = string.Empty;

			// Si es un reporte con fact le pido los join.
			if (this.Tabla != null)
			{
				// A cada camino le pido que me de el join con la Fact.
				// O sea la lkp de primer nivel y la fact.
				foreach(Camino camino in this.caminos)
				{
					// Mientras no sea el primero le agrego el "and " para el proximo where
					if(this.caminos.IndexOf(camino) > 0)
						whereFact += "and ";
				
					whereFact += camino.DameJoinFact(this.tabla.Nombre) + "\n";
				}
			}
			
	
            // Devuelve el resto de las condiciones de join entre las 
			// tablas intermedias.

			string whereCaminos = string.Empty;

			foreach(Camino camino in this.caminos)
			{
				string whereClause = camino.DameWhereClause();
				
				if (!whereClause.Equals(string.Empty) && this.caminos.IndexOf(camino) > 0)
				{
					whereCaminos += "and ";
				}
				
				if (!whereClause.Equals(string.Empty))
				{
					whereCaminos += whereClause + "\n";
				}
			}

			string sql = from;
			sql += !whereFact.Equals(string.Empty) && !whereCaminos.Equals(string.Empty) ? "\nwhere\n" + whereFact : string.Empty;
			sql += !whereFact.Equals(string.Empty) && !whereCaminos.Equals(string.Empty) ? "and " : string.Empty;
			sql += whereCaminos;
			
			return sql;
		}

		public string DameFrom()
		{
			string from = string.Empty;
            
			// Primero agrego la tabla Fact.
			if (this.Tabla != null)
			{
				from += this.tabla.NombreBD + "." + this.tabla.Nombre + " as " + this.tabla.Nombre;
			}

			// Si no tiene ningun camino lo retorno.
			if(this.caminos.Count == 0)
			{
				from += ";";
				return from;
			}

			if (this.Tabla != null)
			{
				from += ",\n";
			}

			// Por cada camino le pido que me de su from,
			// o sea las tablas de cada uno de ellos.
			foreach(Camino camino in this.caminos)
			{
				from += camino.DameFromClause();

				// Mientras no sea el ultimo le agrego la coma y el enter
				if (this.caminos.IndexOf(camino) < this.caminos.Count - 1)
					from += ",\n";
			}

			return from;
		}

		public string DameWhere()
		{
			
			// Agrego la clausula where.
			string whereFact = string.Empty;

			// Si es un reporte con fact le pido los join.
			if (this.Tabla != null)
			{
				// A cada camino le pido que me de el join con la Fact.
				// O sea la lkp de primer nivel y la fact.
				foreach(Camino camino in this.caminos)
				{
					// Mientras no sea el primero le agrego el "and " para el proximo where
					if(this.caminos.IndexOf(camino) > 0)
						whereFact += "and ";
				
					whereFact += camino.DameJoinFact(this.tabla.Nombre) + "\n";
				}
			}
			
	
			// Devuelve el resto de las condiciones de join entre las 
			// tablas intermedias.

			string whereCaminos = string.Empty;

			foreach(Camino camino in this.caminos)
			{
				string whereClause = camino.DameWhereClause();
				
				if (!whereClause.Equals(string.Empty) && !whereCaminos.Equals(string.Empty))
				{
					whereCaminos += "and ";
				}
				
				if (!whereClause.Equals(string.Empty))
				{
					whereCaminos += whereClause + "\n";
				}
			}

			string sql = whereFact;
			sql += !whereFact.Equals(string.Empty) && !whereCaminos.Equals(string.Empty) ? "and " : string.Empty;
			sql += whereCaminos;
			
			return sql;
		}

		
		public string GetIdCamino(Atributo atrib)
		{

			foreach(Camino camino in this.caminos)
			{
				if(camino.TenesAtributo(atrib))
					return camino.Id.ToString();
			}

			return ""; // TODO arreglar esto porque no puede devolver esto;

		}

		public void AgregarCaminos(IList listaCaminos)
		{
			this.caminos.AddRange(listaCaminos);
		}

		public void MergeCaminos()
		{
			ArrayList caminos1 = new ArrayList(this.caminos);
			foreach(Camino camino1 in caminos1)
			{
				ArrayList caminos2 = new ArrayList(this.caminos);
				foreach(Camino camino2 in caminos2)
				{
					if(camino2.TenesAtributo(camino1.AtributoOrigen) && !camino2.Equals(camino1) )
					{
						this.caminos.Remove(camino1);
						break;
					}
				}
			}
		}

	}
}

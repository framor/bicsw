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

		/// <summary>
		/// Genera el SQL necesario para ejecutar.
		/// Compuesto por el from y el where
		/// </summary>
		/// <returns></returns>
		public string DameSql()
		{
			string sql = "from\n";
            
			// Primero agrego la tabla Fact.
			sql += this.tabla.NombreBD + "." + this.tabla.Nombre + " as " + this.tabla.Nombre;

			// Si no tiene ningun camino lo retorno.
			if(this.caminos.Count == 0)
			{
				sql += ";";
				return sql;
			}

			sql += ",\n";
            // Por cada camino le pido que me de su from,
			// o sea las tablas de cada uno de ellos.
			foreach(Camino camino in this.caminos)
			{
				sql += camino.DameFromClause();

				// Mientras no sea el ultimo le agrego la coma y el enter
				if (this.caminos.IndexOf(camino) < this.caminos.Count - 1)
					sql += ",\n";
			}

			
			// Agrego la clausula where.
			sql += "\nwhere\n";

			// A cada camino le pido que me de el join con la Fact.
			// O sea la lkp de primer nivel y la fact.
			foreach(Camino camino in this.caminos)
			{
				// Mientras no sea el primero le agrego el "and " para el proximo where
				if(this.caminos.IndexOf(camino) > 0)
					sql += "and ";
				
				sql += camino.DameJoinFact(this.tabla.Nombre) + "\n";
			}
			
	
            // Devuelve el resto de las condiciones de join entre las 
			// tablas intermedias.
			foreach(Camino camino in this.caminos)
			{
				string whereClause = camino.DameWhereClause();
				
				if(!whereClause.Equals(""))
                    sql += "and " + whereClause + "\n";
			}
			
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
	}
}

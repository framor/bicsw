using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Exception;
using Bic.Domain.Interfaces;
using Bic.Framework;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de Reporte.
	/// </summary>
	public class Reporte
	{

		#region Miembros privados
	
		private IList Atributos = new ArrayList();
		private IList Metricas = new ArrayList();
		private IList Filtros = new ArrayList();
		private TablaReporte tablaReporte;

	
		#endregion

		public Reporte()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		
		#region Metodos publicos

		public void AgregarAtributo(Atributo atributo)
		{
			this.Atributos.Add(atributo);
		}

		public void AgregarMetrica(Metrica metrica)
		{
			this.Metricas.Add(metrica);
		}

		public void AgregarFiltro(Filtro filtro)
		{
			this.Filtros.Add(filtro);
		}


		public void GeneraConsulta()
		{
			ArrayList tablasReporte = new ArrayList();
			// Le pido las tablas candidatas a elegir - Son las que tienen todas las metricas
			ArrayList tablasFactCandidatas = this.DameTablasCandidatas();
			            
			foreach(Tabla tabla in tablasFactCandidatas)
			{
				try
				{
					//Creo el objeto TablaReporte con la tabla Fact destino y todos sus caminos
					TablaReporte tablaReporte = new TablaReporte(tabla,this.GeneraCaminos(tabla,this.Atributos));

					// La agrego a la coleccion de tablasReporte, para ser tenidas en cuenta
					// por tener todos los caminos.
					tablasReporte.Add(tablaReporte);
				}
				catch (NoExisteCaminoException)
				{
                    
				}
			}

			// Verifico que aunque sea exista alguna alternativa de reporte
			if(tablasReporte.Count == 0)
				throw new ReporteInvalidoException("Imposible generar el reporte, no existe combinacion entre los atributos y las metricas seleccionadas");

			// Ordeno todas las alternativas por el comparador CompareTo
			// que elige la de menor peso.
			tablasReporte.Sort();
			
			// Tomo la primera y la agrego al reporte.
			IEnumerator enumerador = tablasReporte.GetEnumerator();
			enumerador.MoveNext();
			this.tablaReporte = (TablaReporte)enumerador.Current;

			return;

		}
		


		public ArrayList GeneraCaminos(Tabla tabla,IList campos)
		{
			ArrayList caminos = new ArrayList();
			//Por cada campo que cumpla con la interfaz TablaMapeable le pido que genere camino
			foreach(ICamino campo in campos)
			{	//TODO aca me llegaria la exepcion de que no hay camino desde el atributo
				try
				{
					caminos.Add(campo.GeneraCamino(tabla));
				}
					// Si me llega una excepcion al no encontrar hijos significa
					// que no encontro un camino hasta la Fact.
					// Capturo la Excepcion.
				catch(NoExisteHijoException nehe)
				{
					// Subo de nivel de Excepcion a una excepcion del dominio.
					// Mando un excepcion de que no encuentra un camino por lo menos.
					throw new NoExisteCaminoException("Por lo menos uno de los atributos no tiene camino hasta la tabla Fact",nehe);
				}
			}

			return caminos;
		}

		public ArrayList DameTablasCandidatas()
		{

			ArrayList tablas = new ArrayList();

			// Le pido las tablas donde estan estas metricas
			IList tablasFact = this.DameTablas(this.Metricas);
			
			// Itero en la colleccion de Tablas preguntandole si tiene a todas las metricas
			foreach(Tabla tabla in tablasFact)
			{
				if(tabla.Tenes(this.Metricas)) 
					tablas.Add(tabla);
			}
			
			if(tablas.Count == 0)
				throw new NoExisteTablaCandidataException("No existe ninguna Fact Table que tenga todas las metricas");

			return tablas;
		}

		public IList DameTablas(IList campos)
		{
			
			ArrayList tablas = new ArrayList();
			// Le pido a todos los campos que me den las tablas donde estan presentes
			foreach(ITablaMapeable campo in campos)
			{
				tablas.AddRange(campo.ObtenerTablas());//TODO todas las clases que tengan tablas pueden aparecer aca
				
			};
			
			// Con esta funcion quito los repetidos
			return Util.ConvertirSet(tablas);
		}

		public TablaReporte TablaReporte
		{
			get { return this.tablaReporte; }
		}


		#endregion

	}
}

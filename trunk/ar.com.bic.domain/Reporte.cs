using System.Collections;
using ar.com.bic.domain.catalogo;
using ar.com.bic.domain.interfaces;
using ar.com.bic.domain.exception;
using ar.com.bic.fwk;

namespace ar.com.bic.domain
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
			
			// Le pido las tablas candidatas a elegir - Son las que tienen todas las metricas
			ArrayList tablasFactCandidatas = this.DameTablasCandidatas();
			            
			foreach(Tabla tabla in tablasFactCandidatas)
			{
				//TODO Hacer Try y Catch de la exepcion al momento de generar el camino por la no existencia de camino
				
				//Creo el objeto TablaReporte con la tabala Fact destino y todos sus caminos
                TablaReporte tablaReporte = new TablaReporte(tabla,this.GeneraCaminos(tabla,this.Atributos));
	
			}

			return;

		}
		


		public ArrayList GeneraCaminos(Tabla tabla,IList campos)
		{
			ArrayList caminos = new ArrayList();
			//Por cada campo que cumpla con la interfaz TablaMapeable le pido que genere camino
			foreach(ICamino campo in campos)
			{	//TODO aca me llegaria la exepcion de que no hay camino desde el atributo
				caminos.Add(campo.GeneraCamino(tabla));
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
				throw new TablaCandidataException("No existe ninguna Fact Table que tenga todas las metricas");

			return tablas;
		}

		public IList DameTablas(IList campos)
		{
			
			ArrayList tablas = new ArrayList();
			// Le pido a todos los campos que me den las tablas donde estan presentes
			foreach(ITablaMapeable campo in campos)
			{
				tablas.AddRange(campo.GetTablas());//TODO todas las clases que tengan tablas pueden aparecer aca
				
			};
			
			// Con esta funcion quito los repetidos
			return Util.ConvertirSet(tablas);
		}


		#endregion

	}
}

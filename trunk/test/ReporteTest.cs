using System;
using System.Collections;
using ar.com.bic.domain;
using ar.com.bic.domain.esquema;
using NUnit.Framework;

namespace test
{
	[TestFixture]
	public class ReporteTest
	{

		private Reporte reporte = new Reporte();

		public ReporteTest()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		[Test]
		public void DameTablasCandidatas()
		{
			// Creo las tablas fact
			Tabla tablaFact1 = new Tabla("Tabla Fact 1","db","TablaFact1");
			Tabla tablaFact2 = new Tabla("Tabla Fact 2","db","TablaFact2");
			Tabla tablaFact3 = new Tabla("Tabla Fact 3","db","TablaFact3");
			Tabla tablaFact4 = new Tabla("Tabla Fact 4","db","TablaFact4");
			Tabla tablaFact5 = new Tabla("Tabla Fact 5","db","TablaFact5");
			Tabla tablaFact6 = new Tabla("Tabla Fact 6","db","TablaFact6");
			
			// Creo las columnas
			Columna columna1 = new Columna("Columna1","char");
			Columna columna2 = new Columna("Columna2","char");
			Columna columna3 = new Columna("Columna3","char");
			Columna columna4 = new Columna("Columna4","char");
			Columna columna5 = new Columna("Columna5","char");
			Columna columna6 = new Columna("Columna6","char");
			Columna columna7 = new Columna("Columna7","char");
			Columna columna8 = new Columna("Columna8","char");
			Columna columna9 = new Columna("Columna9","char");
			Columna columna10 = new Columna("Columna10","char");

			
			//Agrego las columnas a las tablas
			tablaFact1.AgregarColumna(columna1);
			tablaFact1.AgregarColumna(columna2);
			tablaFact1.AgregarColumna(columna3);
			tablaFact1.AgregarColumna(columna4);
			tablaFact1.AgregarColumna(columna10);

			tablaFact2.AgregarColumna(columna1);
			tablaFact2.AgregarColumna(columna2);
			tablaFact2.AgregarColumna(columna3);
			tablaFact2.AgregarColumna(columna5);

			tablaFact3.AgregarColumna(columna1);
			tablaFact3.AgregarColumna(columna2);
			tablaFact3.AgregarColumna(columna3);
			tablaFact3.AgregarColumna(columna6);
			tablaFact3.AgregarColumna(columna10);

			tablaFact4.AgregarColumna(columna1);
			tablaFact4.AgregarColumna(columna2);
			tablaFact4.AgregarColumna(columna3);
			tablaFact4.AgregarColumna(columna7);

			tablaFact5.AgregarColumna(columna1);
			tablaFact5.AgregarColumna(columna2);
			tablaFact5.AgregarColumna(columna3);
			tablaFact5.AgregarColumna(columna8);
			tablaFact5.AgregarColumna(columna10);
			
			tablaFact6.AgregarColumna(columna1);
			tablaFact6.AgregarColumna(columna2);
			tablaFact6.AgregarColumna(columna3);
			tablaFact6.AgregarColumna(columna9);

			// Agrego las tablas a las columnas
			columna1.AgregarTabla(tablaFact1);
			columna1.AgregarTabla(tablaFact2);
			columna1.AgregarTabla(tablaFact3);
			columna1.AgregarTabla(tablaFact4);
			columna1.AgregarTabla(tablaFact5);
			columna1.AgregarTabla(tablaFact6);

			columna2.AgregarTabla(tablaFact1);
			columna2.AgregarTabla(tablaFact2);
			columna2.AgregarTabla(tablaFact3);
			columna2.AgregarTabla(tablaFact4);
			columna2.AgregarTabla(tablaFact5);
			columna2.AgregarTabla(tablaFact6);

			columna3.AgregarTabla(tablaFact1);
			columna3.AgregarTabla(tablaFact2);
			columna3.AgregarTabla(tablaFact3);
			columna3.AgregarTabla(tablaFact4);
			columna3.AgregarTabla(tablaFact5);
			columna3.AgregarTabla(tablaFact6);

            columna4.AgregarTabla(tablaFact1);

			columna5.AgregarTabla(tablaFact2);

			columna6.AgregarTabla(tablaFact3);

			columna7.AgregarTabla(tablaFact4);

			columna8.AgregarTabla(tablaFact5);

			columna9.AgregarTabla(tablaFact6);

			columna10.AgregarTabla(tablaFact1);
			columna10.AgregarTabla(tablaFact3);
			columna10.AgregarTabla(tablaFact5);


			// Creo los hechos en base a las columnas
			Hecho hecho1 = new Hecho("Hecho 1",columna1);
			Hecho hecho2 = new Hecho("Hecho 2",columna2);
			Hecho hecho3 = new Hecho("Hecho 3",columna3);
			Hecho hecho4 = new Hecho("Hecho 4",columna4);
			Hecho hecho5 = new Hecho("Hecho 5",columna5);
			Hecho hecho6 = new Hecho("Hecho 6",columna6);
			Hecho hecho7 = new Hecho("Hecho 7",columna7);
			Hecho hecho8 = new Hecho("Hecho 8",columna8);
			Hecho hecho9 = new Hecho("Hecho 9",columna9);
			Hecho hecho10 = new Hecho("Hecho 10",columna10);
			
			// Creo las metricas de esos echos para el reporte
			Metrica metrica1 = new Metrica("Metrica 1","sum",hecho1);
			Metrica metrica2 = new Metrica("Metrica 2","sum",hecho2);
			Metrica metrica3 = new Metrica("Metrica 3","sum",hecho3);
			Metrica metrica4 = new Metrica("Metrica 4","sum",hecho4);
			Metrica metrica5 = new Metrica("Metrica 5","sum",hecho5);
			Metrica metrica6 = new Metrica("Metrica 6","sum",hecho6);
			Metrica metrica7 = new Metrica("Metrica 7","sum",hecho7);
			Metrica metrica8 = new Metrica("Metrica 8","sum",hecho8);
			Metrica metrica9 = new Metrica("Metrica 9","sum",hecho9);
			Metrica metrica10 = new Metrica("Metrica 10","sum",hecho10);
			
			//Agrego metricas al reporte
			this.reporte.AgregarMetrica(metrica1);
			this.reporte.AgregarMetrica(metrica10);
            
			//Le pido las tablas fact que tienen todas las metricas o sea las candidatas
			ArrayList tablasCandidatas = this.reporte.DameTablasCandidatas();
			
			//Verifico que se alla elegido bien las tablas candidatas
			Assert.Contains(tablaFact1,tablasCandidatas);
			Assert.Contains(tablaFact3,tablasCandidatas);
			Assert.Contains(tablaFact5,tablasCandidatas);

			//Verifico que no se allan elegido tablas que no tenian esas metricas

			Assert.IsFalse(tablasCandidatas.Contains(tablaFact2));
			Assert.IsFalse(tablasCandidatas.Contains(tablaFact4));
			Assert.IsFalse(tablasCandidatas.Contains(tablaFact6));
		}
	}
}

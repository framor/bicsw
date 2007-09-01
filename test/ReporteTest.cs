using ar.com.bic.domain;
using ar.com.bic.domain.catalogo;
using System.Collections;
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

			Columna columna1  = new Columna("campo_a","char",tablaFact1 );
			Columna columna2  = new Columna("campo_b","char",tablaFact1 );
			Columna columna3  = new Columna("campo_c","char",tablaFact1 );
			Columna columna4  = new Columna("campo_d","char",tablaFact1 );
			Columna columna5  = new Columna("campo_j","char",tablaFact1 );
			Columna columna6  = new Columna("campo_a","char",tablaFact2 );
			Columna columna7  = new Columna("campo_b","char",tablaFact2 );
			Columna columna8  = new Columna("campo_c","char",tablaFact2 );
			Columna columna9  = new Columna("campo_e","char",tablaFact2 );
			Columna columna10  = new Columna("campo_a","char",tablaFact3 );
			Columna columna11  = new Columna("campo_b","char",tablaFact3 );
			Columna columna12  = new Columna("campo_c","char",tablaFact3 );
			Columna columna13  = new Columna("campo_f","char",tablaFact3 );
			Columna columna14  = new Columna("campo_j","char",tablaFact3 );
			Columna columna15  = new Columna("campo_a","char",tablaFact4 );
			Columna columna16  = new Columna("campo_b","char",tablaFact4 );
			Columna columna17  = new Columna("campo_c","char",tablaFact4 );
			Columna columna18  = new Columna("campo_g","char",tablaFact4 );
			Columna columna19  = new Columna("campo_a","char",tablaFact5 );
			Columna columna20  = new Columna("campo_b","char",tablaFact5 );
			Columna columna21  = new Columna("campo_c","char",tablaFact5 );
			Columna columna22  = new Columna("campo_h","char",tablaFact5 );
			Columna columna23  = new Columna("campo_j","char",tablaFact5 );
			Columna columna24  = new Columna("campo_a","char",tablaFact6 );
			Columna columna25  = new Columna("campo_b","char",tablaFact6 );
			Columna columna26  = new Columna("campo_c","char",tablaFact6 );
			Columna columna27  = new Columna("campo_i","char",tablaFact6 );

			// Creo los campos con las columnas

			Campo campo_a = new Campo(columna1);
			Campo campo_b = new Campo(columna2);
			Campo campo_c = new Campo(columna3);
			Campo campo_d = new Campo(columna4);
			Campo campo_e = new Campo(columna9);
			Campo campo_f = new Campo(columna13);
			Campo campo_g = new Campo(columna18);
			Campo campo_h = new Campo(columna22);
			Campo campo_i = new Campo(columna27);
			Campo campo_j = new Campo(columna5);
			
			// Agrego el resto de las columnas a los campos del mismo nombre

			campo_a.AgregarColumnas(columna6);
			campo_a.AgregarColumnas(columna10);
			campo_a.AgregarColumnas(columna15);
			campo_a.AgregarColumnas(columna19);
			campo_a.AgregarColumnas(columna24);
			
			campo_b.AgregarColumnas(columna7);
			campo_b.AgregarColumnas(columna11);
			campo_b.AgregarColumnas(columna16);
			campo_b.AgregarColumnas(columna20);
			campo_b.AgregarColumnas(columna25);
			
			campo_c.AgregarColumnas(columna8);
			campo_c.AgregarColumnas(columna12);
			campo_c.AgregarColumnas(columna17);
			campo_c.AgregarColumnas(columna21);
			campo_c.AgregarColumnas(columna26);
			
			campo_j.AgregarColumnas(columna14);
			campo_j.AgregarColumnas(columna23);

			// Agrego las columnas a sus correspondientes tablas

			tablaFact1.AgregarColumna(columna1); 
			tablaFact1.AgregarColumna(columna2); 
			tablaFact1.AgregarColumna(columna3); 
			tablaFact1.AgregarColumna(columna4); 
			tablaFact1.AgregarColumna(columna5); 
			
			tablaFact2.AgregarColumna(columna6); 
			tablaFact2.AgregarColumna(columna7); 
			tablaFact2.AgregarColumna(columna8); 
			tablaFact2.AgregarColumna(columna9); 
			
			tablaFact3.AgregarColumna(columna10);
			tablaFact3.AgregarColumna(columna11);
			tablaFact3.AgregarColumna(columna12);
			tablaFact3.AgregarColumna(columna13);
			tablaFact3.AgregarColumna(columna14);
			
			tablaFact4.AgregarColumna(columna15);
			tablaFact4.AgregarColumna(columna16);
			tablaFact4.AgregarColumna(columna17);
			tablaFact4.AgregarColumna(columna18);
			
			tablaFact5.AgregarColumna(columna19);
			tablaFact5.AgregarColumna(columna20);
			tablaFact5.AgregarColumna(columna21);
			tablaFact5.AgregarColumna(columna22);
			tablaFact5.AgregarColumna(columna23);
			
			tablaFact6.AgregarColumna(columna24);
			tablaFact6.AgregarColumna(columna25);
			tablaFact6.AgregarColumna(columna26);
			tablaFact6.AgregarColumna(columna27);

			// Creo los hechos en base a las campos

			Hecho hecho_a = new Hecho("Hecho a",campo_a);
			Hecho hecho_b = new Hecho("Hecho b",campo_b);
			Hecho hecho_c = new Hecho("Hecho c",campo_c);
			Hecho hecho_d = new Hecho("Hecho d",campo_d);
			Hecho hecho_e = new Hecho("Hecho e",campo_e);
			Hecho hecho_f = new Hecho("Hecho f",campo_f);
			Hecho hecho_g = new Hecho("Hecho g",campo_g);
			Hecho hecho_h = new Hecho("Hecho h",campo_h);
			Hecho hecho_i = new Hecho("Hecho i",campo_i);
			Hecho hecho_j = new Hecho("Hecho j",campo_j);

			// Creo las metricas de esos echos para el reporte

			Metrica metrica_a = new Metrica("Metrica a","sum",hecho_a);
			Metrica metrica_b = new Metrica("Metrica b","sum",hecho_b);
			Metrica metrica_c = new Metrica("Metrica c","sum",hecho_c);
			Metrica metrica_d = new Metrica("Metrica d","sum",hecho_d);
			Metrica metrica_e = new Metrica("Metrica e","sum",hecho_e);
			Metrica metrica_f = new Metrica("Metrica f","sum",hecho_f);
			Metrica metrica_g = new Metrica("Metrica g","sum",hecho_g);
			Metrica metrica_h = new Metrica("Metrica h","sum",hecho_h);
			Metrica metrica_i = new Metrica("Metrica i","sum",hecho_i);
			Metrica metrica_j = new Metrica("Metrica j","sum",hecho_j);
			
			//Agrego metricas al reporte

			this.reporte.AgregarMetrica(metrica_a);
			this.reporte.AgregarMetrica(metrica_j);
            
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

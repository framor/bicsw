using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Bic.Domain;
using Bic.Domain.Catalogo;

namespace Bic.Web.test
{
	/// <summary>
	/// Descripción breve de ReporteTest.
	/// </summary>
	public class ReporteTest : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label consola;
		private Proyecto proyecto = new Proyecto();
		private Reporte reporte = new Reporte();
		private Hashtable tablasFact = new Hashtable();
		private Hashtable tablasLkp = new Hashtable();
		private Hashtable campos = new Hashtable();
		private Hashtable atributos = new Hashtable();
		private Hashtable metricas = new Hashtable();
		protected System.Web.UI.WebControls.Button GeneraConsulta;
		private Hashtable hechos = new Hashtable();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
		}

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.GeneraConsulta.Click += new System.EventHandler(this.GeneraConsulta_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void GeneraAmbiente1()
		{
			this.proyecto.Id = 1;

			Columna product_id = new Columna("product_id","INTEGER");

			Columna product_class_id = new Columna("product_class_id","INTEGER");

			Columna time_id = new Columna("time_id","INTEGER");

			Atributo producto = new Atributo("Producto",product_id,new Tabla("Producto LKP","product","foodmart",1,this.proyecto),this.proyecto);
			Atributo claseProducto = new Atributo("Clase Producto",product_class_id,new Tabla("Clase Producto LKP","product_class","foodmart",2,this.proyecto),this.proyecto);
			Atributo tiempo = new Atributo("Tiempo",time_id,new Tabla("Tiempo LKP","time_by_day","foodmart",5,this.proyecto),this.proyecto);

			claseProducto.Hijo = producto;
			producto.AgregarPadre(claseProducto);

			Columna store_cost = new Columna("store_cost","decimal");
			store_cost.Id = 1;

			Hecho costoAlmacen = new Hecho("Costo de Almacen",store_cost);

			costoAlmacen.Id = 1;
			costoAlmacen.Proyecto = this.proyecto;

			Metrica sumaCostoAlmacen = new Metrica("Suma de Costos de Almacen","sum",costoAlmacen);

			this.metricas.Add("sumaCostoAlmacen",sumaCostoAlmacen);
			this.atributos.Add("claseProducto",claseProducto);
			this.atributos.Add("producto",producto);
			this.atributos.Add("tiempo",tiempo);
		}

		private void LimpiarAmbiente()
		{
			this.proyecto = new Proyecto();
			this.reporte = new Reporte();
			this.tablasFact = new Hashtable();
			this.tablasLkp = new Hashtable();
			this.campos = new Hashtable();
			this.atributos = new Hashtable();
			this.metricas = new Hashtable();
			this.hechos = new Hashtable();
		}

		private void GeneraConsulta_Click(object sender, System.EventArgs e)
		{
			this.LimpiarAmbiente();
			this.GeneraAmbiente1();
			this.reporte.AgregarAtributo((Atributo)this.atributos["claseProducto"]);
			this.reporte.AgregarAtributo((Atributo)this.atributos["producto"]);
			this.reporte.AgregarAtributo((Atributo)this.atributos["tiempo"]);
			this.reporte.AgregarMetrica((Metrica)this.metricas["sumaCostoAlmacen"]);

			this.reporte.GeneraConsulta();

			this.consola.Text = this.reporte.DameSql();
		}

	}
}

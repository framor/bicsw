using System;
using System.Drawing;
using WebChart;

namespace Bic.Web.Reportes
{
	/// <summary>
	/// Clase encargada de renderizar el grafico de previsualizacion.
	/// </summary>
	public class ChartRenderPage : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			ChartEngine chartEngine = new ChartEngine();
			chartEngine.Size = new Size(720, 340);

			ChartCollection chartCollection = ReportManager.GetInstance(this.Session).GetPreviewCharts(chartEngine);
			chartEngine.Charts = chartCollection;			
			
			Bitmap bmp = null;

			System.IO.MemoryStream memStream = new System.IO.MemoryStream();

			this.SetMoreProperties(chartEngine);

			bmp = chartEngine.GetBitmap();
			bmp.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
			memStream.WriteTo(Response.OutputStream);
			Response.End();

		}


		private void SetMoreProperties(ChartEngine engine)
		{
			// TODO : habria que unificar logica en las paginas de renderizacion de garficos
			// tambien habria que modificar las caracteristicas del grafico para que se vea con
			// las descripciones y toda la bola.

			System.Drawing.Font myFont = new System.Drawing.Font("Verdana", 8);
			
			engine.Border.EndCap =System.Drawing.Drawing2D.LineCap.Flat;
			engine.Border.DashStyle=System.Drawing.Drawing2D.DashStyle.Solid;
			engine.Border.StartCap=System.Drawing.Drawing2D.LineCap.Flat;
			engine.Border.Color=Color.SteelBlue;
			engine.Border.Width=0;
			engine.Border.LineJoin= System.Drawing.Drawing2D.LineJoin.Miter;

			engine.PlotBackground.Type = InteriorType.Solid;
			engine.PlotBackground.StartPoint=new Point(0, 0);
			engine.PlotBackground.ForeColor= Color.Black;
			engine.PlotBackground.EndPoint= new Point(100, 100);
			engine.PlotBackground.Color=Color.White;
			engine.PlotBackground.HatchStyle= System.Drawing.Drawing2D.HatchStyle.Shingle;

			engine.Padding =2;
			engine.ChartPadding = 20;
			engine.TopPadding = 20;
			

			// Es util cuando hay mas de un conjunto de datos (mas de 1 tupla de x,y)
			engine.HasChartLegend = false;

	        engine.GridLines = GridLines.Horizontal;
			
			engine.ShowYValues = true;

			engine.Background.Color = Color.FromArgb(70, Color.SteelBlue);

			}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}

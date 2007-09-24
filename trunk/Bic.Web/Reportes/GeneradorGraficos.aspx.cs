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
using WebChart;

namespace Bic.Web.Reportes
{
	/// <summary>
	/// Summary description for GeneradorGraficos.
	/// </summary>
	public class GeneradorGraficos : System.Web.UI.Page
	{
		#region Web controls

		protected System.Web.UI.WebControls.Label lblUsuario;
		protected WebChart.ChartControl chartControl;

		#endregion		
	
		#region Event handlers

		private void Page_Load(object sender, System.EventArgs e)
		{
			Chart chart = ReportManager.GetInstance(this.Session).GetChart();
			chartControl.Charts.Add(chart);

			ChartEngine chartEngine = new ChartEngine();
			chartEngine.Size = new Size(500,500);

			ChartCollection chartCollection = new ChartCollection(chartEngine);
			chartEngine.Charts = chartCollection;

			chartCollection.Add(chart);

			Bitmap bmp = chartEngine.GetBitmap();
			System.IO.MemoryStream memStream = new System.IO.MemoryStream();
			bmp.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
			memStream.WriteTo(Response.OutputStream);
			Response.End(); 			
		}


		#endregion		

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

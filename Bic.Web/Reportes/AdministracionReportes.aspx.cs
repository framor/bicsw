using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Table = iTextSharp.text.Table;
using Color = iTextSharp.text.Color;
using Rectangle = iTextSharp.text.Rectangle;
using Font = iTextSharp.text.Font;



namespace Bic.Web
{
	/// <summary>
	/// Summary description for AdministracionReportes.
	/// </summary>
	public class AdministracionReportes : System.Web.UI.Page
	{
		//TODO : subir al basepage este label
		protected System.Web.UI.WebControls.Label lblUsuario;
		
		#region	Web controls

		protected System.Web.UI.WebControls.DataGrid dtgReport;
		protected System.Web.UI.WebControls.ImageButton imgBtnExcel;
		protected System.Web.UI.WebControls.ImageButton imgBtnWord;
		protected System.Web.UI.WebControls.ImageButton imgBtnText;
		protected System.Web.UI.WebControls.DropDownList ddlTipoGrafico;
		protected System.Web.UI.WebControls.Button btnContinuar;
		protected System.Web.UI.WebControls.DropDownList ddlColumna;
		protected System.Web.UI.WebControls.DropDownList ddlDescripciones;
		protected System.Web.UI.WebControls.ImageButton imgBtnPDF;

		#endregion
	
		#region Event handlers

		private void Page_Load(object sender, System.EventArgs e)
		{						
			if (!IsPostBack)
			{	
				ReportManager.GetInstance(this.Session).ReportCache = DataSourceMockProvider.GetDataSource();

				this.InitializeComboValues();

				this.dtgReport.DataSource = ReportManager.GetInstance(this.Session).ReportCache;
				this.dtgReport.DataBind();	
			}
		}


		private void dtgReport_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			//TODO : aca se puede asignar formato al datagrid.
		}


		private void imgBtnExcel_Click(object sender, ImageClickEventArgs e)
		{
			Response.Clear();
			Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
			Response.Charset = "";
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "application/vnd.xls";
			System.IO.StringWriter stringWrite = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
			this.dtgReport.RenderControl(htmlWrite);
			Response.Write(stringWrite.ToString());
			Response.End();
		}


		private void imgBtnWord_Click(object sender, ImageClickEventArgs e)
		{
			Response.Clear();
			Response.AddHeader("content-disposition", "attachment;filename=FileName.doc");
			Response.Charset = "";
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "application/vnd.word";
			System.IO.StringWriter stringWrite = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
			this.dtgReport.RenderControl(htmlWrite);
			Response.Write(stringWrite.ToString());
			Response.End();
		}
		

		private void imgBtnPDF_Click(object sender, ImageClickEventArgs e)
		{
			Document document = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);
			document.AddAuthor("BIC");
			document.AddSubject("Report to pdf");			
			
			try
			{
				//TODO : comprobar si el archivo existe y eliminarlo

				PdfWriter writer = PdfWriter.GetInstance(document, 
					new FileStream(@"E:\bic\Bic.Web\FileName.pdf", FileMode.Create));

				// step 3: we open the document
				document.Open();

				document.Add(this.GetDataGridTable()); 

				// step 5: we close the document
				document.Close();

				Response.Clear();       
				Response.ContentType = "application/octet-stream";
				Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(@"E:\bic\Bic.Web\FileName.pdf"));
				Response.TransmitFile(@"E:\bic\Bic.Web\FileName.pdf");
				Response.End();
			}
			catch (DocumentException de)
			{
				string a = de.Message;
			}
			catch (IOException ioe)
			{
				string a = ioe.Message;
			}			
		}


		private void imgBtnText_Click(object sender, ImageClickEventArgs e)
		{
			DataSet ds = DataSourceMockProvider.GetDataSource();
			StringBuilder str = new StringBuilder();

			for(int i=0;i<=ds.Tables[0].Rows.Count - 1; i++)
			{

				for(int j=0;j<=ds.Tables[0].Columns.Count - 1; j++)
				{
					str.Append(ds.Tables[0].Rows[i][j].ToString().Length == 0? "NULL":ds.Tables[0].Rows[i][j].ToString());
					str.Append("|");					
				}

				str.Append("\r\n");				
			}

			Response.Clear();
			Response.AddHeader("content-disposition", "attachment;filename=FileName.txt");
			Response.Charset = "";
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "application/vnd.text";
			System.IO.StringWriter stringWrite = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
			Response.Write(str.ToString());
			Response.End();
		}


		private void btnContinuar_Click(object sender, EventArgs e)
		{
			ReportManager.GetInstance(this.Session).DataColumn  = this.ddlColumna.SelectedValue;
			ReportManager.GetInstance(this.Session).DescriptionColumn = this.ddlDescripciones.SelectedValue;

			switch(this.ddlTipoGrafico.SelectedValue)
			{
				case "Barras": 
						ReportManager.GetInstance(this.Session).GraphType  = ReportManager.GraphTypes.Bars;
						break;
				case "Torta": 
						ReportManager.GetInstance(this.Session).GraphType  = ReportManager.GraphTypes.Pie;
						break;
				case "Lineas": 
						ReportManager.GetInstance(this.Session).GraphType  = ReportManager.GraphTypes.Lines;
						break;
				case "Area": 
						ReportManager.GetInstance(this.Session).GraphType  = ReportManager.GraphTypes.Area;
						break;
			}						

			Response.Redirect("GeneradorGraficos.aspx");
		}


		#endregion

		#region	Private methods

		//TODO : para que la exportacion a PDF tenga un formato correcto, habra que darle formato a la
		// tabla y a las celdas en este metodo.
		private Table GetDataGridTable()
		{
			DataSet ds = DataSourceMockProvider.GetDataSource();
 
			int filas= ds.Tables[0].Rows.Count; 
			int columnas  = ds.Tables[0].Columns.Count;

			Table aTable = new Table(columnas,filas);

			for(int i=0;i<=ds.Tables[0].Rows.Count - 1; i++)
			{
				for(int j=0;j<=ds.Tables[0].Columns.Count - 1; j++)
				{					
					Cell cell = new Cell(ds.Tables[0].Rows[i][j].ToString());
					cell.HorizontalAlignment = Element.ALIGN_CENTER;					
					cell.Border = Rectangle.NO_BORDER; 
					
					aTable.AddCell(cell);
				}
			}

			return aTable;
		}


		private void InitializeComboValues()
		{
			this.ddlTipoGrafico.Items.Add(new System.Web.UI.WebControls.ListItem("Barras","Barras"));
			this.ddlTipoGrafico.Items.Add(new System.Web.UI.WebControls.ListItem("Torta","Torta"));
			this.ddlTipoGrafico.Items.Add(new System.Web.UI.WebControls.ListItem("Lineas","Lineas"));
			this.ddlTipoGrafico.Items.Add(new System.Web.UI.WebControls.ListItem("Area","Area"));

			foreach ( DataColumn column in ReportManager.GetInstance(this.Session).ReportCache.Tables[0].Columns)
			{
				if(column.DataType == typeof (System.Int16) || 
					column.DataType == typeof (System.Int32) ||
					column.DataType == typeof (System.Int64) ||
					column.DataType == typeof (System.UInt64 ) ||
					column.DataType == typeof (System.UInt32  ) ||
					column.DataType == typeof (System.UInt16 ) ||
					column.DataType == typeof (System.Decimal))
				{
					this.ddlColumna.Items.Add(new System.Web.UI.WebControls.ListItem(column.Caption,column.Caption));
				}
					//TODO : analizar otros tipos de datos
				else //if ( column.DataType() == typeof (System.String) || column.DataType() == typeof (System.DateTime))
				{
					this.ddlDescripciones.Items.Add(new System.Web.UI.WebControls.ListItem(column.Caption,column.Caption));
				}
				

			}
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
			this.dtgReport.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dtgReport_ItemDataBound);
			this.imgBtnExcel.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnExcel_Click);
			this.imgBtnWord.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnWord_Click);
			this.imgBtnPDF.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnPDF_Click);
			this.imgBtnText.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnText_Click);
			this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		#endregion				
	}
}

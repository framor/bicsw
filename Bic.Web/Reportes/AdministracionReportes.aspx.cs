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
using Bic.Application;
using Bic.Application.DTO;
using Bic.Domain;
using Bic.Framework.Exception;


namespace Bic.Web
{
	public class AdministracionReportes : BasePage 
	{
		#region	Web controls

		protected System.Web.UI.WebControls.Button btnChartWizard;
		protected System.Web.UI.WebControls.DataGrid dtgReport;
		protected System.Web.UI.WebControls.DropDownList ddlDrillDown; 
		protected System.Web.UI.WebControls.DropDownList ddlDrillUp;
		protected System.Web.UI.WebControls.ImageButton imgBtnExcel;
		protected System.Web.UI.WebControls.ImageButton imgBtnWord;
		protected System.Web.UI.WebControls.ImageButton imgBtnText;
		protected System.Web.UI.WebControls.ImageButton imgBtnPDF;

		protected CustomValidator valDrill;
		protected ValidationSummary valSummary;

		#endregion
	
		#region Event handlers

		private void Page_Load(object sender, System.EventArgs e)
		{	
			this.BaseLoad();	

			if (!IsPostBack)
			{
				try
				{
					this.InitializeComboValues();
					this.dtgReport.DataSource = ReportManager.GetInstance(this.Session).ReportSourceCache;				 
					this.dtgReport.DataBind();	
					
					this.RegisterScripts();
					this.btnChartWizard.Enabled = ReportManager.GetInstance(this.Session).Reporte.Metricas.Count != 0 && ReportManager.GetInstance(this.Session).Reporte.Atributos.Count !=0;
					
				}
				catch (ServiceException se)
				{
					Page.RegisterStartupScript("errorscript", "<script>alert('Error de ejecución en el reporte. Contactarse con el arquitecto para verificar el problema.');history.back()</script>");
				}
			}
		}


		private void imgBtnExcel_Click(object sender, ImageClickEventArgs e)
		{
			Response.Clear();
			Response.AddHeader("content-disposition", "attachment;filename="+this.GetFileName()+".xls");
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
			Response.AddHeader("content-disposition", "attachment;filename="+this.GetFileName()+".doc");
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
				//TODO : Manejar adecuadamente las excepciones que se generen durante la exportacion ( para todos los tipos )

				PdfWriter writer = PdfWriter.GetInstance(document, 
					new FileStream(Request.PhysicalApplicationPath + "/" + this.GetFileName()+".pdf", FileMode.Create));

				// step 3: we open the document
				document.Open();

				document.Add(this.GetDataGridTable()); 

				// step 5: we close the document
				document.Close();

				Response.Clear();       
				Response.ContentType = "application/octet-stream";
				Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(@"E:\bic\Bic.Web\" + this.GetFileName()+".pdf"));
				Response.WriteFile(Request.PhysicalApplicationPath + "/" + this.GetFileName()+".pdf");
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
			DataSet ds = ReportManager.GetInstance(this.Session).ReportSourceCache;
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
			Response.AddHeader("content-disposition", "attachment;filename="+this.GetFileName()+".txt");
			Response.Charset = "";
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.ContentType = "application/vnd.text";
			System.IO.StringWriter stringWrite = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
			Response.Write(str.ToString());
			Response.End();
		}


		private void ddlDrillDown_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ddlDrillDown.SelectedValue != string.Empty)
			{
				Atributo atributo = BICContext.Instance.AtributoService.Retrieve(long.Parse( this.ddlDrillDown.SelectedValue));
				ReportManager.GetInstance(this.Session).Reporte.Atributos.Add(atributo);

				try
				{
					this.dtgReport.DataSource = ReportManager.GetInstance(this.Session).ReportSourceCache; 
				}
				catch (ServiceException se)
				{
					this.valDrill.IsValid = false;
					this.valDrill.ErrorMessage = se.Message;

				}
				this.dtgReport.DataBind();	

				this.InitializeComboValues();
			}			
		}


		private void ddlDrillUp_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ddlDrillUp.SelectedValue != string.Empty)
			{
				Atributo atributoPadre = BICContext.Instance.AtributoService.Retrieve(long.Parse( this.ddlDrillUp.SelectedValue));				

				ReportManager.GetInstance(this.Session).Reporte.Atributos.Add(atributoPadre);
				ReportManager.GetInstance(this.Session).Reporte.Atributos.Remove(atributoPadre.Hijo);

				try
				{
					this.dtgReport.DataSource = ReportManager.GetInstance(this.Session).ReportSourceCache; 
				}
				catch (ServiceException se)
				{
					this.valDrill.IsValid = false;
					this.valDrill.ErrorMessage = se.Message;

				}
				this.dtgReport.DataBind();	

				this.InitializeComboValues();
			}
		}


		#endregion

		#region	Private methods

		//TODO : para que la exportacion a PDF tenga un formato correcto, habra que darle formato a la
		// tabla y a las celdas en este metodo.
		private Table GetDataGridTable()
		{
			DataSet ds = ReportManager.GetInstance(this.Session).ReportSourceCache; 
 
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
			this.ddlDrillDown.DataSource = this.GetAtributosHijos();			
			this.ddlDrillDown.DataTextField = "Nombre";
			this.ddlDrillDown.DataValueField = "Id";
			this.ddlDrillDown.DataBind();
			this.ddlDrillDown.Items.Insert(0, new System.Web.UI.WebControls.ListItem(string.Empty,string.Empty));			
			
			this.ddlDrillUp.DataSource = this.GetAtributosPadres();			
			this.ddlDrillUp.DataTextField = "Nombre";
			this.ddlDrillUp.DataValueField = "Id";
			this.ddlDrillUp.DataBind();
			this.ddlDrillUp.Items.Insert(0, new System.Web.UI.WebControls.ListItem(string.Empty,string.Empty));
		}


		private ICollection GetAtributosHijos()
		{
			ArrayList atributosHijos = new ArrayList();
			ReporteDTO repDTO = ReportManager.GetInstance(this.Session).Reporte;

			foreach ( Atributo atributo in repDTO.Atributos )
			{
				if(atributo.Hijo!= null && !repDTO.Atributos.Contains(atributo.Hijo))
				{
					atributosHijos.Add(atributo.Hijo);
				}
			}

			return atributosHijos;
		}


		private ICollection GetAtributosPadres()
		{
			ArrayList atributosPadres = new ArrayList();
			ReporteDTO repDTO = ReportManager.GetInstance(this.Session).Reporte;

			foreach ( Atributo atributo in repDTO.Atributos )
			{
				foreach (Atributo atPadre in atributo.AtributosPadres)
				{
					if(atPadre!= null && !repDTO.Atributos.Contains(atPadre))
					{
						atributosPadres.Add(atPadre);
					}
				}				
			}
			return atributosPadres;
		}


		private void RegisterScripts()
		{
			this.btnChartWizard.Attributes.Add("OnClick", @"window.open('ChartWizardStep1.aspx' , 'Asistente' , 'width= 800 ,height=730 ,directories= no ,location= no ,menubar= no ,scrollbars= no ,status=no ,toolbar= no,resizable=no');");
		}


		private string GetFileName()
		{
			return ReportManager.GetInstance(this.Session).Reporte.Nombre;
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
		

		private void InitializeComponent()
		{    
			this.imgBtnExcel.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnExcel_Click);
			this.imgBtnWord.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnWord_Click);
			this.imgBtnPDF.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnPDF_Click);
			this.imgBtnText.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnText_Click);
			this.ddlDrillDown.SelectedIndexChanged+=new EventHandler(ddlDrillDown_SelectedIndexChanged);
			this.ddlDrillUp.SelectedIndexChanged+=new EventHandler(ddlDrillUp_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
		}


		#endregion

		protected override bool TienePermisosSuficientes()
		{
			return true;
		}

		
	}
}

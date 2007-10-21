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
using Bic.Application;
using Bic.Domain;
using WebChart;

namespace Bic.Web
{
	public class ChartWizardStep2 : WizardBasePage
	{
		#region Web controls

		protected System.Web.UI.WebControls.DropDownList ddlColumna;
		protected System.Web.UI.WebControls.DropDownList ddlDescripciones;
		protected System.Web.UI.WebControls.RadioButtonList rdoBtnLstFilterOptions;
		protected System.Web.UI.WebControls.ImageButton imgPreviewChart;
		protected System.Web.UI.WebControls.ListBox lstBoxDataSources;		
		protected System.Web.UI.WebControls.LinkButton lnkAddDataSource;	
		protected System.Web.UI.WebControls.LinkButton lnkRemoveDataSource;	
		protected System.Web.UI.WebControls.TextBox txtDataSourceName;	

		//protected System.Web.UI.WebControls.RequiredFieldValidator reqDataSourceName;	
		protected System.Web.UI.WebControls.ValidationSummary valSummary;	
		protected System.Web.UI.WebControls.CustomValidator valDataSourceName;	

		#endregion
	
		#region Event handlers

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.BaseLoad();

			if(!IsPostBack)
			{
				this.InitializeComboValues();
				this.InitializeRadioButtonList();
				
				this.PopulateView();
			}
		}


		private void rdoBtnLstFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReportManager.GetInstance(this.Session).GraphFilter = this.rdoBtnLstFilterOptions.SelectedValue;			
			this.PopulateView();
		}


		private void lnkAddDataSource_Click(object sender, EventArgs e)
		{
			//if(! ReportManager.GetInstance(this.Session).DataSources.ContainsKey(this.txtDataSourceName.Text))
			if(! ReportManager.GetInstance(this.Session).DataSources.ContainsKey(this.ddlColumna.SelectedValue))
			{
				DataSourceItem item = new DataSourceItem();
				item.Name = this.txtDataSourceName.Text;
				item.DataField = this.ddlColumna.SelectedValue;
				item.DescriptionField = this.ddlDescripciones.SelectedValue;

				ReportManager.GetInstance(this.Session).DataSources.Add(this.ddlColumna.SelectedValue,item);
			}
			else
			{
				this.valDataSourceName.IsValid = false;
				this.valDataSourceName.ErrorMessage = "Ya existe una fuente de datos con ese nombre.";
			}			

			this.PopulateView();
		}


		private void lnkRemoveDataSource_Click(object sender, EventArgs e)
		{
			if(this.lstBoxDataSources.SelectedIndex != -1)
			{
				ReportManager.GetInstance(this.Session).DataSources.Remove(this.lstBoxDataSources.SelectedValue); 
				this.lstBoxDataSources.Items.RemoveAt(this.lstBoxDataSources.SelectedIndex); 
				this.PopulateView();
			}	
		}


		#endregion

		#region Private methods

		private DataSet GetFilterOptions()
		{
			DataSet dataset = new DataSet();
			DataTable table = new DataTable();
			
			table.Columns.Add(new DataColumn("Text"));
			table.Columns.Add(new DataColumn("Value"));
			
			DataRow row1 = table.NewRow();
			DataRow row2 = table.NewRow();
			DataRow row3 = table.NewRow();
			

			row1["Text"] = "Los primeros 100";
			row1["Value"] = ReportManager.GraphFilters.Top.ToString();

			row2["Text"] = "Los últimos 100";
			row2["Value"] = ReportManager.GraphFilters.Bottom.ToString();

			row3["Text"] = "Todos";
			row3["Value"] = ReportManager.GraphFilters.All.ToString();

			table.Rows.Add(row1);
			table.Rows.Add(row2);
			table.Rows.Add(row3);
			
			dataset.Tables.Add(table);

			return dataset;
		}


		private void InitializeRadioButtonList()
		{
			this.rdoBtnLstFilterOptions.DataSource = this.GetFilterOptions();
			this.rdoBtnLstFilterOptions.DataTextField ="Text";
			this.rdoBtnLstFilterOptions.DataValueField ="Value";
			this.rdoBtnLstFilterOptions.SelectedValue = ReportManager.GraphFilters.All.ToString();
			this.rdoBtnLstFilterOptions.BorderStyle = BorderStyle.None;
			this.rdoBtnLstFilterOptions.RepeatDirection  = RepeatDirection.Horizontal;
			this.rdoBtnLstFilterOptions.RepeatLayout = RepeatLayout.Flow; 
			this.rdoBtnLstFilterOptions.DataBind();
		}


		private void InitializeComboValues()
		{
			DataSet dsSource = ReportManager.GetInstance(this.Session).ReportSourceCache; 

			foreach ( DataColumn column in dsSource.Tables[0].Columns)
			{
				foreach(Atributo atributo in ReportManager.GetInstance(this.Session).Reporte.Atributos)
				{
					foreach(Bic.Domain.Catalogo.Columna columna in atributo.ColumnasDescripciones)
					{
						if (columna.Nombre==column.ColumnName)
						{
							this.ddlDescripciones.Items.Add(new System.Web.UI.WebControls.ListItem(column.Caption,column.Caption));	
						}
					}
				}

				foreach( Metrica metrica in ReportManager.GetInstance(this.Session).Reporte.Metricas)
				{
					if (metrica.Nombre == column.ColumnName)
					{
						this.ddlColumna.Items.Add(new System.Web.UI.WebControls.ListItem(column.Caption,column.Caption));
					}
				}

//				if(column.DataType == typeof (System.Int16) || 
//					column.DataType == typeof (System.Int32) ||
//					column.DataType == typeof (System.Int64) ||
//					column.DataType == typeof (System.UInt64 ) ||
//					column.DataType == typeof (System.UInt32  ) ||
//					column.DataType == typeof (System.UInt16 ) ||
//					column.DataType == typeof (System.Double ) ||
//					column.DataType == typeof (System.SByte ) ||
//					column.DataType == typeof (System.Decimal))
//				{
//					this.ddlColumna.Items.Add(new System.Web.UI.WebControls.ListItem(column.Caption,column.Caption));
//				}
//				
//				this.ddlDescripciones.Items.Add(new System.Web.UI.WebControls.ListItem(column.Caption,column.Caption));				
				
			}
		}


		#endregion

		#region Protected methods

		protected override String NextPage
		{
			get
			{
				return "ChartWizardStep3.aspx";
			}
		}


		protected override String PreviousPage
		{
			get
			{
				return "ChartWizardStep1.aspx";
			}
		}


		protected override void PopulateView()
		{
			this.ddlDescripciones.Enabled = ReportManager.GetInstance(this.Session).DataSources.Keys.Count == 0;
			this.lnkRemoveDataSource.Enabled = ReportManager.GetInstance(this.Session).DataSources.Keys.Count != 0;
			this.txtDataSourceName.Text = string.Empty;

			this.lstBoxDataSources.Items.Clear();
			
			if(ReportManager.GetInstance(this.Session).GraphFilter != null)
			{
				ReportManager.GraphFilters filter = (ReportManager.GraphFilters) Enum.Parse(typeof(ReportManager.GraphFilters), ReportManager.GetInstance(this.Session).GraphFilter);
				switch (filter)
				{
					case ReportManager.GraphFilters.All:
							this.rdoBtnLstFilterOptions.SelectedIndex=2;
							break;
					case ReportManager.GraphFilters.Top:
							this.rdoBtnLstFilterOptions.SelectedIndex=0;
							break;
					case ReportManager.GraphFilters.Bottom:
							this.rdoBtnLstFilterOptions.SelectedIndex=1;
							break;																	
				}
			}

			foreach(String key in ReportManager.GetInstance(this.Session).DataSources.Keys)
			{
				DataSourceItem item = ReportManager.GetInstance(this.Session).DataSources[key] as DataSourceItem; 
//TODO ELIMINAR SI ANDA LO D ABAJO
				//this.lstBoxDataSources.Items.Add(new ListItem(item.Name,item.Name));

				this.lstBoxDataSources.Items.Add(new ListItem(item.DataSourceName ,item.DataField));
			}

			if(ReportManager.GetInstance(this.Session).DataSources.Keys.Count != 0)
			{
				ReportManager.GetInstance(this.Session).GraphFilter  = this.rdoBtnLstFilterOptions.SelectedValue;

				this.imgPreviewChart.ImageUrl="PreviewChartRenderPage.aspx";	
				this.btnNext.Enabled = true;
			}
			else
			{
				this.imgPreviewChart.ImageUrl="../img/emptyPreviewChart.png";		
				this.btnNext.Enabled = false;
			}						
		}


		#endregion	

		#region Web Form Designer generated code

		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		

		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);	
			this.rdoBtnLstFilterOptions.SelectedIndexChanged+=new EventHandler(rdoBtnLstFilterOptions_SelectedIndexChanged);
			this.lnkAddDataSource.Click+=new EventHandler(lnkAddDataSource_Click);
			this.lnkRemoveDataSource.Click+=new EventHandler(lnkRemoveDataSource_Click);
			this.imgPreviewChart.CausesValidation=false;
		}


		#endregion
	}
}

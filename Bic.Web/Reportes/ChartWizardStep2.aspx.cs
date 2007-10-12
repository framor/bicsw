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

		#endregion
	
		#region Event handlers

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.BaseLoad();

			if(!IsPostBack)
			{
				this.InitializeComboValues();
				this.InitializeRadioButtonList();

				ReportManager.GetInstance(this.Session).DataColumn  = this.ddlColumna.SelectedValue;
				ReportManager.GetInstance(this.Session).DescriptionColumn  = this.ddlDescripciones.SelectedValue;
				ReportManager.GetInstance(this.Session).GraphFilter  = this.rdoBtnLstFilterOptions.SelectedValue;

				this.PopulateView();
			}
		}


		private void ddlColumna_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReportManager.GetInstance(this.Session).DataColumn  = this.ddlColumna.SelectedValue;
			this.PopulateView();
		}


		private void ddlDescripciones_SelectedIndexChanged(object sender, EventArgs e)
		{			
			ReportManager.GetInstance(this.Session).DescriptionColumn = this.ddlDescripciones.SelectedValue;
			this.PopulateView();
		}


		private void rdoBtnLstFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReportManager.GetInstance(this.Session).GraphFilter = this.rdoBtnLstFilterOptions.SelectedValue;			
			this.PopulateView();
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
				if(column.DataType == typeof (System.Int16) || 
					column.DataType == typeof (System.Int32) ||
					column.DataType == typeof (System.Int64) ||
					column.DataType == typeof (System.UInt64 ) ||
					column.DataType == typeof (System.UInt32  ) ||
					column.DataType == typeof (System.UInt16 ) ||
					column.DataType == typeof (System.Double ) ||
					column.DataType == typeof (System.SByte ) ||
					column.DataType == typeof (System.Decimal))
				{
					this.ddlColumna.Items.Add(new System.Web.UI.WebControls.ListItem(column.Caption,column.Caption));
				}
				else
				{
					this.ddlDescripciones.Items.Add(new System.Web.UI.WebControls.ListItem(column.Caption,column.Caption));
				}
				
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
		{}

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
			this.ddlColumna.SelectedIndexChanged+=new EventHandler(ddlColumna_SelectedIndexChanged);
			this.ddlDescripciones.SelectedIndexChanged+=new EventHandler(ddlDescripciones_SelectedIndexChanged);
			this.rdoBtnLstFilterOptions.SelectedIndexChanged+=new EventHandler(rdoBtnLstFilterOptions_SelectedIndexChanged);
		}

		#endregion		
	}
}

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
using SqlBuilder.Model;

namespace SqlBuilder
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class MainForm : System.Web.UI.Page
	{
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
			this.btnRemoverAtributo.Click += new System.EventHandler(this.btnRemoverAtributo_Click);
			this.btnAgregarAtributo.Click += new System.EventHandler(this.btnAgregarAtributo_Click);
			this.btnAddHecho.Click += new System.EventHandler(this.btnAddHecho_Click);
			this.btnRemoverHecho.Click += new System.EventHandler(this.btnRemoverHecho_Click);
			this.btnGenerarConsulta.Click += new System.EventHandler(this.btnGenerarConsulta_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Web controls

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ListBox lstBoxHechosDisponibles;
		protected System.Web.UI.WebControls.Button btnAddHecho;
		protected System.Web.UI.WebControls.ListBox lstBoxHechosSeleccionados;
		protected System.Web.UI.WebControls.Button btnRemoverHecho;
		protected System.Web.UI.WebControls.ListBox ListBox1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ListBox lstBoxAtributosDisponibles;
		protected System.Web.UI.WebControls.Button btnAgregarAtributo;
		protected System.Web.UI.WebControls.Button btnRemoverAtributo;
		protected System.Web.UI.WebControls.Button btnGenerarConsulta;
		protected System.Web.UI.WebControls.TextBox txtConsulta;
		protected System.Web.UI.WebControls.ListBox lstBoxAtributosSeleccionados;

		#endregion		
	
		#region Miembros privados

		private ArrayList hechosDisponibles;
		private ArrayList hechosElegidos;

		private ArrayList atributosDisponibles;
		private ArrayList atributosElegidos;

		#endregion

		#region Métodos privados

		private void InicializarListas()
		{
			this.hechosDisponibles = MockHelper.GetInstance().Hechos;
			this.hechosElegidos = new ArrayList();
			this.Session["hechosDisponibles"] = this.hechosDisponibles;
			this.Session["hechosElegidos"] = this.hechosElegidos;

			this.atributosDisponibles = MockHelper.GetInstance().AtributosMostrables;
			this.atributosElegidos = new ArrayList();
			this.Session["atributosDisponibles"] = this.atributosDisponibles;
			this.Session["atributosElegidos"] = this.atributosElegidos;

			this.lstBoxAtributosDisponibles.DataSource = this.atributosDisponibles;
			this.lstBoxAtributosDisponibles.DataTextField = "Alias";
			this.lstBoxAtributosDisponibles.DataBind();

			this.lstBoxHechosDisponibles.DataSource = this.hechosDisponibles;
			this.lstBoxHechosDisponibles.DataTextField = "Alias";
			this.lstBoxHechosDisponibles.DataBind();
		}

		#endregion
        
		#region Propiedades

		private ArrayList HechosDisponibles
		{
			get
			{
				if (this.hechosDisponibles == null)
				{
					this.hechosDisponibles = this.Session["hechosDisponibles"] as ArrayList;
				}					
				return this.hechosDisponibles; 
			}
		}

		private ArrayList HechosElegidos
		{
			get
			{
				if (this.hechosElegidos == null)
				{
					this.hechosElegidos = this.Session["hechosElegidos"] as ArrayList;
				}					
				return this.hechosElegidos; 
			}
		}

		private ArrayList AtributosDisponibles
		{
			get
			{
				if (this.atributosDisponibles == null)
				{
					this.atributosDisponibles = this.Session["atributosDisponibles"] as ArrayList;
				}					
				return this.atributosDisponibles; 
			}
		}

		private ArrayList AtributosElegidos
		{
			get
			{
				if (this.atributosElegidos == null)
				{
					this.atributosElegidos = this.Session["atributosElegidos"] as ArrayList;
				}					
				return this.atributosElegidos; 
			}
		}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				this.InicializarListas();
			}			
		}


		#region Event handlers

		private void btnAddHecho_Click(object sender, System.EventArgs e)
		{	
			if( this.lstBoxHechosDisponibles.SelectedIndex != -1 )
			{
				this.HechosElegidos.Insert(this.lstBoxHechosSeleccionados.Items.Count, this.HechosDisponibles[this.lstBoxHechosDisponibles.SelectedIndex]);
				this.lstBoxHechosSeleccionados.Items.Add( this.lstBoxHechosDisponibles.SelectedItem);								

				this.HechosDisponibles.RemoveAt(this.lstBoxHechosDisponibles.SelectedIndex);
				this.lstBoxHechosDisponibles.Items.RemoveAt(this.lstBoxHechosDisponibles.SelectedIndex);                				
			}

			this.lstBoxHechosDisponibles.SelectedIndex = -1;
			this.lstBoxHechosSeleccionados.SelectedIndex = -1;
		}

		private void btnRemoverHecho_Click(object sender, System.EventArgs e)
		{
			if( this.lstBoxHechosSeleccionados.SelectedIndex != -1 )
			{
				this.HechosDisponibles.Insert(this.lstBoxHechosDisponibles.Items.Count, this.HechosElegidos[this.lstBoxHechosSeleccionados.SelectedIndex]);
				this.lstBoxHechosDisponibles.Items.Add( this.lstBoxHechosSeleccionados.SelectedItem);				

				this.HechosElegidos.RemoveAt(this.lstBoxHechosSeleccionados.SelectedIndex);
				this.lstBoxHechosSeleccionados.Items.RemoveAt(this.lstBoxHechosSeleccionados.SelectedIndex);
			}

			this.lstBoxHechosDisponibles.SelectedIndex = -1;
			this.lstBoxHechosSeleccionados.SelectedIndex = -1;

		}

		private void btnAgregarAtributo_Click(object sender, System.EventArgs e)
		{
			if( this.lstBoxAtributosDisponibles.SelectedIndex != -1 )
			{
				this.AtributosElegidos.Insert(this.lstBoxAtributosSeleccionados.Items.Count, this.AtributosDisponibles[this.lstBoxAtributosDisponibles.SelectedIndex]);
				this.lstBoxAtributosSeleccionados.Items.Add( this.lstBoxAtributosDisponibles.SelectedItem);

				this.AtributosDisponibles.RemoveAt(this.lstBoxAtributosDisponibles.SelectedIndex);
				this.lstBoxAtributosDisponibles.Items.RemoveAt(this.lstBoxAtributosDisponibles.SelectedIndex);

			}

			this.lstBoxAtributosDisponibles.SelectedIndex = -1;
			this.lstBoxAtributosSeleccionados.SelectedIndex = -1;
		}

		private void btnRemoverAtributo_Click(object sender, System.EventArgs e)
		{
			if( this.lstBoxAtributosSeleccionados.SelectedIndex != -1 )
			{
				this.AtributosDisponibles.Insert(this.lstBoxAtributosDisponibles.Items.Count, this.AtributosElegidos[this.lstBoxAtributosSeleccionados.SelectedIndex]);
				this.lstBoxAtributosDisponibles.Items.Add( this.lstBoxAtributosSeleccionados.SelectedItem);

				this.AtributosElegidos.RemoveAt(this.lstBoxAtributosSeleccionados.SelectedIndex);
				this.lstBoxAtributosSeleccionados.Items.RemoveAt(this.lstBoxAtributosSeleccionados.SelectedIndex);
			}

			this.lstBoxAtributosDisponibles.SelectedIndex = -1;
			this.lstBoxAtributosSeleccionados.SelectedIndex = -1;		
		}

		private void btnGenerarConsulta_Click(object sender, System.EventArgs e)
		{

			SQLBuilderManager sqlBuilderManager = new SQLBuilderManager();

			try
			{
				this.txtConsulta.Text = sqlBuilderManager.GetSQLSentence(this.HechosElegidos,this.AtributosElegidos, new ArrayList());
			}
			catch (ReportNotSupportedException)
			{
				this.txtConsulta.Text = "Error al generar el reporte. Contactese con FERNANDO RODRIGUEZ AMOR";
			}
		}

		#endregion

		
	}
}

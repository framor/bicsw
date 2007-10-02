using System;

namespace Bic.Web
{
	/// <summary>
	/// Summary description for WizardBasePage.
	/// </summary>
	public abstract class WizardBasePage : BasePage
	{
		#region Constructor

		public WizardBasePage()
		{}


		#endregion

		#region Private members

		private Boolean isFirstPage;
		private Boolean isLastPage;

		#endregion

		#region Web controls

		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnBack;

		#endregion

		#region Protected methods

		protected override void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit (e);			
		}


		protected override bool TienePermisosSuficientes()
		{
			return true;
		}		


		protected abstract String PreviousPage
		{
			get;
		}


		protected abstract String NextPage
		{
			get;
		}


		protected Boolean IsFirstPage
		{
			set
			{
				this.isFirstPage=value;
			}
		}


		protected Boolean IsLastPage
		{
			set
			{
				this.isLastPage=value;
			}
		}


		protected abstract void PopulateView();

		#endregion

		#region Private methods

		private void InitializeComponent()
		{
			this.btnCancel.Attributes.Add("onclick", "JavaScript:window.close(); return false;");

			this.btnBack.Click+=new EventHandler(btnBack_Click);
			this.btnNext.Click+=new EventHandler(btnNext_Click);
			this.btnCancel.Click+=new EventHandler(btnCancel_Click);
			Page.Load+=new EventHandler(Page_Load);

			if(this.isFirstPage)
			{
				this.btnBack.Visible = false;
			}

			if(this.isLastPage)
			{
				this.btnNext.Visible = false;
			}
		}
	

		#endregion

		#region Event handlers

		private void btnBack_Click(object sender, EventArgs e)
		{
			this.Response.Redirect(this.PreviousPage);
		}


		private void btnNext_Click(object sender, EventArgs e)
		{
			this.Response.Redirect(this.NextPage);
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{

		}


		private void Page_Load(object sender, EventArgs e)
		{
			this.BaseLoad();
		}

		#endregion		
	}
}

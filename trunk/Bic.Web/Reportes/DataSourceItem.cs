using System;

namespace Bic.Web
{
	public class DataSourceItem
	{
		#region Constructor

		public DataSourceItem()
		{}

		#endregion

		#region Private members

		private string name;
		private string descriptionField;
		private string dataField;

		#endregion

		#region Properties

		public String Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		public String DescriptionField
		{
			get
			{
				return this.descriptionField;
			}

			set
			{
				this.descriptionField = value;
			}
		}

		public String DataField
		{
			get
			{
				return this.dataField;
			}

			set
			{
				this.dataField = value;
			}
		}

		#endregion
	}
}

namespace Bic.Framework
{
	/// <summary>
	/// Descripción breve de StringUtils.
	/// </summary>
	public class StringUtils
	{
		public static string TrimSpecialCharacters(string s)
		{
			string ret = s;
			ret = StringUtils.RemoveCharacters(ret,'&');
			ret = StringUtils.RemoveCharacters(ret,'<');
			ret = StringUtils.RemoveCharacters(ret,'>');
			ret = StringUtils.RemoveCharacters(ret,'\'');
			//ret = ret.IndexOf('&') >= 0 ? ret.Remove(ret.IndexOf('&'), 1) : ret;
			//ret = ret.IndexOf('<') >= 0 ? ret.Remove(ret.IndexOf('<'), 1) : ret;
			//ret = ret.IndexOf('>') >= 0 ? ret.Remove(ret.IndexOf('>'), 1) : ret;
			//ret = ret.IndexOf('\'') >= 0 ? ret.Remove(ret.IndexOf('\''), 1) : ret;
			return ret;
		}

		public static string RemoveCharacters(string s, char c)
		{
			string ret = s;
			while(ret.IndexOf(c) >= 0)
			{
				ret = ret.Remove(ret.IndexOf(c),1);
			}

			return ret;
		}
	}
}

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
			ret = ret.IndexOf('&') >= 0 ? ret.Remove(ret.IndexOf('&'), 1) : ret;
			ret = ret.IndexOf('<') >= 0 ? ret.Remove(ret.IndexOf('<'), 1) : ret;
			ret = ret.IndexOf('>') >= 0 ? ret.Remove(ret.IndexOf('>'), 1) : ret;
			ret = ret.IndexOf('\'') >= 0 ? ret.Remove(ret.IndexOf('\''), 1) : ret;
			return ret;
		}
	}
}

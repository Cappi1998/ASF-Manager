using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASF_Manager.Models
{
	public class ASFResponse_ActiveGame
	{
		public string Result { get; set; }
		public string Message { get; set; }
		public bool Success { get; set; }

		public bool ActivedSuccess { get; set; }

		[JsonIgnore]
		public string Status
		{
			get
			{
				string estadoPattern = @"Status:\s*(.*?)\s*\|";
				Match match = Regex.Match(Result, estadoPattern);
				if (match.Success)
				{
					return match.Groups[1].Value.Trim();
				}
				return null;
			}
		}

		[JsonIgnore]
		public string Items
		{
			get
			{
				string itensPattern = @"Items:\s*\[(.*?)\]";
				Match match = Regex.Match(Result, itensPattern);
				if (match.Success)
				{
					return match.Groups[1].Value.Trim();
				}
				return null;
			}
		}

		[JsonIgnore]
		public string AppID
		{
			get
			{
				string itens = Items;
				if (!string.IsNullOrEmpty(itens))
				{
					string[] itensArray = itens.Split(',');
					string appID = itensArray[0].Trim();
					return appID;
				}
				return null;
			}
		}
	}
}

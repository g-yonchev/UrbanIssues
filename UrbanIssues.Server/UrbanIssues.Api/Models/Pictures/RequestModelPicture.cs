using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrbanIssues.Api.Models.Pictures
{
	public class RequestModelPicture
	{
		public string Base64Content { get; set; }

		public byte[] ByteArrayContent
		{
			get
			{
				return Convert.FromBase64String(this.Base64Content);
			}
		}
	}
}
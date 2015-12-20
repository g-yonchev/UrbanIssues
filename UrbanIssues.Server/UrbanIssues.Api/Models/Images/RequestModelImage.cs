namespace UrbanIssues.Api.Models.Images
{
    using System;
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
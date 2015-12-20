using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanIssues.ViewModels;

namespace UrbanIssues.Data
{
	public class Data
	{
		public Data()
		{
			this.GenerateUsers();
			this.GenerateIssues();
		}

		public IList<UserViewModel> Users { get; set; }

		public ICollection<IssueDetailViewModel> Issues { get; set; }


		private void GenerateUsers()
		{
			var usernames = new List<string> { "Pesho", "Tosho", "Gosho", "John Doe", "Doncho Minkov", "Georgi Yonchev", "Nikolay Kenov", "Ivaylo Kenov", "Evlogi Hristov" };

			for (int i = 0; i < usernames.Count; i++)
			{
				this.Users.Add(new UserViewModel { Username = usernames[i] });
			}
		}

		private void GenerateIssues()
		{
			for (int i = 0; i < 40; i++)
			{
				IssueDetailViewModel issue = null;

				if (i % 2 == 0)
				{
					issue = new IssueDetailViewModel
					{
						Category = "Infrastructure",
						Comments = new List<string> { "Comment" + i, "Comment" + i + 10 },
						City = "Sofia",
						CreatedOn = DateTime.Now.AddDays(-i),
						Likes = i + 5,
						User = this.Users[i % 10].Username,
						Urls = new List<string>
						{
							"https://pbs.twimg.com/profile_images/542657927144689664/lgs9uzTU.jpeg",
							"http://home.isr.umich.edu/files/2013/09/ISR-Construction_pd-514.jpg",
							"http://www.ceebusinessportal.eu/documents/10180/470540/infrastructure.jpg/dff5560f-b789-4e00-b27b-4ec626b135e1?t=1412584233082"
						}
					};
				}
				else
				{
					issue = new IssueDetailViewModel
					{
						Category = "Buildings",
						Comments = new List<string> { "Comment Number#" + i, "Comment Number#" + i + 10 },
						City = "Plovdiv",
						CreatedOn = DateTime.Now.AddDays(-i),
						Likes = i + 5,
						User = this.Users[i % 10].Username,
						Urls = new List<string>
						{
							"http://www.modular.org/marketing/images/modularadvantage/disaster_relief_MA.jpg",
							"https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQcVuW2y6ivE0RlvihGkRugco-lzj5WjLkj5_MRa5GoxMUvtgya"						}
					};
				}

				this.Issues.Add(issue);
			}
		}


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.ViewModels
{
	class MainPageViewModel : ViewModelBase, IPageViewModel
	{
		public string Title
		{
			get
			{
				return "MainPage";
			}
		}

		public IContentViewModel ContentViewModel { get; set; }
	}
}

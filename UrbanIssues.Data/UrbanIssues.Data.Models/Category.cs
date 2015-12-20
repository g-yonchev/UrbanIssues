﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanIssues.Data.Models
{
	public class Category
	{
		private ICollection<Issue> issues;

		public Category()
		{
			this.issues = new HashSet<Issue>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<Issue> Issues
		{
			get
			{
				return this.issues;
			}
			set
			{
				this.issues = value;
			}
		}
	}

}

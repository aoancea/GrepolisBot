using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrepolisBot.Enums;

namespace GrepolisBot.Models
{
	/// <summary>
	/// Represents the resource data-model.
	/// </summary>
	public class Resource
	{
		/// <summary>
		/// Gets or sets the resource amount.
		/// </summary>
		public int Amount
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the resources type.
		/// </summary>
		public ResourceType Type
		{
			get;
			set;
		}

		/// <summary>
		/// Creates a new instance of the Resource class.
		/// </summary>
		public Resource()
		{
			this.Amount = 0;
			this.Type = ResourceType.Undefined;
		}
	}
}

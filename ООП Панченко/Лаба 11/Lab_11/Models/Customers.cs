using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Lab_11.Models
{
	public class Customer
	{
		public Guid Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		[MaxLength(100)]
		public string ContactInfo { get; set; }

		public virtual ICollection<Specialize> Specializes { get; set; }
	}

}

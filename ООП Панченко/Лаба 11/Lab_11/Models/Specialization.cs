using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11.Models
{
	public class Specialize
	{
		public Guid Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Title { get; set; }

		public int Hours { get; set; }

		[ForeignKey("Doctor")]
		public Guid DoctorId { get; set; }

		public virtual Doctor Doctor { get; set; }

		public virtual ICollection<Customer> Customers { get; set; }
	}
}

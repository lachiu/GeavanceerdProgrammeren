using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace examen_models
{
	[Table("Tickets")]
	public class Ticket : BaseModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Er moet een winkel geselecteerd zijn.")]
		[ForeignKey("Store")]
		public int StoreId { get; set; }

		[Display(Name = "Totaal")]
		public double? Total { get; set; }

		[Display(Name = "Aankoop datum")]
		[DataType(DataType.Date)]
		[Required(ErrorMessage = "Er moet een aankoopdatum geselecteerd zijn.")]
		public DateTime PurchaseDate { get; set; }

		public virtual Store Store { get; set; }

		public List<TicketsProducts> TicketsProducts { get; set; }
	}
}

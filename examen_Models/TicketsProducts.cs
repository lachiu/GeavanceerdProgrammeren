using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace examen_models
{
	[Table("TicketsProducts")]
	public class TicketsProducts : BaseModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Er moet een ticket geselecteerd zijn.")]
		[ForeignKey("Ticket")]
		public int TicketId { get; set; }

		[Required(ErrorMessage = "Er moet een product geselecteerd zijn.")]
		[ForeignKey("Product")]
		public int ProductId { get; set; }

		[Display(Name = "Hoeveelheid")]
		[Required(ErrorMessage = "Er moet een hoeveelheid opgegeven zijn.")]
		public int Qty { get; set; }

		[Display(Name = "Eenheidsprijs")]
		[Required(ErrorMessage = "Er moet een eenheidsprijs opgegeven zijn.")]
		public double UnitPrice { get; set; }

		[Required(ErrorMessage = "Er moet een BTW percentage geselecteerd zijn.")]
		[ForeignKey("Vatpercentage")]
		public int VatPercentageId { get; set; }
		public virtual Ticket Ticket { get; set; }
		public virtual Product Product { get; set; }
		public virtual VatPercentage VatPercentage { get; set; }
	}
}

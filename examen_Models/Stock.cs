using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace examen_models
{
	[Table("Stocks")]
	public class Stock : BaseModel
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Hoeveelheid")]
		[Required(ErrorMessage = "Het veld 'hoeveelheid' moet ingevuld zijn.")]
		public int Qty { get; set; }

		[Required(ErrorMessage = "Een locatie moet geselecteerd zijn.")]
		[ForeignKey("Location")]
		public int LocationId { get; set; }

		[Required(ErrorMessage = "Een product moet geselecteerd zijn.")]
		[ForeignKey("Product")]
		public int ProductId { get; set; }

		public virtual Location Location { get; set; }
		public virtual Product Product { get; set; }
	}
}

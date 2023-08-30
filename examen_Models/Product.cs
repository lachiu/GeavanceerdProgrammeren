using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;

namespace examen_models
{
	[Table("Products")]
	public class Product : BaseModel
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Naam")]
		[Required(ErrorMessage = "Het veld 'naam' moet ingevuld zijn.")]
		[MaxLength(100)]
		public string Name { get; set; }

		[Display(Name = "Beschrijving")]
		public string Description { get; set; }

		[MaxLength(100)]
		public string Barcode { get; set; }

		public List<Stock> Stocks { get; set; }
		public List<TicketsProducts> TicketsProducts { get; set; }
	}
}

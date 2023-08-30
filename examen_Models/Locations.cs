using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examen_models
{
	[Table("Locations")]
	public class Location : BaseModel
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Naam")]
		[Required(ErrorMessage = "Het veld 'naam' moet ingevuld zijn.")]
		[MaxLength(50)]
		public string Name { get; set; }
		public List<Stock> Stocks { get; set; }
	}
}

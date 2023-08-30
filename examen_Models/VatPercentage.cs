using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examen_models
{
	[Table("VatPercentages")]
	public class VatPercentage : BaseModel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int Percentage { get; set; }
		public List<TicketsProducts> TicketsProducts { get; set; }
	}
}

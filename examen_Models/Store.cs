using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace examen_models
{
	[Table("Stores")]
	public class Store : BaseModel
	{
		[Key]
		public int Id { get; set; }
		[Display(Name = "Naam")]
		[Required(ErrorMessage = "Het veld 'naam' moet ingevuld zijn.")]
		[MaxLength(50)]
		public string Name { get; set; }

		public List<Ticket> Tickets { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniNext.Models
{
	public class Cliente
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Campo obligatorio")]

		[DisplayName("Nombre:")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Campo obligatorio")]


		[DisplayName("Apellido:")]
		public string Apellido { get; set; }


		[Required(ErrorMessage = "Campo obligatorio")]
		[DisplayName("DNI:")]
		public string Dni { get; set; }


		[Required(ErrorMessage = "Campo obligatorio")]
		[EmailAddress]
		[DisplayName("Email :")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Campo obligatorio")]
		[DisplayName("Contraseña:")]
		[DataType(DataType.Password)]
		public string Contraseña { get; set; }


		[Required(ErrorMessage = "Campo obligatorio")]
		[CreditCard(ErrorMessage = "Campo obligatorio")]
		[DisplayName("Tarjeta de Credito :")]
		public string TarjetaCredito { get; set; }

		public TipoAbono Abono { get; set; }

		
	}
}
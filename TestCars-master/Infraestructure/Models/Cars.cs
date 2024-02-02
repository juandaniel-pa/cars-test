using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Cars
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string rol { get; set; }

        [Required]
        public DateTime enterCar { get; set; }

        [Required]
        public DateTime leaveCar { get; set; }

    }
}

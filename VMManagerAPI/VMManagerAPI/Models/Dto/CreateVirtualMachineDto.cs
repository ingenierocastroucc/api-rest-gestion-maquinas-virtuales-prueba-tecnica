using System.ComponentModel.DataAnnotations;

namespace VMManagerAPI.Models.Dto
{
    public class CreateVirtualMachineDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string OS { get; set; } = string.Empty;

        [Range(1, 1024)]
        public int RAM { get; set; }

        [Range(1, 64)]
        public int CPU { get; set; }

        [Range(1, 10000)]
        public int Disk { get; set; }

        [Required]
        [RegularExpression("Running|Stopped|Suspended", ErrorMessage = "El estado debe ser Running, Stopped o Suspended")]
        public string Status { get; set; } = "Stopped";

        [Required]
        public int UserId { get; set; }
    }
}
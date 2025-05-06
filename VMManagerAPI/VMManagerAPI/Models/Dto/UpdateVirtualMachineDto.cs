using System.ComponentModel.DataAnnotations;

namespace VMManagerAPI.DTOs
{
    public class UpdateVirtualMachineDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string OS { get; set; } = string.Empty;

        [Range(1, 1024, ErrorMessage = "La RAM debe estar entre 1 y 1024.")]
        public int RAM { get; set; }

        [Range(1, 64, ErrorMessage = "La CPU debe estar entre 1 y 64.")]
        public int CPU { get; set; }

        [Range(1, 10000, ErrorMessage = "El disco debe estar entre 1 y 10000.")]
        public int Disk { get; set; }

        [Required]
        [RegularExpression("Running|Stopped|Suspended", ErrorMessage = "El estado debe ser Running, Stopped o Suspended.")]
        public string Status { get; set; } = "Stopped";

        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public int UserId { get; set; }
    }
}
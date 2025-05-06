using System.ComponentModel.DataAnnotations;

namespace VMManagerAPI.Models.Dto
{
    public class VirtualMachineDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre de la máquina virtual no puede exceder los 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "El sistema operativo no puede exceder los 100 caracteres.")]
        public string OS { get; set; } = string.Empty;

        [Range(1, 1024, ErrorMessage = "RAM debe estar entre 1 MB y 1024 MB.")]
        public int RAM { get; set; }

        [Range(1, 64, ErrorMessage = "CPU debe tener entre 1 y 64 núcleos.")]
        public int CPU { get; set; }

        [Range(1, 1024, ErrorMessage = "Disk debe estar entre 1 GB y 1024 GB.")]
        public int Disk { get; set; }

        [Required]
        [EnumDataType(typeof(VMStatus), ErrorMessage = "El estado debe ser 'Activo' o 'Inactivo'.")]
        public VMStatus Status { get; set; } 

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; }

    }

    public enum VMStatus
    {
        Stopped,
        Running,
        Suspended
    }
}
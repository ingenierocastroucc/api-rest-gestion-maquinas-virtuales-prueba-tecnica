using VMManagerAPI.Models.Dto;

namespace VMManagerAPI.Models
{
    public class VirtualMachine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RAM { get; set; }
        public int CPU { get; set; }
        public int Disk { get; set; }
        public string OS { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
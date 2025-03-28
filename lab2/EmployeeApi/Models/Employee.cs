using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string RoomNumber { get; set; } = string.Empty;

    [Required]
    public string Department { get; set; } = string.Empty;

    public string ComputerInfo { get; set; } = string.Empty;
}
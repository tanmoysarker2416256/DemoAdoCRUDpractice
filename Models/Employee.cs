using System.ComponentModel.DataAnnotations;

namespace DemoAdoCrud.Models; 

public class Employee
{

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string City { get; set; }

}

using System.ComponentModel.DataAnnotations;


namespace SaudiTour;

public class TripType
{
     [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}


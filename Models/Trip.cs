using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudiTour;


public class Trip
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location  { get; set; }
    public string Description { get; set; }
    
    public string Includes { get; set; }
    public decimal Price { get; set; }
    
     public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
    public string Image { get; set; }

    public int ProviderId { get; set; }// Forign Key   

    [ForeignKey("ProviderId")]
    public TripProvider? provider { get; set; }
    
     public int TripTypeId { get; set; }// Forign Key   

    [ForeignKey("TripTypeId")]
    public TripType? TripType { get; set; }
}



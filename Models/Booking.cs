using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SaudiTour;

public class Booking
{
    [Key]
    public int Id { get; set; }

    public int TripId { get; set; }

    [ForeignKey("TripId")]
    public Trip? Trip { get; set; }

    public string UserId { get; set; } // معرف المستخدم من جدول AspNetUsers
     [ForeignKey("UserId")]
     public IdentityUser User { get; set; }

    public DateTime BookingDate { get; set; } = DateTime.Now;

    public int NumberOfPeople { get; set; } 

    [NotMapped]
    public decimal TotalPrice => Trip != null ? Trip.Price * NumberOfPeople : 0;
}

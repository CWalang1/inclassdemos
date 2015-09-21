using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestaurantSystem.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Required(ErrorMessage = "A Customer Name is Required ")]
        [StringLength(48, ErrorMessage = "Customer Name must be less than 48 characters")]
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        [Range(1,16, ErrorMessage="Party size is limited to 1-16 people")]
        public int NumberInParty { get; set; }
        [StringLength(15)]
        public string ContactPhone { get; set; }
        [Required,StringLength(1,MinimumLength=1, ErrorMessage="Reservation status is required")]
        public string ReservationStatus { get; set; }
        [StringLength(1)]
        public string EventCode { get; set; }


        //Navigation properties 
        public virtual SpecialEvent Event { get; set; }
        //The ReservationsTables is a many to many relationship to Tables table the sql
        //ReservationsTable resovles this problem however ReservationTable holds only a compound primary key.
        //We will NOT create a ReservationTable entity in our project but handle it via navigation mapping.
        //Therefore we will place an ICollection property in this entity referring to the Tables table.
        public virtual ICollection<Table> Tables { get; set; }


    }
}

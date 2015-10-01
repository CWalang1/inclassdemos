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
    public class Table
    {
        [Key]
        public int TableID { get; set; }
        [Required, Range(1,25)]
        public byte TableNumber { get; set; }
        public bool Smoking { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }

        //Navigation property 
        //The ReservationsTables is a many to many relationship to Tables table the sql
        //ReservationsTable resovles this problem however ReservationTable holds only a compound primary key.
        //We will NOT create a ReservationTable entity in our project but handle it via navigation mapping.
        //Therefore we will place an ICollection property in this entity referring to the Reservation table.
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }

        public Table()
        {
            Available = true;
        }
    }
}

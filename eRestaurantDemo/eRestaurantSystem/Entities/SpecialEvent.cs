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
    public class SpecialEvent
    {
        [Key]
        [Required(ErrorMessage="An Event Code is Required (only one character)")]
        [StringLength(1, ErrorMessage="Event Code can only use a single character code")]
        public string EventCode { get; set; }
        [Required(ErrorMessage="A description is required 5-30 characters")]
        [StringLength(30, MinimumLength=5, ErrorMessage="Description must be between 5-30 characters")]
        public string Description { get; set; }
        public bool Active { get; set; }

        //Navigation virtual property(s) 
        public virtual ICollection<Reservation> Reservations { get; set; }


        //All classes can have their own constructor
        //constructors can contain initialization values 
        
        public SpecialEvent()
        {
            Active = true;
        }
    }
}

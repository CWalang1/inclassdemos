using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
#endregion 

namespace eRestaurantSystem.Entities.POCOs
{
    public class ReservationDetail
    {
        //note: no validation in these POCO classes  
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }

    }
}

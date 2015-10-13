using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces 
using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;
using eRestaurantSystem.Entities.DTOs;
using eRestaurantSystem.Entities.POCOs; //Use for ODS access 
#endregion 

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        #region QuerySamples
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            using (var context = new eRestaurantContext())
            {
                //retrieve the data from the SpecialEvents table on sql 
                //to do so we will use the DbSet in the eRestaurantContext 
                //call SpecialEvents (done by mapping) 


                //Method syntax 
                //return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //query syntax 
                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationByEventCode(string eventcode)
        {
            using (var context = new eRestaurantContext())
            {
                //query syntax
                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName, item.ReservationDate
                              select item;
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReservationByDate> GetReservationsByDate(string reservationdate)
        {
            using (var context = new eRestaurantContext())
            {
                //remember LINQ does not like using DateTime casting 
                int theYear = DateTime.Parse(reservationdate).Year;
                int theMonth = DateTime.Parse(reservationdate).Month;
                int theDay = DateTime.Parse(reservationdate).Day;

                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select new ReservationByDate() //DTO
                              {
                                  Description = item.Description,
                                  Reservations = from row in item.Reservations
                                                 where row.ReservationDate.Year == theYear
                                                 && row.ReservationDate.Month == theMonth
                                                 && row.ReservationDate.Day == theDay
                                                 select new ReservationDetail()
                                                 {
                                                     CustomerName = row.CustomerName,
                                                     ReservationDate = row.ReservationDate,
                                                     NumberInParty = row.NumberInParty,
                                                     ContactPhone = row.ContactPhone, 
                                                     ReservationStatus = row.ReservationStatus
                                                 }
                              };
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItems> CategoryMenuItems_List()
        {
            using (var context = new eRestaurantContext())
            {
                //remember LINQ does not like using DateTime casting 

                var results = from category in context.MenuCategories
                              orderby category.Description
                              select new CategoryMenuItems() //DTO
                              {
                                  Description = category.Description,
                                  MenuItems = from row in category.MenuItems
                                              select new MenuItem()
                                                 {
                                                     Description = row.Description,
                                                     Price = row.CurrentPrice,
                                                     Calories = row.Calories,
                                                     Comment = row.Comment 
          
                                                 }
                              };
                return results.ToList();
            }
        }
        #endregion

        #region CRUD Insert, Update, Delete
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            // input into this method is at the instance level
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //create a pointer variable for the instance type 
                //set this pointer to null
                SpecialEvent added = null;



                //set up the add request for the dbcontext 
                added = context.SpecialEvents.Add(item);


                //saving the changes will cause the .Add to execute
                //commits the add to the database
                //evaluates the annotations (validation) on your entity 
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State =
                    System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //look up the item instance on the database to determine if 
                //the instance exists
                SpecialEvent existing = context.SpecialEvents.Find(item);
                //setup the delete request command 
                context.SpecialEvents.Remove(existing);
                //commit the action to happen
                context.SaveChanges();

            }
        }

        #endregion
    }
}

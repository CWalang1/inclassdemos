﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using System.Data.Entity;
#endregion

namespace eRestaurantSystem.DAL
{
    //this class should be restricted to access by ONLY 
    //the BLL methods 
    //this class should NOT be accessible outside of the component library 


    // this class inherits DBContext 
    internal class eRestaurantContext : DbContext
    {
        public eRestaurantContext(): base ("name=EatIn")
        { 
            //constructor is used to pass web config string 

        }

        //setup the DbSet mappings 
        //One DbSet for each entity I create.
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Waiter> Waiters { get; set; }

        //when overridding OnModelCreating(), it is important to remember to 
        //call the base method's implementation before you exit the method

        //the ManyToManyNavigationPropertyConfiguration.Map method lets you configure 
        //the tables and columns used for many-to-many relationships.
        //it takes a ManyToManyNavigationPropertyConfiguration instance in which you 
        //specify by the column names by calling the MapLeftKey, MapRightKey, and 
        //ToTable methods.

        //the "left" key is the one specified in the HasMany method
        //the "right" key is the one specified in the WithMany method 

        //We have a many to many relationship between reservation and tables 
        //A reservation may need many tables. 
        //A table can have over time many reservations. 


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(x => x.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("TableID");
                    mapping.MapRightKey("ReservationID");
                });
            base.OnModelCreating(modelBuilder);
        }


    }
}

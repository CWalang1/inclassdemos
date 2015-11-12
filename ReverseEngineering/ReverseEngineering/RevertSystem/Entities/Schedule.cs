namespace RevertSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Schedule
    {
        public int ScheduleID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Day { get; set; }

        public int ShiftID { get; set; }

        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Shift Shift { get; set; }
    }
}

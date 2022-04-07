using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX.Models
{
    public class Crash
    {
        [Key]
        [Required]
        public int CRASH_ID { get; set; }

        [Required]
        public string CRASH_DATE { get; set; }
        [Required]
        public string CRASH_TIME { get; set; }
        [Required]
        public string ROUTE { get; set; }
        [Required]
        public double MILEPOINT { get; set; }
        [Required]
        public double LAT_UTM_Y { get; set; }
        [Required]
        public double LONG_UTM_X { get; set; }
        [Required]
        public string MAIN_ROAD_NAME { get; set; }
        [Required]
        public string CITY { get; set; }
        [Required]
        public string COUNTY_NAME { get; set; }
        [Required]
        public int CRASH_SEVERITY_ID { get; set; }



        //All of the Binary options
        [Required]
        public bool WORK_ZONE_RELATED { get; set; }
        [Required]
        public bool PEDESTRIAN_INVOLVED { get; set; }
        [Required]
        public bool BICYCLIST_INVOLVED { get; set; }
        [Required]
        public bool MOTORCYCLE_INVOLVED { get; set; }
        [Required]
        public bool IMPROPER_RESTRAINT { get; set; }
        [Required]
        public bool UNRESTRAINED { get; set; }
        [Required]
        public bool DUI { get; set; }
        [Required]
        public bool INTERSECTION_RELATED { get; set; }
        [Required]
        public bool WILD_ANIMAL_RELATED { get; set; }
        [Required]
        public bool DOMESTIC_ANIMAL_RELATED { get; set; }
        [Required]
        public bool OVERTURN_ROLLOVER { get; set; }
        [Required]
        public bool COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }
        [Required]
        public bool TEENAGE_DRIVER_INVOLVED { get; set; }
        [Required]
        public bool OLDER_DRIVER_INVOLVED { get; set; }
        [Required]
        public bool NIGHT_DARK_CONDITION { get; set; }
        [Required]
        public bool SINGLE_VEHICLE { get; set; }
        [Required]
        public bool DISTRACTED_DRIVING { get; set; }
        [Required]
        public bool DROWSY_DRIVING { get; set; }
        [Required]
        public bool ROADWAY_DEPARTURE { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace INTEX.Models
{
    public class CrashData
    {
        [Required(ErrorMessage = "Please enter the milepoint location")]
        [Range(0, 550, ErrorMessage = "Enter a decimal between 0 to 550")]
        public float milepoint { get; set; }
        [Required(ErrorMessage = "Please enter the latitude in decimal form (~4000000.000 - 5000000.000")]
        [Range(1, 5000000, ErrorMessage = "Enter a latitude decimal between 4000000 to 5000000")]
        public float lat_utm_y { get; set; }
        [Required(ErrorMessage = "Please enter the longitude in decimal form (~20000.000 - 700000.000")]
        [Range(1, 700000, ErrorMessage = "Enter a longitude decimal between 20000 to 700000")]
        public float long_utm_x { get; set; }
        public float work_zone_related { get; set; }
        public float pedestrian_involved { get; set; }
        public float bicyclist_involved { get; set; }
        public float motorcycle_involved { get; set; }
        public float unrestrained { get; set; }
        public float intersection_related { get; set; }
        public float overturn_rollover { get; set; }
        public float teenage_driver_involved { get; set; }
        public float older_driver_involved { get; set; }
        public float night_dark_condition { get; set; }
        public float single_vehicle { get; set; }
        public float distracted_driving { get; set; }
        public float roadway_departure { get; set; }
        [Required(ErrorMessage = "Please enter a month")]
        [Range(1, 12, ErrorMessage = "Enter a number between 1 to 12")]
        public float month { get; set; }
        [Required(ErrorMessage = "Please an hour")]
        [Range(1, 24, ErrorMessage = "Enter a number between 1 to 24")]
        public float hour { get; set; }
        //public float main_road_name_Other { get; set; }
        //public float crash_severity_id { get; set; }
        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                    milepoint, lat_utm_y, long_utm_x, work_zone_related,
                    pedestrian_involved, bicyclist_involved, motorcycle_involved, unrestrained,
                    intersection_related, overturn_rollover, teenage_driver_involved, older_driver_involved,
                    night_dark_condition, single_vehicle, distracted_driving, roadway_departure, month,
                    hour
            };
            int[] dimensions = new int[] { 1, 18 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrashCourseServer.Models
{
    public class Entry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public DateTime? date { get; set; }
        public int weight { get; set; }
        public double bodyFat { get; set; }
    }
}

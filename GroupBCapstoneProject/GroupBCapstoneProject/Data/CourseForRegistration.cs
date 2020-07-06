﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupBCapstoneProject.Data
{
    public class CourseForRegistration
    {
        public int ID { get; set; }
        public string CourseNumber { get; set; }
        public string SectionNumber { get; set; }
        public int AvailableSeats { get; set; }
        public string Faculty { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int CreditHours { get; set; }
        public string BuildingName { get; set; }
        public string BuildingNumber { get; set; }
        public bool MeetsOnMonday { get; set; }
        public bool MeetsOnTuesday { get; set; }
        public bool MeetsOnWednesday { get; set; }
        public bool MeetsOnThursday { get; set; }
        public bool MeetsOnFriday { get; set; }
        public bool MeetsOnSaturday { get; set; }
    }
}

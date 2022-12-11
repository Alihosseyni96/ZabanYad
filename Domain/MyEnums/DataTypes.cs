using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Domain.MyEnums
{

    public enum CourseLevel
    {
        [Display(Name = "مقدماتی")]
        Intermediate,

        [Display(Name = "متوسط")]
        MidLevel,

        [Display(Name = "پیشرفته")]
        professional
    }
    public enum CourseStatus
    {
        [Display(Name = "به اتمام رسیده")]
        Finished,

        [Display(Name = "درحال برگزاری")]
        OnPerforming
    }
    public static class GetConstants
    {
        public static List<CourseLevel> GetLevels()
        {

            return Enum.GetValues(typeof(CourseLevel)).Cast<CourseLevel>().ToList();
        }
        public static List<CourseStatus> GetStatus()
        {
            return Enum.GetValues(typeof(CourseStatus)).Cast<CourseStatus>().ToList();
        }

    }

}

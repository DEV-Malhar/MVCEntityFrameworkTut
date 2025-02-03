using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProDropDownDB.Models
{
    public class StudentModels
    {
        public int studId { get; set; }

        public List<SelectListItem> studList { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace table.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nmae is required")]
        [Display(Name ="اسم التصنبف")]
        public string CategoryName { get; set; }
        [Display(Name = "وصف التصنبف")]
        public string Description { get; set; }
    }
}

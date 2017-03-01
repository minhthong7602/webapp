using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepApp.Models
{
    [Table("People")]
    public class People
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Số thứ tự")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [Display(Name = "Tuổi")]
        [Range(1,100,ErrorMessage ="Nhập quá tuổi")]
        public int Age { get; set; }

        [Required]
        public bool Gender { get; set; }
    }
}
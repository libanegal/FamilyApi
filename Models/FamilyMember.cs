using System.ComponentModel.DataAnnotations;

namespace using_DB.Models
{
    public class FamilyMember
    {

        [Key] public int id { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string SecondName { get; set; }
        public int Height { get; set; }
    }
    
}

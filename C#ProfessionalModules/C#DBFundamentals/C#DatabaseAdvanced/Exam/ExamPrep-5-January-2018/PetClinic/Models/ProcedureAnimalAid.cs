using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class ProcedureAnimalAid
    {
        //        -	ProcedureId – integer, Primary Key
        //-	Procedure – the animal aid’s procedure(required)
        //-	AnimalAidId – integer, Primary Key
        //-	AnimalAid – the procedure’s animal aid(required)
        
            //maybe int?
        public int ProcedureId { get; set; }
        [Required]
        public Procedure Procedure { get; set; }

        //maybe int?
        public int AnimalAidId { get; set; }
        [Required]
        public AnimalAid AnimalAid { get; set; }
    }
}

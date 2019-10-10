using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data 
{
    public class Major /*: IValidatableObject*/
    {
        public int MajorId { get; set; }
        //[Required]
        public string MajorName { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    List<ValidationResult> errors = new List<ValidationResult>();

        //    if (string.IsNullOrEmpty(MajorName))
        //    {
        //        errors.Add(new ValidationResult("Please enter major name.",
        //            new[] { "MajorName" }));
        //    }
        //    return errors;
        //}

    }
}
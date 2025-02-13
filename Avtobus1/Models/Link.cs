using Avtobus1.Context;
using System.ComponentModel.DataAnnotations;

namespace Avtobus1.Models
{
    public class Link : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Link was not provided")]
        [Url(ErrorMessage = "Provided link is bad")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Short name was not provided")]
        public string? ShortName { get; set; }

        public DateTime CreatedAt { get; set; }

        [Range(0, int.MaxValue)]
        public int Redirects { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = [];
            LinkContext linkContext = (LinkContext)validationContext.GetService(typeof(LinkContext))!;

            var findLinkByShortName = linkContext.Links.FirstOrDefault(l => l.ShortName == ShortName);
            if (findLinkByShortName is not null && findLinkByShortName.Id != Id)
            {
                errors.Add(new ValidationResult("Short name already in use"));
            }

            if (CreatedAt >= DateTime.Now)
            {
                errors.Add(new ValidationResult("Wrong creation date value"));
            }

            return errors;
        }
    }
}

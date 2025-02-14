using Avtobus1.Context;
using System.ComponentModel.DataAnnotations;

namespace Avtobus1.Models
{
    public class Link : IValidatableObject
    {
        public Guid Id { get; set; }

        [Url(ErrorMessage = "Provided link is bad")]
        public string? FullLink { get; set; }

        [Required(ErrorMessage = "Short link was not provided")]
        [RegularExpression(@"^[0-9a-zA-Z]{6,}$", ErrorMessage = "Invalid short link: only letter, numbers and at least 6 characters")]
        public string? ShortLink { get; set; }

        public DateTime CreatedAt { get; set; }

        [Range(0, int.MaxValue)]
        public int Redirects { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = [];
            LinkContext linkContext = (LinkContext)validationContext.GetService(typeof(LinkContext))!;

            var findLinkByShortName = linkContext.Links.FirstOrDefault(l => l.ShortLink == ShortLink);
            if (findLinkByShortName is not null && findLinkByShortName.Id != Id)
            {
                errors.Add(new ValidationResult("Short name already in use"));
            }

            if (CreatedAt > DateTime.Now)
            {
                errors.Add(new ValidationResult("Wrong creation date value"));
            }

            return errors;
        }
    }
}

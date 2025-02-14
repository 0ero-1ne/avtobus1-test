using System.ComponentModel.DataAnnotations;

namespace Avtobus1.Models
{
    public class PostLink
    {
        [Url(ErrorMessage = "Provided link is bad")]
        public string? Value { get; set; }
    }
}

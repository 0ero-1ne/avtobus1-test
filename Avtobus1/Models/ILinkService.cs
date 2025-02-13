namespace Avtobus1.Models
{
    public interface ILinkService
    {
        Task<IReadOnlyList<Link>> GetAll();

        Task<Link?> GetById(Guid id);

        Task<Link?> Create(string link);

        Task<Link?> Update(Link link);

        Task<bool> Delete(Guid id);
    }
}

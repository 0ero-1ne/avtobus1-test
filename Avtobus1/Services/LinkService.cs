using Avtobus1.Context;
using Avtobus1.Models;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1.Services
{
    public class LinkService(LinkContext context) : ILinkService
    {
        private readonly LinkContext _context = context;

        public async Task<IReadOnlyList<Link>> GetAll()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<Link?> GetById(Guid id)
        {
            return await _context.Links.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Link?> GetByShortLink(string shortLink)
        {
            var link = await _context.Links.FirstOrDefaultAsync(l => l.ShortName == shortLink);
            return link;
        }

        public async Task<Link?> Create(string link)
        {
            Link linkEntry = new()
            {
                Id = Guid.NewGuid(),
                Name = link,
                ShortName = Utilities.RandomGenerator.GenerateString(8),
                CreatedAt = DateTime.Now,
                Redirects = 0
            };

            while (await _context.Links.FirstOrDefaultAsync(l => l.ShortName == linkEntry.ShortName) is not null)
            {
                linkEntry.ShortName = Utilities.RandomGenerator.GenerateString(8);
            }

            _context.Links.Add(linkEntry);
            await _context.SaveChangesAsync();
            return linkEntry;
        }

        public async Task<Link?> Update(Link link)
        {
            var entry = await GetById(link.Id);

            if (entry is null)
            {
                return null;
            }

            _context.Entry(entry!).CurrentValues.SetValues(link);
            await _context.SaveChangesAsync();
            return link;
        }

        public async Task<bool> Delete(Guid id)
        {
            var link = await GetById(id);

            if (link is not null)
            {
                _context.Remove(link);
            }

            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }
    }
}

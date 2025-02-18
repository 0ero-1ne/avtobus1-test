﻿using Avtobus1.Models;

namespace Avtobus1.Services
{
    public interface ILinkService
    {
        Task<IReadOnlyList<Link>> GetAll();

        Task<Link?> GetById(Guid id);

        Task<Link?> GetByShortLink(string shortLink);

        Task<Link?> Create(string link);

        Task<Link?> Update(Link link);

        Task<bool> Delete(Guid id);
    }
}

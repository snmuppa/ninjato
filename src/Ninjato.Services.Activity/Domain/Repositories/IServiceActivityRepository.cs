using System;
using System.Threading.Tasks;
using Ninjato.Services.Activity.Domain.Models;

namespace Ninjato.Services.Activity.Domain.Repositories
{
    public interface IServiceActivityRepository 
    {
        Task<ServiceActivity> GetAsync (Guid id);

        Task AddAsync (ServiceActivity activity);
    }
}
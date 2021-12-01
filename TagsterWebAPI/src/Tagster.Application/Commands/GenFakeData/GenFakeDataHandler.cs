using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tagster.Application.Services;
using Tagster.CQRS.Commands.Handlers;

namespace Tagster.Application.Commands.GenFakeData
{
    internal class GenFakeDataHandler : ICommandHandler<GenFakeData>
    {
        private readonly IAdminService _adminService;

        public GenFakeDataHandler(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<Unit> Handle(GenFakeData request, CancellationToken cancellationToken)
        {
            await _adminService.CreateFakeDataAsync(request);
            return Unit.Value;
        }
    }
}

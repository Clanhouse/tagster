using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tagster.Application.Services;
using Tagster.CQRS.Commands.Handlers;

namespace Tagster.Application.Commands.GenFakeData
{
    class GenFakeDataHandler : ICommandHandler<GenFakeData>
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

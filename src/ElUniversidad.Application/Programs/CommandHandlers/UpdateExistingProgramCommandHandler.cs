using AutoMapper;
using ElUniversidad.Application.Programs.Commands;
using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Data.Repositories.Interfaces;
using ElUniversidad.Infrastructure.Extensions;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElUniversidad.Application.Programs.CommandHandlers
{
    public class UpdateExistingProgramCommandHandler : ICommandHandler<UpdateExistingProgramCommand, ProgramResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<AddNewProgramCommandHandler> _logger;

        public UpdateExistingProgramCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IMapper mapper,
            ILogger<AddNewProgramCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ProgramResult> Handle(UpdateExistingProgramCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.CustomRepository<IProgramRepository>();

            var program = await repo.GetExistingProgramAsync(request.Id, cancellationToken).ConfigureAwait(false);

            program.UpdateTitleAndDescription(request.Title, request.Description);

            await _unitOfWork.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            await _mediator.DispatchDomainEventsAsync(program, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            var result = _mapper.Map<ProgramResult>(program);

            _logger.LogInformation("ProgramId #{Id} was sucessfully updated. Code: {Code}.", program.Id, program.Code);

            return result;
        }

        #region IDisposable Members

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion IDisposable Members
    }
}

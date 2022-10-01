using AutoMapper;
using ElUniversidad.Application.Students.Commands;
using ElUniversidad.Application.Students.Results;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Data.Repositories.Interfaces;
using ElUniversidad.Infrastructure.Extensions;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElUniversidad.Application.Students.CommandHandlers
{
    public class UpdateExistingStudentCommandHandler : ICommandHandler<UpdateExistingStudentCommand, StudentResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<AddNewStudentCommandHandler> _logger;

        public UpdateExistingStudentCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IMapper mapper,
            ILogger<AddNewStudentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<StudentResult> Handle(UpdateExistingStudentCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.CustomRepository<IStudentRepository>();

            var Student = await repo.GetExistingStudentAsync(request.Id, cancellationToken).ConfigureAwait(false);

            // TODO: Update Student

            await _unitOfWork.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            await _mediator.DispatchDomainEventsAsync(Student, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            var result = _mapper.Map<StudentResult>(Student);

            _logger.LogInformation("StudentId #{Id} was sucessfully updated.", Student.Id);

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

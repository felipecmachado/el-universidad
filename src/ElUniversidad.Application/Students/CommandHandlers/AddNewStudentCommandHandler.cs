using AutoMapper;
using ElUniversidad.Application.Students.Commands;
using ElUniversidad.Application.Students.Results;
using ElUniversidad.Domain.Students;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Extensions;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElUniversidad.Application.Students.CommandHandlers
{
    public class AddNewStudentCommandHandler : ICommandHandler<AddNewStudentCommand, StudentResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<AddNewStudentCommandHandler> _logger;

        public AddNewStudentCommandHandler(
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

        public async Task<StudentResult> Handle(AddNewStudentCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Student>();

            var student = Student
                .New(request.FirstName, request.LastName, request.BirthDate);

            repo.Add(student);

            await _unitOfWork.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            await _mediator.DispatchDomainEventsAsync(student, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            var result = _mapper.Map<StudentResult>(student);

            _logger.LogInformation("A new StudentId #{Id} was sucessfully created.", student.Id);

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

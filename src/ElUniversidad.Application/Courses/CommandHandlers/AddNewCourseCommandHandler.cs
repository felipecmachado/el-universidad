using AutoMapper;
using ElUniversidad.Application.Courses.Commands;
using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Extensions;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElUniversidad.Application.Courses.CommandHandlers
{
    public class AddNewCourseCommandHandler : ICommandHandler<AddNewCourseCommand, CourseResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<AddNewCourseCommandHandler> _logger;

        public AddNewCourseCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IMapper mapper,
            ILogger<AddNewCourseCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CourseResult> Handle(AddNewCourseCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Course>();

            var course = Course
                .New(request.Title, request.Description, string.Empty, request.Credits, request.MinimumGrade);

            repo.Add(course);

            await _unitOfWork.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            await _mediator.DispatchDomainEventsAsync(course, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            var result = _mapper.Map<CourseResult>(course);

            _logger.LogInformation("A new CourseId #{Id} was sucessfully created. Course Title: {Title}.", course.Id, course.Title);

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

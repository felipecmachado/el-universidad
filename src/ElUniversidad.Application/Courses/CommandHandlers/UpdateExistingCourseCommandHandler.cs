using AutoMapper;
using ElUniversidad.Application.Courses.Commands;
using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Data.Repositories.Interfaces;
using ElUniversidad.Infrastructure.Extensions;
using EntityFrameworkCore.Repository.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElUniversidad.Application.Courses.CommandHandlers
{
    public class UpdateExistingCourseCommandHandler : ICommandHandler<UpdateExistingCourseCommand, CourseResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateExistingCourseCommandHandler> _logger;

        public UpdateExistingCourseCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IMapper mapper,
            ILogger<UpdateExistingCourseCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CourseResult> Handle(UpdateExistingCourseCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.CustomRepository<ICourseRepository>();

            var course = await repo.GetExistingCourseAsync(request.Id, cancellationToken).ConfigureAwait(false);

            course.Update(request.Title, request.Description, request.Credits, request.MinimumGrade);

            (repo as IRepository<Course>).Update(course);

            await _unitOfWork.SaveChangesAsync(cancellationToken: cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            await _mediator.DispatchDomainEventsAsync(course, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            var result = _mapper.Map<CourseResult>(course);

            _logger.LogInformation("CourseId #{Id} was sucessfully updated.", course.Id);

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

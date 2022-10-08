using AutoMapper;
using ElUniversidad.Application.Courses.Queries;
using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.Programs;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Data.Contexts;
using EntityFrameworkCore.UnitOfWork.Interfaces;

namespace ElUniversidad.Application.Courses.QueryHandlers
{
    public class GetCourseQueryHandler : IQueryHandler<GetCourseQuery, CourseResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCourseQueryHandler(
            IUnitOfWork<ElUniversidadContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CourseResult> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Course>();

            var query = repo.SingleResultQuery()
                .AndFilter(x => x.Id == request.Id);

            var course = await repo.FirstOrDefaultAsync(query, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var result = _mapper.Map<CourseResult>(course);

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
                    _unitOfWork?.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion IDisposable Members
    }
}

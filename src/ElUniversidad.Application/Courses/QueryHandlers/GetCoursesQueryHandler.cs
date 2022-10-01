using AutoMapper;
using ElUniversidad.Application.Courses.Queries;
using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Domain.Courses;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Data.Contexts;
using EntityFrameworkCore.UnitOfWork.Interfaces;

namespace ElUniversidad.Application.Courses.QueryHandlers
{
    public class GetCoursesQueryHandler : IQueryHandler<GetCoursesQuery, CoursesResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(
            IUnitOfWork<ElUniversidadContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CoursesResult> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Course>();

            var query = repo.MultipleResultQuery();

            var programs = await repo.SearchAsync(query, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var programsResult = _mapper.Map<CoursesResult>(programs);

            return programsResult;
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

using AutoMapper;
using ElUniversidad.Application.Students.Queries;
using ElUniversidad.Application.Students.Results;
using ElUniversidad.Domain.Students;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Data.Contexts;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using ElUniversidad.Application.Programs.Results;

namespace ElUniversidad.Application.Students.QueryHandlers
{
    public class GetStudentsQueryHandler : IQueryHandler<GetStudentsQuery, StudentsResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(
            IUnitOfWork<ElUniversidadContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StudentsResult> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Student>();

            var query = repo.MultipleResultQuery();

            var Students = await repo.SearchAsync(query, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var StudentsResult = _mapper.Map<StudentsResult>(Students);

            return StudentsResult;
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

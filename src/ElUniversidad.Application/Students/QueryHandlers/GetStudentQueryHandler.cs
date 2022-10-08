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
    public class GetStudentQueryHandler : IQueryHandler<GetStudentQuery, StudentResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentQueryHandler(
            IUnitOfWork<ElUniversidadContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<StudentResult> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Student>();

            var query = repo.SingleResultQuery()
                .AndFilter(x => x.Id == request.Id);

            var Student = await repo.FirstOrDefaultAsync(query, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var result = _mapper.Map<StudentResult>(Student);

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

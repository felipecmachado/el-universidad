using AutoMapper;
using ElUniversidad.Application.Programs.Queries;
using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.Programs;
using ElUniversidad.Domain.SeedWork;
using ElUniversidad.Infrastructure.Data.Contexts;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElUniversidad.Application.Programs.QueryHandlers
{
    public class GetProgramStructuresQueryHandler : IQueryHandler<GetProgramStructuresQuery, ProgramStructuresResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProgramStructuresQueryHandler(
            IUnitOfWork<ElUniversidadContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProgramStructuresResult> Handle(GetProgramStructuresQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<ProgramStructure>();

            var query = repo.MultipleResultQuery()
                .Include(x => x.Include(y => y.Program))
                .Include(x => x.Include(y => y.Courses).ThenInclude(y => y.Course));

            var structures = await repo.SearchAsync(query, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var structuresResult = _mapper.Map<ProgramStructuresResult>(structures);

            return structuresResult;
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

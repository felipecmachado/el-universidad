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
    public class GetProgramsQueryHandler : IQueryHandler<GetProgramsQuery, ProgramsResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProgramsQueryHandler(
            IUnitOfWork<ElUniversidadContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProgramsResult> Handle(GetProgramsQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Program>();

            var query = repo.MultipleResultQuery()
                .Include(x => x.Include(y => y.Offers));

            var programs = await repo.SearchAsync(query, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var programsResult = _mapper.Map<ProgramsResult>(programs);

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

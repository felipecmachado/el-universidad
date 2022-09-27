using AutoMapper;
using ElUniversidad.Application.Programs.Queries;
using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.Programs;
using ElUniversidad.Domain.SeedWork;
using EntityFrameworkCore.UnitOfWork.Interfaces;

namespace ElUniversidad.Application.Programs.QueryHandlers
{
    public class GetProgramsQueryCommandHandler : IQueryHandler<GetProgramsQueryCommand, ProgramsResult>, IDisposable
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProgramsQueryCommandHandler(
            IUnitOfWork unitOfWork,
            IRepositoryFactory repositoryFactory,
            IMapper mapper)
        {
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProgramsResult> Handle(GetProgramsQueryCommand request, CancellationToken cancellationToken)
        {
            var repo = _repositoryFactory.Repository<Program>();

            var query = repo.MultipleResultQuery();

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
                    if (_repositoryFactory is IDisposable repositoryFactory)
                    {
                        repositoryFactory.Dispose();
                    }

                    _unitOfWork.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion IDisposable Members
    }
}

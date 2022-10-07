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
    public class GetOffersQueryHandler : IQueryHandler<GetOffersQuery, OffersResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOffersQueryHandler(
            IUnitOfWork<ElUniversidadContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OffersResult> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Offer>();

            var query = repo.MultipleResultQuery()
                .Include(x => x.Include(y => y.ProgramStructure)
                    .ThenInclude(x => x.Program))
                .Include(x => x.Include(y => y.ProgramStructure)
                                .ThenInclude(y => y.Courses)
                                    .ThenInclude(y => y.Course));

            var offer = await repo.SearchAsync(query, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var offerResult = _mapper.Map<OffersResult>(offer);

            return offerResult;
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

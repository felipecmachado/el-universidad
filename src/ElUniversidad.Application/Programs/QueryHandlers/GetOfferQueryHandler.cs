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
    public class GetOfferQueryHandler : IQueryHandler<GetOfferQuery, OfferResult>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOfferQueryHandler(
            IUnitOfWork<ElUniversidadContext> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OfferResult> Handle(GetOfferQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<Offer>();

            var query = repo.SingleResultQuery()
                .AndFilter(x => x.Id == request.Id)
                .Include(x => x.Include(y => y.ProgramStructure)
                    .ThenInclude(x => x.Program))
                .Include(x => x.Include(y => y.ProgramStructure)
                                .ThenInclude(y => y.Courses)
                                    .ThenInclude(y => y.Course));

            var offer = await repo.FirstOrDefaultAsync(query, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var offerResult = _mapper.Map<OfferResult>(offer);

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

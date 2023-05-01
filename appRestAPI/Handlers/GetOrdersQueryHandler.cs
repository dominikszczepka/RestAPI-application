using appRestAPI.Contracts.Orders;
using appRestAPI.Models;
using appRestAPI.Services.FileService;
using appRestAPI.Services.Verificators;
using AutoMapper;
using MediatR;

namespace appRestAPI.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, GetOrdersResult>
    {
        private readonly IFileService _fileService;
        private readonly IArgumentVerificator<GetOrdersQuery> _argumentVerificator;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IFileService fileService, IArgumentVerificator<GetOrdersQuery> argumentVerificator, IMapper mapper)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _argumentVerificator = argumentVerificator ?? throw new ArgumentNullException(nameof(argumentVerificator));
            _mapper = mapper;
        }

        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken = default)
        {
            var invalidityReason = _argumentVerificator.Verify(query);

            return new GetOrdersResult()
            {
                InvalidityReason = invalidityReason!,
                IsQueryValid = invalidityReason == null,
                Orders = invalidityReason == null ?
                    _mapper.Map<IEnumerable<OrderResult>>(await _fileService.GetOrdersAsync(query)) :
                    Enumerable.Empty<OrderResult>()
            };
        }
    }
}

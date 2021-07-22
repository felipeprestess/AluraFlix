using AluraFlix.API.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AluraFlix.API.Application.Videos.Queries.GetVideos
{
    public class GetVideosQuery : IRequest<VideosVm>
    {
    }

    public class GetVideosQueryHandler : IRequestHandler<GetVideosQuery, VideosVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVideosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<VideosVm> Handle(GetVideosQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

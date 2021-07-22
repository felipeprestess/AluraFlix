using AluraFlix.API.Application.Common.Mappings;
using AluraFlix.API.Domain.Entities;

namespace AluraFlix.API.Application.Videos.Queries.GetVideos
{
    public class VideoDto : IMapFrom<Video>
    {
        public VideoDto()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
    }
}

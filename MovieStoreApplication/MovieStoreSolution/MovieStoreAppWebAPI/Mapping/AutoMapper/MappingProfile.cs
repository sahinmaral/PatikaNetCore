using AutoMapper;

using MovieStoreAppWebAPI.Entities;
using MovieStoreAppWebAPI.Operations.FilmOperation.Create;
using MovieStoreAppWebAPI.Operations.FilmOperation.Read;

namespace MovieStoreAppWebAPI.Mapping.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, ReadFilmViewModel>()
                .ForMember(opt => opt.PublishedDate , src=>src.MapFrom(x=>x.PublishedDate.ToShortDateString())
                );

            CreateMap<CreateFilmViewModel, Film>();
        }
    }
}

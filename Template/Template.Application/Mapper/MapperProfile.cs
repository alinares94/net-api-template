namespace $safeprojectname$.Mapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Status, StatusDto>().ReverseMap();
    }
}

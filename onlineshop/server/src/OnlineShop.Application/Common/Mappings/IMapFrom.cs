using AutoMapper;

namespace OnlineShop.Application.Common.Mappings;

internal interface IMapFrom<T>
{
    void Map(Profile profile) => profile.CreateMap(typeof(T), GetType());
}

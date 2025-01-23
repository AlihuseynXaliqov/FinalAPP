using AutoMapper;
using CakeFinalApp.Areas.Manage.ViewModels.Position;
using CakeFinalApp.Models;

namespace CakeFinalApp.Areas.Manage.Helpers.Mapper
{
    public class PositionProfile:Profile
    {
        public PositionProfile()
        {
            CreateMap<CreatePositionVm,Position>().ReverseMap();
            CreateMap<UpdatePositionVm, Position>().ReverseMap();

        }
    }
}

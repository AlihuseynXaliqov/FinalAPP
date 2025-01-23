using AutoMapper;
using CakeFinalApp.Areas.Manage.ViewModels.Agent;
using CakeFinalApp.Models;

namespace CakeFinalApp.Areas.Manage.Helpers.Mapper
{
    public class AgentProfile:Profile
    {
        public AgentProfile()
        {
            CreateMap<CreateAgentVm,Agent>().ReverseMap();
            CreateMap<UpdateAgentVm, Agent>().ReverseMap();


        }
    }
}

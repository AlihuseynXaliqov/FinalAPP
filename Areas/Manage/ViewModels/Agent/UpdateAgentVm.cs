using FluentValidation;

namespace CakeFinalApp.Areas.Manage.ViewModels.Agent
{
    public class UpdateAgentVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public int PositionId { get; set; }
        public IFormFile? formFile { get; set; }
    }
   
}

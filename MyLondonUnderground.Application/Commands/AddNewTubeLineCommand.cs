using MediatR;

namespace MyLondonUnderground.Application.Commands
{
    public class AddNewTubeLineCommand : BaseCommand, IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; } 
    }
}

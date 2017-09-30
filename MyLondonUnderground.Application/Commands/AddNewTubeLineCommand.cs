using MediatR;

namespace MyLondonUnderground.Application.Commands
{
    public class AddNewTubeLineCommand : INotification
    {
        public string Name { get; set; }

        public string Description { get; set; } 
    }
}

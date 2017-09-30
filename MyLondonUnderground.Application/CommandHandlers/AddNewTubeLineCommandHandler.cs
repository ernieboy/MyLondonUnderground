using System.Threading.Tasks;
using MediatR;
using MyLondonUnderground.Application.Commands;

namespace MyLondonUnderground.Application.CommandHandlers
{
    public class AddNewTubeLineCommandHandler : IAsyncNotificationHandler<AddNewTubeLineCommand>
    {
        public Task Handle(AddNewTubeLineCommand notification)
        {
            throw new System.NotImplementedException();
        }
    }
}

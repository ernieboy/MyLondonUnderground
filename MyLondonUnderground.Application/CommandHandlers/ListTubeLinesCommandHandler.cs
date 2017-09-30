using System.Threading.Tasks;
using MediatR;
using MyLondonUnderground.Application.Commands;
using MyLondonUnderground.QueryStack.ViewModels;
using System.Collections.Generic;

namespace MyLondonUnderground.Application.CommandHandlers
{
    public class ListTubeLinesCommandHandler : 
        IAsyncRequestHandler<ListTubeLinesCommand, ICollection<TubeLinesListingViewModel>>
    {
        public Task<ICollection<TubeLinesListingViewModel>> Handle(ListTubeLinesCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System.Threading.Tasks;
using MediatR;
using MyLondonUnderground.Application.Commands;
using MyLondonUnderground.QueryStack.ViewModels;
using System.Collections.Generic;
using MyLondonUnderground.QueryStack.Abstractions;

namespace MyLondonUnderground.Application.CommandHandlers
{
    public class ListTubeLinesCommandHandler : 
        IAsyncRequestHandler<ListTubeLinesCommand, ICollection<TubeLinesListingViewModel>>
    {
        private ILondonUndergroundDbReaderService _londonUndergroundDbReaderService;

        public ListTubeLinesCommandHandler(ILondonUndergroundDbReaderService londonUndergroundDbReaderService)
        {
            _londonUndergroundDbReaderService = londonUndergroundDbReaderService;
        }

        public Task<ICollection<TubeLinesListingViewModel>> Handle(ListTubeLinesCommand message)
        {
            
            throw new System.NotImplementedException();
        }
    }
}

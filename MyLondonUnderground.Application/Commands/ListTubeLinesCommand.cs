using MediatR;
using MyLondonUnderground.QueryStack.ViewModels;
using System.Collections.Generic;

namespace MyLondonUnderground.Application.Commands
{
    public class ListTubeLinesCommand : IRequest<ICollection<TubeLinesListingViewModel>> 
    {
        public int NumberOfItems { get; set; }  
    }
}

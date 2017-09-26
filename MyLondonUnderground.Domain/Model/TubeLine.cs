using System.Collections.Generic;
using DotNetCoreToolKit.Library.Abstractions;
using DotNetCoreToolKit.Library.Models.Persistence;
using static MyLondonUnderground.Domain.Model.Enums;

namespace MyLondonUnderground.Domain.Model
{
    public class TubeLine : Entity, IAggregateRoot
    {
        public TubeLine()
        {
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public TubeLineColourEnum Colour
        {
            get;
            set;
        }

        public ICollection<TubeLineToTubeLineStationMap> TubeLineToTubeLineStationMaps
        {
            get;
            set;
        }

    }
}

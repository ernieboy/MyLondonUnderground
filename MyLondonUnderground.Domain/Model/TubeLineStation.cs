using System.Collections.Generic;
using DotNetCoreToolKit.Library.Abstractions;
using DotNetCoreToolKit.Library.Models.Persistence;

namespace MyLondonUnderground.Domain.Model
{
    public class TubeLineStation : Entity, IAggregateRoot
    {
        public TubeLineStation()
        {
            
        }

        public string Name
        {
            get;
            set;
        }

        public bool HasStepFreeAccessFromStreetToPlatform
        {
            get;
            set;
        }

        public bool HasStepFreeAccessFromStreetToTrain
        {
            get;
            set;
        }

        public bool HasNationalRailConnection
        {
            get;
            set;
        }

        public int Position
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


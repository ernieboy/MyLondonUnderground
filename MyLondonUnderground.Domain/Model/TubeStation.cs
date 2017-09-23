using System;
using DotNetCoreToolKit.Library.Models.Persistence;

namespace MyLondonUnderground.Domain.Model
{
    public class TubeStation : Entity
    {
        public TubeStation()
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
    }
}


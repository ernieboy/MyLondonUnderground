namespace MyLondonUnderground.Domain.Model
{
    public class TubeLineToTubeLineStationMap
    {
        public int TubeLineId
        {
            get;
            set;
        }

        public virtual TubeLine TubeLine
        {
            get;
            set;
        }

        public int TubeLineStationId
        {
            get;
            set;

        }

        public virtual TubeLineStation TubeLineStation
        {
            get;
            set;
       
        }
    }
}

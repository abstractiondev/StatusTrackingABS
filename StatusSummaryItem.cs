namespace StatusTracking_v1_0
{
    public class StatusSummaryItem
    {
        public decimal RedCount;
        public decimal YellowCount;
        public decimal GreenCount;
        public decimal GreenPercentage
        {
            get { return (decimal)GreenCount / (RedCount + YellowCount + GreenCount); }
        }
    }
}
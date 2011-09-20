namespace StatusTracking_v1_0
{
    public class StatusSummaryItem
    {
        public decimal RedCount;
        public decimal YellowCount;
        public decimal GreenCount;
        public decimal GreenPercentage
        {
            get
            {
                decimal totalDivider = RedCount + YellowCount + GreenCount;
                if (totalDivider == 0)
                    return 100;

                return 100 * (decimal)GreenCount / (RedCount + YellowCount + GreenCount);
            }
        }
    }
}
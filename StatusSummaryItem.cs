using System.Linq;

namespace StatusTracking_v1_0
{
    public class StatusSummaryItem
    {
        private const string ItemCountSummaryFormat = "{0} {1}";

        public decimal RedCount
        {
            get { return RedItems.Sum(item => item.StatusValue.indicatorValue); }
        }
        public string RedSummaryString
        {
            get
            {
                string displayText = RedItems.Select(item => item.StatusValue.indicatorDisplayText).FirstOrDefault();
                return displayText == null ? "" : string.Format(ItemCountSummaryFormat, displayText, RedCount);
            }
        }
        public decimal YellowCount
        {
            get { return YellowItems.Sum(item => item.StatusValue.indicatorValue); }
        }
        public string YellowSummaryString
        {
            get
            {
                string displayText = YellowItems.Select(item => item.StatusValue.indicatorDisplayText).FirstOrDefault();
                return displayText == null ? "" : string.Format(ItemCountSummaryFormat, displayText, YellowCount);
            }
        }
        public decimal GreenCount
        {
            get { return GreenItems.Sum(item => item.StatusValue.indicatorValue); }
        }
        public string GreenSummaryString
        {
            get
            {
                string displayText = GreenItems.Select(item => item.StatusValue.indicatorDisplayText).FirstOrDefault();
                return displayText == null ? "" : string.Format(ItemCountSummaryFormat, displayText, GreenCount);
            }
        }
        public StatusItemType[] GreenItems;
        public StatusItemType[] YellowItems;
        public StatusItemType[] RedItems;
        private decimal TotalDivider
        {
            get
            {
                return RedCount + YellowCount + GreenCount;
            }
        }

        public decimal GreenRatio
        {
            get
            {
                if (TotalDivider == 0)
                    return 1;
                return GreenCount / TotalDivider;
            }
        }

        public decimal YellowRatio
        {
            get
            {
                if (TotalDivider == 0)
                    return 1;
                return YellowCount / TotalDivider;
            }
        }

        public decimal RedRatio
        {
            get
            {
                if (TotalDivider == 0)
                    return 1;
                return RedCount / TotalDivider;
            }
        }



        public bool IsComplete
        {
            get { return RedCount == 0 && YellowCount == 0; }
        }

        public bool IsIncomplete
        {
            get { return IsComplete == false; }
        }
    }
}
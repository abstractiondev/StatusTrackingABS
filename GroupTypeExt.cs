using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatusTracking_v1_0
{
    public static class GroupTypeExt
    {
        public static StatusItemType[] GetStatusItems(this GroupType grp, StatusTrackingAbstractionType currAbstraction)
        {
            return grp.GetStatusItems(false, currAbstraction);
        }

        public static GroupType[] GetSubGroups(this GroupType grp, StatusTrackingAbstractionType currAbstraction)
        {
            var groupTypes =
                grp.GroupRef.Select(
                    groupRef => currAbstraction.Groups.Single(grpItem => grpItem.name == groupRef.groupName)).ToArray();
            return groupTypes;
        }

        public static StatusItemType[] GetStatusItems(this GroupType grp, bool deepSummary, StatusTrackingAbstractionType currAbstraction)
        {
            StatusItemType[] subGroupItems = new StatusItemType[0];
            if (deepSummary)
            {
                List<GroupType> groupTypes = new List<GroupType> { grp };
                AddGroupHierarchyGroups(groupTypes, currAbstraction);
                var groupItems = groupTypes.SelectMany(subGroup => subGroup.GetStatusItems(false, currAbstraction));
                subGroupItems = groupItems.ToArray();
            }
            var itemTypes =
                grp.ItemRef.Select(itemRef => currAbstraction.StatusItems.Single(item => item.name == itemRef.itemName));
            StatusItemType[] result = itemTypes.Union(subGroupItems).Distinct().ToArray();
            return result;

        }

        private static void AddGroupHierarchyGroups(List<GroupType> groupTypes, StatusTrackingAbstractionType currAbstraction)
        {
            List<GroupType> addingList = new List<GroupType>();
            foreach (GroupType grp in groupTypes)
            {
                addingList.AddRange(grp.GetSubGroups(currAbstraction));
            }
            addingList.RemoveAll(groupTypes.Contains);
            groupTypes.AddRange(groupTypes);
        }

        public static StatusSummaryItem GetGroupSummary(this GroupType grp, StatusTrackingAbstractionType currAbstraction)
        {
            return GetGroupSummary(grp, false, currAbstraction);
        }

        public static StatusSummaryItem GetGroupSummary(this GroupType grp, bool deepSummary, StatusTrackingAbstractionType currAbstraction)
        {
            StatusItemType[] items = grp.GetStatusItems(deepSummary, currAbstraction);
            var greenItems =
                items.Where(item => item.StatusValue.trafficLightIndicator == StatusValueTypeTrafficLightIndicator.green);
            var yellowItems =
                items.Where(item => item.StatusValue.trafficLightIndicator == StatusValueTypeTrafficLightIndicator.yellow);
            var redItems =
                items.Where(item => item.StatusValue.trafficLightIndicator == StatusValueTypeTrafficLightIndicator.red);
            StatusSummaryItem summaryItem = new StatusSummaryItem
            {
                GreenCount = greenItems.Sum(item => item.StatusValue.indicatorValue),
                YellowCount =
                    yellowItems.Sum(item => item.StatusValue.indicatorValue),
                RedCount = redItems.Sum(item => item.StatusValue.indicatorValue)
            };
            return summaryItem;
        }

    }
}

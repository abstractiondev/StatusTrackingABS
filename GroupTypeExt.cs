using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatusTracking_v1_0
{
    public partial class StatusTrackingAbstractionType
    {
        public GroupType[] GetTopLevelGroups()
        {
            StatusTrackingAbstractionType currAbstraction = this;
            GroupType[] groups = currAbstraction.Groups.Where(topLevelCandidate =>
                                         currAbstraction.Groups.All(nonParent => nonParent.GroupRef == null || 
                                                                    nonParent.GroupRef.All(
                                                                        gRef => gRef.groupName != topLevelCandidate.name)))
                .ToArray();
            return groups;
        }
    }

    public partial class GroupType
    {
        public StatusItemType[] GetStatusItems(StatusTrackingAbstractionType currAbstraction)
        {
            GroupType grp = this;
            return grp.GetStatusItems(false, currAbstraction);
        }
        public StatusSummaryItem GetGroupSummary(bool deepSummary, StatusTrackingAbstractionType currAbstraction)
        {
            GroupType grp = this;
            StatusItemType[] items = grp.GetStatusItems(deepSummary, currAbstraction);
            var greenItems =
                items.Where(item => item.StatusValue.trafficLightIndicator == StatusValueTypeTrafficLightIndicator.green);
            var yellowItems =
                items.Where(item => item.StatusValue.trafficLightIndicator == StatusValueTypeTrafficLightIndicator.yellow);
            var redItems =
                items.Where(item => item.StatusValue.trafficLightIndicator == StatusValueTypeTrafficLightIndicator.red);
            StatusSummaryItem summaryItem = new StatusSummaryItem
            {
                GreenItems = greenItems.ToArray(),
                YellowItems = yellowItems.ToArray(),
                RedItems = redItems.ToArray(),
            };
            return summaryItem;
        }

        public GroupType[] GetSubGroups(StatusTrackingAbstractionType currAbstraction)
        {
            GroupType grp = this;
            if (grp.GroupRef == null)
                return new GroupType[0];
            var groupTypes =
                grp.GroupRef.Select(
                    groupRef => currAbstraction.Groups.Single(grpItem => grpItem.name == groupRef.groupName)).ToArray();
            return groupTypes;
        }

        public StatusItemType[] GetStatusItems(bool deepSummary, StatusTrackingAbstractionType currAbstraction)
        {
            GroupType grp = this;
            StatusItemType[] subGroupItems = new StatusItemType[0];
            if (deepSummary)
            {
                List<GroupType> groupTypes = new List<GroupType> { grp };
                AddGroupHierarchyGroups(groupTypes, currAbstraction);
                var groupItems = groupTypes.SelectMany(subGroup => subGroup.GetStatusItems(false, currAbstraction));
                subGroupItems = groupItems.ToArray();
            }
            var itemTypes = (grp.ItemRef ?? new ItemRefType[0])
                .Select(itemRef => currAbstraction.StatusItems.Single(item => item.name == itemRef.itemName));
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

        public StatusSummaryItem GetGroupSummary(StatusTrackingAbstractionType currAbstraction)
        {
            GroupType grp = this;
            return grp.GetGroupSummary(false, currAbstraction);
        }


    }

    public static class GroupTypeExt
    {

        //public static StatusItemType[] GetStatusItems(this GroupType grp, StatusTrackingAbstractionType currAbstraction)
        //{
        //    return grp.GetStatusItems(false, currAbstraction);
        //}

    }
}

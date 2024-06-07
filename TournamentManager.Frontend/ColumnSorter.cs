using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Frontend
{

    public class ColumnSorter : IComparer
    {
        public int Column { get; set; }
        public SortOrder Order { get; set; }

        public ColumnSorter(int column)
        {
            Column = column;
            Order = SortOrder.Ascending;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = x as ListViewItem;
            ListViewItem itemY = y as ListViewItem;

            int compareResult;

            switch (Column)
            {
                case 0: // Name
                case 2: // Type
                    compareResult = String.Compare(itemX.SubItems[Column].Text, itemY.SubItems[Column].Text);
                    break;

                case 1: // Finished
                    bool boolX = bool.Parse(itemX.SubItems[Column].Text);
                    bool boolY = bool.Parse(itemY.SubItems[Column].Text);
                    compareResult = boolX.CompareTo(boolY);
                    break;

                case 3: // Team Count
                    int intX = int.Parse(itemX.SubItems[Column].Text);
                    int intY = int.Parse(itemY.SubItems[Column].Text);
                    compareResult = intX.CompareTo(intY);
                    break;

                default:
                    compareResult = String.Compare(itemX.SubItems[Column].Text, itemY.SubItems[Column].Text);
                    break;
            }

            if (Order == SortOrder.Descending)
            {
                compareResult = -compareResult;
            }

            return compareResult;
        }
    }
}

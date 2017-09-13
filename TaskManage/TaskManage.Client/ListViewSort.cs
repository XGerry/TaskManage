using System;
using System.Collections;
using System.Windows.Forms;

namespace TaskManage.Client
{
    public class ListViewSort : IComparer
    {
        private readonly int _col;
        private readonly bool _descK;

        public ListViewSort()
        {
            _col = 0;
        }

        public ListViewSort(int column, object desc)
        {
            _descK = (bool)desc;
            _col = column;    
        }

        public int Compare(object x, object y)
        {
            int tempInt = String.CompareOrdinal(((ListViewItem)x).SubItems[_col].Text,
                                                ((ListViewItem)y).SubItems[_col].Text);
            if (_descK)
            {
                return -tempInt;
            }
            return tempInt;
        }
    }
}

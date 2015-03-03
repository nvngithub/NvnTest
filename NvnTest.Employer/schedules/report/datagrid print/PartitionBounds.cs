
using System;
using System.Windows.Forms;
namespace NvnTest.Employer
{
    public delegate bool RowSelector(DataGridViewRow row);
    public delegate bool ColSelector(DataGridViewColumn col);

    /// <author>Blaise Braye</author>
    /// <summary>
    /// Bounds of a partition, it covers mostly included rows and columns
    /// but also cordinates information about it (size,..)
    /// </summary>
    public class PartitionBounds
    {
        public PartitionBounds(
            int startRowIndex, int endRowIndex, int startColumnIndex, int endColumnIndex,
            float startX, float startY, float width, float height, RowSelector rowSelector, ColSelector colSelector)
        {
            this.StartRowIndex = startRowIndex;
            this.EndRowIndex = endRowIndex;
            this.StartColumnIndex = startColumnIndex;
            this.EndColumnIndex = endColumnIndex;
            this.StartX = startX;
            this.StartY = startY;
            this.Width = width;
            this.Height = height;
            this.RowSelector = rowSelector;
            this.ColSelector = colSelector;
        }


        public int StartRowIndex { get; set; }
        public int EndRowIndex { get; set; }

        public int StartColumnIndex { get; set; }
        public int EndColumnIndex { get; set; }

        public float StartX { get; set; }
        public float StartY { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }

        public RowSelector RowSelector { get; set; }
        public ColSelector ColSelector { get; set; }


        public int ColumnCount
        {
            get { return 1 + EndColumnIndex - StartColumnIndex; }
        }

        public int RowsCount
        {
            get { return 1 + EndRowIndex - StartRowIndex; }
        }
    }
}

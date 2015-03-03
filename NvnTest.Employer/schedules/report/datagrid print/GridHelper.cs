using System;
using System.Windows.Forms;
using System.Drawing;

namespace NvnTest.Employer
{
    /// <author>Blaise Braye</author>
    /// <summary>
    /// usefull helper for DataGridView components
    /// </summary>
    public static class GridHelper
    {

        /// <returns>affected Font to the cell</returns>
        public static Font Font(DataGridViewCell cell)
        {
            return (cell.HasStyle && cell.Style.Font != null) ?
                cell.Style.Font : cell.InheritedStyle.Font;
        }

        /// <summary>
        /// Multiply the cell font with scale
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="scale">percentage of font size</param>
        /// <returns>Scaled Font</returns>
        public static Font Font(DataGridViewCell cell, float scale)
        {
            Font font = Font(cell);

            if (scale != 1)
                font = new Font(font.FontFamily,font.Size * scale);

            return font;
        }



        /// <summary>
        /// Get the forecolor of the cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns>ForeColor of the cell</returns>
        public static Color ForeColor(DataGridViewCell cell)
        {
            if (cell.HasStyle && cell.Style.ForeColor != Color.Empty) return cell.Style.ForeColor;
            else return cell.InheritedStyle.ForeColor;
        }

        /// <summary>
        /// Get the BackColor of the cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns>BackColor of the cell</returns>
        public static Color BackColor(DataGridViewCell cell)
        {
            if (cell.HasStyle && cell.Style.BackColor != Color.Empty) return cell.Style.BackColor;
            else return cell.InheritedStyle.BackColor;
        }

        /// <summary>
        /// Get the BackColor of the column headers of the gridview
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns>BackColor of the cell</returns>
        public static Color ColumnsHeaderBackColor(DataGridView gridView){
            return (!gridView.ColumnHeadersDefaultCellStyle.BackColor.IsEmpty) 
                ? gridView.ColumnHeadersDefaultCellStyle.BackColor : gridView.DefaultCellStyle.BackColor;
        }

        /// <summary>
        /// Get the forecolor of the row
        /// </summary>
        /// <param name="row"></param>
        /// <returns>ForeColor of the row</returns>
        public static Color ForeColor(DataGridViewRow row)
        {
            if (row.HasDefaultCellStyle && row.DefaultCellStyle.ForeColor != Color.Empty)
                return row.DefaultCellStyle.ForeColor;
            else return row.InheritedStyle.ForeColor;
        }

        /// <summary>
        /// Get the BackColor of the row
        /// </summary>
        /// <param name="row"></param>
        /// <returns>BackColor of the row</returns>
        public static Color BackColor(DataGridViewRow row)
        {
            if (row.Index % 2 == 0 || row.DataGridView.AlternatingRowsDefaultCellStyle.BackColor.IsEmpty)
            {
                if (row.HasDefaultCellStyle && row.DefaultCellStyle.BackColor != Color.Empty)
                    return row.DefaultCellStyle.BackColor;
                else return row.InheritedStyle.BackColor;
            }
            else
            {
                return row.DataGridView.AlternatingRowsDefaultCellStyle.BackColor;
            }

        }

        /// <summary>
        /// Get text horizontal alignement in given cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns>text horizontal alignement in given cell</returns>
        public static StringAlignment HorizontalAlignement(DataGridViewCell cell)
        {

            DataGridViewContentAlignment alignement = DataGridViewContentAlignment.TopLeft;

            if (cell.HasStyle && cell.Style.Alignment != DataGridViewContentAlignment.NotSet)
                alignement = cell.Style.Alignment;
            else alignement = cell.InheritedStyle.Alignment;

            // Check the CurrentCell alignment and apply it to the CellFormat
            if (alignement.ToString().Contains("Right"))
                return StringAlignment.Far;
            else if (alignement.ToString().Contains("Center"))
                return StringAlignment.Center;
            else
                return StringAlignment.Near;
        }


        /// <summary>
        /// Calculate the height of a DataGridViewRow in a drawing surface,
        /// it doesn't make calculation with hidden cells
        /// </summary>
        /// <param name="row"></param>
        /// <param name="g"></param>
        /// <returns>row height</returns>
        public static float RowHeight(DataGridViewRow row, Graphics g)
        {
            float max = float.MinValue;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    float cellHeight = g.MeasureString(
                         cell.EditedFormattedValue.ToString(),
                         Font(cell),
                         cell.Size.Width).Height;
                    if (cellHeight > max) max = cellHeight;
                }
            }
            return max;
        }

        /// <summary>
        /// Multiply row height with scale value
        /// </summary>
        /// <param name="row"></param>
        /// <param name="g"></param>
        /// <param name="scale"></param>
        /// <returns>Scaled height</returns>
        public static float RowHeight(DataGridViewRow row, Graphics g, float scale)
        {
            return RowHeight(row, g) * scale;
        }

        /// <summary>
        /// Calculate the height of a cell in a drawing surface
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="g"></param>
        /// <returns>cell row height</returns>
        public static float RowHeight(DataGridViewCell cell, Graphics g)
        {
            return RowHeight(cell.OwningRow, g);
        }

        /// <summary>
        /// Multiply cell height with scale value
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="g"></param>
        /// <param name="scale"></param>
        /// <returns>Scaled cell height</returns>
        public static float RowHeight(DataGridViewCell cell, Graphics g, float scale)
        {
            return RowHeight(cell, g) * scale;
        }

        /// <summary>
        /// Calculate the header height of a DataGridView in a drawing surface,
        /// it takes care only about visible columns
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="g"></param>
        /// <returns>DataGridView Columns Header Height</returns>
        public static float HeaderHeight(DataGridView dgv, Graphics g)
        {
            float max = float.MinValue;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    float headerHeight = g.MeasureString(
                         column.HeaderCell.EditedFormattedValue.ToString(),
                         Font(column.HeaderCell),
                         column.HeaderCell.Size.Width).Height;

                    if (headerHeight > max) max = headerHeight;
                }
                
            }

            return max;
        }

        /// <summary>
        /// Multiply DataGridView Columns Header Height with scale value 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="g"></param>
        /// <param name="scale"></param>
        /// <returns>Scaled DataGridView Columns Header Height</returns>
        public static float HeaderHeight(DataGridView dgv, Graphics g, float scale)
        {
            return HeaderHeight(dgv, g) * scale;
        }

        /// <summary>
        /// Calculate the width of a column in a drawing surface,
        /// it doesn't make calculation with hidden cells
        /// </summary>
        /// <param name="column"></param>
        /// <param name="g"></param>
        /// <returns>Column width</returns>
        public static float Width(DataGridViewColumn column, Graphics g)
        {

            float maxCellsWidth = float.MinValue;

            foreach (DataGridViewRow row in column.DataGridView.Rows)
            {
                if (row.Visible)
                {
                    float cellWidth = g.MeasureString(
                        row.Cells[column.Index].EditedFormattedValue.ToString(),
                        Font(row.Cells[column.Index]),
                        row.Cells[column.Index].Size.Width).Width;

                    if (cellWidth > maxCellsWidth) maxCellsWidth = cellWidth;
                }
            }

            float headerWidth =
                g.MeasureString(
                    column.HeaderText,
                    Font(column.HeaderCell),
                    column.HeaderCell.Size.Width).Width;

            return (maxCellsWidth > headerWidth) ? maxCellsWidth : headerWidth;

        }

        /// <summary>
        /// Multiply column width with scale value
        /// </summary>
        /// <param name="column"></param>
        /// <param name="g"></param>
        /// <param name="scale"></param>
        /// <returns>Scaled column width</returns>
        public static float Width(DataGridViewColumn column, Graphics g, float scale)
        {
            return Width(column, g) * scale;
        }

        /// <summary>
        /// Calculate the width of a DataGridViewCell in a drawing surface
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="g"></param>
        /// <returns>Cell width</returns>
        public static float ColumnWidth(DataGridViewCell cell, Graphics g)
        {
            return Width(cell.OwningColumn,g);
        }
        /// <summary>
        /// Multiply cell width with scale value
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="g"></param>
        /// <param name="scale"></param>
        /// <returns>Scaled cell width</returns>
        public static float ColumnWidth(DataGridViewCell cell, Graphics g, float scale)
        {
            return ColumnWidth(cell, g) * scale;
        }

    }
}

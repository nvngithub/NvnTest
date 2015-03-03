using System.Drawing.Printing;

namespace NvnTest.Employer
{
    /// <author>Blaise Braye</author>
    /// <summary>
    /// Usefull to keep the printable coordinates of a document
    /// </summary>
    public class DocumentMetrics
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int LeftMargin { get; set; }

        public int RightMargin { get; set; }

        public int TopMargin { get; set; }

        public int BottomMargin { get; set; }

        /// <summary>
        /// substract the margins from the document width
        /// </summary>
        public int PrintAbleWidth
        {
            get
            {
                return Width - LeftMargin - RightMargin;
            }
        }

        /// <summary>
        /// substract the margins from the document height
        /// </summary>
        public int PrintAbleHeight
        {
            get
            {
                return Height - TopMargin - BottomMargin;
            }
        }

        public DocumentMetrics(int width, int height, int leftMargin, int topMargin, int rightMargin, int bottomMargin)
        {
            this.Width = width;
            this.Height = height;
            this.LeftMargin = leftMargin;
            this.TopMargin = topMargin;
            this.RightMargin = rightMargin;
            this.BottomMargin = bottomMargin;
        }


        /// <summary>
        /// DocumentMetrics factory, take information in given PrintDocument object
        /// </summary>
        /// <param name="printDocument"></param>
        /// <returns>printable coordinates</returns>
        public static DocumentMetrics FromPrintDocument(PrintDocument printDocument)
        {
            PageSettings pageSettings = printDocument.DefaultPageSettings;

            return new DocumentMetrics(
                (pageSettings.Landscape)
                        ? pageSettings.PaperSize.Height : pageSettings.PaperSize.Width,
                (pageSettings.Landscape)
                        ? pageSettings.PaperSize.Width : pageSettings.PaperSize.Height,
                pageSettings.Margins.Left,
                pageSettings.Margins.Top,
                pageSettings.Margins.Right,
                pageSettings.Margins.Bottom);
        }


    }
}

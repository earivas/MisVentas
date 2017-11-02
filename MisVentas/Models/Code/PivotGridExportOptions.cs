using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MisVentas.Models
{
    public enum PivotGridExportFormats { ExcelDataAware, Pdf, Excel, Mht, Rtf, Text, Html }
    public class PivotGridExportOptions
    {
        public PivotGridExportOptions()
        {
            WYSIWYG = new PivotGridExportWYSIWYGDemoOptions();
            DataAware = new PivotGridDataAwareDemoExportOptions();
        }

        public PivotGridExportFormats ExportType { get; set; }
        public PivotGridExportWYSIWYGDemoOptions WYSIWYG { get; set; }
        public PivotGridDataAwareDemoExportOptions DataAware { get; set; }
    }
    public class PivotGridExportWYSIWYGDemoOptions
    {
        public PivotGridExportWYSIWYGDemoOptions()
        {
            PrintFilterHeaders = true;
            PrintColumnHeaders = true;
            PrintRowHeaders = true;
            PrintDataHeaders = true;
        }

        public bool PrintHeadersOnEveryPage { get; set; }
        public bool PrintFilterHeaders { get; set; }
        public bool PrintColumnHeaders { get; set; }
        public bool PrintRowHeaders { get; set; }
        public bool PrintDataHeaders { get; set; }
    }
    public class PivotGridDataAwareDemoExportOptions
    {
        public PivotGridDataAwareDemoExportOptions()
        {
            AllowGrouping = true;
            AllowFixedColumnAndRowArea = true;
        }

        public bool AllowGrouping { get; set; }
        public bool AllowFixedColumnAndRowArea { get; set; }
        public bool ExportDisplayText { get; set; }
        public bool ExportRawData { get; set; }
    }
}
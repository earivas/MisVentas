using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.Web;

namespace MisVentas.Models.Code
{
    public class PivotGridDataOutputHelper {
        static PivotGridSettings exportPivotGridSettings;
        static PivotGridSettings dataAwarePivotGridSettings;

        public static PivotGridSettings ExportPivotGridSettings {
            get {
                if(exportPivotGridSettings == null)
                    exportPivotGridSettings = CreatePivotGridSettings();
                return exportPivotGridSettings;
            }
        }
        public static PivotGridSettings DataAwarePivotGridSettings {
            get {
                if(dataAwarePivotGridSettings == null)
                    dataAwarePivotGridSettings = CreateDataAwarePivotGridSettings();
                return dataAwarePivotGridSettings;
            }
        }

        public static PivotGridSettings GetPivotGridExportSettings(PivotGridExportWYSIWYGDemoOptions options) {
            PivotGridSettings exportSettings = ExportPivotGridSettings;
            exportSettings.SettingsExport.OptionsPrint.PrintHeadersOnEveryPage = options.PrintHeadersOnEveryPage;
            exportSettings.SettingsExport.OptionsPrint.PrintFilterHeaders = ConvertToDefaultBoolean(options.PrintFilterHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintColumnHeaders = ConvertToDefaultBoolean(options.PrintColumnHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintRowHeaders = ConvertToDefaultBoolean(options.PrintRowHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintDataHeaders = ConvertToDefaultBoolean(options.PrintDataHeaders);
            return exportSettings;
        }
        static PivotGridSettings CreatePivotGridSettingsBase() {
            PivotGridSettings settings = new PivotGridSettings();
            settings.Name = "pivotGrid";
            settings.CallbackRouteValues = new { Controller = "DataOutput", Action = "ExportPartial" };
            settings.Width = Unit.Percentage(100);
            settings.OptionsView.HorizontalScrollBarMode = ScrollBarMode.Auto;
            return settings;
        }
        static PivotGridSettings CreatePivotGridSettings() {
            PivotGridSettings settings = CreatePivotGridSettingsBase();

            //settings.Fields.Add(field => {
            //    field.Area = PivotArea.FilterArea;
            //    field.AreaIndex = 0;
            //    field.Caption = "Product";
            //    field.FieldName = "ProductName";
            //});
            //settings.Fields.Add(field => {
            //    field.Area = PivotArea.RowArea;
            //    field.AreaIndex = 0;
            //    field.Caption = "Customer";
            //    field.FieldName = "CompanyName";
            //});
            //settings.Fields.Add(field => {
            //    field.Area = PivotArea.ColumnArea;
            //    field.AreaIndex = 0;
            //    field.Caption = "Year";
            //    field.FieldName = "OrderDate";
            //    field.GroupInterval = PivotGroupInterval.DateYear;
            //});
            //settings.Fields.Add(field => {
            //    field.Area = PivotArea.DataArea;
            //    field.AreaIndex = 0;
            //    field.Caption = "Product Amount";
            //    field.FieldName = "ProductAmount";
            //    field.CellFormat.FormatString = "c";
            //    field.CellFormat.FormatType = FormatType.Custom;
            //});
            //settings.Fields.Add(field => {
            //    field.Area = PivotArea.FilterArea;
            //    field.AreaIndex = 1;
            //    field.Caption = "Quarter";
            //    field.FieldName = "OrderDate";
            //    field.GroupInterval = PivotGroupInterval.DateQuarter;
            //});

            settings.Name = "PivotGrid";
            settings.CallbackRouteValues = new { Controller = "BI_Presupuestos", Action = "PivotGridPartial" };
            settings.Styles.AreaStyle.Font.Size = 8;
            settings.Styles.CellStyle.Font.Size = 8;
            settings.Styles.ColumnAreaStyle.Font.Size = 8;
            settings.Styles.CustomTotalCellStyle.Font.Size = 8;
            settings.Styles.CustomizationFieldsCloseButtonStyle.Font.Size = 8;
            settings.Styles.CustomizationFieldsContentStyle.Font.Size = 8;
            settings.Styles.CustomizationFieldsHeaderStyle.Font.Size = 8;
            settings.Styles.CustomizationFieldsStyle.Font.Size = 8;
            settings.Styles.CustomTotalCellStyle.Font.Size = 8;
            settings.Styles.DataAreaStyle.Font.Size = 8;
            settings.Styles.FieldValueGrandTotalStyle.Font.Size = 8;
            settings.Styles.FieldValueStyle.Font.Size = 8;
            settings.OptionsData.DataFieldUnboundExpressionMode = DataFieldUnboundExpressionMode.UseSummaryValues;

            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "Vendedor";
                field.Caption = "Vendedor";
                field.AreaIndex = 0;
            });

            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "OrgVentas";
                field.Caption = "Empresa";
                field.AreaIndex = 0;
            });


            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.FilterArea;
                field.AreaIndex = 0;
                field.FieldName = "Fecha";
                field.Caption = "Mes";
                field.GroupInterval = PivotGroupInterval.DateMonth;
            });

            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.RowArea;
                field.FieldName = "Linea";
                field.Caption = "Linea";
                field.AreaIndex = 0;
            });


            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.RowArea;
                field.FieldName = "Producto";
                field.Caption = "Producto";
                field.AreaIndex = 0;
            });


            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.DataArea;
                field.FieldName = "VentaMLAnterior";
                field.Caption = "Año Anterior";
                field.AreaIndex = 0;
            });

            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.DataArea;
                field.FieldName = "VentaMLActual";
                field.Caption = "Año Actual";
                field.AreaIndex = 1;
                field.SortOrder = PivotSortOrder.Descending;
            });

            settings.Fields.Add(field =>
            {
                field.Area = PivotArea.DataArea;
                field.FieldName = "PptoMlocal";
                field.Caption = "Presupuesto";
                field.AreaIndex = 3;
            });


            settings.Fields.Add(f =>
            {
                f.Caption = "Cump. Ppto $";
                f.UnboundExpression = "[fieldVentaMLActual]-[fieldPptoMlocal]";
                f.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                f.DisplayFolder = "Cumpl";
                f.CellFormat.FormatType = FormatType.Numeric;
                f.CellFormat.FormatString = "c";
                f.Area = PivotArea.DataArea;
            });

            settings.Fields.Add(f =>
            {

                f.Caption = "%Cump Ppto";
                f.FieldName = "CumpPptoPorc";
                f.UnboundExpression = "Iif( [fieldPptoMlocal] = 0, 0, ([fieldVentaMLActual]/[fieldPptoMlocal])*100)";
                //  f.UnboundExpression = "Iif([PptoMlocal]=0,0, Iff([VentaMLActual]=0,0,[VentaMLActual]/[PptoMlocal]))";
                f.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                f.DisplayFolder = "%Cumpl";
                f.CellFormat.FormatType = FormatType.Numeric;
                f.CellFormat.FormatString = "{0:f2} %";
                f.Area = PivotArea.DataArea;

                //f.UnboundExpressionMode = "UsesSummaryValues";


            });


            return settings;
        }
        static PivotGridSettings CreateDataAwarePivotGridSettings() {
            PivotGridSettings settings = CreatePivotGridSettingsBase();

            settings.Fields.Add(field => {
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 0;
                field.Caption = "Product";
                field.FieldName = "ProductName";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.AreaIndex = 0;
                field.Caption = "Customer";
                field.FieldName = "CompanyName";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.ColumnArea;
                field.AreaIndex = 0;
                field.Caption = "Year";
                field.FieldName = "OrderDate";
                field.GroupInterval = PivotGroupInterval.DateYear;
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.ColumnArea;
                field.AreaIndex = 1;
                field.Caption = "Quarter";
                field.FieldName = "OrderDate";
                field.GroupInterval = PivotGroupInterval.DateQuarter;
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.DataArea;
                field.AreaIndex = 0;
                field.Caption = "Product Amount";
                field.FieldName = "ProductAmount";
                field.CellFormat.FormatString = "c";
                field.CellFormat.FormatType = FormatType.Custom;
            });

            return settings;
        }
        static DefaultBoolean ConvertToDefaultBoolean(bool value) {
            return value ? DefaultBoolean.True : DefaultBoolean.False;
        }

        static Dictionary<PivotGridExportFormats, PivotGridExportType> exportTypes;
        static Dictionary<PivotGridExportFormats, PivotGridExportType> CreateExportTypes() {
            Dictionary<PivotGridExportFormats, PivotGridExportType> types = new Dictionary<PivotGridExportFormats, PivotGridExportType>();
            types.Add(PivotGridExportFormats.Pdf, new PivotGridExportType { Title = "Export to PDF", Method = PivotGridExtension.ExportToPdf });
            types.Add(PivotGridExportFormats.Excel, new PivotGridExportType { Title = "Export to XLSX", ExcelMethod = PivotGridExtension.ExportToXlsx });
            types.Add(PivotGridExportFormats.ExcelDataAware, new PivotGridExportType { Title = "Export to XLSX", ExcelMethod = PivotGridExtension.ExportToXlsx });
            types.Add(PivotGridExportFormats.Mht, new PivotGridExportType { Title = "Export to MHT", Method = PivotGridExtension.ExportToMht });
            types.Add(PivotGridExportFormats.Rtf, new PivotGridExportType { Title = "Export to RTF", Method = PivotGridExtension.ExportToRtf });
            types.Add(PivotGridExportFormats.Text, new PivotGridExportType { Title = "Export to TEXT", Method = PivotGridExtension.ExportToText });
            types.Add(PivotGridExportFormats.Html, new PivotGridExportType { Title = "Export to HTML", Method = PivotGridExtension.ExportToHtml });
            return types;
        }
        public static ActionResult GetExportActionResult(PivotGridExportOptions options, object data) {
            if(exportTypes == null)
                exportTypes = CreateExportTypes();

            PivotGridExportFormats format = options.ExportType;
            PivotGridSettings settings = GetPivotGridExportSettings(options.WYSIWYG);
            switch(format) {
                case PivotGridExportFormats.Excel:
                    return exportTypes[format].ExcelMethod(settings, data, new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                case PivotGridExportFormats.ExcelDataAware:
                    XlsxExportOptionsEx exportOptions = new XlsxExportOptionsEx() { ExportType = ExportType.DataAware };
                    exportOptions.AllowFixedColumnHeaderPanel = exportOptions.AllowFixedColumns = options.DataAware.AllowFixedColumnAndRowArea ? DefaultBoolean.True : DefaultBoolean.False;
                    exportOptions.AllowGrouping = options.DataAware.AllowGrouping ? DefaultBoolean.True : DefaultBoolean.False;
                    exportOptions.RawDataMode = options.DataAware.ExportRawData;
                    exportOptions.TextExportMode = options.DataAware.ExportDisplayText ? TextExportMode.Text : TextExportMode.Value;
                    return exportTypes[format].ExcelMethod(DataAwarePivotGridSettings, data, exportOptions);
                default:
                    return exportTypes[format].Method(settings, data);
            }
        }
        public delegate ActionResult PivotGridExportMethod(PivotGridSettings settings, object dataObject);
        public delegate ActionResult PivotGridDataAwareExportMethod(PivotGridSettings settings, object dataObject, XlsxExportOptions exportOptions);
        public class PivotGridExportType {
            public string Title { get; set; }
            public PivotGridExportMethod Method { get; set; }
            public PivotGridDataAwareExportMethod ExcelMethod { get; set; }
        }

      //  static PivotGridSettings pivotChartIntegrationSettings;
        //public static PivotGridSettings PivotChartIntegrationSettings() {
        //    return PivotChartIntegrationSettings(null);
        //}
        ////public static PivotGridSettings PivotChartIntegrationSettings(PivotGridChartIntegrationDemoOptions options) {
        //    if(pivotChartIntegrationSettings == null)
        //        pivotChartIntegrationSettings = CreatePivotChartIntegrationSettings();
        //    if(options != null) {
        //        pivotChartIntegrationSettings.OptionsChartDataSource.ProvideColumnGrandTotals = options.ShowColumnGrandTotals;
        //        pivotChartIntegrationSettings.OptionsChartDataSource.ProvideRowGrandTotals = options.ShowRowGrandTotals;
        //        pivotChartIntegrationSettings.OptionsChartDataSource.ProvideDataByColumns = options.GenerateSeriesFromColumns;
        //    }
        //    return pivotChartIntegrationSettings;
        //}
        //static PivotGridSettings CreatePivotChartIntegrationSettings() {
        //    PivotGridSettings pivotGridSettings = new PivotGridSettings();
        //    pivotGridSettings.Name = "pivotGrid";
        //    pivotGridSettings.CallbackRouteValues = new { Controller = "DataOutput", Action = "ChartsIntegrationPivotPartial" };
        //    pivotGridSettings.OptionsChartDataSource.DataProvideMode = PivotChartDataProvideMode.UseCustomSettings;
        //    pivotGridSettings.OptionsView.ShowFilterHeaders = false;
        //    pivotGridSettings.OptionsView.HorizontalScrollBarMode = ScrollBarMode.Auto;
        //    pivotGridSettings.Width = Unit.Percentage(100);

        //    pivotGridSettings.Fields.Add(field => {
        //        field.FieldName = "Extended_Price";
        //        field.Caption = "Extended Price";
        //        field.Area = PivotArea.DataArea;
        //        field.AreaIndex = 0;
        //    });
        //    pivotGridSettings.Fields.Add(field => {
        //        field.FieldName = "CategoryName";
        //        field.Caption = "Category Name";
        //        field.Area = PivotArea.RowArea;
        //        field.AreaIndex = 0;
        //    });
        //    pivotGridSettings.Fields.Add(field => {
        //        field.FieldName = "OrderDate";
        //        field.Caption = "Order Month";
        //        field.Area = PivotArea.ColumnArea;
        //        field.AreaIndex = 0;
        //        field.UnboundFieldName = "fieldOrderDate";
        //        field.GroupInterval = PivotGroupInterval.DateMonth;
        //    });
        //    pivotGridSettings.PreRender = (sender, e) => {
        //        int selectNumber = 4;
        //        var field = ((MVCxPivotGrid)sender).Fields["Category Name"];
        //        object[] values = field.GetUniqueValues();
        //        List<object> includedValues = new List<object>(values.Length / selectNumber);
        //        for(int i = 0; i < values.Length; i++) {
        //            if(i % selectNumber == 0)
        //                includedValues.Add(values[i]);
        //        }
        //        field.FilterValues.ValuesIncluded = includedValues.ToArray();
        //    };
        //    pivotGridSettings.ClientSideEvents.EndCallback = "UpdateChart";
        //    return pivotGridSettings;
        //}
        //public static IEnumerable<XtraCharts.ViewType> GetSupportedChartTypes() {
        //    IEnumerable<XtraCharts.ViewType> restictedChartTypes = new List<XtraCharts.ViewType> {
        //        XtraCharts.ViewType.PolarArea,
        //        XtraCharts.ViewType.PolarRangeArea,
        //        XtraCharts.ViewType.PolarLine,
        //        XtraCharts.ViewType.ScatterPolarLine,
        //        XtraCharts.ViewType.SideBySideGantt,
        //        XtraCharts.ViewType.SideBySideRangeBar,
        //        XtraCharts.ViewType.RangeBar,
        //        XtraCharts.ViewType.Gantt,
        //        XtraCharts.ViewType.PolarPoint,
        //        XtraCharts.ViewType.Stock,
        //        XtraCharts.ViewType.CandleStick,
        //        XtraCharts.ViewType.Bubble
        //    };
        //    return Enum.GetValues(typeof(XtraCharts.ViewType)).Cast<XtraCharts.ViewType>().Except(restictedChartTypes).ToList();
        //}
    }
}

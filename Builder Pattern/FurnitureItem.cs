using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class FurnitureItem
    {
        public string Name;
        public double Price;
        public double Height;
        public double Width;
        public double Weight;
        public FurnitureItem(string productName, double price, double height, double width, double weight )
        {
            this.Name = productName;
            this.Price = price;
            this.Height = height;                
            this.Width = width;
            this.Weight = weight;
                
        }
    }

    public class InventoryReport
    {
        public string TitleSection;
        public string DimesnsionsSection;
        public string LogisticsSection;

        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DimesnsionsSection)
                .AppendLine(LogisticsSection).ToString();
        }

    }

    /// <summary>
    /// IFurnitureInventoryBuilder interface
    /// </summary>
    public interface  IFurnitureInventoryBuilder
    {
        IFurnitureInventoryBuilder AddTitle();
        IFurnitureInventoryBuilder AddDimesnsions();
        IFurnitureInventoryBuilder AddLogistics(DateTime dateTime);
        InventoryReport GetDailyReport();
    }

    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport _inventoryReport;
        private IEnumerable<FurnitureItem> _items;

        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            Reset();
            _items = items;

        }

        public void Reset()
        {
            _inventoryReport = new InventoryReport();
        }

        public IFurnitureInventoryBuilder AddDimesnsions()
        {
            _inventoryReport.DimesnsionsSection = string.Join(Environment.NewLine,_items.Select(product=> 
            $"Product: {product.Name} \n Price: {product.Price} \n" +
            $"Height: {product.Height} \n Width: {product.Width} -> Weight: {product.Weight} lbs"));
            return this;
        }

        public IFurnitureInventoryBuilder AddLogistics(DateTime dateTime)
        {
            _inventoryReport.LogisticsSection = $"Report generated on {dateTime}";
            return this;
        }

        public IFurnitureInventoryBuilder AddTitle()
        {
            _inventoryReport.TitleSection="-----------Daily Inventory Report--------\n\n";
            return this;
        }

        public InventoryReport GetDailyReport()
        {
            InventoryReport finishedReport = _inventoryReport;
            Reset();
            return finishedReport;
        }
    }

    public class InventoryBuildDirector
    {
        private IFurnitureInventoryBuilder _inventoryBuilder;

        public InventoryBuildDirector(IFurnitureInventoryBuilder concreteBuilder)
        {
            _inventoryBuilder = concreteBuilder;
        }

        public void BuildCompleteReport()
        {
            _inventoryBuilder.AddTitle();
            _inventoryBuilder.AddDimesnsions();
            _inventoryBuilder.AddLogistics(DateTime.Now);
        }
    }
}

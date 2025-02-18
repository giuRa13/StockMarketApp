using Newtonsoft.Json;
using StockMarket.Domain.Models;
using StockMarket.Domain.Services;
using StockMarket.Domain.Services.Transactions;
using StockMarket.WPF.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Documents;
using StockMarket.WPF.Models;
using StockMarket.WPF.Controls;
using ScottPlot.Colormaps;
using System.Security.Policy;
using ScottPlot;
using ScottPlot.Statistics;
using ScottPlot.WPF;
using StockMarket.FMPApi.Services;
using ScottPlot.Plottables;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;


namespace StockMarket.WPF.ViewModels
{

    public class BuyViewModel : ViewModelBase
    {

        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private string _searchSymbol = string.Empty;
        public string SearchSymbol
        {
            get { return _searchSymbol; }
            set
            {
                _searchSymbol = value;
                OnPropertyChanged(nameof(SearchSymbol));
            }
        }

        private double _stockPrice;
        public double StockPrice
        {
            get { return _stockPrice; }
            set
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }


        private int _sharesToBuy;
        public int SharesToBuy
        {
            get { return _sharesToBuy; }
            set
            {
                _sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private double _change;
        public double Change
        {
            get { return _change; }
            set
            {
                _change = value;
                OnPropertyChanged(nameof(Change));
                OnPropertyChanged(nameof(ChartData));
                OnPropertyChanged(nameof(SearchSymbol));
            }
        }

        public System.Windows.Media.Brush _foreground;
        public System.Windows.Media.Brush Foreground
        {
            get { return _foreground; }
            set
            {
                _foreground = value;
                OnPropertyChanged(nameof(Foreground));
                OnPropertyChanged(nameof(Change));
            }
        }

        public double TotalPrice
        {
            get { return SharesToBuy * StockPrice; }
        }


        private TopStock _stock;
        public TopStock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }


        private ChartData _chartData;
        public ChartData ChartData
        {
            get { return _chartData; }
            set
            {
                _chartData = value;
                OnPropertyChanged(nameof(ChartData));
                OnPropertyChanged(nameof(Symbol));
            }
        }

        public ICommand SearchSymbolCommand { get; set; }
        public ICommand BuyStockCommand { get; set; }

        public WpfPlot plotControl { get; set; }
        public List<OHLC> prices { get; set; }



        public BuyViewModel(IStockService stockService, IBuyStockService buyStockService)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService);

            plotControl = new WpfPlot();
            prices = new List<OHLC>();

            //prices.Add(new OHLC(100, 200, 100, 100, DateTime.Now, TimeSpan.FromDays(1)));
            var candlePlot = plotControl.Plot.Add.Candlestick(prices);
            candlePlot.RisingColor = ScottPlot.Color.FromHtml("#089981"); //#00e676
            candlePlot.FallingColor = ScottPlot.Color.FromHtml("#f23645"); //#f23645 #ff5252

            plotControl.Plot.Axes.DateTimeTicksBottom();
            plotControl.Plot.FigureBackground.Color = new("#1c1c1e");
            plotControl.Plot.Axes.Color(new("#888888"));

            plotControl.Plot.Axes.Left.TickLabelStyle.IsVisible = false;
            plotControl.Plot.Axes.Left.MajorTickStyle.Length = 0;
            plotControl.Plot.Axes.Left.MinorTickStyle.Length = 0;
            plotControl.Plot.Axes.Top.FrameLineStyle.Width = 0;
            //WpfPlot1.Plot.Axes.Left.FrameLineStyle.Width = 0;
            plotControl.Plot.Axes.Left.FrameLineStyle.IsVisible = false;
            candlePlot.Axes.YAxis = plotControl.Plot.Axes.Right;
            plotControl.Plot.Axes.Right.TickGenerator = new ScottPlot.TickGenerators.NumericAutomatic()
            {
                LabelFormatter = (double value) => value.ToString("C")
            };

            plotControl.Plot.Grid.XAxisStyle.MajorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(15);
            plotControl.Plot.Grid.YAxisStyle.MajorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(15);
            plotControl.Plot.Grid.XAxisStyle.MinorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(5);
            plotControl.Plot.Grid.YAxisStyle.MinorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(5);

            plotControl.Refresh();
        }


    }  

}

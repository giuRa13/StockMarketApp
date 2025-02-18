using Newtonsoft.Json;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WPF;
using StockMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Colors = ScottPlot.Colors;

namespace StockMarket.WPF.Views
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl
    {
     
        string date = "";
        string ticker = "TSLA";
        List<OHLC> prices = new();

        double[] ema = { };
        DateTime[] ys = { };
        List<DateTime> listTime = new List<DateTime>();
        List<double> listEma = new List<double>();



        public ChartView()
        {
            InitializeComponent();

            //DrawGraph();
        }

        private async void DrawGraph()
        {
            string url = $"https://financialmodelingprep.com/api/v3/historical-price-full/" + ticker + "?from=" + date + "&apikey=vTzirAVlYuLErLtb6lcjwcW3cybPTTBk";
            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponse = await httpClient.GetAsync(url);
                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                ChartData stock = JsonConvert.DeserializeObject<ChartData>(jsonResponse);
                foreach (var result in stock.historical)
                {
                    double open = result.open;
                    double close = result.close;
                    double high = result.high;
                    double low = result.low;
                    double adjClose = result.adjClose;

                    DateTime dt = DateTime.Parse(result.date);
                    TimeSpan timeSpan = TimeSpan.FromDays(1);

                    prices.Add(new OHLC(open, high, low, close, dt, timeSpan));

                    /*listEma.Add(adjClose);
                    ema = listEma.ToArray();
                    listTime.Add(dt);
                    ys = listTime.ToArray();*/
                }


                //WpfPlot1.Plot.Add.Candlestick(prices);
                var candlePlot = WpfPlot1.Plot.Add.Candlestick(prices);
                candlePlot.RisingColor = ScottPlot.Color.FromHtml("#00FF00");
                candlePlot.FallingColor = ScottPlot.Color.FromHtml("#FF0000");

                WpfPlot1.Plot.Axes.DateTimeTicksBottom();
                WpfPlot1.Plot.FigureBackground.Color = new("#1c1c1e");
                WpfPlot1.Plot.Axes.Color(new("#888888"));

                WpfPlot1.Plot.Axes.Left.TickLabelStyle.IsVisible = false;
                WpfPlot1.Plot.Axes.Left.MajorTickStyle.Length = 0;
                WpfPlot1.Plot.Axes.Left.MinorTickStyle.Length = 0;
                WpfPlot1.Plot.Axes.Top.FrameLineStyle.Width = 0;
                //WpfPlot1.Plot.Axes.Left.FrameLineStyle.Width = 0;
                WpfPlot1.Plot.Axes.Left.FrameLineStyle.IsVisible = false;
                candlePlot.Axes.YAxis = WpfPlot1.Plot.Axes.Right;
                WpfPlot1.Plot.Axes.Right.TickGenerator = new ScottPlot.TickGenerators.NumericAutomatic()
                {
                    LabelFormatter = (double value) => value.ToString("C")
                };

                WpfPlot1.Plot.Grid.XAxisStyle.MajorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(15);
                WpfPlot1.Plot.Grid.YAxisStyle.MajorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(15);
                WpfPlot1.Plot.Grid.XAxisStyle.MinorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(5);
                WpfPlot1.Plot.Grid.YAxisStyle.MinorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(5);

                //double[] ema50 = EMA(ema, 50);
                //WpfPlot1.Plot.Add.ScatterLine(ys, ema50);

                WpfPlot1.Refresh();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public double[] EMA(double[] x, int N)
        {
            // x is the input series            
            // N is the notional age of the data used
            // k is the smoothing constant

            double k = 2.0 / (N + 1);
            double[] y = new double[x.Length];
            y[0] = x[0];

            for (int i = 1; i < x.Length; i++)
                y[i] = (x[i] * k) + (y[i - 1] * (1 - k));
            //y[i] = k * x[i] + (1 - k) * y[i - 1];
            //Closing price x multiplier + EMA (previous day) x (1-multiplier)
            
            return y;
        }

    }
}

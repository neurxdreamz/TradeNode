using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TradeNodeLogic; // Подключаем нашу независимую логику!
using TradeNode;
using TradeNodeLogic;

namespace TradeNode.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private decimal _price;
        public decimal Price { get => _price; set { _price = value; OnPropertyChanged(); } }

        private decimal _cost;
        public decimal Cost { get => _cost; set { _cost = value; OnPropertyChanged(); } }

        private int _quantity;
        public int Quantity { get => _quantity; set { _quantity = value; OnPropertyChanged(); } }

        private decimal _commission = 5;
        public decimal Commission { get => _commission; set { _commission = value; OnPropertyChanged(); } }

        private decimal _adsCost;
        public decimal AdsCost { get => _adsCost; set { _adsCost = value; OnPropertyChanged(); } }

        private CalculatorResult _result = new CalculatorResult();

        // Свойства для вывода на экран
        public decimal Turnover => _result.TurnOver;
        public decimal TotalExpenses => _result.TotalExpenses;
        public decimal NetProfit => _result.NetProfit;
        public decimal Margin => _result.Margin;

        public ICommand CalculateCommand { get; }

        public MainViewModel()
        {
            CalculateCommand = new RelayCommand(ExecuteCalculate);
        }

        private void ExecuteCalculate(object parameter)
        {
            // Вызываем расчет из библиотеки Core
            _result = AvitoCalculator.Calculate(Price, Cost, Quantity, Commission, AdsCost);

            // Сообщаем интерфейсу, что результаты обновились
            OnPropertyChanged(nameof(Turnover));
            OnPropertyChanged(nameof(TotalExpenses));
            OnPropertyChanged(nameof(NetProfit));
            OnPropertyChanged(nameof(Margin));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
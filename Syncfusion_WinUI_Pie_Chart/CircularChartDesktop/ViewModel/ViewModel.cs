using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularChartDesktop
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model("Algeria", 28),
                new Model("Australia", 14),
                new Model("Bolivia", 31),
                new Model("Cambodia", 77),
                new Model("Canada", 19),
            };
        }
    }
}

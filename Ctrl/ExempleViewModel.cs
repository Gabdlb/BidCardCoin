using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class MetierViewModel : INotifyPropertyChanged
    {
        public int idMetier;
        public string libMetier;
        public MetierViewModel(int idMetier, string libMetier)
        {
            this.idMetier = idMetier;
            this.libMetier = libMetier;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                MetierORM.updateMetier(this);
            }
        }
        public string LibMetier
        {
            get
            {
                return libMetier;
            }
        }
    }
}

/*
 * CREATE TABLE `metier` (
 * `idMetier` int(11) NOT NULL,
 * `libMetier` varchar(45) DEFAULT NULL,
 * PRIMARY KEY (`idMetier`)
using ColorsLib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ColorsLib.ViewModel;
using System.Windows;

namespace ColorsLib.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        ColorInfo _colorinfo;
        public ColorInfo CurrentColor
        {
            get
            {
                if (_colorinfo == null)
                    _colorinfo = new ColorInfo();
                return _colorinfo;
            }
            set
            {
                _colorinfo = value;
                OnPropertyChanged("CurrentColor");
            }
        }
        int _index;
        public int Index
        {
            get
            {
                Clipboard.SetText(Colors[_index].HexColor);
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChanged("Index");
            }
        }


        private static ObservableCollection<ColorInfo> _colors;
        public ObservableCollection<ColorInfo> Colors
        {
            get
            {
                if (_colors == null)
                    _colors = ColorRepository.Colors;
                return _colors;
            }
        }

        //Команды --------------
        
            
        // Поиск по имени -----------------------
        RelayCommand _searcheColorBynameCommand;
        public ICommand SearcheColorByname
        {
            get
            {
                if (_searcheColorBynameCommand == null)
                    _searcheColorBynameCommand = new RelayCommand(ExecuteSeadrcheColorByNameCommand, CanExecuteSeadrcheColorByNameCommand);
                return _searcheColorBynameCommand;
            }
        }

        public void ExecuteSeadrcheColorByNameCommand(object parameter)
        {
            CurrentColor = new ColorInfo()
            {
                RColor = "",
                GColor = "",
                BColor = "",
                HexColor = "",
                NameColor = CurrentColor.NameColor
            };
            ColorRepository.SearcheColorByName(CurrentColor.NameColor);
           
        }

        public bool CanExecuteSeadrcheColorByNameCommand(object parameter)
        {
            return true;
        }


        // поиск по Hex представлению 
        RelayCommand _searcheColorByhexCommand;
        public ICommand SearcheColorByhex
        {
            get
            {
                if (_searcheColorByhexCommand == null)
                    _searcheColorByhexCommand = new RelayCommand(ExecuteSeadrcheColorByHexCommand, CanExecuteSeadrcheColorByHexCommand);
                return _searcheColorByhexCommand;
            }
        }

        public void ExecuteSeadrcheColorByHexCommand(object parameter)
        {
            CurrentColor = new ColorInfo()
            {
                RColor = "",
                GColor = "",
                BColor = "",
                HexColor = CurrentColor.HexColor,
                NameColor = ""
            };
            ColorRepository.SearcheColorByHexName(CurrentColor.HexColor);
        }

        public bool CanExecuteSeadrcheColorByHexCommand(object parameter)
        {
            return true;
        }


        // поиск по RGB представлению 
        RelayCommand _searcheColorByRGBCommand;
        public ICommand SearcheColorByRGB
        {
            get
            {
                if (_searcheColorByRGBCommand == null)
                    _searcheColorByRGBCommand = new RelayCommand(ExecuteSeadrcheColorByRGBCommand, CanExecuteSeadrcheColorRGByBCommand);
                return _searcheColorByRGBCommand;
            }
        }

        public void ExecuteSeadrcheColorByRGBCommand(object parameter)
        {
            CurrentColor = new ColorInfo()
            {
                RColor = CurrentColor.RColor,
                GColor = CurrentColor.GColor,
                BColor = CurrentColor.BColor,
                HexColor = null,
                NameColor = null
            };
            ColorRepository.SearcheColorByRGB(CurrentColor.RColor,CurrentColor.GColor,CurrentColor.BColor);
        }

        public bool CanExecuteSeadrcheColorRGByBCommand(object parameter)
        {
            return true;
        }
    }
}

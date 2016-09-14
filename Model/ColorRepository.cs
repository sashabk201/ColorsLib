using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System;

namespace ColorsLib
{
    static class ColorRepository
    {
        static string path = "Colors\\colors.txt";

        private static ObservableCollection<ColorInfo> _colorsFull = new ObservableCollection<ColorInfo>();

        private static ObservableCollection<ColorInfo> _colors;
        public static ObservableCollection<ColorInfo> Colors
        {
            get
            {
                if (_colors == null)
                    _colors = GenerateColorRepository();
                return _colors;
            }
        }

        /// <summary>
        /// Добавить проверку на правильность цвета. 
        /// добавить проверку ошибки
        /// </summary>
        /// <returns></returns>
        private static ObservableCollection<ColorInfo> GenerateColorRepository()
        {
            try
            {
                _colorsFull.Clear();
                ObservableCollection<ColorInfo> colors = new ObservableCollection<ColorInfo>();
                if (File.Exists(path))
                {

                    string[] streaam = File.ReadAllLines(path);
                    for (int i = 1; i < streaam.Length; i++)
                    {
                        string[] color = streaam[i].Split(':');
                        ColorInfo ci =  new ColorInfo
                        {
                            NameColor = color[0],
                            HexColor = color[1],
                            RColor = color[2],
                            GColor = color[3],
                            BColor = color[4]
                        };
                        colors.Add(ci);
                        _colorsFull.Add(ci);
                    }
                }
                return colors;
            }
            catch { };
            return null;
            
        }

        public static void SearcheColorByName(string nameColor)
        {
           
            if (nameColor.Length >= 1)
            {
                ObservableCollection<ColorInfo> colorN = new ObservableCollection<ColorInfo>((from it in _colorsFull where it.NameColor.ToUpper().IndexOf(nameColor.ToUpper()) > -1 select it));
                _colors.Clear();
                foreach (ColorInfo col in colorN)
                    _colors.Add(col);
            }
            else
            {
                _colors.Clear();
                foreach (ColorInfo col in GenerateColorRepository())
                    _colors.Add(col);
            }
        }

        public static void SearcheColorByHexName(string hexColor)
        {

            if (hexColor.Length >= 1)
            {
                ObservableCollection<ColorInfo> colorN = new ObservableCollection<ColorInfo>((from it in _colorsFull where it.HexColor.ToUpper().IndexOf(hexColor.ToUpper()) > -1 select it));
                _colors.Clear();
                foreach (ColorInfo col in colorN)
                    _colors.Add(col);
            }
            else
            {
                _colors.Clear();
                foreach (ColorInfo col in GenerateColorRepository())
                    _colors.Add(col);
            }
        }

        public static void SearcheColorByR(string r)
        {

            if (r.Length >= 1)
            {
                ObservableCollection<ColorInfo> colorN = new ObservableCollection<ColorInfo>((from it in _colorsFull where it.RColor.ToUpper().IndexOf(r.ToUpper()) > -1 select it));
                _colors.Clear();
                foreach (ColorInfo col in colorN)
                    _colors.Add(col);
            }
            else
            {
                _colors.Clear();
                foreach (ColorInfo col in GenerateColorRepository())
                    _colors.Add(col);
            }
        }

        public static void SearcheColorByG(string g)
        {

            if (g.Length >= 1)
            {
                ObservableCollection<ColorInfo> colorN = new ObservableCollection<ColorInfo>((from it in _colorsFull where it.GColor.ToUpper().IndexOf(g.ToUpper()) > -1 select it));
                _colors.Clear();
                foreach (ColorInfo col in colorN)
                    _colors.Add(col);
            }
            else
            {
                _colors.Clear();
                foreach (ColorInfo col in GenerateColorRepository())
                    _colors.Add(col);
            }
        }

        public static void SearcheColorByB(string b)
        {

            if (b.Length >= 1)
            {
                ObservableCollection<ColorInfo> colorN = new ObservableCollection<ColorInfo>((from it in _colorsFull where it.BColor.ToUpper().IndexOf(b.ToUpper()) > -1 select it));
                _colors.Clear();
                foreach (ColorInfo col in colorN)
                    _colors.Add(col);
            }
            else
            {
                _colors.Clear();
                foreach (ColorInfo col in GenerateColorRepository())
                    _colors.Add(col);
            }
        }

        public static void SearcheColorByRGB(string r,string g,string b)
        {
            if(r!= null || g!= null || b!= null)
            {
                ObservableCollection<ColorInfo> searchColect = _colorsFull;
                if(r!= null)
                    searchColect = new ObservableCollection<ColorInfo>((from it in searchColect where it.RColor.ToUpper().IndexOf(r.ToUpper()) > -1 select it));
                if (g != null)
                    searchColect = new ObservableCollection<ColorInfo>((from it in searchColect where it.GColor.ToUpper().IndexOf(g.ToUpper()) > -1 select it));
                if (b != null)
                    searchColect = new ObservableCollection<ColorInfo>((from it in searchColect where it.BColor.ToUpper().IndexOf(b.ToUpper()) > -1 select it));

                _colors.Clear();
                foreach (ColorInfo col in searchColect)
                    _colors.Add(col);
            }
            else
            {
                _colors.Clear();
                foreach (ColorInfo col in GenerateColorRepository())
                    _colors.Add(col);
            }
        }
    }
}

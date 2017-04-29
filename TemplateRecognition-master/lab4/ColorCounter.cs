using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;

namespace lab4
{
    static public class InfColors
    {
        public static Dictionary<string, double> dc = new Dictionary<string, double>();
        static Dictionary<string, string> dict = new Dictionary<string, string>();

        static public void SetInfo(string key, string val)
        {
            if(!dict.ContainsKey(key))
                dict.Add(key, val);
        }
        public static string GetHColor(string st)
        {
            if (st == "Коричневый")
                return null;
            else
            {
                return dict[st];
            }
        }
    }
    ////////////
    static public class OutPut
    {
        static string Info = "";

        static public string GetSetInfo
        {
            set { Info += value + "\n"; }
            get { return Info; }
        }

        static public void MessageClear()
        {
            Info = "";
        }
    }

    public abstract class Handler
    {
        protected Handler h;
        public void SetNext(Handler tmph)
        {
            h = tmph;
        }
        public abstract void Request(string st);
        protected void ShowInfo(string path,string colname)
        {
            FileStream fs = new FileStream(@".\\colors\\" + path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string tmp = "";
            while (!sr.EndOfStream)
            {
                /*Console.Write(sr.ReadLine());*/
                tmp += sr.ReadLine();
            }
            sr.Close();
            sr.Dispose();
            //MessageBox.Show("Характеристика", tmp);
            OutPut.GetSetInfo = tmp;
            InfColors.SetInfo(colname, tmp);
            //Console.WriteLine("\n\n");
        }
    }

    class SBlack : Handler
    {
        public override void Request(string st)
        {
            if (st == "Черный")
            {
                ShowInfo("Black.txt", st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SWhite : Handler
    {
        public override void Request(string st)
        {
            if (st == "Белый")
            {
                ShowInfo("White.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SGray : Handler
    {
        public override void Request(string st)
        {
            if (st == "Серый")
            {
                ShowInfo("Gray.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SRed : Handler
    {
        public override void Request(string st)
        {
            if (st == "Красный")
            {
                ShowInfo("Red.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SYellow : Handler
    {
        public override void Request(string st)
        {
            if (st == "Желтый")
            {
                ShowInfo("Yellow.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SGreen : Handler
    {
        public override void Request(string st)
        {
            if (st == "Зеленый")
            {
                ShowInfo("Green.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SBlue : Handler
    {
        public override void Request(string st)
        {
            if (st == "Синий")
            {
                ShowInfo("Blue.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SAqua : Handler
    {
        public override void Request(string st)
        {
            if (st == "Аква")
            {
                ShowInfo("Aqua.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SPurpure : Handler
    {
        public override void Request(string st)
        {
            if (st == "Фиолетовый")
            {
                ShowInfo("Purpure.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SOrange : Handler
    {
        public override void Request(string st)
        {
            if (st == "Оранжевый")
            {
                ShowInfo("Orange.txt",st);
            }
            else
            {
                if (!(h == null))
                {
                    h.Request(st);
                }
            }
        }
    }
    class SBrown : Handler
    {
        public override void Request(string st)
        {
            if (st == "Коричневый")
            {
                ShowInfo("Brown.txt", st);
            }
            else
            {
                if (!(h == null)) 
                {
                    h.Request(st);
                }
            }
        }
    }
    ////////////
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague prog);
    }
    class ConcreateMediator : Mediator
    {
        private ConcreteInformer col1;
        private ConcreteReceiver col2;
        public ConcreteInformer Colleague1
        {
            set
            {
                col1 = value;
            }
        }
        public ConcreteReceiver Colleague2
        {
            set
            {
                col2 = value;
            }
        }
        public override void Send(string message, Colleague col)
        {
            if (col == col1)
            {
                col2.Notify(message);
            }
            else
            {
                col1.Notify(message);
            }
        }
    }
    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
    class ConcreteInformer : Colleague
    {
        public ConcreteInformer(Mediator mediator) : base(mediator)
        {

        }
        public void Info(string str)
        {
            mediator.Send(str, this);
        }
        public void Notify(string str)
        {
            Console.WriteLine("Инфо для информатора: " + str);
        }
    }
    class ConcreteReceiver : Colleague
    {
        public ConcreteReceiver(Mediator mediator) : base(mediator)
        {
        }
        public void Send(string str)
        {
        }
        public void Notify(string str)
        {
            Console.WriteLine("Инфо: " + str);
        }
    }
    /////////////////////////////////////////////////////////////////////
    //Одиночка//////////////
    public class Singleton<T> where T : class
    {
        protected Singleton()
        {}

        private sealed class SingletonCreator<T> where T : class
        {
            private static readonly T instance = (T)typeof(T).GetConstructor(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, new Type[0], new System.Reflection.ParameterModifier[0]).Invoke(null);
            public static T CreatorInstance
            {
                get
                {
                    return instance;
                }
            }
            static public T Instance
            {
                get
                {
                    return SingletonCreator<T>.CreatorInstance;
                }
            }
        }
    }

    class ResultContainer
    {
        public List<ResultObject> lt = new List<ResultObject>();
    }
    class ResultObject
    {
        public ResultObject() { }
        public ResultObject(string str, int count)
        {
            colorName = str; colorCount = count;
        }
        public string colorName
        {
            get;
        }
        public int colorCount
        {
            get;
        }
    }
    abstract class PhyhoAnalyze : Singleton<PhyhoAnalyze>
    {
        static public string gInfo = "";
        public ResultContainer data;
        public Dictionary<string, int> InfoColors;
        abstract public void FillStat();
        abstract public void GetNewMaxTest();
        abstract public string ShowInfo();
        abstract public Dictionary<string, double> GetMaxPercent();
        abstract public Dictionary<string, double> PriorColor(Dictionary<string, double> dc);
        static public Handler h1 = new SBlack();
        static public Handler h2 = new SWhite();
        static public Handler h3 = new SGray();
        static public Handler h4 = new SRed();
        static public Handler h5 = new SYellow();
        static public Handler h6 = new SOrange();
        static public Handler h7 = new SGreen();
        static public Handler h8 = new SBlue();
        static public Handler h9 = new SAqua();
        static public Handler h10 = new SPurpure();
        static public Handler h11 = new SBrown();
    } //Вроде как на фасад похож?
    class CounterColor : PhyhoAnalyze
    {
        private Dictionary<int, int> dic = new Dictionary<int, int>();//Старый словарь
        public Dictionary<string, int> dicSort = new Dictionary<string, int>();
        private Bitmap bt;
        ConcreateMediator m = new ConcreateMediator();
        ConcreteInformer mInformer;
        ConcreteReceiver mReceiver;
        public CounterColor()
        {
            mInformer = new ConcreteInformer(m);
            mReceiver = new ConcreteReceiver(m);
        }
        public CounterColor(string path)
        {
            Image img = Image.FromFile(path);
            bt = new Bitmap(img);
            mInformer = new ConcreteInformer(m);
            mReceiver = new ConcreteReceiver(m);
            m.Colleague1 = mInformer;
            m.Colleague2 = mReceiver;
            h1.SetNext(h2);
            h2.SetNext(h3);
            h3.SetNext(h4);
            h4.SetNext(h5);
            h5.SetNext(h6);
            h6.SetNext(h7);
            h7.SetNext(h8);
            h8.SetNext(h9);
            h9.SetNext(h10);
            h10.SetNext(h11);
        }
        public override void FillStat()
        {
            for (int i = 0; i < bt.Width; i++)
            {
                for (int j = 0; j < bt.Height; j++)
                {
                    /*int tmp = bt.GetPixel(i, j).ToArgb();
                    tmp = (tmp << 8) >> 8;
                    #region oldcheck 
                    if (dic.ContainsKey(tmp))
                    {
                        dic[tmp] = dic[tmp] + 1;
                        //Console.WriteLine(tmp);
                    }
                    else
                    {
                        dic.Add(tmp, 1);
                    }
                    #endregion*/
                    //////////////Новое распознование + сокращение количества ключей в словаре///////////////////////////////////
                    float H = bt.GetPixel(i, j).GetHue(), S = bt.GetPixel(i, j).GetSaturation(), V = bt.GetPixel(i, j).GetBrightness();
                    if (V < 0.1)
                    {
                        if (dicSort.ContainsKey("Черный"))
                        {
                            dicSort["Черный"] = dicSort["Черный"] + 1;
                        }
                        else
                        {
                            dicSort.Add("Черный", 1);
                            mInformer.Info("Впервые найден черный цвет!");
                        }
                    }
                    else if (V > 0.65 && S < 0.15)
                    {
                        if (dicSort.ContainsKey("Белый"))
                        {
                            dicSort["Белый"] = dicSort["Белый"] + 1;
                        }
                        else
                        {
                            dicSort.Add("Белый", 1);
                            mInformer.Info("Впервые найден белый цвет!");
                        }
                    }
                    else if (S < 0.15f && V < 0.65f && V > 0.1f)
                    {
                        if (dicSort.ContainsKey("Серый"))
                        {
                            dicSort["Серый"] = dicSort["Серый"] + 1;
                        }
                        else
                        {
                            dicSort.Add("Серый", 1);
                            mInformer.Info("Впервые найден серый цвет!");
                        }
                    }
                    else
                    {
                        if ((H < 11 || H > 351) && S > 0.7 && V > 0.1)
                        {
                            if (dicSort.ContainsKey("Красный"))
                            {
                                dicSort["Красный"] = dicSort["Красный"] + 1;
                            }
                            else
                            {
                                dicSort.Add("Красный", 1);
                                mInformer.Info("Впервые найден красный цвет!");
                            }
                        }
                        else if (H < 45.0f && H > 11.0f && V > 0.15f && S >= 0.75f)
                        {
                            if (dicSort.ContainsKey("Оранжевый"))
                            {
                                dicSort["Оранжевый"] = dicSort["Оранжевый"] + 1;
                            }
                            else
                            {
                                dicSort.Add("Оранжевый", 1);
                                mInformer.Info("Впервые найден оранжевый цвет!");
                            }
                        }
                        else if (V > 0.15f && S > 0.1f && S < 0.75f && H > 11.0f && H < 45.0f)
                        {
                            if (dicSort.ContainsKey("Коричневый"))
                            {
                                dicSort["Коричневый"] = dicSort["Коричневый"] + 1;
                            }
                            else
                            {
                                dicSort.Add("Коричневый", 1);
                                mInformer.Info("Впервые найден Коричневый цвет!");
                            }
                        }
                        else if (H < 64 && H > 45 && S > 0.15 && V > 0.1)
                        {
                            if (dicSort.ContainsKey("Желтый"))
                            {
                                dicSort["Желтый"] = dicSort["Желтый"] + 1;
                            }
                            else
                            {
                                dicSort.Add("Желтый", 1);
                                mInformer.Info("Впервые найден желтый цвет!");
                            }
                        }
                        else if (H < 150 && H < 64 && S > 0.15 && V > 0.1)
                        {
                            if (dicSort.ContainsKey("Зеленый"))
                            {
                                dicSort["Зеленый"] = dicSort["Зеленый"] + 1;
                            }
                            else
                            {
                                dicSort.Add("Зеленый", 1);
                                mInformer.Info("Впервые найден зеленый цвет!");
                            }
                        }
                        else if (H < 180 && H < 150 && S > 0.15 && V > 0.1)
                        {
                            if (dicSort.ContainsKey("Аква"))
                            {
                                dicSort["Аква"] = dicSort["Аква"] + 1;
                            }
                            else
                            {
                                dicSort.Add("Аква", 1);
                                mInformer.Info("Впервые найден аква цвет!");
                            }
                        }
                        else if (H < 255 && H > 180 && S > 0.1 && V > 0.1)
                        {
                            if (dicSort.ContainsKey("Синий"))
                            {
                                dicSort["Синий"] = dicSort["Синий"] + 1;
                            }
                            else
                            {
                                dicSort.Add("Синий", 1);
                                mInformer.Info("Впервые найден синий цвет!");
                            }
                        }
                        else if (H < 310 && H > 255 && S > 0.1 && V > 0.1)
                        {
                            if (dicSort.ContainsKey("Фиолетовый"))
                            {
                                dicSort["Фиолетовый"] = dicSort["Фиолетовый"] + 1;
                            }
                            else
                            {
                                dicSort.Add("Фиолетовый", 1);
                                mInformer.Info("Впервые найден фиолетовый цвет!");
                            }
                        }
                    } // настройка H по картинке https://ru.wikipedia.org/wiki/HSV_(%D1%86%D0%B2%D0%B5%D1%82%D0%BE%D0%B2%D0%B0%D1%8F_%D0%BC%D0%BE%D0%B4%D0%B5%D0%BB%D1%8C)#/media/File:HueScale.svg
                    //////////////////////////////////////////////////////////////////////////////////
                }
            }
            //Console.WriteLine("Анализ изображения выполнен!");
            GetNewMaxTest();
        }
        /*public List<Color> GetMaxColors()
        {
            int idMax=0, valueMax=int.MinValue;
           //Console.WriteLine(dic.Values.Max().ToString());
           //Console.WriteLine(dic.Keys.Max().ToString());
            List<int> Maximum = new List<int>();
            List<Color> lt = new List<Color>();
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    if (dic.ElementAt(i).Value > valueMax)
                    {
                        valueMax = dic.ElementAt(i).Value;
                        idMax = dic.ElementAt(i).Key;
                    }
                }
                Color tmpColor = new Color();
                tmpColor = Color.FromArgb(idMax);
                lt.Add(tmpColor);
                float H = tmpColor.GetHue(), S = tmpColor.GetSaturation(), V = tmpColor.GetBrightness();
                Console.WriteLine("Цвет " + tmpColor.R.ToString() + " " + tmpColor.G.ToString() + " " + tmpColor.B.ToString());
                Console.WriteLine(H.ToString() + " " + S.ToString() + " " + V.ToString());
                if (V < 0.1)
                    Console.WriteLine("Черный");
                else if (V > 0.6 && S < 0.6)
                    Console.WriteLine("Белый");
                else if (S < 0.53f && V < 0.85f)
                    Console.WriteLine("Серый");
                else
                {
                    if (H < 7)
                        Console.WriteLine("Красный");
                    else if (H < 25)
                        Console.WriteLine("Оранжевый");
                    else if (H < 34)
                        Console.WriteLine("Желтый");
                    else if (H < 73)
                        Console.WriteLine("Зеленый");
                    else if (H < 102)
                        Console.WriteLine("Аква");
                    else if (H < 140)
                        Console.WriteLine("Синий");
                    else if (H < 170)
                        Console.WriteLine("Фиолетовый");
                    else    // full circle 
                        Console.WriteLine("Красный");   // back to Red
                }
                ///else if()
                Console.WriteLine("Повторения " + valueMax.ToString());
                Maximum.Add(valueMax);
                dic.Remove(idMax);
                idMax = 0;
                valueMax = int.MinValue;
            }
            return lt;
        }*/
        public override void GetNewMaxTest()
        {
            string idMax = "";
            int valueMax = int.MinValue;
            ResultContainer ob = new ResultContainer();
            Dictionary<string, int> tmp = new Dictionary<string, int>(dicSort);
            for (int j = 0; j < tmp.Count; j++)
            {
                for (int i = 0; i < tmp.Count; i++)
                {
                    if (tmp.ElementAt(i).Value > valueMax)
                    {
                        valueMax = tmp.ElementAt(i).Value;
                        idMax = tmp.ElementAt(i).Key;
                    }
                }
                //Console.WriteLine(idMax + " " + valueMax.ToString());
                ob.lt.Add(new ResultObject(idMax, valueMax));
                //tmp.Remove(idMax);
                idMax = "";
                valueMax = int.MinValue;
            }
            data = ob;
            //Console.WriteLine("Определение максимальной частоты цвета завершено, можно выводить информацию!");
        }
        public override string ShowInfo()
        {            
            if(data.lt.Count == 0)
            {
                return "error";
            }
            if (data.lt.Count < 2)
            {
                gInfo += "Чаще встречающиеся цвета:\n" + data.lt[0].colorName;
                /*Console.WriteLine("Чаще встречающиеся цвета:\n" + data.lt[0].colorName);*/
                OutPut.GetSetInfo=gInfo;
                h1.Request(data.lt[0].colorName);
            }
            else if (((data.lt[1].colorCount * 100) / data.lt[0].colorCount) > 15.0)
            {
                //Console.WriteLine("Чаще встречающиеся цвета:\n" + data.lt[0].colorName + ", " + data.lt[1].colorName);
                gInfo += "Чаще встречающиеся цвета:\n"+data.lt[0].colorName + ", " + data.lt[1].colorName;
                OutPut.GetSetInfo=gInfo;
                List<string> costil = new List<string>();
                //этот костыль ради диаграммы цветов, да простит меня Боженька
                costil.Add("Черный");
                costil.Add("Белый");
                costil.Add("Красный");
                costil.Add("Аква");
                costil.Add("Оранжевый");
                costil.Add("Синий");
                costil.Add("Серый");
                costil.Add("Фиолетовый");
                costil.Add("Черный");
                costil.Add("Зеленый");
                costil.Add("Желтый");
                //costil.Add("Коричневый"); тк отсутствует файл Brown.txt
                for (int i = 0; i < costil.Count; i++)
                {
                    h1.Request(costil[i]);
                }
                
                //h1.Request(data.lt[0].colorName);
                //h1.Request(data.lt[1].colorName);
            }
            else
            {
                gInfo += "Чаще встречающиеся цвета:\n" + data.lt[0].colorName;
                OutPut.GetSetInfo = gInfo;
                //Console.WriteLine("Чаще встречающиеся цвета:\n" + data.lt[0].colorName);
                h1.Request(data.lt[0].colorName);
            }
            //MessageBox.Show(gInfo);
            return OutPut.GetSetInfo;
        }
        //-----------------------------------------------------------------------
        public override Dictionary<string,double> GetMaxPercent()
        {
            int all = dicSort.Values.Sum();
            Dictionary<string, double> tmp = new Dictionary<string, double>();
            for (int i = 0; i < dicSort.Count; i++)
            {
                tmp.Add(dicSort.ElementAt(i).Key, (double)dicSort.ElementAt(i).Value / all);
            }
            return tmp;
        }

        public override Dictionary<string, double> PriorColor(Dictionary<string, double> dc)
        {
            //это то что должно работать в DiagPrior в цепочке обязаностей
            Dictionary<string, double> tmp = new Dictionary<string, double>();

            for (int i = 0; i < dc.Count; i++)
            {
                if (dc.ElementAt(i).Value >= 0.7)
                {
                    tmp.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                }
                else if (dc.ElementAt(i).Value>=0.6)
                {
                    if (tmp.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    tmp.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    for (int j = 0; j < dc.Count; j++)
                    {
                        if (i == j)
                            continue;
                        if (dc.ElementAt(j).Value >= 0.2 && dc.ElementAt(j).Value <= 0.4)
                        {
                            tmp.Add(dc.ElementAt(j).Key, dc.ElementAt(j).Value);
                        }
                    }
                }
                else if (dc.ElementAt(i).Value>=0.5)
                {
                    if (tmp.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    tmp.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    for (int j = 0; j < dc.Count; j++)
                    {
                        if (i == j)
                            continue;
                        if (dc.ElementAt(j).Value >= 0.2 && dc.ElementAt(j).Value <= 0.5)
                        {
                            tmp.Add(dc.ElementAt(j).Key, dc.ElementAt(j).Value);
                        }
                    }
                }
                else if (dc.ElementAt(i).Value >= 0.4)
                {
                    if (tmp.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    tmp.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    for (int j = 0; j < dc.Count; j++)
                    {
                        if (i == j)
                            continue;
                        if (dc.ElementAt(j).Value >= 0.3 && dc.ElementAt(j).Value <= 0.5)
                        {
                            tmp.Add(dc.ElementAt(j).Key, dc.ElementAt(j).Value);
                        }
                    }
                }
            }
            return tmp;
        }




    }
}

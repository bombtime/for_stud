using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    class DiagrPrior 
    {
        Dictionary<string, double> pr;
        public DiagrPrior(Dictionary<string, double> tmp)
        {
            pr = new Dictionary<string, double>(tmp);
        } 
    }
    abstract class DiagPrBuild : Singleton<DiagPrBuild>
    {
        abstract public void FillPrior();
        abstract public Dictionary<string,double> GetPriorColor();
        static protected Dictionary<string, double> dict;
        static public Handlerr s70 = new S70();
        static public Handlerr s60 = new S60();
        static public Handlerr s50 = new S50();
        static public Handlerr s2050 = new S2050();
        static public Handlerr s2040 = new S2040();
        static public Handlerr s40 = new S40();
        static public Handlerr s3050 = new S3050();
    }

    class DGBuild : DiagPrBuild
    {
        public DGBuild(Dictionary<string, double> tmp)
        {
            dict = new Dictionary<string, double>(tmp);
            s70.SetNext(s60);
            s60.SetNext(s2040);
            s2040.SetNext(s50);
            s50.SetNext(s2050);
            s2050.SetNext(s40);
            s40.SetNext(s3050);
        }

        public override Dictionary<string, double> GetPriorColor()
        {
            return dict;
        }
        public override void FillPrior()
        {
            s70.Request(dict);
        }
    }
    public abstract class Handlerr
    {
        protected Handlerr h;
        public void SetNext(Handlerr tmph)
        {
            h = tmph;
        }
        public abstract void Request(Dictionary<string, double> dc);
        protected void ShowInfo(string path, string colname)
        {
            
            
            //MessageBox.Show("Характеристика", InfColors.dc);
            
            //Console.WriteLine("\n\n");
        }
        //public override Dictionary<string, double> PriorColor(Dictionary<string, double> dc)
        //{
        //    Dictionary<string, double> InfColors.dc = new Dictionary<string, double>();

        //    for (int i = 0; i < dc.Count; i++)
        //    {
        //        if (dc.ElementAt(i).Value >= 0.7)
        //        {
        //            InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
        //        }
        //        else if (dc.ElementAt(i).Value >= 0.6)
        //        {
        //            if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
        //                continue;
        //            InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
        //            for (int j = 0; j < dc.Count; j++)
        //            {
        //                if (i == j)
        //                    continue;
        //                if (dc.ElementAt(j).Value >= 0.2 && dc.ElementAt(j).Value <= 0.4)
        //                {
        //                    InfColors.dc.Add(dc.ElementAt(j).Key, dc.ElementAt(j).Value);
        //                }
        //            }
        //        }
        //        else if (dc.ElementAt(i).Value >= 0.5)
        //        {
        //            if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
        //                continue;
        //            InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
        //            for (int j = 0; j < dc.Count; j++)
        //            {
        //                if (i == j)
        //                    continue;
        //                if (dc.ElementAt(j).Value >= 0.2 && dc.ElementAt(j).Value <= 0.5)
        //                {
        //                    InfColors.dc.Add(dc.ElementAt(j).Key, dc.ElementAt(j).Value);
        //                }
        //            }
        //        }
        //        else if (dc.ElementAt(i).Value >= 0.4)
        //        {
        //            if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
        //                continue;
        //            InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
        //            for (int j = 0; j < dc.Count; j++)
        //            {
        //                if (i == j)
        //                    continue;
        //                if (dc.ElementAt(j).Value >= 0.3 && dc.ElementAt(j).Value <= 0.5)
        //                {
        //                    InfColors.dc.Add(dc.ElementAt(j).Key, dc.ElementAt(j).Value);
        //                }
        //            }
        //        }
        //    }
        //    return InfColors.dc;
        //}
    }
    class S70 : Handlerr
    {
        public override void Request(Dictionary<string, double> dc)
        {
            for (int i = 0; i < dc.Count; i++)
            {
                if(dc.ElementAt(i).Value >= 0.7)
                {
                    InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    dc.Remove(dc.ElementAt(i).Key);
                    return;//чтобы это реально все работало
                }
            }
            if (h != null)
                h.Request(dc);
        }
    }
    class S60 : Handlerr
    {
        public override void Request(Dictionary<string, double> dc)
        {
            Dictionary<string, double> tmp = new Dictionary<string, double>(dc);
            for (int i = 0; i < dc.Count; i++)
            {
                if (dc.ElementAt(i).Value >= 0.6)
                {
                    if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    tmp.Remove(dc.ElementAt(i).Key);//необходимо немного переделать архитектуру
                }
            }
            if (h != null)
                h.Request(tmp);
        }
    }
    class S50 : Handlerr
    {
        public override void Request(Dictionary<string, double> dc)
        {
            Dictionary<string, double> tmp = new Dictionary<string, double>(dc);
            for (int i = 0; i < dc.Count; i++)
            {
                if (dc.ElementAt(i).Value >= 0.5)
                {
                    if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    tmp.Remove(dc.ElementAt(i).Key);
                }
            }
            if (h != null)
                h.Request(tmp);
        }
    }
    class S2040 : Handlerr
    {
        public override void Request(Dictionary<string, double> dc)
        {
            Dictionary<string, double> tmp = new Dictionary<string, double>(dc);
            for (int i = 0; i < dc.Count; i++)
            {
                if (dc.ElementAt(i).Value >= 0.2 && dc.ElementAt(i).Value <= 0.4)
                {
                    if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    tmp.Remove(dc.ElementAt(i).Key);
                }
            }
            if (h != null)
                h.Request(tmp);
        }
    }
    class S2050 : Handlerr
    {
        public override void Request(Dictionary<string, double> dc)
        {
            Dictionary<string, double> tmp = new Dictionary<string, double>(dc);
            for (int i = 0; i < dc.Count; i++)
            {
                if (dc.ElementAt(i).Value >= 0.2 && dc.ElementAt(i).Value <= 0.5)
                {
                    if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    tmp.Remove(dc.ElementAt(i).Key);
                }
            }
            if (h != null)
                h.Request(tmp);
        }
    }
    class S40 : Handlerr
    {
        public override void Request(Dictionary<string, double> dc)
        {
            Dictionary<string, double> tmp = new Dictionary<string, double>(dc);
            for (int i = 0; i < dc.Count; i++)
            {
                if (dc.ElementAt(i).Value >= 0.4)
                {
                    if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    tmp.Remove(dc.ElementAt(i).Key);
                }
            }
            if (h != null)
                h.Request(tmp);
        }
    }
    class S3050 : Handlerr
    {
        public override void Request(Dictionary<string, double> dc)
        {
            Dictionary<string, double> tmp = new Dictionary<string, double>(dc);
            for (int i = 0; i < dc.Count; i++)
            {
                if (dc.ElementAt(i).Value >= 0.3 && dc.ElementAt(i).Value <= 0.5)
                {
                    if (InfColors.dc.ContainsKey(dc.ElementAt(i).Key))
                        continue;
                    InfColors.dc.Add(dc.ElementAt(i).Key, dc.ElementAt(i).Value);
                    tmp.Remove(dc.ElementAt(i).Key);
                }
            }
            if (h != null)
                h.Request(tmp);
        }
    }

}

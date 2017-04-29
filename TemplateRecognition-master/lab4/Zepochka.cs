﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using System.Drawing;
namespace lab4
{
    abstract class FindAndResult
    {
        protected FindAndResult successor;
        public void SetConnect(FindAndResult successor)
        {
            this.successor = successor;
        }
        public abstract int FindSimbol(double res);
    }

    class ResultFoundHandler : FindAndResult
    {
        public override int FindSimbol(double res)
        {
            if (res < AppData.getInstance().accuracy)
            {
                Console.WriteLine("Я что то распознал");
                return 1;
            }
            else if (successor != null)
            {
                successor.FindSimbol(res);
                return 0;
            }
            return -1;

        }
    }
    class ResultNotFoundHandler : FindAndResult
    {
        public override int FindSimbol(double res)
        {
            if (res >= 0.05)
            {
                Console.WriteLine("Я ничего не распознал");
                return 2;
            }
            else if (successor != null)
            {
                successor.FindSimbol(res);
                return 0;
            }
            return -1;
        }
    }
    /// <summary>
    /// factorymethod for (exrsimvol and simvol) = product
    /// к фабричному методу необходимо в теле мейна  добавить условие в 
    /// каком режиме мы находимся эксперт или обычный человек, код слегка избыточен,
    /// но это плюс к паттерну так что сойдет.
    /// </summary>
    class Product
    {
        public string name;
        public string info;
        public Bitmap template;
        /// <summary>
        /// Создаёт продукт
        /// </summary>
        /// <param name="template">шаблон, который требуется найти на изображении</param>
        /// <param name="name">название шаблона</param>
        /// <param name="info">описание шаблона</param>
        public Product(Bitmap template, string name, string info = "")
        {
            this.template = template;
            this.name = name;
            this.info = info;
        }
           virtual public bool ValidateIsUpper()
        {
            if (char.IsUpper(name[0])) return true;
            else return false;         
        }
        public Product() { }
    }


    abstract class DecoratorProduct : Product
    {
        protected Product product;

        public void SetProduct(Product product)
        {
            this.product = product;
        }

        public override bool ValidateIsUpper()
        {
            if (product != null)
            {
                return product.ValidateIsUpper();
            }
            else return false;
        }
    }
   

    class DecoratorA : DecoratorProduct
    {
        public override bool ValidateIsUpper()
        {
            if (base.ValidateIsUpper())
            {
                name = base.name + '.';
            }
            return true;
        }
    }

    abstract class Creator
    {
        protected ConcreteFactory factory;
        public abstract AbstractSimvol FactoryMethod(Rectangle aa);
    }

    class SimvolOutProductCreator : Creator
    {
        public SimvolOutProductCreator(Product product)
        {
            factory = new ConcreteFactory(product);
        }
        public override AbstractSimvol FactoryMethod(Rectangle aa)
        {
            return factory.CreateSimvol(aa);
        }
    }
    class CreateExpSimvolOutProduct : Creator
    {
        public CreateExpSimvolOutProduct(Product product)
        {
            factory = new ConcreteFactory(product);
        }
        public override AbstractSimvol FactoryMethod(Rectangle aa)
        {
            return factory.CreateExpSimvol();
        }
    }
}

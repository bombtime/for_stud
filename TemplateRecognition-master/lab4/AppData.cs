﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab4
{
    /// <summary>
    /// Этот класс используется для хранения основных данных и состояния
    /// приложения, паттерн [singleton]
    /// </summary>
    class AppData
    {
        private static AppData instance;
        public ImageDataBase dataBase;
        private static readonly Object syncRoot = new Object();
        public bool isExpert;
        public double accuracy = 0.01;

        //Данные и состояния
        public static List<Image> listImages { get; set; }
        public static string pathDirection { get; set; }
        public static string DataBaseConnetionState { get; set; }        


        protected AppData()
        {
            dataBase = new ImageDataBase();
        }
        public static AppData getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new AppData();
                    }
                }
            }
            return instance;
        }
    }
}

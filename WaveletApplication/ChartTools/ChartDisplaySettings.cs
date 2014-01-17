using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WaveletApplication.ChartTools
{
    public class ChartDisplaySettings
    {

        
        private int _borderPadding=30;
        private bool _resizeRedraw=true;
        private int _ticksLength=4;
        private System.Drawing.Color _chartLineColor = Color.Black;
        private float _chartLineWidth = 1;
        private bool _chartSizeArea = true;
        private int _yAxisMax = 0;
        private int _yAxisMin = 0;

        [CategoryAttribute("Основные параметры"), DisplayName(@"Отступ координатной сетки:"), Description("Расстояние отступа координатных осей от границы холста (int)")]
        public int BorderPadding
        {
            get { return _borderPadding; }
            set { _borderPadding = value; }
        }

        [CategoryAttribute("Основные параметры"), DisplayName(@"Авто-обновление параметров:"), Description("Разрешить перерисовку графика при изменении размера окна (bool)")]
        public bool ResizeRedraw
        {
            get { return _resizeRedraw; }
            set { _resizeRedraw = value; }
        }
        [CategoryAttribute("Основные параметры"), DisplayName(@"Длина рисок:"), Description("Длинна рисок, отвечающих за цену деления (int)")]
        public int TicksLength
        {
            get { return _ticksLength; }
            set { _ticksLength = value; }
        }
        [CategoryAttribute("Основные параметры"), DisplayName(@"Цвет графика:"), Description("Цвет линий графика, (colour)")]
        public Color ChartLineColor
        {
            get { return _chartLineColor; }
            set { _chartLineColor = value; }
        }
        [CategoryAttribute("Основные параметры"), DisplayName(@"Толщина линий:"), Description("Толщина линий графика, (float)")]
        public float ChartLineWidth
        {
            get { return _chartLineWidth; }
            set { _chartLineWidth = value; }
        }
        [CategoryAttribute("Основные параметры"), DisplayName(@"Размер холста:"), Description("Показывать размер холста на графике, (bool)")]
        public bool ChartSizeArea
        {
            get { return _chartSizeArea; }
            set { _chartSizeArea = value; }
        }
        [CategoryAttribute("Настройка Осей"), DisplayName(@"Фиксировать YMax:"), Description("Зафиксировать максимальную координату графика по оси Y, (int)")]
        public int YAxisMax
        {
            get { return _yAxisMax; }
            set { _yAxisMax = value; }
        }
        [CategoryAttribute("Настройка Осей"), DisplayName(@"Фиксировать YMin:"), Description("Зафиксировать минимальную координату графика по оси Y, (int)")]
        public int YAxisMin
        {
            get { return _yAxisMin; }
            set { _yAxisMin = value; }
        }

    }
}

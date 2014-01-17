using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveletApplication
{
    class StatisticTools
    {
        public static double MeanValue(List<double> a)
        {
            return a.Sum()/a.Count();

        }
        public static double VarianceValue(List<double> a)
        {
            double mean = MeanValue(a);
            double sum = 0;
            foreach (int i in a)
            {
                sum+=((i-mean)*(i-mean));               
            }
            return sum/(a.Count()-1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionVisualizer.Functions
{
    public struct СalculData
    {
        public double StartInterval;
        public double EndInterval;
        public double Step;

        public СalculData(double startInterval, double endInterval, double step)
        {
            if (endInterval <= startInterval)
                throw new Exception("Начало интервало должно быть меньше конца интервала." +
                         $"Начало интервала: {startInterval};" +
                         $" Конец интервала :{endInterval}");
            if (step <= 0)
                throw new Exception($"Шаг должен быть болше нуля. Шаг: {step}");
            StartInterval = startInterval;
            EndInterval = endInterval;
            Step = step;
        }
    }
}

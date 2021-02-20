using System;
using System.Collections;
using System.Collections.Generic;

namespace FunctionVisualizer.Functions
{
    class FunctionsControler : IEnumerable
    {
        Function _Function;
        private double _StartInterval;
        private double _EndInterval;
        private double _Step;

        string FunctionStr { set => _Function = new Function(value); }
        public FunctionsControler(double startInterval, double endInterval, double step, string funcStr)
        {
            if (string.IsNullOrWhiteSpace(funcStr))            
                throw new ArgumentException($" \"{funcStr}\" не может быть пустым или содержать только пробел", nameof(funcStr));
            _Function = new Function(funcStr);
            _StartInterval = startInterval;
            _EndInterval = endInterval;
            _Step = step;
        }

        public double Step
        {
            get => _Step; set
            {
                if (value > 0)
                    _Step = value;
                else
                    throw new Exception($"Шаг должен быть болше нуля. Шаг: {Step}");
            }
        }
        public double StartInterval
        {
            get => _StartInterval;
            set
            {
                if (value < EndInterval)
                    _StartInterval = value;
                else
                    ReturnExceptionBadIntervals(value, EndInterval);
            }
        }
        public double EndInterval
        {
            get => _EndInterval; set
            {
                if (value > StartInterval)
                    _EndInterval = value;
                else
                    ReturnExceptionBadIntervals(StartInterval,value);
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new FunctionEnumerator(StartInterval, EndInterval, Step, _Function);
        }
        public double[] GetArrayValue()
        {
            List<double> resultList = new List<double>();
            foreach (var item in this)
            {
                resultList.Add((double)item);
            }
            return resultList.ToArray();
        }

        private void ReturnExceptionBadIntervals(double StartInterval, double EndInterval)
        {
            throw new Exception("Начало интервало должно быть меньше конца интервала." +
                         Environment.NewLine + $"Начало интервала: {StartInterval}; Конец интервала :{EndInterval}");
        }
    }
}
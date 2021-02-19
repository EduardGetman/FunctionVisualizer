using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionVisualizer.Functions
{
    class FunctionEnumerator : IEnumerator
    {
        private double _StartInterval;
        private double _EndInterval;
        private double _Step;
        Function _Function;
        private double _Parameter;

        public FunctionEnumerator(double startInterval, double endInterval, double step,  Function function)
        {
            _Parameter = _StartInterval = startInterval;
            _EndInterval = endInterval;
            _Step = step;
            _Function = function;
        }

        public object Current => _Function.Calculate(_Parameter);

        public bool MoveNext()
        {
            if (_Parameter < _EndInterval && _Parameter > _StartInterval)
            {
                _Parameter += _Step;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            _Parameter = _StartInterval;
        }
    }
}

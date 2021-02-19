using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionVisualizer.Function
{
    class FunctionEnumerator : IEnumerator
    {
        private double _StartInterval;
        private double _EndInterval;
        private double _Step;
        private IExpression _FunctionInstruction;
        private double _Parameter;

        public FunctionEnumerator(double startInterval, double endInterval, double step, IExpression expression)
        {
            _StartInterval = startInterval;
            _EndInterval = endInterval;
            _Step = step;
            _Parameter = startInterval;
            _FunctionInstruction = expression;
        }

        public object Current => _FunctionInstruction.GetValue(_Parameter);

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

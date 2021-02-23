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
        private CalculData _Data;
        private Function _Function;
        private double _Parameter;

        public FunctionEnumerator(CalculData data,  Function function)
        {
            _Data = data;
            _Parameter = data.StartInterval;
            _Function = function;
        }
        public object Current => _Function.Calculate(_Parameter);

        public bool MoveNext()
        {
            if (_Parameter < _Data.EndInterval)
            {
                _Parameter += _Data.Step;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            _Parameter = _Data.StartInterval;
        }
    }
}

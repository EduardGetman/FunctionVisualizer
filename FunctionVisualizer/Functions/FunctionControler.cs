using System;
using System.Collections;
using System.Collections.Generic;
using FunctionVisualizer.Functions.Validators;
namespace FunctionVisualizer.Functions
{
    class FunctionsControler : IEnumerable
    {
        Function _Function;
        private CalculData _Data;

        ValidString FunctionStr { set => _Function = new Function(value); }
        public FunctionsControler(CalculData data,ValidString funcStr)
        {
            _Function = new Function(funcStr);
            _Data = data;
        }
                      
        public IEnumerator GetEnumerator()
        {
            return new FunctionEnumerator(_Data, _Function);
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
    }
}
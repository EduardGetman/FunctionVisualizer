using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer.Function
{
    public class Function:IEnumerable
    {
        private IExpression _FunctionInstruction;
        private double _StartInterval;
        private double _EndInterval;
        private double _Step;


        public IExpression FunctionInstruction { get => _FunctionInstruction; set => _FunctionInstruction = value; }
        public double StartInterval { get => _StartInterval; set => _StartInterval = value; }
        public double EndInterval { get => _EndInterval; set => _EndInterval = value; }
        public double Step { get => _Step; set => _Step = value; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
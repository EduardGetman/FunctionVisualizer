using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer.Functions.Expression
{
    public interface IExpression
    {
        double GetValue(double parametr);
    }
}
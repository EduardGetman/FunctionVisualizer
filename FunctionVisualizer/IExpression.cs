using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionVisualizer
{
   public interface IExpression 
    {
        double GetValue(double parametr);
    }
}
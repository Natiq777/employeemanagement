
using Application.Common.Enum;

namespace Application.Filters
{
    public class CompareExpressionModel
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public CompareType CompareType { get; set; }
    }

}

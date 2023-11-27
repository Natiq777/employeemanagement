using Application.Common.Enum; 
using System.Net; 

namespace Application.Filters
{
    public class CompareExpressionModels
    {
        public static List<CompareExpressionModel> CompareExpression(string queryString)
        {

            queryString = WebUtility.UrlDecode(queryString);


            List<CompareExpressionModel> expressionModels = new List<CompareExpressionModel>();

            if (queryString.FirstOrDefault().Equals('?'))
            {
                queryString = queryString.Remove(0, 1);
            }

            foreach (var item in queryString.Split("&"))
            {
                string[] keys = item.Split("=");

                (string Name, string Value) key = (keys[0], keys[1]);

                if (key.Name.StartsWith("q") && !string.IsNullOrEmpty(key.Value))
                {
                    CompareType compareType = CompareType.EqualTo;
                    string propertyName = key.Name.Substring(1, key.Name.Length - 1); 
                    string[] arr = propertyName.Split('_');
                    if (arr.Length == 2)
                    {
                        propertyName = arr[0];
                        if (int.TryParse(arr[1], out int compareTypeValue))
                        {
                            compareType = (CompareType)compareTypeValue;
                        }
                    }

                    var key1 = (key.Value == "null" ? null : key.Value);
                    CompareExpressionModel expressionModel = new CompareExpressionModel()
                    {
                        PropertyName = propertyName,
                        PropertyValue = key1,
                        CompareType = compareType
                    };
                    expressionModels.Add(expressionModel);

                }
            }

            return expressionModels;
        }
    }
}

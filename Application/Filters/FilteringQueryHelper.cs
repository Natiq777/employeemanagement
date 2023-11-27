using Application.Common.Enum; 
using System.Linq.Expressions; 

namespace Application.Filters
{
    public static class FilteringQueryHelper
    {
        private static MemberExpression NestedExprProp(Expression expr, string propName)
        {
            string[] arrProp = propName.Split('.');
            int arrPropCount = arrProp.Length;

            var nestedExp = (arrPropCount > 1) ? Expression.Property(NestedExprProp(expr, arrProp.Take(arrPropCount - 1).Aggregate((a, i) => a + "." + i)), arrProp[arrPropCount - 1]) : Expression.Property(expr, propName);

            return nestedExp;
        }
        private static Expression ApplyFilter(CompareType compareType, Expression left, Expression right)
        {
            Expression InnerLambda = null;

            if (left.Type == typeof(string))
            {
                left = Expression.Call(left, typeof(string).GetMethod("ToUpper", System.Type.EmptyTypes));
                right = Expression.Call(right, typeof(string).GetMethod("ToUpper", System.Type.EmptyTypes));
            }
            switch (compareType)
            {
                case CompareType.EqualTo:
                    InnerLambda = Expression.Equal(left, right);
                    break;
                case CompareType.LessThen:
                    InnerLambda = Expression.LessThan(left, right);
                    break;
                case CompareType.GraterThan:
                    InnerLambda = Expression.GreaterThan(left, right);
                    break;
                case CompareType.GreaterThanOrEqual:
                    InnerLambda = Expression.GreaterThanOrEqual(left, right);
                    break;
                case CompareType.LessThanOrEqual:
                    InnerLambda = Expression.LessThanOrEqual(left, right);
                    break;
                case CompareType.NotEqual:
                    InnerLambda = Expression.NotEqual(left, right);
                    break;
                case CompareType.Contains:
                    InnerLambda = Expression.Call(left, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), right);
                    break;
                case CompareType.NotContains:
                    InnerLambda = Expression.Not(Expression.Call(left, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), right));
                    break;
            }
            return InnerLambda;
        }
        public static Expression<Func<T, bool>> ToExpression<T>(string propName, CompareType opr, string value)
        {
            try
            {
                ParameterExpression paramExpr = Expression.Parameter(typeof(T));
                var arrProp = propName.Split('.').ToList();
                Expression binExpr = null;
                string partName = string.Empty;
                arrProp.ForEach(x =>
                {
                    Expression tempExpr = null;
                    partName = string.IsNullOrEmpty(partName) || string.IsNullOrWhiteSpace(partName) ? x : partName + "." + x;
                    if (partName == propName)
                    {
                        var member = NestedExprProp(paramExpr, partName);
                        var type = member.Type.Name == "Nullable`1" ? Nullable.GetUnderlyingType(member.Type) : member.Type;

                        tempExpr = ApplyFilter(opr, member, Expression.Convert(ToExprConstant(type, value), member.Type));
                    }
                    else
                        tempExpr = ApplyFilter(CompareType.NotEqual, NestedExprProp(paramExpr, partName), Expression.Constant(null));
                    if (binExpr != null)
                        binExpr = Expression.AndAlso(binExpr, tempExpr);
                    else

                        binExpr = tempExpr;
                });
                return Expression.Lambda<Func<T, bool>>(binExpr, paramExpr);
            }
            catch
            {
                return null;
            }
        }
        private static Expression ToExprConstant(Type prop, string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return Expression.Constant(value);
            object val = null;
            switch (prop.FullName)
            {
                case "System.Guid":
                    val = Guid.Parse(value);
                    break;
                default:
                    val = Convert.ChangeType(value, Type.GetType(prop.FullName));
                    break;
            }
            return Expression.Constant(val);
        }
        public static IQueryable<TEntity> AddWhereExpressionsToQuery<TEntity>(this IQueryable<TEntity> source, List<CompareExpressionModel> expressionModels)
        {
            if (expressionModels != null && expressionModels.Count() > 0)
            {
                Expression<Func<TEntity, bool>> expr = null;
                foreach (var item in expressionModels)
                {
                    if (expr == null)
                    {
                        expr = ToExpression<TEntity>(item.PropertyName, item.CompareType, item.PropertyValue);
                    }
                    else
                    {
                        Expression<Func<TEntity, bool>> temp = ToExpression<TEntity>(item.PropertyName, item.CompareType, item.PropertyValue);
                        expr = expr.And(temp);
                    }
                }
                if (expr != null)
                {
                    source = source.Where(expr);
                }
            }
            return source;
        }
        private static Expression<Func<T, TResult>> And<T, TResult>(this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, TResult>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}

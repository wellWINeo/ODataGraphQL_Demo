using System.Linq.Expressions;
using System.Reflection;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;

namespace GraphQLDemo.Handlers;

public class QueryableStringInvariantContainsHandler : QueryableStringOperationHandler
{
    private static readonly MethodInfo _toLower = typeof(string)
        .GetMethods()
        .Single(
            x => x.Name == nameof(string.ToLower) && x.GetParameters().Length == 0);

    private static readonly MethodInfo _contains = typeof(string)
        .GetMethods()
        .Single(x 
            => x.Name == nameof(string.Contains) && _checkContainsMethodParameters(x.GetParameters()));

    private static bool _checkContainsMethodParameters(IReadOnlyList<ParameterInfo> parameters)
        => parameters.Count == 1 && parameters[0].ParameterType == typeof(string);

    protected override int Operation => DefaultFilterOperations.Contains;

    public QueryableStringInvariantContainsHandler(InputParser inputParser) : base(inputParser) { }

    public override Expression HandleOperation(QueryableFilterContext context, IFilterOperationField field, IValueNode value,
        object? parsedValue)
    {
        var property = context.GetInstance();

        if (parsedValue is string str)
        {
            return Expression.AndAlso(
                BuildNotEqualsToNullExpression(property),
                BuildContainsMethodExpression(property, str)
            );
        }

        throw new InvalidOperationException();       
    }
    
    private static Expression BuildContainsMethodExpression(Expression propertyAccessExpression, string value)
    {
        var lowerPropertyExpression = Expression.Call(propertyAccessExpression, _toLower);
        
        return Expression.Call(
            lowerPropertyExpression,
            _contains, 
            Expression.Constant(value.ToLower(), typeof(string)));
    }

    private static Expression BuildNotEqualsToNullExpression(Expression propertyAccessExpression)
        => Expression.NotEqual(propertyAccessExpression, Expression.Constant(null, typeof(string)));
}
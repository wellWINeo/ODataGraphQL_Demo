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
            x => x.Name == nameof(string.ToLower) &&
                 x.GetParameters().Length == 0);
    
    protected override int Operation => DefaultFilterOperations.Contains;

    public QueryableStringInvariantContainsHandler(InputParser inputParser) : base(inputParser)
    { }

    public override Expression HandleOperation(QueryableFilterContext context, IFilterOperationField field, IValueNode value,
        object? parsedValue)
    {
        var property = context.GetInstance();

        if (parsedValue is string str)
        {
            return Expression.Equal(
                Expression.Call(property, _toLower),
                Expression.Constant(str.ToLower()));
        }

        throw new InvalidOperationException();       
    }
}
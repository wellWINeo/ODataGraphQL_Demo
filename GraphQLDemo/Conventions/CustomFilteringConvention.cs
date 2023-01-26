using GraphQLDemo.Handlers;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;

namespace GraphQLDemo.Conventions;

public class CustomFilteringConvention : FilterConvention
{
    protected override void Configure(IFilterConventionDescriptor descriptor)
    {
        descriptor.AddDefaults();
        descriptor
            .Operation(DefaultFilterOperations.Contains)
            .Name("contains");
        descriptor.Provider(new QueryableFilterProvider(x
            => x
                .AddDefaultFieldHandlers()
                .AddFieldHandler<QueryableStringInvariantContainsHandler>())
        );
    }
}
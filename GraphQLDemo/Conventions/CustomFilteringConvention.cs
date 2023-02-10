using GraphQLDemo.Handlers;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;

namespace GraphQLDemo.Conventions;

public class CustomFilteringConvention : FilterConvention
{
    protected override void Configure(IFilterConventionDescriptor descriptor)
    {
        descriptor.AddDefaults();
        
        // contains
        descriptor
            .Operation(DefaultFilterOperations.Contains)
            .Name("contains");
        descriptor.AddProviderExtension(new QueryableFilterProviderExtension(x
            => x.AddFieldHandler<QueryableStringInvariantContainsHandler>())
        );
    }
}
using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.Extensions;
using GraphqlServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphqlServer.Queries.Categories
{
    [ExtendObjectType(Name = "Mutation")]
    public class CategoryMutation
    {
        [UseApplicationDbContext]
        public async Task<AddCategoryPayload> AddCategoryAsync(
            AddCategoryInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var category = new Category {
                Name = input.name
            };

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return new AddCategoryPayload(category);

        }        
    }
}
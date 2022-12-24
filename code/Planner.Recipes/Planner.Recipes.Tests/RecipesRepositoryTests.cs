using Microsoft.EntityFrameworkCore;
using Moq;
using Planner.Recipes.Domain.Models;
using Planner.Recipes.Infrastructure.Core;
using Planner.Recipes.Infrastructure.Infrastructure;

namespace Planner.Recipes.Tests
{
    [TestClass]
    public class RecipesRepositoryTests
    {
        private Mock<RecipesDbContext> _dbContextMock;
        private Mock<DbSet<Recipe>> _recipesSetMock;
        private Mock<DbSet<Favorite>> _favoritesSetMock;
        private Mock<DbSet<Product>> _productsSetMock;
        private Mock<DbSet<ProductPortion>> _productPortionsSetMock;
        private Mock<DbSet<Step>> _stepSetMock;

        private IRecipesRepository _recipesRepository;
        
        [TestInitialize]
        public void Init()
        {
            _dbContextMock = new Mock<RecipesDbContext>();

            _recipesSetMock = new Mock<DbSet<Recipe>>();
            _favoritesSetMock = new Mock<DbSet<Favorite>>();
            _productsSetMock = new Mock<DbSet<Product>>();
            _productPortionsSetMock = new Mock<DbSet<ProductPortion>>();
            _stepSetMock = new Mock<DbSet<Step>>();

            _dbContextMock
                .Setup(_ => _.Recipes)
                .Returns(_recipesSetMock.Object);

            _dbContextMock
                .Setup(_ => _.Favorites)
                .Returns(_favoritesSetMock.Object);

            _dbContextMock
                .Setup(_ => _.Products)
                .Returns(_productsSetMock.Object);

            _dbContextMock
                .Setup(_ => _.ProductPortions)
                .Returns(_productPortionsSetMock.Object);

            _dbContextMock
                .Setup(_ => _.Steps)
                .Returns(_stepSetMock.Object);
        }
    }
}

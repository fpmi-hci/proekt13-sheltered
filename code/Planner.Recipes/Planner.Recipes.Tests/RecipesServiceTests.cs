using Moq;
using Planner.Recipes.Domain.Core;
using Planner.Recipes.Domain.Models;
using Planner.Recipes.DomainServices;
using Planner.Recipes.Infrastructure.Core;

namespace Planner.Recipes.Tests
{
    [TestClass]
    public class RecipesServiceTests
    {
        private Mock<IRecipesRepository> _recipesRepositoryMock;
        private Mock<IFavoritesRepository> _favoritesRepositoryMock;

        private IList<Recipe> _recipesStorage;
        private IList<Favorite> _favoritesStorage;

        private IRecipesService _service;

        [TestInitialize]
        public void Init()
        {
            _recipesRepositoryMock = new Mock<IRecipesRepository>();
            _favoritesRepositoryMock = new Mock<IFavoritesRepository>();

            _recipesStorage = new List<Recipe>();
            _favoritesStorage = new List<Favorite>();

            _recipesRepositoryMock
                .Setup(_ => _.CreateAsync(It.IsAny<Recipe>(), It.IsAny<CancellationToken>()))
                .Callback((Recipe r, CancellationToken ct) =>
                {
                    _recipesStorage.Add(r);
                });

            _recipesRepositoryMock
                .Setup(_ => _.DeleteAsync(It.IsAny<Recipe>(), It.IsAny<CancellationToken>()))
                .Callback((Recipe r, CancellationToken ct) =>
                {
                    _recipesStorage.Remove(r);
                });

            _favoritesRepositoryMock
                .Setup(_ => _.CreateAsync(It.IsAny<Favorite>(), It.IsAny<CancellationToken>()))
                .Callback((Favorite f, CancellationToken ct) => 
                {
                    _favoritesStorage.Add(f);
                });

            _favoritesRepositoryMock
                .Setup(_ => _.DeleteAsync(It.IsAny<Favorite>(), It.IsAny<CancellationToken>()))
                .Callback((Favorite f, CancellationToken ct) =>
                {
                    _favoritesStorage.Remove(f);
                });

            _service = new RecipesService(
                _recipesRepositoryMock.Object,
                _favoritesRepositoryMock.Object);
        }

        [TestMethod]
        public async Task AddRecipeToFavoritesAsync_CallRepositoryCreateAsyncMethod()
        {
            //Setup 
            var recipeId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            //Act
            await _service.AddRecipeToFavoritesAsync(recipeId, userId, CancellationToken.None);

            //Assert
            _favoritesRepositoryMock.Verify(
                _ => _.CreateAsync(It.IsAny<Favorite>(), It.IsAny<CancellationToken>()), 
                Times.Once);

            Assert.IsTrue(_favoritesStorage.Any(_ => 
                _.UserId.Equals(userId) &&
                _.RecipeId.Equals(recipeId)));
        }

        [TestMethod]
        public async Task RemoveRecipeFromFavoritesAsync_CallRepositoryDeleteMethod()
        {
            //Setup
            var userId = Guid.NewGuid();
            var recipeId = Guid.NewGuid();

            var favorite = new Favorite()
            {
                UserId = userId,
                RecipeId = recipeId
            };

            //Act
            await _service.RemoveRecipeFromFavoritesAsync(recipeId, userId, CancellationToken.None);

            //Assert
            _favoritesRepositoryMock.Verify(
                _ => _.DeleteAsync(It.IsAny<Favorite>(), It.IsAny<CancellationToken>()),
                Times.Once);

            Assert.IsFalse(_favoritesStorage.Any(_ =>
                _.UserId.Equals(userId) &&
                _.RecipeId.Equals(recipeId)));
        }

        [TestMethod]
        public async Task GetRecipeDetailsAsync_CallGetReposiptryMethod()
        {
            //Setup
            var recipeId = Guid.NewGuid();

            //Act
            await _service.GetRecipeDetailsAsync(recipeId, CancellationToken.None);

            //Assert
            _recipesRepositoryMock.Verify(
                _ => _.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [TestMethod]
        public async Task GetRecipesAsync_WhenFavoritesSearchParameterPassed_CallsFavoritesRepositoryGetMethod()
        {
            //Setup
            var userId = Guid.NewGuid();
            var parameter = new FavoritesSearchParameter()
            {
                UserId = userId
            };

            //Act
            await _service.GetRecipesAsync(parameter, CancellationToken.None);

            //Assert
            _favoritesRepositoryMock.Verify(
                _ => _.GetAllAsync(It.IsAny<FavoritesSearchParameter>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [TestMethod]
        public async Task GetRecipesAsync_WhenRecipesSearchParameterPassed_CallsRecipesRepositoryGetMethod()
        {
            //Setup
            var userId = Guid.NewGuid();
            var parameter = new RecipesSearchParameter()
            {
                Filter = "pie"
            };

            //Act
            await _service.GetRecipesAsync(parameter, CancellationToken.None);

            //Assert
            _recipesRepositoryMock.Verify(
                _ => _.GetAllAsync(It.IsAny<RecipesSearchParameter>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [TestMethod]
        public async Task GetRecipesTotalCountAsync_WhenFavoritesSearchParameterPassed_CallsFavoritesRepositoryCountMethod()
        {
            //Setup
            var userId = Guid.NewGuid();
            var parameter = new FavoritesSearchParameter()
            {
                UserId = userId
            };

            //Act
            await _service.GetRecipesTotalCountAsync(parameter, CancellationToken.None);

            //Assert
            _favoritesRepositoryMock.Verify(
                _ => _.CountAsync(It.IsAny<FavoritesSearchParameter>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [TestMethod]
        public async Task GetRecipesTotalCountAsync_WhenRecipesSearchParameterPassed_CallsRecipesRepositoryCountMethod()
        {
            //Setup
            var userId = Guid.NewGuid();
            var parameter = new RecipesSearchParameter()
            {
                Filter = "pie"
            };

            //Act
            await _service.GetRecipesTotalCountAsync(parameter, CancellationToken.None);

            //Assert
            _recipesRepositoryMock.Verify(
                _ => _.CountAsync(It.IsAny<RecipesSearchParameter>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
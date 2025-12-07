using AntiqueBookstore.Controllers;
using AntiqueBookstore.Data;
using AntiqueBookstore.Domain.Entities;
using AntiqueBookstore.Models;
using AntiqueBookstore.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AntiqueBookstore.Web.Tests.Books
{
    public class BooksControllerCreateTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        private class FakeEnvironment : IWebHostEnvironment
        {
            public string ApplicationName { get; set; } = "TestApp";
            public IFileProvider WebRootFileProvider { get; set; } = null!;
            public string WebRootPath { get; set; } = Path.GetTempPath();
            public string EnvironmentName { get; set; } = "Development";
            public string ContentRootPath { get; set; } = Directory.GetCurrentDirectory();
            public IFileProvider ContentRootFileProvider { get; set; } = null!;
        }

        private class FakeFileStorageService : IFileStorageService
        {
            public Task<FileUploadResult> SaveFileAsync(IFormFile file, string subfolder)
                => Task.FromResult(FileUploadResult.Succeeded("/images/covers/fake.jpg"));

            public Task<FileDeleteResult> DeleteFileAsync(string relativePath)
                => Task.FromResult(FileDeleteResult.Succeeded());
        }

        private class MockTempDataProvider : ITempDataProvider
        {
            public IDictionary<string, object> LoadTempData(HttpContext context)
                => new Dictionary<string, object>();

            public void SaveTempData(HttpContext context, IDictionary<string, object> values) { }
        }

        private static ITempDataProvider CreateTempDataProvider()
        {
            return new MockTempDataProvider();
        }

        [Fact]
        public async Task Create_ValidModel_PersistsBook_AndRedirectsToIndex()
        {
            using var context = CreateContext();

            // Minimal seed for SelectedAuthorIds
            var author = new Author { FirstName = "John", LastName = "Doe" };
            context.Authors.Add(author);
            await context.SaveChangesAsync();

            var env = new FakeEnvironment();
            var logger = LoggerFactory.Create(b => b.AddDebug()).CreateLogger<BooksController>();
            var fileStorage = new FakeFileStorageService();

            var controller = new BooksController(context, env, logger, fileStorage);
            controller.TempData = new TempDataDictionary(
                new DefaultHttpContext(),
                CreateTempDataProvider()
            );

            var model = new BookCreateViewModel
            {
                Title = "Test Book",
                PublicationDate = 2000,
                ConditionId = 1,
                StatusId = 1,
                SelectedAuthorIds = new List<int> { author.Id }
            };

            // Correct action signature
            var result = await controller.Create(model);

            // Assertions
            context.Books.Should().HaveCount(1);
            var savedBook = context.Books.Include(b => b.BookAuthors).Single();

            savedBook.Title.Should().Be("Test Book");
            savedBook.BookAuthors.Should().HaveCount(1);

            var redirect = result.Should().BeOfType<RedirectToActionResult>().Subject;
            redirect.ActionName.Should().Be(nameof(BooksController.Index));
        }

        [Fact]
        public async Task Create_With_PublicationYear_Before1600_Should_ReturnView_WithModelError()
        {
            // Arrange
            using var context = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options);

            var env = new FakeEnvironment();
            var logger = NullLogger<BooksController>.Instance;
            var storage = new FakeFileStorageService();

            var controller = new BooksController(context, env, logger, storage);

            controller.TempData = new TempDataDictionary(
                new DefaultHttpContext(),
                CreateTempDataProvider()
            );

            var vm = new BookCreateViewModel
            {
                Title = "Invalid Book",
                PublicationDate = 1500,
                ConditionId = 1,
                StatusId = 1
            };

            controller.ModelState.AddModelError(nameof(vm.PublicationDate), "Invalid year");

            // Act
            var result = await controller.Create(vm);

            // Assert
            var view = Assert.IsType<ViewResult>(result);
            Assert.Equal(vm, view.Model);
        }
    }
}

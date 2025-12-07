using AntiqueBookstore.Controllers;
using AntiqueBookstore.Data;
using AntiqueBookstore.Models;
using AntiqueBookstore.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace AntiqueBookstore.Web.Tests.Books
{
    public class BooksControllerTests
    {
        // Helper isolated context
        private ApplicationDbContext CreateFakeDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        // Minimal fake StorageService (file upload is optional)
        private class FakeFileStorageService : IFileStorageService
        {
            public Task<FileUploadResult> SaveFileAsync(IFormFile file, string subfolder)
                => Task.FromResult(FileUploadResult.Succeeded("/fake/path.jpg"));

            public Task<FileDeleteResult> DeleteFileAsync(string relativePath)
                => Task.FromResult(FileDeleteResult.Succeeded());
        }

        // Minimal fake IWebHostEnvironment 
        private class FakeWebHostEnvironment : IWebHostEnvironment
        {
            public string WebRootPath { get; set; } = "";
            public string ContentRootPath { get; set; } = "";
            public string EnvironmentName { get; set; } = "Development";
            public string ApplicationName { get; set; } = "TestApp";

            public IFileProvider WebRootFileProvider { get; set; } = new NullFileProvider();
            public IFileProvider ContentRootFileProvider { get; set; } = new NullFileProvider();
        }


        [Fact]
        public async Task Create_InvalidModelState_ReturnsViewWithModel()
        {
            // Arrange
            var fakeContext = CreateFakeDbContext();
            var fakeEnv = new FakeWebHostEnvironment();
            var fakeLogger = new LoggerFactory().CreateLogger<BooksController>();
            var fakeStorage = new FakeFileStorageService();
            var controller = new BooksController(fakeContext, fakeEnv, fakeLogger, fakeStorage);

            // Force an invalid ModelState
            controller.ModelState.AddModelError("Title", "Required");

            var vm = new BookCreateViewModel
            {
                Title = null,          // triggers invalid model state
                PublicationDate = 2020,
                ConditionId = 1,
                StatusId = 1,
                SelectedAuthorIds = new List<int>()
            };

            // Act
            var result = await controller.Create(vm);

            // Assert
            var view = Assert.IsType<ViewResult>(result);
            Assert.Same(vm, view.Model); // must return the same instance unchanged
        }
    }
}

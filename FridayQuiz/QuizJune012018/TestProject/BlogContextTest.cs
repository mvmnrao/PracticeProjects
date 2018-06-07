using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuizJune012018;

namespace TestProject
{
    [TestClass]
    public class BlogContextTest
    {
        [TestMethod]
        public void GetAllBlogsAsync_orders_by_name()
        {

            IQueryable<Blog> data = new List<Blog>  {
                new Blog { Name = "BBB" },
                new Blog { Name = "ZZZ" },
                new Blog { Name = "AAA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Blog>>();
            mockSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BloggingContext>();
            mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);

            var service = new BlogService(mockContext.Object);
            var blogs = service.GetAllBlogsAsync();  // Error Here

            Assert.AreEqual(3, blogs.Result.Count);
            Assert.AreEqual("AAA", blogs.Result[0].Name);
            Assert.AreEqual("BBB", blogs.Result[1].Name);
            Assert.AreEqual("ZZZ", blogs.Result[2].Name);
        }
    }
}

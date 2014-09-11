using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using QueryObjectMvc.Contexts;
using QueryObjectMvc.Interfaces;
using QueryObjectMvc.Models.QueryObjects;

namespace QueryObjectMvc.Tests
{
    [TestFixture]
    public static  class QueryTest
    {
        [Test]
        public static void AuthorByNameQueryTest()
        {
            const string CheckName = "sasha";



            var mockDb = new Mock<IStorage>();
            
            
            var authors = new List<Author>()
            {
                new Author()
                        {
                            NickName = CheckName
                        }
            };
            
            
            mockDb.SetupGet(a => a.Authors).Returns(authors.AsQueryable);

            
            

            var authorQuery = new AuthorByNickNameQuery(mockDb.Object, CheckName);

            var author=authorQuery.Execute();

            Assert.IsNotNull(author);
            Assert.AreEqual(author.NickName, CheckName);
        }
    }
}
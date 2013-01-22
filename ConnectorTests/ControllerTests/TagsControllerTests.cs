using System;
using Connector.Controllers;
using Connector.DependencyResolution;
using Connector.Services.Interfaces;
using Moq;
using MvcContrib.TestHelper;
using Raven.Client;
using Xunit;

namespace ConnectorTests.ControllerTests
{
    public class TagsControllerTests : IDisposable
    {
        private readonly TagsController controller;
        
        private readonly Mock<ITagService> mockTagservice;

        private readonly Mock<IDocumentSession> mockSession;

        public TagsControllerTests()
		{
            // TODO Register ONLY the types you need in your container for this suite of tests
            IoC.Initialize();

            this.mockSession = new Mock<IDocumentSession>();
            controller = new TagsController(this.mockTagservice.Object, mockSession.Object);
		}
        
        [Fact]
        public void CanRenderIndexView()
        {
            var result = controller.Index();

            result.AssertViewRendered().ForView(MVC.Tags.Views.Index);
        }

        public void Dispose()
        {
            controller.Dispose();
        }
    }
}
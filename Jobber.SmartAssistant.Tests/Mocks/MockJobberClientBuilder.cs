using System.Collections.Generic;
using Jobber.Sdk;
using Jobber.Sdk.Models.Clients;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Moq;

namespace Jobber.SmartAssistant.Tests.Mocks
{
    public class MockJobberClientBuilder
    {
        private readonly Mock<IJobberClient> _jobberClientMock;

        private MockJobberClientBuilder()
        {
            _jobberClientMock = new Mock<IJobberClient>();
        }

        public static MockJobberClientBuilder Create()
        {
            return new MockJobberClientBuilder();
        }

        public MockJobberClientBuilder ReturnsClients(IEnumerable<Client> clients)
        {
            _jobberClientMock
                .Setup(m => m.GetClientsAsync(It.IsAny<string>()))
                .ReturnsAsync(() => new ClientCollection
                {
                    Clients = clients
                });
            
            return this;
        }
        
        public Mock<IJobberClient> Build()
        {
            return _jobberClientMock;
        }
    }
}
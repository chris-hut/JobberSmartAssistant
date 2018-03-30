using System.Collections.Generic;
using System.Threading.Tasks;
using Jobber.Sdk;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Rest.Requests;
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
            _jobberClientMock.Setup(m => m.CreateJobAsync(It.IsAny<CreateJobRequest>()))
                .Returns(() => Task.CompletedTask);
            _jobberClientMock.Setup(m => m.UpdateQuoteAsync(It.IsAny<string>(), It.IsAny<Quote>()))
                .Returns(() => Task.CompletedTask);
        }

        public static MockJobberClientBuilder Create()
        {
            return new MockJobberClientBuilder();
        }

        public MockJobberClientBuilder ReturnsJobs(IEnumerable<Job> jobs)
        {
            _jobberClientMock
                .Setup(m => m.GetJobsAsync())
                .ReturnsAsync(() => new JobCollection
                {
                    Jobs = jobs
                });

            return this;
        }

        public MockJobberClientBuilder ReturnsQuotesAsync(IEnumerable<Quote> quotes)
        {
            _jobberClientMock
                .Setup(m => m.GetQuotesAsync())
                .ReturnsAsync(() => new QuotesCollection
                {
                    Quotes = quotes
                });

            return this;
        }
        
        public MockJobberClientBuilder ReturnsClients(IEnumerable<Client> clients, string clientQuery = "")
        {
            _jobberClientMock
                .Setup(m => m.GetClientsAsync(It.Is<string>(s => s == clientQuery)))
                .ReturnsAsync(() => new ClientCollection
                {
                    Clients = clients
                });
            
            return this;
        }

        public MockJobberClientBuilder ReturnsInvoices(IEnumerable<Invoice> invoices)
        {
            _jobberClientMock
                .Setup(m => m.GetInvoicesAsync())
                .ReturnsAsync(() => new InvoicesCollection
                {
                    Invoices = invoices
                });

            return this;
        }

        public MockJobberClientBuilder ReturnsTransactions(IEnumerable<Transaction> transactions)
        {
            _jobberClientMock
                .Setup(m => m.GetTransactionsAsync())
                .ReturnsAsync(() => new TransactionCollection
                {
                    Transactions = transactions
                });

            return this;
        }

        public MockJobberClientBuilder ReturnsRangedTransactions(IEnumerable<Transaction> transactions)
        {
            _jobberClientMock
                .Setup(m => m.GetRangedTransactionsAsync(It.IsAny<GetTransactionRequest>()))
                .ReturnsAsync(new TransactionCollection
                {
                    Transactions = transactions
                });

            return this;
        }

        public MockJobberClientBuilder ReturnsVisits(IEnumerable<Visit> visits)
        {
            _jobberClientMock
                .Setup(m => m.GetVisitsAsync())
                .ReturnsAsync(() => new VisitsCollections
                {
                    Visits = visits
                });

            return this;
        }
        
        public MockJobberClientBuilder ReturnsVisitsForToday(IEnumerable<Visit> visits)
        {
            _jobberClientMock
                .Setup(m => m.GetTodaysVisitsAsync())
                .ReturnsAsync(() => new VisitsCollections
                {
                    Visits = visits
                });

            return this;
        }
        
        public MockJobberClientBuilder ReturnsVisitsAssignedForToday(IEnumerable<Visit> visits, long userId)
        {
            _jobberClientMock
                .Setup(m => m.GetTodayAssignedVisitsAsync(It.Is<long>(l => l == userId), It.IsAny<long>()))
                .ReturnsAsync(() => new VisitsCollections
                {
                    Visits = visits
                });

            return this;
        }
        
        public Mock<IJobberClient> Build()
        {
            return _jobberClientMock;
        }
    }
}
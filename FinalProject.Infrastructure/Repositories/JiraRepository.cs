using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Repositories
{
    public class JiraRepository : IJiraRepository
    {
        private readonly HttpClient _httpClient;

        private readonly string _host;
        private readonly string _authorizationToken;
        private readonly string _projectId;
        private readonly string _roleId;
        public JiraRepository(IConfiguration configuration) 
        {
            _host = configuration.GetSection("Jira").GetSection("Host").Value;
            _authorizationToken = configuration.GetSection("Jira").GetSection("AuthorizationToken").Value;
            _projectId = configuration.GetSection("Jira").GetSection("ProjectId").Value;
            _roleId = configuration.GetSection("Jira").GetSection("RoleId").Value;

            _httpClient = new HttpClient();
            SetHeaders();
        }

        public async Task AddUserToRoleAsync(string userId)
        {
            var content = JsonContent.Create(new
            {
                User = new string[]
                {
                    userId
                }
            });

            using var response = await _httpClient.PostAsync(_host + "project/" + _projectId + "/role/" + _roleId, content);
        }

        public async Task CreateIssueAsync(string summary, string collection, string url, 
            string priority, string email, string userId)
        {
            var content = JsonContent.Create(new
            {
                Fields = new
                {
                    Project = new
                    {
                        Id = _projectId
                    },
                    Issuetype = new
                    {
                        Id = "10002"
                    },
                    Summary = summary,
                    Reporter = new
                    {
                        Id = userId
                    },
                    Customfield_10034 = collection,
                    Customfield_10035 = url,
                    Customfield_10036 = priority,
                }
            });

            using var response = await _httpClient.PostAsync(_host + "issue", content);
        }

        public async Task<string?> CreateUserAsync(string email)
        {
            var content = JsonContent.Create(new
            {
                EmailAddress = email,
                DisplayName = email,
                Products = Array.Empty<string>()
            });

            using var response = await _httpClient.PostAsync(_host + "user", content);

            var json = await response.Content.ReadFromJsonAsync<UserResponse>();

            return json!.AccountId;
        }

        public async Task<IssuesResponse> GetIssuesAsync(string accountId)
        {
            using var response = await _httpClient.GetAsync(_host + "search?jql=reporter=" + accountId);

            var json = await response.Content.ReadFromJsonAsync<IssuesResponse>();

            if (json is null)
                throw new ArgumentNullException(nameof(json));

            return json;
        }

        private void SetHeaders()
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(_authorizationToken)));
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        }
    }
}

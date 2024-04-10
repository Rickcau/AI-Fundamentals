using System.ComponentModel;
using System.Net.Http.Json;
using Microsoft.SemanticKernel;

namespace Console_SK_DeFi_Assistant.Plugins
{
    public class UniswapV3SubgraphPlugin
    {
        const string UniswapV3SubgraphEndpoint = "https://api.thegraph.com/subgraphs/name/uniswap/uniswap-v3";

        private readonly HttpClient _client = new();

        [KernelFunction]
        [Description("Queries the Uniswap V3 subgraph using GraphQL queries and returns the result in json format.")]
        public async Task<string> QueryAsync([Description("The GraphQL query")] string query)
        {
            HttpRequestMessage request = new(HttpMethod.Post, UniswapV3SubgraphEndpoint)
            {
                Content = JsonContent.Create(new { query = query })
            };

            var response = await _client.SendAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return result;
        }
    }
}

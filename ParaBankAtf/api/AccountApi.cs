using Newtonsoft.Json;
using ParaBankAtf.Models;
using RestSharp;

namespace ParaBankAtf.api
{ 
    public class AccountApi
    {
        private RestClient _restClient;
        List<int> newAccounts = new List<int>();

        public AccountApi()
        {
            _restClient = new RestClient("http://localhost:8080/parabank/services/bank/");
        }

        private List<int> CreateNewAccounts(int numberOfAccounts, int customerId, int baseAccountId)
        {
            var accounts = new List<int>();

            var newAccRequest = new RequestBuilder("createAccount")
                .SetMethod(Method.Post)
                .AddQueryParameter("customerId", customerId)
                .AddQueryParameter("newAccountType", 0)
                .AddQueryParameter("fromAccountId", baseAccountId)
                .Create();

            for (int i = 0; i < numberOfAccounts; i++)
            {
                var response = _restClient.Execute(newAccRequest);
                AccountModel createdAccount = JsonConvert.DeserializeObject<AccountModel>(response.Content);
                accounts.Add(createdAccount.id);
            }

            return accounts;
        }

        private void MakeTransfer(int fromAccountId, int toAccountId, int amount)
        {
            var transferRequest = new RequestBuilder("transfer")
                .SetMethod(Method.Post)
                .AddQueryParameter("fromAccountId", fromAccountId)
                .AddQueryParameter("toAccountId", toAccountId)
                .AddQueryParameter("amount", amount)
                .Create();

            _restClient.Execute(transferRequest);
        }

        public void PerpareFindTransactionsData()
        {
            newAccounts = CreateNewAccounts(2, 12212, 12345);
            MakeTransfer(newAccounts[0], newAccounts[1], 27);
        }
    }
}

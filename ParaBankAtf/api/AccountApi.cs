using Newtonsoft.Json;
using ParaBankAtf.Models;
using RestSharp;

namespace ParaBankAtf.api
{ 
    public class AccountApi
    {
        private RestClient restClient;

        public AccountApi()
        {
            restClient = new RestClient("http://localhost:8080/parabank/services/bank/");
        }

        public void PerpareFindTransactionsData()
        {
            int[] newAccounts = new int[2];

            // create 2 accounts
            var newAccRequest = new RequestBuilder("createAccount")
                .SetMethod(Method.Post)
                .AddQueryParameter("customerId", 12212)
                .AddQueryParameter("newAccountType", 0)
                .AddQueryParameter("fromAccountId", 12345)
                .Create();

            for (int i=0; i<2; i++)
            {
                var response = restClient.Execute(newAccRequest);
                AccountModel createdAccount = JsonConvert.DeserializeObject<AccountModel>(response.Content);
                newAccounts[i] = createdAccount.id;
            }

            // make transfer between accounts
            var transferRequest = new RequestBuilder("transfer")
                .SetMethod(Method.Post)
                .AddQueryParameter("fromAccountId", newAccounts[0])
                .AddQueryParameter("toAccountId", newAccounts[1])
                .AddQueryParameter("amount", 27)
                .Create();

            restClient.Execute(transferRequest);
        }
    }
}

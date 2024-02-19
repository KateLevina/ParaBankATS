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
            var newAccRequest = new RestRequest("/createAccount", Method.Post);
            newAccRequest.AddQueryParameter("customerId", 12212);
            newAccRequest.AddQueryParameter("newAccountType", 0);
            newAccRequest.AddQueryParameter("fromAccountId", 12345);
            for (int i=0; i<2; i++)
            {
                var response = restClient.Execute(newAccRequest);
                AccountModel createdAccount = JsonConvert.DeserializeObject<AccountModel>(response.Content);
                newAccounts[i] = createdAccount.id;
            }

            // make transfer between accounts
            var transferRequest = new RestRequest("/transfer", Method.Post);
            transferRequest.AddQueryParameter("fromAccountId", newAccounts[0]);
            transferRequest.AddQueryParameter("toAccountId", newAccounts[1]);
            transferRequest.AddQueryParameter("amount", 27);
            var resp = restClient.Execute(transferRequest);
        }
    }
}

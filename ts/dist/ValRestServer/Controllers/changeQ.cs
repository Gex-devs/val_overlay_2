﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ValRestServer.Controllers
{
    [ApiController]
    [Route("api/changeQ")]
    public class ChangeQController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ChangeQController()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(httpClientHandler);
        }

        [HttpGet]
        public async Task<ActionResult<string>> ChangeQ(string queue)
        {
            var partyId = RiotClientHelper.Instance.GetPartyId(1);
            var url = $"https://glz-eu-1.eu.a.pvp.net/parties/v1/parties/{partyId}/queue";

            var payload = new
            {
                queueID = queue
            };

            var jsonPayload = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-Riot-Entitlements-JWT", RiotClientHelper.Instance.GetEntitlement());
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {RiotClientHelper.Instance.GetAuthorization()}");

            var response = await _httpClient.PostAsync(url, jsonPayload);

            return response.StatusCode.ToString();
        }
    }
}

using CrudClientApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrudClientApplication.Controllers
{
    
    public class CustomerController : Controller
    {
        private readonly HttpClientHandler _clientHandler = new HttpClientHandler();
        public CustomerController() 
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            GetAllCustResponse Customer = new GetAllCustResponse();
            using (var httpclient=new HttpClient(_clientHandler))
            {
                httpclient.DefaultRequestHeaders.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpclient.GetAsync("https://localhost:44301/api/Customer/get-all-customer");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent=await response?.Content?.ReadAsStringAsync();
                    var responseList = JsonConvert.DeserializeObject<GetAllCustResponse>(responseContent);

                    //List<CustomerModel> responseList = JsonConvert.DeserializeObject<GetAllCustResponse>/*(responseContent)?.CustomerList;*/
                    Customer = responseList;  
                }
            }

            return View(Customer);
        }

        [HttpGet]
        [ActionName("Get-cust-ById")]
        public async Task<IActionResult> GetCustById()
        {

            GetCustByIdCustResponse customer = new GetCustByIdCustResponse();
            using (var httpclient = new HttpClient(_clientHandler))
            {
                httpclient.DefaultRequestHeaders.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpclient.GetAsync("https://localhost:44301/api/Customer/get-cust-ById");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response?.Content?.ReadAsStringAsync();
                    var responseList = JsonConvert.DeserializeObject<GetAllCustResponse>(responseContent);
                }
            }

            return Json(new { status = false });
        }


        [HttpGet]
        [ActionName("Create-customer")]
        public IActionResult CreateCust()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Create-customer")]
        public async Task<IActionResult> CreateCust(CreateCustRequest request)
        {
            CreateCustResponse customer = new CreateCustResponse();
            using (var httpclient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                httpclient.DefaultRequestHeaders.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpclient.PostAsync("https://localhost:44301/api/Customer/Create-customer",content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        [HttpGet]
        [ActionName("Update-customer")]
        public IActionResult UpdateCust()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Update-customer")]
        public async Task <IActionResult> UpdateCust(UpdateCustRequest request)
        {
            
            using (var httpclient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                httpclient.DefaultRequestHeaders.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpclient.PostAsync("https://localhost:44301/api/Customer/Update-customer", content);
                if(response.IsSuccessStatusCode) 
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
           
        }

        [HttpGet]
        [ActionName("Delete-customer")]
        public async Task<IActionResult>DeleteCust(int id)
        {
            CustomerModel request = new CustomerModel();
            using (var httpclient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                httpclient.DefaultRequestHeaders.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpclient.PostAsync("https://localhost:44301/api/Customer/Delete-customer?id="+id, content);
            }
            return View();
        }


        [HttpGet]
        [ActionName("Get-joinlist")]
        public async Task<ActionResult> Getjoinlist()
        {

            GetjoinlistResponse Customer = new GetjoinlistResponse();
            using (var httpclient = new HttpClient(_clientHandler))
            {
                httpclient.DefaultRequestHeaders.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpclient.GetAsync("https://localhost:44301/api/Customer/get-joinlist");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response?.Content?.ReadAsStringAsync();
                    var responseList = JsonConvert.DeserializeObject<GetjoinlistResponse>(responseContent);

                    Customer = responseList;
                }
            }
            return View(Customer);
        }
    }
}

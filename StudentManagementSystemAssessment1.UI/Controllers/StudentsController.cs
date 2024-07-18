using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemAssessment1.UI.Models;
using StudentManagementSystemAssessment1.UI.Models.DTO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace StudentManagementSystemAssessment1.UI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public StudentsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<StudentDto> response = new List<StudentDto>();
            //Get all Students from Web API
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7100/api/Student");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<StudentDto>>());

                
            }
            catch (Exception ex)
            {
                //Log the exception
                
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StudentDto model)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpRequestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7100/api/Student"),
                    Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
                };
                var httpResponseMessage = await client.SendAsync(httpRequestMessage);
                //httpResponseMessage.EnsureSuccessStatusCode();

                //var httpResponseMessage = await client.PostAsync("https://localhost:7100/api/Student", new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json"));

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();
                    if (response is not null)
                    {
                        return RedirectToAction("Index", "Students");
                    }
                }
                else
                {
                    var errorResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                }

                /*var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();
                if (response is not null)
                {
                    return RedirectToAction("Index", "Students");
                }*/
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            
            
            var client = httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<StudentDto>($"https://localhost:7100/api/Student/{id.ToString()}");

            if(response is not null)
            {
                return View(response);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentDto request)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7100/api/Student/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            //httpResponseMessage.EnsureSuccessStatusCode();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();
                if (response is not null)
                {
                    return RedirectToAction("Edit", "Students");
                }
            }
            else
            {
                var errorResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            }

            /*var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();

            if(response is not null)
            {
                return RedirectToAction("Edit", "Students");
            }*/

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7100/api/Student/{id}");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var response = await httpResponseMessage.Content.ReadFromJsonAsync<StudentDto>();
                    if (response is not null)
                    {
                        return RedirectToAction("Index", "Students");
                    }
                }
                else
                {
                    var errorResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                }

                //httpResponseMessage.EnsureSuccessStatusCode();

                //return RedirectToAction("Index", "Students");
            }
            catch (Exception ex)
            {

                //
            }
            
            
            return View("Delete");
        }


    }

}

using Microsoft.AspNetCore.Mvc.RazorPages;
using AnagraficaMedica.Frontend.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnagraficaMedica.Frontend.Pages
{
    public class PatientModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public PatientModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Patient> Patients { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:5001/api/patients");
            if (response.IsSuccessStatusCode)
            {
                Patients = await response.Content.ReadFromJsonAsync<List<Patient>>() ?? new List<Patient>();
            }
        }
    }
}
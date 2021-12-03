using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using UTS.Models;
using System.Text.Json;
using System;

namespace UTS.Services
{
    public class EmployeeServiceCard : IEmployeeServiceCard
    {
        private HttpClient _httpClient;
        public EmployeeServiceCard(HttpClient httpClient)
        {
              _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var results = await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("/api/Employees");
            return results;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Employee>($"/api/Employees/{id}");
            return result;
        }

        public async Task<Employee> Add(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/Employees",employee);
            if(response.IsSuccessStatusCode){
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }else{
                throw new Exception("gagal Tambah Data Employee");
            }
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Employees/{id}",employee);
            if(response.IsSuccessStatusCode){
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }else{
                throw new Exception("gagal Update Employee");
            }
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
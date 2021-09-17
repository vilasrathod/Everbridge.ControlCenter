using Everbridge.ControlCenter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Everbridge.ControlCenter.DoorControl.Services
{
    internal class DoorControlService : IDoorControlService
    {
        private string _serverUrl = "https://localhost:5001/api/door/";
        private static readonly HttpClient client = new HttpClient();
        public DoorControlService()
        {

        }
        public async void AddDoor(DoorRecord door)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(door);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_serverUrl, content);  // Blocking call!                
            }
            catch (Exception)
            {
                //TO-DO
            }            
        }

        public DoorRecord GetDoor(string doorId)
        {
            DoorRecord door = null;
            try
            {
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(_serverUrl + doorId).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    door = JsonConvert.DeserializeObject<DoorRecord>(res);
                }
            }
            catch (Exception)
            {
                //TO-DO
            }

            return door;
        }

        public IEnumerable<DoorRecord> GetDoorRecords()
        {
            IEnumerable<DoorRecord> doors = null;

            try
            {
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // List all Names.
                HttpResponseMessage response = client.GetAsync(_serverUrl).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    doors = JsonConvert.DeserializeObject<IEnumerable<DoorRecord>>(data);
                }
            }
            catch (Exception)
            {
                //TO-DO
            }

            return doors;
        }

        public bool RemoveDoor(string id)
        {
            bool status = false;
            try
            {
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = client.DeleteAsync(_serverUrl+ id).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                //TO-DO
            }

            return status;
        }

        public async void UpdateDoor(DoorRecord door)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(door);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(_serverUrl, content);  // Blocking call!                
            }
            catch (Exception)
            {
                //TO-DO
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace XamarinApiRestfull.Service
{
    public class ApiService
    {
        HttpClient client = new HttpClient();

        //POST
        public async Task<string> Login(string username, string password)
        {
            try
            {               

                var values = new Dictionary<string, string>();
                values.Add("username", username);
                values.Add("password", password);


                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("YOUR_URL_HERE", content);

                var responseString = response.Content.ReadAsStringAsync().Result;

                //you can manipulate your response here using statusCode
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return responseString;

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("User not authorized");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new Exception("User not found");



                throw new Exception(responseString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //PUT
        public async Task<string> PutUser(string username, string password, string id)
        {
            try
            {

                var values = new Dictionary<string, string>();
                values.Add("username", username);
                values.Add("password", password);
                values.Add("id", id);



                var content = new FormUrlEncodedContent(values);
                var response = await client.PutAsync("YOUR_URL_HERE", content);

                var responseString = response.Content.ReadAsStringAsync().Result;

                //you can manipulate your response here using statusCode
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return responseString;

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("User not authorized");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new Exception("User not found");



                throw new Exception(responseString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //GET
        public async Task<string> GetDashboard()
        {
            try
            {

                string uri = "YOUR_URL_HERE";

                var response = await client.GetAsync(uri);

                var responseString = response.Content.ReadAsStringAsync().Result;

                //ofc you can use a base class to manipulate your responses, its only an example.
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return responseString;

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("User not authorized");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new Exception("Request not found");

                //....


                throw new Exception(responseString);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //How to send an image
        public async Task<string> UploadImage(Stream imageStream)
        {
            try
            {

                StreamContent scontent = new StreamContent(imageStream);
                scontent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    FileName = "imagem",
                    Name = "imagem"
                };
                scontent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                var client = new HttpClient();
                var multi = new MultipartFormDataContent();
                multi.Add(scontent);                

                var result = await client.PostAsync("YOUR_URL_HERE", multi);
                var response = result.Content.ReadAsStringAsync().Result;                

                if(result.StatusCode == System.Net.HttpStatusCode.OK)
                    return response;

                throw new Exception("An error ocurred: " + response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
    }
}

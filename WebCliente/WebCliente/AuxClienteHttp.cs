﻿using System.Net.Http.Headers;

namespace WebCliente
{
    public class AuxClienteHttp
    {
        public static string ObtenerBody(string verbo, string url, object obj, string token, out bool exito)
        {
            HttpClient cliente = new HttpClient();

            if (token != null)
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Task<HttpResponseMessage> response = null;

            switch (verbo)
            {
                case "get":
                    response = cliente.GetAsync(url);
                    response.Wait();
                    break;

                case "post":
                    response = cliente.PostAsJsonAsync(url, obj);
                    response.Wait();
                    break;

                case "put":
                    response = cliente.PutAsJsonAsync(url, obj);
                    response.Wait();
                    break;
            }

            exito = response.Result.IsSuccessStatusCode;
            Task<string> body = response.Result.Content.ReadAsStringAsync();
            body.Wait();
            return body.Result;
        }
    }
}

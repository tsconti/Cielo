﻿using RestSharp;
using Cielo.Requests;

namespace Cielo
{
    public class CieloService : ICieloService
    {
        private readonly string _endPointUrl;

        public CieloService(string endPointUrl)
        {
            _endPointUrl = endPointUrl;
        }

        public IRestResponse Execute(ICieloRequest cieloRequest)
        {
            var client = new RestClient(_endPointUrl);
            var request = new RestRequest(Method.POST);
            request.AddParameter("mensagem", cieloRequest.ToXml(false));
            return client.Execute(request);
        }
    }
}
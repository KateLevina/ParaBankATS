﻿using RestSharp;

namespace ParaBankAtf.api.Interfaces
{
    public interface IRequestBuilder
    {
        int HeaderCount { get; }

        IRequestBuilder AddCookie(string name, string value);

        IRequestBuilder AddHeader(string name, string value);

        IRequestBuilder AddHeaders(Dictionary<string, string> headers);

        IRequestBuilder SetTimeout(int timeout);

        IRequestBuilder SetMethod(Method method);

        IRequestBuilder AddParameter(Parameter parameter);

        IRequestBuilder AddQueryParameter(string name, object value);

        IRequestBuilder AddParameters(Parameter[] parameters);

        IRequestBuilder RemoveHeaders();

        IRequestBuilder RemoveHeader(string name);

        IRequestBuilder RemoveCookies();

        IRequestBuilder RemoveParameters();

        IRequestBuilder RemoveParameter(Parameter parameter);

        IRequestBuilder SetFormat(DataFormat dataFormat);

        IRequestBuilder AddBody(object body);

        IRequestBuilder AddFile(string name, string path, string contentType = null);

        RestRequest Create();
    }
}

using System;
using System.Web;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Configuration;
using System.Net.Http;

namespace Restaurant.Web.WebAPI
{
    public class WebAPIWrapper
    {
        private static readonly string WebAPIURL = ConfigurationManager.AppSettings["WebAPIURL"] + "/api/";

        /// <summary>
        /// Description: Method to call the Web API with Web API Name and parameters sent sent in a single Parameter.
        /// </summary>
        /// <typeparam name="TModelObject">TModelObject Represents a Strongly Typed object which will be Serialized from the JASON data returened from Web API.</typeparam>
        /// <param name="apiMethodNameWithParams">apiMethodNameWithParams will contain WebAPI Name and Parameters used to call the corresponding Web API.</param>
        /// <returns>Returns a Strongly Typed Object of the T Class specified during the Method call.</returns>
        public static ModelObjectWrapper<TModelObject> ExecuteWebAPIMethod<TModelObject>(string apiMethodNameWithParams)
        {
            return CallWebAPIMethod<TModelObject>(apiMethodNameWithParams);
        }

        /// <summary>
        /// Description: Method to call the Web API with Web API Name and parameters sent which will be Encoded for use cases where the parameters have special characters.
        /// </summary>
        /// <typeparam name="TModelObject">TModelObject Represents a Strongly Typed object which will be Serialized from the JASON data returened from Web API.</typeparam>
        /// <param name="apiMethodName">apiMethodName will contain only the Web API Name and Method to be processed.</param>
        /// <param name="methodParams">Params which has special characters which needs to be encoded to be sent to the Web API.</param>
        /// <returns></returns>
        public static ModelObjectWrapper<TModelObject> ExecuteWebAPIMethod<TModelObject>(string apiMethodName, params string[] methodParams)
        {
            if (methodParams == null) return ExecuteWebAPIMethod<TModelObject>(apiMethodName);
            string apiMethodNameWithParams = apiMethodName;

            for (int i = 0; i < methodParams.Length; i++)
            {
                if (i == 0) apiMethodNameWithParams += "?" + EncodeOnlyParamValue(methodParams[i]);
                else apiMethodNameWithParams += "&" + EncodeOnlyParamValue(methodParams[i]);
            }
            return CallWebAPIMethod<TModelObject>(apiMethodNameWithParams);
        }


        /// <summary>
        /// Description: Method to call the Web API with Web API Name and parameters along with the Strongly Typed object which is searialized to a JASON object.
        /// </summary>
        /// <typeparam name="TModelObject">TModelObject Represents a Strongly Typed object which will be Serialized from the JASON data returened from Web API.</typeparam>
        /// <typeparam name="TParamsObject">TParamsObject Represents a Strongly Typed object Param which will be Serialized to JASON/XML format to be transported to the Web API call.</typeparam>
        /// <param name="apiMethodNameWithParams">apiMethodNameWithParams will contain WebAPI Name and Parameters used to call the corresponding Web API.</param>
        /// <param name="Params">TParamsObject Represents a Strongly Typed object Param which will be Serialized to JASON/XML format to be transported to the Web API call.</param>
        /// <param name="asnycDataFormat">Serialization Data Format. Use XML Data format, only if the Text is too-heavy. For all other uses cases Use JASON as JASON Serialization is faster.</param>
        /// <returns></returns>
        public static ModelObjectWrapper<TModelObject> ExecuteWebAPIMethod<TModelObject, TParamsObject>
            (string apiMethodNameWithParams, TParamsObject Params, AsyncPostDataFormat asnycDataFormat)
            where TParamsObject : class
        {
            return CallWebAPIMethod<TModelObject, TParamsObject>(apiMethodNameWithParams, Params, asnycDataFormat);
        }

        /// <summary>
        /// Description: Method to call the Web API with Web API Name and parameters along with the Strongly Typed object and Parameters which needs to be Encoded.
        /// </summary>
        /// <typeparam name="TModelObject">TModelObject Represents a Strongly Typed object which will be Serialized from the JASON data returened from Web API.</typeparam>
        /// <typeparam name="TParamsObject">TParamsObject Represents a Strongly Typed object Param which will be Serialized to JASON/XML format to be transported to the Web API call.</typeparam>
        /// <param name="apiMethodName">apiMethodName will contain only the Web API Name and Method to be processed.</param>
        /// <param name="Params">TParamsObject Represents a Strongly Typed object Param which will be Serialized to JASON/XML format to be transported to the Web API call.</param>
        /// <param name="asnycDataFormat">Serialization Data Format. Use XML Data format, only if the Text is too-heavy. For all other uses cases Use JASON as JASON Serialization is faster.</param>
        /// <param name="methodParams">Params which has special characters which needs to be encoded to be sent to the Web API.</param>
        /// <returns></returns>
        public static ModelObjectWrapper<TModelObject> ExecuteWebAPIMethod<TModelObject, TParamsObject>
            (string apiMethodName, TParamsObject Params, AsyncPostDataFormat asnycDataFormat,
             params string[] methodParams)
            where TParamsObject : class
        {
            if (methodParams == null)
                return ExecuteWebAPIMethod<TModelObject, TParamsObject>(apiMethodName, Params, asnycDataFormat);
            string apiMethodNameWithParams = apiMethodName;
            for (int i = 0; i < methodParams.Length; i++)
            {
                if (i == 0) apiMethodNameWithParams += "?" + EncodeOnlyParamValue(methodParams[i]);
                else apiMethodNameWithParams += "&" + EncodeOnlyParamValue(methodParams[i]);
            }
            return CallWebAPIMethod<TModelObject, TParamsObject>(apiMethodNameWithParams, Params, asnycDataFormat);
        }

        public static ModelObjectWrapper<TModelObject> PostWebAPI<TModelObject>(string apiMethodNameWithParams, AsyncPostDataFormat asnycDataFormat)
        {
            return PostWebAPIMethod<TModelObject>(apiMethodNameWithParams, asnycDataFormat);
        }

        private static string EncodeOnlyParamValue(string parameterString)
        {
            string encodedParameterString = parameterString;
            var arEncodedString = encodedParameterString.Split('=');
            if (arEncodedString.Length > 1)
            {
                encodedParameterString = string.Format
                    ("{0}={1}", arEncodedString[0],
                     HttpUtility.UrlEncode(arEncodedString[1]));
            }
            return encodedParameterString;
        }

        private static ModelObjectWrapper<TModelObject> PostWebAPIMethod<TModelObject>(string apiMethodNameWithParams, AsyncPostDataFormat asnycDataFormat)
        {
            var httpClient = new HttpClient();
            if (WebAPIURL.ToLower().StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
                httpClient.DefaultRequestHeaders.Add("authorization-token", SSLCertificateToken.SSLToken);
            }
            HttpResponseMessage httpResponse;
            if (asnycDataFormat == AsyncPostDataFormat.XML)
            {
                httpResponse = httpClient.PostAsXmlAsync(WebAPIURL + apiMethodNameWithParams, CancellationToken.None).Result;
            }
            else
            {
                httpResponse = httpClient.PostAsJsonAsync(WebAPIURL + apiMethodNameWithParams, CancellationToken.None).Result;
            }
            if (httpResponse != null && httpResponse.IsSuccessStatusCode)
            {
                return new ModelObjectWrapper<TModelObject>
                {
                    ModelObject =
                        httpResponse.Content.ReadAsAsync<TModelObject>().
                        Result
                };
            }
            throw new NullReferenceException(string.Format("Model Object could not be de-serialized. Method Call for:" + apiMethodNameWithParams));
        }

        private static ModelObjectWrapper<TModelObject> CallWebAPIMethod<TModelObject, TParamsObject>
            (string apiMethodNameWithParams, TParamsObject Params, AsyncPostDataFormat asnycDataFormat)
            where TParamsObject : class
        {
            var httpClient = new HttpClient();
            if (WebAPIURL.ToLower().StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
                httpClient.DefaultRequestHeaders.Add("authorization-token", SSLCertificateToken.SSLToken);
            }
            HttpResponseMessage httpResponse;
            if (asnycDataFormat == AsyncPostDataFormat.XML)
            {
                httpResponse = httpClient.PostAsXmlAsync(WebAPIURL + apiMethodNameWithParams, Params, CancellationToken.None).Result;
            }
            else
            {
                httpResponse = httpClient.PostAsJsonAsync(WebAPIURL + apiMethodNameWithParams, Params, CancellationToken.None).Result;
            }
            if (httpResponse != null && httpResponse.IsSuccessStatusCode)
            {
                return new ModelObjectWrapper<TModelObject>
                {
                    ModelObject =
                        httpResponse.Content.ReadAsAsync<TModelObject>().
                        Result
                };
            }
            throw new NullReferenceException
                (
                string.Format("Model Object could not be deserialized. Method Call for:" + apiMethodNameWithParams));
        }

        private static ModelObjectWrapper<TModelObject> CallWebAPIMethod<TModelObject>(string apiMethodNameWithParams)
        {
            var httpClient = new HttpClient();

            if (WebAPIURL.ToLower().StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
                httpClient.DefaultRequestHeaders.Add("authorization-token", SSLCertificateToken.SSLToken);
            }

            var httpResponse = httpClient.GetAsync(WebAPIURL + apiMethodNameWithParams).Result;
            
            if (httpResponse.IsSuccessStatusCode)
            {
                return new ModelObjectWrapper<TModelObject>
                {
                    ModelObject = httpResponse.Content.ReadAsAsync<TModelObject>().Result
                };
            }

            return null;

            //throw new NullReferenceException(string.Format("Model Object could not be deserialized. Method Call for:" + apiMethodNameWithParams));
        }

        private static bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }

    public class ModelObjectWrapper<T> : IDisposable
    {
        private bool _bIsDisposable = false;
        protected T _modelObject;

        public T ModelObject
        {
            get { return _modelObject; }
            set { _modelObject = value; }
        }

        public void Dispose()
        {
            if (!_bIsDisposable)
            {
                try
                {
                    (_modelObject as IDisposable).Dispose();
                }
                catch
                {
                }
            }
        }
    }

    public enum AsyncPostDataFormat
    {
        XML,
        JASON
    }

    public class SSLCertificateToken
    {
        private static string _sSSLSecurityToken = null;

        public static string SSLToken
        {
            get
            {
                if (_sSSLSecurityToken == null)
                {
                    _sSSLSecurityToken = GetServerCertificate();
                }
                return _sSSLSecurityToken;
            }
        }

        private static string GetServerCertificate()
        {
            X509Store certificateStore = new X509Store(StoreLocation.LocalMachine);
            certificateStore.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection portalServerCertificate = certificateStore.Certificates.Find(X509FindType.FindBySubjectName, "SSLKey", false);
            if (portalServerCertificate.Count == 0)
            {
                certificateStore.Close();
                return null;
            }
            else
            {
                certificateStore.Close();
                return portalServerCertificate[0].GetCertHashString();
            }
        }
    }
}
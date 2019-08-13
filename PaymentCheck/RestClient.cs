﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PaymentCheckService
{
    public class RestClient
    {

        public enum httpVerb
        {
            GET,
            POST,
            PUT,
            DELETE

        }

        public string endpoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient()
        {
            endpoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);

            request.Method = httpMethod.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + response.StatusCode.ToString());
                }
                //Process the response stream... (should be JSON)
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }//end of using StreamReader
                    }
                }//End of using ResponseStream

            }//End of using response


            return strResponseValue;
        }

        //}

    }
}

﻿using System.Text;
using Titanium.Web.Proxy.Http;
using Titanium.Web.Proxy.Shared;

namespace Titanium.Web.Proxy.Extensions
{
    public static class HttpWebResponseExtensions
    {
        public static Encoding GetResponseCharacterEncoding(this Response response)
        {
            try
            {
                //return default if not specified
                if (response.ContentType == null)
                    return Encoding.GetEncoding("ISO-8859-1");

                //extract the encoding by finding the charset
                var contentTypes = response.ContentType.Split(Constants.SemiColonSplit);
                foreach (var contentType in contentTypes)
                {
                    var encodingSplit = contentType.Split('=');
                    if (encodingSplit.Length == 2 && encodingSplit[0].ToLower().Trim() == "charset")
                    {
                        return Encoding.GetEncoding(encodingSplit[1]);
                    }
                }
            }
            catch
            {
                //parsing errors
                // ignored
            }

            //return default if not specified
            return Encoding.GetEncoding("ISO-8859-1");
        }
    }
}
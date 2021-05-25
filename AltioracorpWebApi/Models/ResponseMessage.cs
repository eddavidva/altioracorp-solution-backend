using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltioracorpWebApi.Models
{
    public class ResponseMessage
    {
        public ResponseMessage() { }
        public object OkMessage(string message, object data)
        {
            return new
            {
                status = 200,
                statusTex = "success",
                message,
                data
            };

        }

        public object BadMessage(string message)
        {
            return new
            {
                status = 400,
                statusTex = "error",
                message
            };

        }

        public object ErrorMessage(string message, object error)
        {
            return new
            {
                status = 500,
                statusTex = "error",
                message,
                error
            };

        }
    }
}
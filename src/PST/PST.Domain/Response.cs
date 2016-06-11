//  ==============================================================
//   Copyright (c) 上海梓迅信息技术有限公司. All rights reserved.   
//  
//   File: Response.cs
//   Author: Eric Gohn
//   Email: eric.gohn@outlook.com
//     
//  ==============================================================

using System.Runtime.Serialization;

namespace PST.Domain
{
    /// <summary>
    ///     WCF返回对象。
    /// </summary>
    [DataContract]
    public class Response
    {
        private static readonly Response _invalidOperationResponse = new Response(false, "非法调用，请检查您的调用参数");

        public Response()
        {
        }

        protected Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string Message { get; set; }

        public static Response Succeed()
        {
            return new Response(true, string.Empty);
        }

        public static Response Failed(string message)
        {
            return new Response(false, message);
        }

        /// <summary>
        ///     创建一个非法调用的<see cref="Response" />
        /// </summary>
        /// <returns></returns>
        public static Response InvalidOperation()
        {
            return _invalidOperationResponse;
        }
    }

    /// <summary>
    ///     WCF返回对象。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class Response<T> : Response
    {
        private static readonly Response<T> _invalidOperationResponse = new Response<T>(false, "非法调用，请检查您的调用参数");

        public Response()
        {
        }

        protected Response(bool success, string message) : base(success, message)
        {
        }

        protected Response(bool success, string message, T arg)
            : base(success, message)
        {
            Arg = arg;
        }

        [DataMember]
        public T Arg { get; set; }

        /// <summary>
        ///     创建一个成功的<see cref="Response"></see>对象。
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static Response<T> Succeed(T arg)
        {
            return new Response<T>(true, string.Empty, arg);
        }

        /// <summary>
        ///     创建一个失败的<see cref="Response"></see>对象。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public new static Response<T> Failed(string message)
        {
            var result = new Response<T>
            {
                Success = false,
                Message = message
            };
            return result;
        }

        /// <summary>
        ///     创建一个非法调用的<see cref="Response" />
        /// </summary>
        /// <returns></returns>
        public new static Response<T> InvalidOperation()
        {
            return _invalidOperationResponse;
        }
    }
}
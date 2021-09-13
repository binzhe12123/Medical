using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// JWT泛型类,实现JWT的加密和解密
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class JWTHelper<T>
    {


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="entity">需要加密的对象</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static string Encrypt(T entity,string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new Exception("秘钥为空");
            }
            //secret需要加密
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            string token = encoder.Encode(entity, key);
            return token;
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="token">需解密的token串</param>
        /// <param name="key">秘钥</param>
        /// <returns></returns>
        public static T Decrypt(string token,string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("秘钥为空");
            }
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("token为空");
            }
            //secret需要加密
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
            T json = decoder.DecodeToObject<T>(token, key, verify: true);
            return json;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MyBlog.Models.Services
{
    public class PasswordHash
    {
        public static string CreateSalt(int size)
        {
            var cryptoServiceProvider = new RNGCryptoServiceProvider();
            var buffer = new byte[size];

            cryptoServiceProvider.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }

        public static byte[] GetByteArray(string inputString)
        {
            return Encoding.UTF8.GetBytes(inputString);
        }

        public static string GetPasswordHashAndSalt(string message)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = GetByteArray(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            return GetString(resultBytes);
        }

        private static string GetString(byte[] resultBytes)
        {
            return Convert.ToBase64String(resultBytes);
        }
    }
}
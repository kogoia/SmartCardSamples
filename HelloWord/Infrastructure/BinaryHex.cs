﻿using System;
using System.Linq;

namespace HelloWord.Infrastructure
{
    public class BinaryHex : IBinary
    {
        private readonly string _str;
        public BinaryHex(string str)
        {
            this._str = str;
        }

        public byte[] Bytes()
        {
            return Enumerable.Range(0, this._str.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(this._str.Substring(x, 2), 16))
                    .ToArray();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.Cryptography
{
    public class KSeed : IBinary
    {
        private readonly IBinary _hash;
        public KSeed(IBinary hash)
        {
            this._hash = hash;
        }
        public byte[] Binary()
        {
            return this._hash
                .Binary()
                .Take(16)
                .ToArray();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class D : IBinary
    {
        private readonly IBinary _kSeed;
        private readonly byte[] _c;
        //TODO: Delete this constructor and refactor
        public D(IBinary kSeed, string c) : this(kSeed, new BinaryHex(c).Bytes()) { }
        public D(IBinary kSeed, byte[] c)
        {
            this._kSeed = kSeed;
            this._c = c;
        }

        public byte[] Bytes()
        {
            return this._kSeed
                .Bytes()
                .Concat(this._c)
                .ToArray();
        }
    }
}

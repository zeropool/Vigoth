#region Copyright
/*
* Copyright Onix Solutions Limited [OnixS]. All rights reserved.
*
* This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
* and international copyright treaties.
*
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting
* a non-assignable, non-transferable and non-exclusive license to use the software
* for it's own data processing purposes under the terms defined in the Agreement.
*
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited.
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with
* the terms of the Agreement is a violation of copyright law.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using FIXForge.NET.FIX;

namespace Benchmark
{
    namespace Latency
    {
        struct SessionTimeMarks
        {
            public long SendStart;
            public long SendFinish;
            public long RecvStart;
            public long RecvFinish;

            public long SendSpan
            {
                get
                {
                    return (SendFinish - SendStart);
                }
            }

            public long RecvSpan
            {
                get
                {
                    return (RecvFinish - RecvStart);
                }
            }

            public long RoundtripSpan
            {
                get
                {
                    return (RecvFinish - SendStart);
                }
            }
        }
    }
}
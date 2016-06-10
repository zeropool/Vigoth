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
using System.Text;
using FIXForge.NET.FIX;

namespace FastEncodingAndDecoding
{
    using FIXForge.NET.FIX.FAST;

    class Program
    {
        static void Main()
        {
            try
            {
                EngineSettings settings = new EngineSettings();
                settings.ListenPort = -1;

                Engine.Init(settings);

                EncodeAndDecode();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }

        static void EncodeAndDecode()
        {
            string xmlFastTemplate = System.IO.File.ReadAllText("UdpFastTemplate.xml");

            // Dialect-independent mode

            const bool encodeEachMessageIndependently = true;
            Encoder encoder = new Encoder(ProtocolVersion.FIX44, xmlFastTemplate, encodeEachMessageIndependently);

            const bool decodeEachMessageIndependently = true;
            Decoder decoder = new Decoder(ProtocolVersion.FIX44, xmlFastTemplate, decodeEachMessageIndependently, InputDataTraits.CompleteMessagesOnly);

            byte[] fileContents = System.IO.File.ReadAllBytes("MarketDataIncrementalRefresh.fix");

            Message sourceFixMessage = Message.Parse(fileContents, encoder.Dialect);
            sourceFixMessage.Validate();

            const int fastTemplateID = 36;
            byte[] fastStreamChunk = encoder.Encode(sourceFixMessage, fastTemplateID);

            Console.WriteLine("\nEncoded FAST stream chunk: (" + fastStreamChunk.Length + " bytes) \n'"
                                + BitConverter.ToString(fastStreamChunk) + "'\n");

            Console.WriteLine("Source FIX message: (" + sourceFixMessage.ToString().Length + " bytes)\n" + sourceFixMessage);

            Message decodedMessage = decoder.Decode(fastStreamChunk);
            Console.WriteLine("\nDecoded FIX message: (" + sourceFixMessage.ToString().Length + " bytes)\n" + decodedMessage);
            decodedMessage.Validate();
        }
    }
}

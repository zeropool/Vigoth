' Copyright Onix Solutions Limited [OnixS]. All rights reserved.
'
' This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
' and international copyright treaties.
'
' Access to and use of the software is governed by the terms of the applicable ONIXS Software
' Services Agreement (the Agreement) and Customer end user license agreements granting
' a non-assignable, non-transferable and non-exclusive license to use the software
' for it's own data processing purposes under the terms defined in the Agreement.
'
' Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
' of this source code or associated reference material to any other location for further reproduction
' or redistribution, and any amendments to this copyright notice, are expressly prohibited.
'
' Any reproduction or redistribution for sale or hiring of the Software not in accordance with
' the terms of the Agreement is a violation of copyright law.

Imports System
Imports FIXForge.NET.FIX
Imports FF = FIXForge.NET.FIX
Imports FIXForge.NET.FIX.FIX44
Imports Helpers

'/ <summary>
'/ Establishes FIX session-initiator.
'/ </summary>

Class Initiator

    Sub OnInboundApplicationMsg(ByVal sender As [Object], ByVal e As InboundApplicationMsgEventArgs)
        Console.WriteLine(("Incoming application-level message:" + ControlChars.Lf + e.Msg.ToString()))
        ' Processing of the application-level incoming message ... 
    End Sub 'OnInboundApplicationMsg


    Sub Run()
        Try
            Dim fixEngine As Engine = Engine.Init()

            Dim sn As New Session(Settings.Get("SenderCompID"), Settings.Get("TargetCompID"), Settings.GetVersion())

            AddHandler sn.InboundApplicationMsgEvent, AddressOf OnInboundApplicationMsg
            AddHandler sn.StateChangeEvent, AddressOf OnStateChange

            sn.LogonAsInitiator(Settings.Get("Counterparty Host"), Int32.Parse(Settings.Get("Counterparty Port")), True)

            Console.WriteLine("Press any key to send an order.")
            Console.ReadKey()

            Dim order As New Message(MsgType.NewOrderSingle, Settings.GetVersion())
            order.Set(Tags.HandlInst, HandlInst.AutoExecPriv)
            order.Set(Tags.ClOrdID, "Unique identifier for Order")
            order.Set(Tags.Symbol, "IBM")
            order.Set(Tags.Side, Side.Sell)
            order.Set(Tags.OrderQty, 1000)
            order.Set(Tags.OrdType, "1")
            order.Set(Tags.TransactTime, DateTime.UtcNow.ToString("yyyyMMdd-HH:mm:ss"))

            order.Validate()

            sn.Send(order)

            Console.WriteLine("The order (" + order.ToString() + ") was sent")

            Console.WriteLine("Press any key to disconnect the sesssion and terminate the application.")
            Console.ReadKey()

            sn.Logout("The session is disconnected by BuySide")
            sn.Dispose()

            fixEngine.Shutdown()
        Catch ex As Exception
            Console.WriteLine("Exception: " + ex.ToString())
        End Try
    End Sub 'Run

    Sub OnStateChange(ByVal sender As [Object], ByVal e As StateChangeEventArgs)
        Console.WriteLine("FIX session state: " + e.NewState.ToString())
    End Sub 'OnStateChange

End Class 'Initiator


Module BuySide

    Sub Main()
        Dim initiator As New Initiator()
        initiator.Run()

        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()
    End Sub

End Module

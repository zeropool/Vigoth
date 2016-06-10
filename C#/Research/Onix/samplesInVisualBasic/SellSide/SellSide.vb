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

Imports FIXForge.NET.FIX
Imports FF = FIXForge.NET.FIX
Imports FIXForge.NET.FIX.FIX44
Imports Helpers
Imports System
Imports System.Threading


   '/ <summary>
   '/ Waits for incoming connections and processes incoming messages.
   '/ </summary>
   
   Class Acceptor
      
      Sub run()
         Console.WriteLine("SellSide Sample")
         
         Try
            Engine.Init()
            
            Dim senderCompID As String = Helpers.Settings.Get("SenderCompID")
            Dim targetCompID As String = Settings.Get("TargetCompID")
            Dim fixVersion As ProtocolVersion = Settings.GetVersion()
            
            Dim sn As New Session(senderCompID, targetCompID, fixVersion)
            
            AddHandler sn.InboundApplicationMsgEvent, AddressOf OnInboundApplicationMsg
            AddHandler sn.StateChangeEvent, AddressOf OnStateChange
            AddHandler sn.ErrorEvent, AddressOf OnError
            AddHandler sn.WarningEvent, AddressOf OnWarning
            
            sn.LogonAsAcceptor()
            
            While True                
                Console.WriteLine(ControlChars.Lf.ToString() + "Awaiting session-initiator with")
                Console.WriteLine(" SenderCompID (49) = " + targetCompID) ' from the counterparty's  point of  view SenderCompID is TargetCompID 
                Console.WriteLine(" TargetCompID (56) = " + senderCompID)
                Console.WriteLine(" FIX version = " + fixVersion.ToString)
                Console.WriteLine("on port " + Engine.Instance.Settings.ListenPort.ToString + " ...")

                DisconnectedEvent.WaitOne()
            End While
        Catch ex As Exception
            Console.WriteLine("Exception: " + ex.ToString())
         End Try
      End Sub 'run
      
      
    Sub OnInboundApplicationMsg(sender As [Object], e As InboundApplicationMsgEventArgs)
        Console.WriteLine("Received application-level message:" + ControlChars.Lf + e.Msg.ToString())

        Console.WriteLine("Decoded: " + ControlChars.Lf + e.Msg.ToString(Message.StringFormat.TAG_NAME, " "))

        Try
            Dim version As ProtocolVersion = Settings.GetVersion()
            Dim reply As Message = Nothing
            If e.Msg.Type = "D" Then
                ' New Order - Single
                OrderCounter += 1
                Dim order As Message = e.Msg
                Dim execReport As New Message("8", Settings.GetVersion())

                execReport(Tags.OrderID) = order(Tags.ClOrdID)
                execReport(Tags.ExecType) = ExecType.[New]
                execReport(Tags.ExecID) = "ExecID_" + OrderCounter.ToString()
                If version < ProtocolVersion.FIX43 Then
                    execReport(Tags.ExecTransType) = ExecTransType.[New]
                End If
                execReport(Tags.OrdStatus) = "0" ' New
                execReport(Tags.Symbol) = order(Tags.Symbol)
                execReport(Tags.Side) = order(Tags.Side)
                execReport(Tags.OrderQty) = order(Tags.OrderQty)
                execReport(Tags.CumQty) = 0
                execReport(Tags.AvgPx) = 0
                execReport(Tags.LeavesQty) = order(Tags.OrderQty)

                reply = execReport
            Else
                Dim email As New Message("C", Settings.GetVersion())
                email(Tags.EmailThreadID) = "SellSide reply"
                email(Tags.EmailType) = FF.FIX44.EmailType.[New]
                email(Tags.Subject) = "Message was received"

                email(Tags.EmailType) = "0"
                Dim group As Group = email.SetGroup(Tags.NoLinesOfText, 1)
                group.Set(Tags.Text, 0, "The message with MsgType=" + e.Msg(Tags.MsgType) + " was received")

                reply = email
            End If
            reply.Validate()

            Dim sn As Session = CType(sender, Session)
            sn.Send(reply)
            Console.WriteLine("Sent to the counterparty: " + ControlChars.Lf + reply.ToString())

        Catch ex As Exception
            Console.WriteLine("Exception during the processing of incoming message: " + ex.ToString)
        End Try
    End Sub 'OnInboundApplicationMsg
      
    Sub OnStateChange(sender As [Object], e As StateChangeEventArgs)
        Console.WriteLine(("FIX session state: " + e.NewState.ToString()))
        If e.NewState = SessionState.DISCONNECTED Then
            DisconnectedEvent.Set()
        End If
    End Sub 'OnStateChange
      
      
    Sub OnError(sender As [Object], e As ErrorEventArgs)
        Console.WriteLine(("Error: " + e.ToString()))
    End Sub 'OnError
      
      
    Sub OnWarning(sender As [Object], e As WarningEventArgs)
        Console.WriteLine(("Warning: " + e.ToString()))
    End Sub 'OnWarning
      
      Private DisconnectedEvent As New AutoResetEvent(False)
      Private OrderCounter As Integer            
          
   End Class 'Acceptor


    Module SellSide

    Sub Main()
        Dim acceptor As New Acceptor()

        acceptor.run()

        Console.WriteLine("Press any key for exit.")
        Console.ReadKey()

    End Sub

    End Module

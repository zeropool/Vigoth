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
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ExchangeEmulator.Properties;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX43;
using Message = FIXForge.NET.FIX.Message;
using System.Diagnostics;
using System.Globalization;

namespace ExchangeEmulator
{
    public partial class MainForm : Form
    {
        private bool disposed = false;
        private Session tradingSession;
        private Session marketDataSession;
        private Exchange exchange;
        private MarketDataFeed marketDataFeed;

        public MainForm()
        {
            InitializeComponent();

            HandleDestroyed += new EventHandler(MainForm_HandleDestroyed);
            
            OnTradingSessionDisconnectedSetMenuItems();
			OnMarketDataSessionDisconnectedSetMenuItems();
            
            CreateTradingSession();
            CreateMarketDataSession();

            toolStripStatusLabelStatus.Text =
                string.Format(CultureInfo.InvariantCulture, "Bid: {0}   Ask: {1}", ConfigurationHelper.GetDouble("BidPrice"),
							  ConfigurationHelper.GetDouble("AskPrice"));

            modeToolStripComboBox.Items.AddRange(Enum.GetNames(typeof (Exchange.EmulationMode)));
            modeToolStripComboBox.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            ConnectTradingSession();
            ConnectMarketDataSession();

            eventView.LogInfo("Using configuration file " + ConfigurationHelper.GetConfigurationPath());
            Trace.TraceInformation("Using configuration file " + ConfigurationHelper.GetConfigurationPath());
            eventView.LogInfo("Log files could be found in " + Engine.Instance.Settings.LogDirectory);
            Trace.TraceInformation("Log files could be found in " + Engine.Instance.Settings.LogDirectory);

            eventView.LogInfo("ExchangeEmulator listens for incoming FIX Connections on port " + Engine.Instance.Settings.ListenPort);
            Trace.TraceInformation("ExchangeEmulator listens for incoming FIX Connections on port " + Engine.Instance.Settings.ListenPort);

            Engine.Instance.Error += Instance_Error;
            Engine.Instance.Warning += Instance_Warning;
        }

        void Instance_Warning(object sender, Engine.WarningEventArgs args)
        {
            eventView.LogWarning("FIX Engine level warning: " + args.ToString());
        }

        void Instance_Error(object sender, Engine.ErrorEventArgs args)
        {
            eventView.LogError("FIX Engine level error: " + args.ToString());
        }

        private void MainForm_HandleDestroyed(object sender, EventArgs e)
        {
            Engine.Instance.Error -= Instance_Error;
            Engine.Instance.Warning -= Instance_Warning;

            disposed = true;
        }

        private void ShowAboutDialog()
        {
            AboutDlg form = new AboutDlg();
            form.ShowDialog(this);
		}

		#region Business Logic Initiation

		private void CreateTradingSession(int inSeqNum, int outSeqNum)
        {
            CreateTradingSession();
            
            if (inSeqNum > 0 && tradingSession.InSeqNum != inSeqNum)
                tradingSession.InSeqNum = inSeqNum;
            if (outSeqNum > 0 && tradingSession.OutSeqNum != outSeqNum)
                tradingSession.OutSeqNum = outSeqNum;
        }

        private void CreateTradingSession()
        {
            if (tradingSession != null)
            {
                tradingSession.InboundApplicationMsgEvent -= new InboundApplicationMsgEventHandler(tradingSession_InboundApplicationMsgEvent);
                tradingSession.InboundSessionMsgEvent -= new InboundSessionMsgEventHandler(session_InboundSessionMsgEvent);
                tradingSession.OutboundApplicationMsgEvent -= new OutboundApplicationMsgEventHandler(session_OutboundApplicationMsgEvent);
                tradingSession.OutboundSessionMsgEvent -= new OutboundSessionMsgEventHandler(session_OutboundSessionMsgEvent);
                tradingSession.MessageResending += new MessageResendingEventHandler(session_MessageResending);
                tradingSession.StateChangeEvent -= new StateChangeEventHandler(tradingSession_StateChangeEvent);
                tradingSession.WarningEvent -= new WarningEventHandler(session_WarningEvent);
                tradingSession.ErrorEvent -= new FIXForge.NET.FIX.ErrorEventHandler(session_ErrorEvent);

                tradingSession.Dispose();
            }


			SessionConfiguration settings = (SessionConfiguration)ConfigurationHelper.GetSection("TradingSession");
           
            tradingSession = new Session(settings.SenderCompID, settings.TargetCompID, settings.Version, settings.KeepSequenceNumbersAfterLogout);

            eventView.LogInfo("Trading Session " + tradingSession.ToString() + " created.");
            Trace.TraceInformation("Trading Session " + tradingSession.ToString() + " created.");
                            
            exchange = new Exchange(tradingSession, eventView);
            tradingSession.SenderSubID = settings.SenderSubID;
            tradingSession.SenderLocationID = settings.SenderLocationID;
            tradingSession.TargetSubID = settings.TargetSubID;

            if (settings.UseSslEncryption)
            {
                eventView.LogInfo("Trading Session will use SSL Encryption.");

                tradingSession.Encryption = EncryptionMethod.SSL;                

                if (!string.IsNullOrEmpty(settings.SslCertificateFile))
                {
                    tradingSession.Ssl.CertificateFile = settings.SslCertificateFile;
                    tradingSession.Ssl.PrivateKeyFile = settings.SslCertificateFile;
                }
            }
                                       
            tradingSession.InboundApplicationMsgEvent +=
                new InboundApplicationMsgEventHandler(tradingSession_InboundApplicationMsgEvent);
            tradingSession.InboundSessionMsgEvent += new InboundSessionMsgEventHandler(session_InboundSessionMsgEvent);
            tradingSession.OutboundApplicationMsgEvent +=
                new OutboundApplicationMsgEventHandler(session_OutboundApplicationMsgEvent);
            tradingSession.OutboundSessionMsgEvent +=
                new OutboundSessionMsgEventHandler(session_OutboundSessionMsgEvent);
            tradingSession.MessageResending += new MessageResendingEventHandler(session_MessageResending);
            tradingSession.StateChangeEvent += new StateChangeEventHandler(tradingSession_StateChangeEvent);
            tradingSession.WarningEvent += new WarningEventHandler(session_WarningEvent);
            tradingSession.ErrorEvent += new FIXForge.NET.FIX.ErrorEventHandler(session_ErrorEvent);
        }

		private void CreateMarketDataSession(int inSeqNum, int outSeqNum)
		{
			CreateMarketDataSession();

			if (inSeqNum > 0 && marketDataSession.InSeqNum != inSeqNum)
				marketDataSession.InSeqNum = inSeqNum;
			if (outSeqNum > 0 && marketDataSession.OutSeqNum != outSeqNum)
				marketDataSession.OutSeqNum = outSeqNum;
		}

		private void CreateMarketDataSession()
        {
            if (marketDataSession != null)
            {
                marketDataSession.InboundApplicationMsgEvent -= new InboundApplicationMsgEventHandler(marketDataSession_InboundApplicationMsgEvent);
                marketDataSession.InboundSessionMsgEvent -= new InboundSessionMsgEventHandler(session_InboundSessionMsgEvent);
                marketDataSession.OutboundApplicationMsgEvent -= new OutboundApplicationMsgEventHandler(session_OutboundApplicationMsgEvent);
                marketDataSession.OutboundSessionMsgEvent -= new OutboundSessionMsgEventHandler(session_OutboundSessionMsgEvent);
                marketDataSession.MessageResending -= new MessageResendingEventHandler(session_MessageResending);
                marketDataSession.StateChangeEvent -= new StateChangeEventHandler(marketDataSession_StateChangeEvent);
                marketDataSession.WarningEvent -= new WarningEventHandler(session_WarningEvent);
                marketDataSession.ErrorEvent -= new FIXForge.NET.FIX.ErrorEventHandler(session_ErrorEvent);

				marketDataFeed.Dispose();
                marketDataSession.Dispose();
            }

			SessionConfiguration settings = (SessionConfiguration)ConfigurationHelper.GetSection("MarketDataSession");           

            marketDataSession = new Session(settings.SenderCompID, settings.TargetCompID, settings.Version, settings.KeepSequenceNumbersAfterLogout);

            eventView.LogInfo("Market Data Session " + marketDataSession.ToString() + " created.");
            Trace.TraceInformation("Market Data Session " + marketDataSession.ToString() + " created.");

            if (settings.UseSslEncryption)
            {
                eventView.LogInfo("Market Data Session will use SSL Encryption.");

                marketDataSession.Encryption = EncryptionMethod.SSL;

                if (!string.IsNullOrEmpty(settings.SslCertificateFile))
                {
                    marketDataSession.Ssl.CertificateFile = settings.SslCertificateFile;
                    marketDataSession.Ssl.PrivateKeyFile = settings.SslCertificateFile;
                }
            }

			marketDataFeed = new MarketDataFeed(marketDataSession, eventView);

            marketDataSession.SenderSubID = settings.SenderSubID;
            marketDataSession.SenderLocationID = settings.SenderLocationID;
            marketDataSession.TargetSubID = settings.TargetSubID;

            marketDataSession.InboundApplicationMsgEvent +=
                new InboundApplicationMsgEventHandler(marketDataSession_InboundApplicationMsgEvent);
            marketDataSession.InboundSessionMsgEvent += new InboundSessionMsgEventHandler(session_InboundSessionMsgEvent);
            marketDataSession.OutboundApplicationMsgEvent +=
                new OutboundApplicationMsgEventHandler(session_OutboundApplicationMsgEvent);
            marketDataSession.OutboundSessionMsgEvent +=
                new OutboundSessionMsgEventHandler(session_OutboundSessionMsgEvent);
            marketDataSession.MessageResending += new MessageResendingEventHandler(session_MessageResending);
            marketDataSession.StateChangeEvent += new StateChangeEventHandler(marketDataSession_StateChangeEvent);
            marketDataSession.WarningEvent += new WarningEventHandler(session_WarningEvent);
            marketDataSession.ErrorEvent += new FIXForge.NET.FIX.ErrorEventHandler(session_ErrorEvent);
        }

		#endregion Business Logic Initiation

		#region Session Management

		private void ConnectTradingSession()
        {
            try
            {
                tradingSession.LogonAsAcceptor();
				OnTradingSessionConnectedSetMenuItems();
			}
            catch (Exception ex)
            {
                eventView.LogError("Cannot connect Trading FIX Session: " + ex.Message);
                Trace.TraceError("Cannot connect Trading FIX Session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot connect Trading FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

		private void DisconnectTradingSession()
		{
			try
			{
				tradingSession.Logout();
				OnTradingSessionDisconnectedSetMenuItems();
			}
			catch (Exception ex)
			{
				eventView.LogError("Cannot Disconnect Trading FIX Session: " + ex.Message);
                Trace.TraceError("Cannot Disconnect Trading FIX Session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Disconnect Trading FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ConnectMarketDataSession()
        {
            try
            {
                marketDataSession.LogonAsAcceptor();
                OnMarketDataSessionConnectedSetMenuItems();
            }
            catch (Exception ex)
            {
                eventView.LogError("Cannot Connect Market Data FIX Session: " + ex.Message);
                Trace.TraceError("Cannot Connect Market Data FIX Session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Connect Market Data FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }                        
        }

        private void DisconnectMarketDataSession()
        {
            try
            {
                marketDataSession.Logout();
                OnMarketDataSessionDisconnectedSetMenuItems();

            }
            catch (Exception ex)
            {
                eventView.LogError("Cannot Disconnect Market Data FIX Session: " + ex.Message);
                Trace.TraceError("Cannot Disconnect Market Data FIX Session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Disconnect Market Data FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void ResetSession(Session session)
		{
			try
			{
				session.ResetLocalSequenceNumbers();
			}
			catch (Exception ex)
			{
				eventView.LogError("Cannot Reset FIX Session: " + ex.Message);
                Trace.TraceError("Cannot Reset FIX Session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Reset FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BreakSession(Session session)
		{
			try
			{
				session.BreakConnection();
			}
			catch (Exception ex)
			{
				eventView.LogError("Cannot Break FIX Connection: " + ex.Message);
                Trace.TraceError("Cannot Break FIX Connection: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Break FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private static void ReplayLog(Session session)
		{
			using (ReplayLogFileForm form = new ReplayLogFileForm())
			{
				if (DialogResult.OK == form.ShowDialog())
				{
					try
					{
						ReplayLog(form.File, form.Filter, session);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Cannot Replay Log File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
		}

		private static void ReplayLog(string file, string filter, Session session)
		{
			using (StreamReader sr = new StreamReader(file))
			{
				while (sr.Peek() >= 0)
				{
					string line = sr.ReadLine();
					int messageStartIndex = line.IndexOf("8=FIX.", StringComparison.Ordinal);
					if (-1 != messageStartIndex)
					{
						line = line.Substring(messageStartIndex);
					}

					Message msg = new Message(line);
					if (msg.Type == MsgType.Logon || msg.Type == MsgType.Logout
						|| msg.Type == MsgType.Heartbeat || msg.Type == MsgType.Test_Request
						|| msg.Type == MsgType.Resend_Request || msg.Type == MsgType.Sequence_Reset
						|| msg.Type == MsgType.Reject
						)
					{
						continue;
					}
					if ("*" != filter)
					{
						if (msg.Type != filter)
						{
							continue;
						}
					}
					session.Send(msg);
				}
			}
		}

		static void OpenLogFile(Session session)
		{
			string path = session.StorageID + ".summary";

			try
			{
				Process.Start(path);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Cannot Open Log File");
			}
		}

		private void OnTradingSessionConnectedSetMenuItems()
        {
            toolStripButtonDisconnect.Enabled = true;
            disconnectTradingSessionToolStripMenuItem.Enabled = true;
            toolStripButtonConnect.Enabled = false;
            connectTradingSessionToolStripMenuItem.Enabled = false;
            resetTradingSessionToolStripMenuItem.Enabled = false;
        }

        private void OnTradingSessionDisconnectedSetMenuItems()
        {
            toolStripButtonDisconnect.Enabled = false;
            disconnectTradingSessionToolStripMenuItem.Enabled = false;
            toolStripButtonConnect.Enabled = true;
            connectTradingSessionToolStripMenuItem.Enabled = true;
            resetTradingSessionToolStripMenuItem.Enabled = true;
        }

        private void OnMarketDataSessionConnectedSetMenuItems()
        {
            disconnectMarketDataSessionToolStripMenuItem.Enabled = true;
            disconnectMarketDataSessionToolStripButton.Enabled = true;
            connectMarketDataSessionToolStripMenuItem.Enabled = false;
            connectMarketDataSessionToolStripButton.Enabled = false;
            resetMarketDataSessionToolStripMenuItem.Enabled = false;
        }

        private void OnMarketDataSessionDisconnectedSetMenuItems()
        {
            disconnectMarketDataSessionToolStripMenuItem.Enabled = false;
            disconnectMarketDataSessionToolStripButton.Enabled = false;
            connectMarketDataSessionToolStripMenuItem.Enabled = true;
            connectMarketDataSessionToolStripButton.Enabled = true;
            resetMarketDataSessionToolStripMenuItem.Enabled = true;
        }

        private void SetSessionsSettings()
        {
            SessionsSettingsForm sessionSettingsForm = new SessionsSettingsForm(tradingSession.InSeqNum, tradingSession.OutSeqNum, marketDataSession.InSeqNum, marketDataSession.OutSeqNum);
            if (sessionSettingsForm.ShowDialog(this) == DialogResult.OK)
            {
                int inSeqNum = sessionSettingsForm.TradingInSeqNum;
                int outSeqNum = sessionSettingsForm.TradingOutSeqNum;
                CreateTradingSession(inSeqNum, outSeqNum);
				ConnectTradingSession();

				inSeqNum = sessionSettingsForm.MarketDataInSeqNum;
				outSeqNum = sessionSettingsForm.MarketDataOutSeqNum;
				CreateMarketDataSession(inSeqNum, outSeqNum);
				ConnectMarketDataSession();
			}
        }

		#endregion Session Management

        #region Session Event Handlers

        private void session_WarningEvent(object source, WarningEventArgs args)
        {
            eventView.LogWarning(args.ToString());
            Trace.TraceWarning(args.ToString());
        }

        private void session_ErrorEvent(object source, FIXForge.NET.FIX.ErrorEventArgs args)
        {
            eventView.LogError(args.ToString());
            Trace.TraceError(args.ToString());
        }

        private void tradingSession_StateChangeEvent(object source, StateChangeEventArgs args)
        {
            eventView.LogInfo(string.Format(CultureInfo.InvariantCulture, "Trading Session state changed from {0} to {1}", args.PrevState, args.NewState));
            Trace.TraceInformation(string.Format(CultureInfo.InvariantCulture, "Trading Session state changed from {0} to {1}", args.PrevState, args.NewState));

            if (!Disposing && !disposed)
                BeginInvoke(new UpdateSesionStateDelegate(SafeUpdateTradingSessionState), args);
        }

        private void marketDataSession_StateChangeEvent(object source, StateChangeEventArgs args)
        {
            eventView.LogInfo(string.Format(CultureInfo.InvariantCulture, "Market Data Session state changed from {0} to {1}", args.PrevState, args.NewState));
            Trace.TraceInformation(string.Format(CultureInfo.InvariantCulture, "Market Data Session state changed from {0} to {1}", args.PrevState, args.NewState));
            
            if((SessionState.ACTIVE == args.PrevState) && (SessionState.ACTIVE != args.NewState))
            {
                marketDataFeed.Reset();
            }

            if (!Disposing && !disposed)
                BeginInvoke(new UpdateSesionStateDelegate(SafeUpdateMarketDatagSessionState), args);
        }

        private delegate void UpdateSesionStateDelegate(StateChangeEventArgs args);

        private void SafeUpdateTradingSessionState(StateChangeEventArgs args)
        {
            if (args.NewState == SessionState.DISCONNECTED &&
                args.PrevState != SessionState.DISCONNECTED)
            {
                OnTradingSessionDisconnectedSetMenuItems();
            }
            tradingSessionStateToolStripLabel.Text = args.NewState.ToString();
            if (args.NewState == SessionState.ACTIVE)
                tradingSessionStateToolStripLabel.ForeColor = Color.Green;
            else if (args.NewState == SessionState.RECONNECTING)
                tradingSessionStateToolStripLabel.ForeColor = Color.Orange;
            else
                tradingSessionStateToolStripLabel.ForeColor = Color.Black;
        }

        private void SafeUpdateMarketDatagSessionState(StateChangeEventArgs args)
        {
            if (args.NewState == SessionState.DISCONNECTED &&
                args.PrevState != SessionState.DISCONNECTED)
            {
                OnMarketDataSessionDisconnectedSetMenuItems();             
            }
            marketDataSessionStateToolStripLabel.Text = args.NewState.ToString();
            if (args.NewState == SessionState.ACTIVE)
                marketDataSessionStateToolStripLabel.ForeColor = Color.Green;
            else if (args.NewState == SessionState.RECONNECTING)
                marketDataSessionStateToolStripLabel.ForeColor = Color.Orange;
            else
                marketDataSessionStateToolStripLabel.ForeColor = Color.Black;
        }

        private void session_MessageResending(object sender, MessageResendingEventArgs e)
        {
            eventView.LogInfo(string.Format(CultureInfo.InvariantCulture, "Resend request for message {0}", e.Msg));
            Trace.TraceInformation(string.Format(CultureInfo.InvariantCulture, "Resend request for message {0}", e.Msg));
            e.AllowResending = true;
        }

        private void session_OutboundSessionMsgEvent(object sender, OutboundSessionMsgEventArgs args)
        {
            eventView.LogOutgoingMessage(args.Msg);
        }

        private void session_OutboundApplicationMsgEvent(object sender, OutboundApplicationMsgEventArgs args)
        {
            eventView.LogOutgoingMessage(args.Msg);
        }

        private void session_InboundSessionMsgEvent(object sender, InboundSessionMsgEventArgs args)
        {
            eventView.LogIncomingMessage(args.Msg);

            if (MsgType.Logon == args.Msg.Type)
            {
				string sectionName;
				if (sender == tradingSession)
					sectionName = "TradingSession";
				else
					sectionName = "MarketDataSession";
				SessionConfiguration settings = (SessionConfiguration)ConfigurationHelper.GetSection(sectionName);
				
				if (!string.IsNullOrEmpty(settings.RawData))
				{
					if (settings.RawData != args.Msg[Tags.RawData])
					{
						throw new ApplicationException("Invalid RawData");
					}
				}

                if (!string.IsNullOrEmpty(settings.Username))
                {
                    if (settings.Username != args.Msg[Tags.Username])
                    {
                        throw new ApplicationException("Invalid Username");
                    }
				}
                if (!string.IsNullOrEmpty(settings.Password))
				{
                    if (settings.Password != args.Msg[Tags.Password])
                    {
                        throw new ApplicationException("Invalid Password");
                    }
                }
            }
        }

        private void tradingSession_InboundApplicationMsgEvent(object sender, InboundApplicationMsgEventArgs args)
        {
            eventView.LogIncomingMessage(args.Msg);
            exchange.ProcessIncomingMessage(args.Msg);
        }

        private void marketDataSession_InboundApplicationMsgEvent(object sender, InboundApplicationMsgEventArgs args)
        {
            eventView.LogIncomingMessage(args.Msg);
            if (MsgType.Market_Data_Request == args.Msg.Type)
            {
                marketDataFeed.ProcessMarketDataRequest(args.Msg);
            }
            if (MsgType.Security_Definition_Request == args.Msg.Type)
			{
				marketDataFeed.ProcessSecurityDefinitionRequest(args.Msg);
			}
		}

		#endregion Session Event Handlers

		#region Form Event Handlers

		private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {
            ConnectTradingSession();
        }

        private void toolStripButtonDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectTradingSession();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectTradingSession();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisconnectTradingSession();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetSession(tradingSession);
        }        

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                toolStripStatusLabelStatus.Text = string.Format(CultureInfo.InvariantCulture, "Ask price: {0}, Bid price: {1}",
                                                                ConfigurationHelper.GetDouble("AskPrice"),
                                                                ConfigurationHelper.GetDouble("BidPrice"));
            }
		}

		private void replayLogFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReplayLog(tradingSession);
		}

		private void modeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Exchange.EmulationMode mode = (Exchange.EmulationMode)Enum.Parse(typeof(Exchange.EmulationMode), modeToolStripComboBox.Text);
			exchange.Mode = mode;
		}

		private void sessionsSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetSessionsSettings();
		}

		private void connectMarketDataSessionToolStripButton_Click(object sender, EventArgs e)
		{
			ConnectMarketDataSession();
		}

		private void disconnectMarketDataSessionToolStripButton_Click(object sender, EventArgs e)
		{
			DisconnectMarketDataSession();
		}

		private void connectMarketDataSessionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ConnectMarketDataSession();
		}

		private void disconnectMarketDataSessionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisconnectMarketDataSession();
		}

		private void resetMarketDataSessionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResetSession(marketDataSession);
		}

		private void breakTradingConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BreakSession(tradingSession);
			OnTradingSessionDisconnectedSetMenuItems();
		}

		private void breakMarketDataConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BreakSession(marketDataSession);
			OnMarketDataSessionDisconnectedSetMenuItems();
		}

		private void replayLogFileMarketDataSessionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReplayLog(marketDataSession);
		}

		private void openMarketDataLogFileToolStripButton_Click(object sender, EventArgs e)
		{
			OpenLogFile(marketDataSession);
		}

		private void openOrderLogFileToolStripButton_Click(object sender, EventArgs e)
		{
			OpenLogFile(tradingSession);
		}


		#endregion Form Event Handlers
    }
}
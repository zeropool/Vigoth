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
using System.Drawing;
using System.Windows.Forms;
using TradingClientSample.Properties;
using FIXForge.NET.FIX;
using FIXForge.NET.FIX.FIX43;
using System.Globalization;

namespace TradingClientSample
{
    public partial class MainForm : Form
    {       
        bool disposed = false;
        TradingManager tradingManager;
        MarketDataHandler marketDataHandler;

        public MainForm()
        {
            InitializeComponent();

			eventView.LogInfo("Using configuration file " + ConfigurationHelper.GetConfigurationPath());
            Trace.TraceInformation("Using configuration file " + ConfigurationHelper.GetConfigurationPath());

            HandleDestroyed += new EventHandler(MainForm_HandleDestroyed);
            OnTradigSessionDisconnectSetMenuItems();
			OnMarketDataSessionDisconnectSetMenuItems();
            CreateTradingManager();
            CreateMarketDataHandler();
		}

		void ShowAboutDialog()
		{
			AboutDlg form = new AboutDlg();
			form.ShowDialog(this);
		}

		void ClearEventLog()
		{
			eventView.Clear();
		}

		#region Form Event Handlers

		void MainForm_HandleDestroyed(object sender, EventArgs e)
        {
            disposed = true;
        }

		private void MainForm_Load(object sender, EventArgs e)
		{
			eventView.LogInfo("Log files could be found in " + Engine.Instance.Settings.LogDirectory);
            Trace.TraceInformation("Log files could be found in " + Engine.Instance.Settings.LogDirectory);
        }

		void toolStripButtonConnect_Click(object sender, EventArgs e)
		{
			ConnectTradingSession();
		}

		void toolStripButtonDisconnect_Click(object sender, EventArgs e)
		{
			DisconnectTradingSession();
		}

		void connectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ConnectTradingSession();
		}

		void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisconnectTradingSession();
		}

		void connectMarketDataSessionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ConnectMarketDataSession();
		}

		void connectMarketDataSessionToolStripButton_Click(object sender, EventArgs e)
		{
			ConnectMarketDataSession();
		}

		void disconnectMarketDataSessionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisconnectMarketDataSession();
		}

		void disconnectMarketDataSessionToolStripButton_Click(object sender, EventArgs e)
		{
			DisconnectMarketDataSession();
		}

		void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResetSession(tradingManager.Session);
		}

		private void marketDataResetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResetSession(marketDataHandler.Session);
		}

		void breakConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BreakSession(tradingManager.Session);
			OnTradigSessionDisconnectSetMenuItems();
		}

		private void marketDataBreakConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BreakSession(marketDataHandler.Session);
			OnMarketDataSessionDisconnectSetMenuItems();
		}

		private void openOrderLogFileToolStripButton_Click(object sender, EventArgs e)
		{
			OpenLogFile(tradingManager.Session);
		}

		private void openMarketDataLogFileToolStripButton_Click(object sender, EventArgs e)
		{
			OpenLogFile(marketDataHandler.Session);
		}

		void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClearEventLog();
		}

		void toolStripButtonClearEventLog_Click(object sender, EventArgs e)
		{
			ClearEventLog();
		}

		void clearEventsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClearEventLog();
		}

		void newOrderToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			NewOrder();
		}

		void toolStripButtonNewOrder_Click(object sender, EventArgs e)
		{
			NewOrder();
		}

		void newOrderToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			NewOrder();
		}

		void modifyOrderToolBarButton_Click(object sender, EventArgs e)
		{
			ModifyOrder();
		}

		void modifyOrderContextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ModifyOrder();
		}

		void toolStripButtonCancelOrder_Click(object sender, EventArgs e)
		{
			CancelOrder();
		}

		void cancelOrderToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			CancelOrder();
		}

		void subscribeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SubscribeMarketDataRequest();
		}

		void subscribeSymbolToolStripButton_Click(object sender, EventArgs e)
		{
			SubscribeMarketDataRequest();
		}

		private void unsubscribeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UnsubscribeMarketDataRequest();
		}

		private void unsubscribeToolStripButton_Click(object sender, EventArgs e)
		{
			UnsubscribeMarketDataRequest();
		}

		void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowAboutDialog();
		}

		void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		void contextMenuStripOrders_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			cancelOrderContextToolStripMenuItem.Enabled = IsCancelAndModifyOrderAvailable();
			modifyOrderContextToolStripMenuItem.Enabled = IsCancelAndModifyOrderAvailable();
		}

		void sessionsSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetSessionsSettings();
		}

		#endregion Form Event Handlers

		#region Business Logic Initiation

		void CreateTradingManager(int inSeqNum, int outSeqNum)
		{
			CreateTradingManager();

			if (inSeqNum > 0 && tradingManager.Session.InSeqNum != inSeqNum)
			{
				tradingManager.Session.InSeqNum = inSeqNum;
			}
			if (outSeqNum > 0 && tradingManager.Session.OutSeqNum != outSeqNum)
			{
				tradingManager.Session.OutSeqNum = outSeqNum;
			}
		}

		void CreateTradingManager()
		{
			if (null != tradingManager)
			{
				tradingManager.OrderStateChanged -= new EventHandler<TradingManager.OrderStateChangedArgs>(OnOrderStateChanged);

				tradingManager.Session.InboundApplicationMsgEvent -= new InboundApplicationMsgEventHandler(session_InboundApplicationMsgEvent);
				tradingManager.Session.InboundSessionMsgEvent -= new InboundSessionMsgEventHandler(session_InboundSessionMsgEvent);
				tradingManager.Session.OutboundApplicationMsgEvent -= new OutboundApplicationMsgEventHandler(session_OutboundApplicationMsgEvent);
				tradingManager.Session.OutboundSessionMsgEvent -= new OutboundSessionMsgEventHandler(session_OutboundSessionMsgEvent);
				tradingManager.Session.MessageResending -= new MessageResendingEventHandler(session_MessageResendingEvent);
				tradingManager.Session.StateChangeEvent -= new StateChangeEventHandler(tradingSession_StateChangeEvent);
				tradingManager.Session.WarningEvent -= new WarningEventHandler(session_WarningEvent);
                tradingManager.Session.ErrorEvent -= new FIXForge.NET.FIX.ErrorEventHandler(session_ErrorEvent);

				tradingManager.Session.Dispose();
			}

			SessionConfiguration settings = (SessionConfiguration)ConfigurationHelper.GetSection("TradingSession");

			tradingManager = new TradingManager(settings, eventView);

			tradingManager.OrderStateChanged += new EventHandler<TradingManager.OrderStateChangedArgs>(OnOrderStateChanged);

			tradingManager.Session.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(session_InboundApplicationMsgEvent);
			tradingManager.Session.InboundSessionMsgEvent += new InboundSessionMsgEventHandler(session_InboundSessionMsgEvent);
			tradingManager.Session.OutboundApplicationMsgEvent += new OutboundApplicationMsgEventHandler(session_OutboundApplicationMsgEvent);
			tradingManager.Session.OutboundSessionMsgEvent += new OutboundSessionMsgEventHandler(session_OutboundSessionMsgEvent);
			tradingManager.Session.MessageResending += new MessageResendingEventHandler(session_MessageResendingEvent);
			tradingManager.Session.StateChangeEvent += new StateChangeEventHandler(tradingSession_StateChangeEvent);
			tradingManager.Session.WarningEvent += new WarningEventHandler(session_WarningEvent);
            tradingManager.Session.ErrorEvent += new FIXForge.NET.FIX.ErrorEventHandler(session_ErrorEvent);
		}

		void CreateMarketDataHandler(int inSeqNum, int outSeqNum)
		{
			CreateMarketDataHandler();

			if (inSeqNum > 0 && marketDataHandler.Session.InSeqNum != inSeqNum)
			{
				marketDataHandler.Session.InSeqNum = inSeqNum;
			}
			if (outSeqNum > 0 && marketDataHandler.Session.OutSeqNum != outSeqNum)
			{
				marketDataHandler.Session.OutSeqNum = outSeqNum;
			}
		}

		void CreateMarketDataHandler()
		{
			if (null != marketDataHandler)
			{

				marketDataHandler.Session.InboundApplicationMsgEvent -= new InboundApplicationMsgEventHandler(session_InboundApplicationMsgEvent);
				marketDataHandler.Session.InboundSessionMsgEvent -= new InboundSessionMsgEventHandler(session_InboundSessionMsgEvent);
				marketDataHandler.Session.OutboundApplicationMsgEvent -= new OutboundApplicationMsgEventHandler(session_OutboundApplicationMsgEvent);
				marketDataHandler.Session.OutboundSessionMsgEvent -= new OutboundSessionMsgEventHandler(session_OutboundSessionMsgEvent);
				marketDataHandler.Session.MessageResending -= new MessageResendingEventHandler(session_MessageResendingEvent);
				marketDataHandler.Session.StateChangeEvent -= new StateChangeEventHandler(marketDataSession_StateChangeEvent);
				marketDataHandler.Session.WarningEvent -= new WarningEventHandler(session_WarningEvent);
				marketDataHandler.Session.ErrorEvent -= new ErrorEventHandler(session_ErrorEvent);
				marketDataHandler.PriceChange -= new EventHandler<MarketDataHandler.PriceChangeArgs>(marketDataHandler_PriceChange);
				marketDataHandler.TradeReceived -= new EventHandler<MarketDataHandler.TradeArgs>(marketDataHandler_TradeReceived);
				marketDataHandler.SecurityDefinitionReceived -= new EventHandler<MarketDataHandler.SecurityDefinitionArgs>(marketDataHandler_SecurityDefinitionReceived);

				marketDataHandler.Session.Dispose();
			}

			SessionConfiguration settings = (SessionConfiguration)ConfigurationHelper.GetSection("MarketDataSession");

			marketDataHandler = new MarketDataHandler(settings, eventView);

			marketDataHandler.Session.InboundApplicationMsgEvent += new InboundApplicationMsgEventHandler(session_InboundApplicationMsgEvent);
			marketDataHandler.Session.InboundSessionMsgEvent += new InboundSessionMsgEventHandler(session_InboundSessionMsgEvent);
			marketDataHandler.Session.OutboundApplicationMsgEvent += new OutboundApplicationMsgEventHandler(session_OutboundApplicationMsgEvent);
			marketDataHandler.Session.OutboundSessionMsgEvent += new OutboundSessionMsgEventHandler(session_OutboundSessionMsgEvent);
			marketDataHandler.Session.MessageResending += new MessageResendingEventHandler(session_MessageResendingEvent);
			marketDataHandler.Session.StateChangeEvent += new StateChangeEventHandler(marketDataSession_StateChangeEvent);
			marketDataHandler.Session.WarningEvent += new WarningEventHandler(session_WarningEvent);
			marketDataHandler.Session.ErrorEvent += new ErrorEventHandler(session_ErrorEvent);
			marketDataHandler.PriceChange += new EventHandler<MarketDataHandler.PriceChangeArgs>(marketDataHandler_PriceChange);
			marketDataHandler.TradeReceived += new EventHandler<MarketDataHandler.TradeArgs>(marketDataHandler_TradeReceived);
			marketDataHandler.SecurityDefinitionReceived += new EventHandler<MarketDataHandler.SecurityDefinitionArgs>(marketDataHandler_SecurityDefinitionReceived);
		}

		#endregion Business Logic Initiation

		#region Trading

		Dictionary<Order, DataGridViewRow> order2row = new Dictionary<Order, DataGridViewRow>();

		void NewOrder()
		{
			NewOrderForm form = new NewOrderForm(tradingManager, this, eventView);
			form.Show(this);
			form.Focus();
		}

		void ModifyOrder()
		{
			if (dataGridViewOrders.SelectedRows.Count == 1)
			{
				try
				{
					DataGridViewRow row = dataGridViewOrders.SelectedRows[0];
					if (null == row.Cells[columnClientOrderID.Index].Value)
					{
						return;
					}

					Order order = (Order)row.Tag;

					using (NewOrderForm form = new NewOrderForm(tradingManager, this, order, eventView))
					{
						if (DialogResult.OK == form.ShowDialog())
						{
							tradingManager.ModifyOrder(order);
						}
					}
				}
				catch (Exception ex)
				{
					eventView.LogError("Cannot Modify Order: " + ex.Message);
                    Trace.TraceError("Cannot Modify Order: " + ex.Message);
					MessageBox.Show(this, ex.Message, "Cannot Modify Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		void CancelOrder()
		{
			if (dataGridViewOrders.SelectedRows.Count == 1)
			{
				try
				{
					DataGridViewRow row = dataGridViewOrders.SelectedRows[0];
					if (null == row.Cells[columnClientOrderID.Index].Value)
					{
						return;
					}

					Order order = (Order)row.Tag;

					tradingManager.CancelOrder(order);
				}
				catch (Exception ex)
				{
					eventView.LogError("Cannot Cancel Order: " + ex.Message);
                    Trace.TraceError("Cannot Cancel Order: " + ex.Message);
                    MessageBox.Show(this, ex.Message, "Cannot Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		delegate void UpdateOrderRowDelegate(Order order);

		void UpdateOrderRowDelegateImpl(Order order)
		{
			DataGridViewRow row;
			if (order2row.ContainsKey(order))
			{
				row = order2row[order];
			}
			else
			{
				int newRowIndex = dataGridViewOrders.Rows.Add();
				row = dataGridViewOrders.Rows[newRowIndex];
				row.Tag = order;
				order2row.Add(order, row);
			}

			row.Cells[columnText.Index].Value = order.Text;
			row.Cells[columnClientOrderID.Index].Value = order.ClientOrderID;

			if (Order.OrderStatus.New != order.Status)
			{
				row.Cells[columnLastPx.Index].Value = order.LastFillPrice.ToString(CultureInfo.InvariantCulture);
				row.Cells[columnCumQty.Index].Value = order.FilledQuantity.ToString(CultureInfo.InvariantCulture);
			}
			row.Cells[columnOrderID.Index].Value = order.OrderID;

			row.Cells[columnOrderStatus.Index].Value = order.Status.ToString();
			switch (order.Status)
			{
				default:
					row.DefaultCellStyle.ForeColor = Color.Black;
					break;

				case Order.OrderStatus.PartialFill:
					row.DefaultCellStyle.ForeColor = Color.Green;
					break;

				case Order.OrderStatus.Fill:
					row.DefaultCellStyle.ForeColor = Color.Blue;
					break;

				case Order.OrderStatus.Canceled:
					row.DefaultCellStyle.ForeColor = Color.Gray;
					break;

				case Order.OrderStatus.Rejected:
					row.DefaultCellStyle.ForeColor = Color.Orange;
					break;

			}

			row.Cells[columnOrderType.Index].Value = order.Type.ToString();

			if (0 != order.Price)
			{
				row.Cells[columnPrice.Index].Value = order.Price.ToString(CultureInfo.InvariantCulture);
			}
			row.Cells[columnQuantity.Index].Value = order.Quantity.ToString(CultureInfo.InvariantCulture);
			row.Cells[columnSide.Index].Value = order.Side.ToString();
			row.Cells[columnSymbol.Index].Value = order.Symbol;

			UpdateStateOfToolBarButtons();
		}

		void OnOrderStateChanged(object sender, TradingManager.OrderStateChangedArgs args)
		{
			if (!Disposing && !disposed)
			{
				BeginInvoke(new UpdateOrderRowDelegate(UpdateOrderRowDelegateImpl), args.Order);
			}
		}

		bool IsCancelAndModifyOrderAvailable()
		{
			if (dataGridViewOrders.SelectedRows.Count == 1)
			{
				Order order = dataGridViewOrders.SelectedRows[0].Tag as Order;
				if (null != order
					&& Order.OrderStatus.Fill != order.Status
					&& Order.OrderStatus.Canceled != order.Status
					&& Order.OrderStatus.Rejected != order.Status)
				{
					return true;
				}
			}
			return false;
		}

		void cancelOrderContextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CancelOrder();
		}

		void dataGridViewOrders_SelectionChanged(object sender, EventArgs e)
		{
			UpdateStateOfToolBarButtons();
		}

		void UpdateStateOfToolBarButtons()
		{
			cancelOrderToolBarButton.Enabled = IsCancelAndModifyOrderAvailable();
			modifyOrderToolBarButton.Enabled = IsCancelAndModifyOrderAvailable();
		}

		#endregion Trading

		#region MarketData

		void SubscribeMarketDataRequest()
		{
			using (MarketDataRequestForm form = new MarketDataRequestForm())
			{
				if (DialogResult.OK == form.ShowDialog())
				{
					marketDataHandler.Subscribe(form.Symbol, form.RequestUpdates);
				}
			}
		}

		void UnsubscribeMarketDataRequest()
		{
			using (MarketDataUnsubscribeRequestForm form = new MarketDataUnsubscribeRequestForm(marketDataHandler.Subscriptions))
			{
				if (DialogResult.OK == form.ShowDialog())
				{
					string symbolAndID = form.Symbol;
					if (!string.IsNullOrEmpty(symbolAndID))
					{
						string symbol = symbolAndID.Substring(0, symbolAndID.IndexOf('-')).Trim();
						marketDataHandler.Unsubscribe(symbol);
					}
				}
			}
		}

		void marketDataHandler_SecurityDefinitionReceived(object sender, MarketDataHandler.SecurityDefinitionArgs args)
		{
			BeginInvoke(new ProcessSecurityDefinitionDelegate(ProcessSecurityDefinition), args);
		}

		void marketDataHandler_TradeReceived(object sender, MarketDataHandler.TradeArgs args)
		{
			BeginInvoke(new ProcessTradeDelegate(ProcessTrade), args);
		}

		void marketDataHandler_PriceChange(object sender, MarketDataHandler.PriceChangeArgs args)
		{
			BeginInvoke(new ProcessPriceChangeDelegate(ProcessPriceChange), args);
		}

		delegate void ProcessPriceChangeDelegate(MarketDataHandler.PriceChangeArgs priceChange);
		delegate void ProcessTradeDelegate(MarketDataHandler.TradeArgs trade);
		delegate void ProcessSecurityDefinitionDelegate(MarketDataHandler.SecurityDefinitionArgs securityDefinition);

		void ProcessSecurityDefinition(MarketDataHandler.SecurityDefinitionArgs securityDefinition)
		{
			securityDefinitionsViewControl.ProcessSecurityDefinition(securityDefinition);
		}

		void ProcessTrade(MarketDataHandler.TradeArgs priceChange)
		{
			tradesViewControl.ProcessTrade(priceChange);
		}


		void ProcessPriceChange(MarketDataHandler.PriceChangeArgs priceChange)
		{
			marketDataView.ProcessPriceChange(priceChange);
		}

		#endregion MarketData

		#region Session Management

		void ConnectTradingSession()
		{
			try
			{
				tradingManager.Connect();
			}
			catch (Exception ex)
			{
				eventView.LogError("Cannot Connect Trading FIX Session: " + ex.Message);
                Trace.TraceError("Cannot Connect Trading FIX Session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Connect Tradiong FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			OnTradingSessionConnectSetMenuItems();

			if (OnConnect != null)
			{
				OnConnect(tradingManager.Session, EventArgs.Empty);
			}
		}

		void DisconnectTradingSession()
		{
			try
			{
				try
				{
					tradingManager.Disconnect();
				}
				catch (Exception ex)
				{
					eventView.LogError("Cannot Disconnect Trading FIX Session: " + ex.Message);
                    Trace.TraceError("Cannot Disconnect Trading FIX Session: " + ex.Message);
                    MessageBox.Show(this, ex.Message, "Cannot Disconnect Tradiong FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			finally
			{
				if (OnDisconnect != null)
					OnDisconnect(tradingManager.Session, EventArgs.Empty);
			}

			OnTradigSessionDisconnectSetMenuItems();
		}

		void ConnectMarketDataSession()
		{
			try
			{
				marketDataHandler.Connect();
			}
			catch (Exception ex)
			{
				eventView.LogError("Cannot Connect Market Data FIX Session: " + ex.Message);
                Trace.TraceError("Cannot Connect Market Data FIX Session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Connect Market Data FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			OnMarketDataSessionConnectSetMenuItems();
		}

		void DisconnectMarketDataSession()
		{
			try
			{
				marketDataHandler.Disconnect();
			}
			catch (Exception ex)
			{
				eventView.LogError("Cannot Disconnect Market Data FIX Session: " + ex.Message);
                Trace.TraceError("Cannot Disconnect Market Data FIX Session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Disconnect Market Data FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			OnMarketDataSessionDisconnectSetMenuItems();
		}

		void OnTradingSessionConnectSetMenuItems()
		{
			disconnectTradingSessionToolStripButton.Enabled = true;
			disconnectTradingSessionToolStripMenuItem.Enabled = true;
			connectTradingSessionToolStripButton.Enabled = false;
			connectTradingSessionToolStripMenuItem.Enabled = false;
			resetTradingSessionToolStripMenuItem.Enabled = false;
			toolStripButtonNewOrder.Enabled = true;
			newOrderToolStripMenuItem.Enabled = true;
			newOrderToolStripMenuItem1.Enabled = true;
			cancelOrderToolStripMenuItem.Enabled = true;
			tradingSessionBreakConnectionToolStripMenuItem.Enabled = true;

			UpdateStateOfToolBarButtons();
		}

		void OnTradigSessionDisconnectSetMenuItems()
		{
			disconnectTradingSessionToolStripButton.Enabled = false;
			disconnectTradingSessionToolStripMenuItem.Enabled = false;
			connectTradingSessionToolStripButton.Enabled = true;
			connectTradingSessionToolStripMenuItem.Enabled = true;
			resetTradingSessionToolStripMenuItem.Enabled = true;
			toolStripButtonNewOrder.Enabled = false;
			newOrderToolStripMenuItem.Enabled = false;
			newOrderToolStripMenuItem1.Enabled = false;
			cancelOrderToolStripMenuItem.Enabled = false;
			cancelOrderToolBarButton.Enabled = false;
			modifyOrderToolBarButton.Enabled = false;
			tradingSessionBreakConnectionToolStripMenuItem.Enabled = false;
		}

		void OnMarketDataSessionConnectSetMenuItems()
		{
			disconnectMarketDataSessionToolStripButton.Enabled = true;
			disconnectMarketDataSessionToolStripMenuItem.Enabled = true;
			subscribeSymbolToolStripMenuItem.Enabled = true;
			subscribeSymbolToolStripButton.Enabled = true;
			unsubscribeToolStripButton.Enabled = true;
			unsubscribeToolStripMenuItem.Enabled = true;
			marketDataBreakConnectionToolStripMenuItem.Enabled = true;

			connectMarketDataSessionToolStripMenuItem.Enabled = false;
			connectMarketDataSessionToolStripButton.Enabled = false;
			marketDataResetToolStripMenuItem.Enabled = false;
		}

		void OnMarketDataSessionDisconnectSetMenuItems()
		{
			disconnectMarketDataSessionToolStripButton.Enabled = false;
			disconnectMarketDataSessionToolStripMenuItem.Enabled = false;
			subscribeSymbolToolStripMenuItem.Enabled = false;
			subscribeSymbolToolStripButton.Enabled = false;
			unsubscribeToolStripButton.Enabled = false;
			unsubscribeToolStripMenuItem.Enabled = false;
			marketDataBreakConnectionToolStripMenuItem.Enabled = false;

			connectMarketDataSessionToolStripMenuItem.Enabled = true;
			connectMarketDataSessionToolStripButton.Enabled = true;
			marketDataResetToolStripMenuItem.Enabled = true;
		}

		public event EventHandler OnConnect;
		public event EventHandler OnDisconnect;

		void ResetSession(Session session)
		{
			try
			{
				session.ResetLocalSequenceNumbers();
			}
			catch (Exception ex)
			{
				eventView.LogError("Cannot Reset FIX session: " + ex.Message);
                Trace.TraceError("Cannot Reset FIX session: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Reset FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void SetSessionsSettings()
		{
			SessionsSettingsForm sessionSettingsForm = new SessionsSettingsForm(tradingManager.Session.InSeqNum, tradingManager.Session.OutSeqNum,
				marketDataHandler.Session.InSeqNum, marketDataHandler.Session.OutSeqNum);

			if (DialogResult.OK == sessionSettingsForm.ShowDialog(this))
			{
				int inSeqNum = sessionSettingsForm.TradingInSeqNum;
				int outSeqNum = sessionSettingsForm.TradingOutSeqNum;
				CreateTradingManager(inSeqNum, outSeqNum);
				inSeqNum = sessionSettingsForm.MarketDataInSeqNum;
				outSeqNum = sessionSettingsForm.MarketDataOutSeqNum;
				CreateMarketDataHandler(inSeqNum, outSeqNum);
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

		void BreakSession(Session session)
		{
			try
			{
				session.BreakConnection();
			}
			catch (Exception ex)
			{
				eventView.LogError("Cannot Break Trading FIX Connection: " + ex.Message);
                Trace.TraceError("Cannot Break Trading FIX Connection: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Break Trading FIX Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion Session Management

		#region Session Event Handlers

		void session_WarningEvent(object sender, WarningEventArgs args)
		{
			eventView.LogWarning(args.ToString());
            Trace.TraceWarning(args.ToString());
        }

        void session_ErrorEvent(object source, FIXForge.NET.FIX.ErrorEventArgs args)
		{
            eventView.LogError(args.ToString());
            Trace.TraceError(args.ToString());
        }

		void tradingSession_StateChangeEvent(object sender, StateChangeEventArgs args)
		{
			eventView.LogInfo(string.Format(CultureInfo.InvariantCulture, "Trading Session state changed from {0} to {1}", args.PrevState, args.NewState));
            Trace.TraceInformation(string.Format(CultureInfo.InvariantCulture, "Trading Session state changed from {0} to {1}", args.PrevState, args.NewState));
            BeginInvoke(new UpdateSesionStateDelegate(SafeUpdateTradingSessionState), args);
		}

		void marketDataSession_StateChangeEvent(object sender, StateChangeEventArgs args)
		{
			eventView.LogInfo(string.Format(CultureInfo.InvariantCulture, "Market Data Session state changed from {0} to {1}", args.PrevState, args.NewState));
            Trace.TraceInformation(string.Format(CultureInfo.InvariantCulture, "Market Data Session state changed from {0} to {1}", args.PrevState, args.NewState));

			if ((SessionState.ACTIVE == args.PrevState) && (SessionState.ACTIVE != args.NewState))
			{
				marketDataView.Reset();
				tradesViewControl.Reset();
				securityDefinitionsViewControl.Reset();
			}
			else if ((SessionState.ACTIVE != args.PrevState) && (SessionState.ACTIVE == args.NewState))
			{
				marketDataHandler.RequestSecurityDefinitions();
			}

			BeginInvoke(new UpdateSesionStateDelegate(SafeUpdateMarketDataSessionState), args);
		}

		delegate void UpdateSesionStateDelegate(StateChangeEventArgs args);

		void SafeUpdateTradingSessionState(StateChangeEventArgs args)
		{
			if (args.NewState == SessionState.DISCONNECTED &&
				args.PrevState != SessionState.DISCONNECTED)
			{
				OnTradigSessionDisconnectSetMenuItems();
				if (OnConnect != null)
					OnConnect(tradingManager.Session, EventArgs.Empty);
			}
			tradingSessionStateToolStripStatusLabel.Text = args.NewState.ToString();
			if (args.NewState == SessionState.ACTIVE)
				tradingSessionStateToolStripStatusLabel.ForeColor = Color.Green;
			else if (args.NewState == SessionState.RECONNECTING)
				tradingSessionStateToolStripStatusLabel.ForeColor = Color.Orange;
			else
				tradingSessionStateToolStripStatusLabel.ForeColor = Color.Black;
		}

		void SafeUpdateMarketDataSessionState(StateChangeEventArgs args)
		{
			if (args.NewState == SessionState.DISCONNECTED &&
				args.PrevState != SessionState.DISCONNECTED)
			{
				OnMarketDataSessionDisconnectSetMenuItems();
			}
			marketDataSessionStateToolStripStatusLabel.Text = args.NewState.ToString();
			if (args.NewState == SessionState.ACTIVE)
				marketDataSessionStateToolStripStatusLabel.ForeColor = Color.Green;
			else if (args.NewState == SessionState.RECONNECTING)
				marketDataSessionStateToolStripStatusLabel.ForeColor = Color.Orange;
			else
				marketDataSessionStateToolStripStatusLabel.ForeColor = Color.Black;
		}

		void session_MessageResendingEvent(object sender, MessageResendingEventArgs e)
		{
            eventView.LogInfo("Resend request for message " + e.Msg);

            e.AllowResending = !IsStale(e.Msg);

            eventView.LogInfo("AllowResending=" + e.AllowResending);
		}

        private bool IsStale(FIXForge.NET.FIX.Message message)
        {
            // Simple sending time based filtering of stale messages.
            DateTime previousSendingTime = message.GetTimestamp(Tags.SendingTime).ToUniversalTime();

            TimeSpan keepingTime = TimeSpan.FromMinutes(30);

            bool isStale = (DateTime.UtcNow - previousSendingTime) >= keepingTime;

            return isStale;

            // More advanced filtering could take into account the message type and/or application-level contents.
        }

		void session_OutboundSessionMsgEvent(object sender, OutboundSessionMsgEventArgs args)
		{
			eventView.LogOutgoingMessage(args.Msg);
		}

		void session_OutboundApplicationMsgEvent(object sender, OutboundApplicationMsgEventArgs args)
		{
			eventView.LogOutgoingMessage(args.Msg);
		}

		void session_InboundSessionMsgEvent(object sender, InboundSessionMsgEventArgs args)
		{
			eventView.LogIncomingMessage(args.Msg);
		}

		void session_InboundApplicationMsgEvent(object sender, InboundApplicationMsgEventArgs args)
		{
			eventView.LogIncomingMessage(args.Msg);
		}

		#endregion Session Event Handlers

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIXTradingExample
{
  class ExampleApplication : QuickFix44.MessageCracker, QuickFix.Application
  {
    // delegate and event variable for the LoginComplete event
    public delegate void LoginComplete();
    public event LoginComplete loginComplete;
    // delegate and event variable for the MessageRecieved event
    public delegate void MessageRecieved(QuickFix.Message message);
    public event MessageRecieved messageRecieved;

    private const int REQUEST_LIST_OF_TRADING_SESSIONS = 5;
    private DateTime sessionStart;
    private QuickFix.SessionSettings settings;
    private QuickFix44.TradingSessionStatus sessionStatus;
    private long requestID = 0L;
    private QuickFix.SessionID sessionID;
    private QuickFix.SessionID sessionID_md;
    private String username, password;
    private Boolean newAccountReq = false, exampleRunning = false;
    private QuickFix.SubscriptionRequestType subscriptionType = new QuickFix.SubscriptionRequestType(QuickFix.SubscriptionRequestType.SNAPSHOT_PLUS_UPDATES);

    private QuickFix.Symbol[] instruments;
    public string _mdSession = "MD_";

    /**
     * Constructor. Send the constructed SessionSettings
     */
    public ExampleApplication(QuickFix.SessionSettings settings)
    {
        this.settings = settings; // keep the passed settings locally
        this.username = this.settings.get().getString("Username"); // extract the username from the settings
        this.password = this.settings.get().getString("Password"); // extract the password from the settings
        if ( Convert.ToInt32(this.settings.getSessions().Count) > 1)
        {
            if (this.settings.getSessions()[0].ToString().Contains(_mdSession))
            {
                sessionID_md = (QuickFix.SessionID)this.settings.getSessions()[0];
                sessionID = (QuickFix.SessionID)this.settings.getSessions()[1];
            }

            if (this.settings.getSessions()[1].ToString().Contains(_mdSession))
           {
                sessionID_md = (QuickFix.SessionID)this.settings.getSessions()[1];
                sessionID = (QuickFix.SessionID)this.settings.getSessions()[0];
            }
        }
        else
            sessionID = (QuickFix.SessionID)this.settings.getSessions()[0];
    }

    #region Misc Functions
    /**
     * Retrieve the next request counter
     */
    private long nextID()
    {
      // increment the local long id counter
      requestID++;
      // if the long request id is nearing Long.MAX_VALUE 
      if (requestID > (long.MaxValue - 2))
        // reset back to one
        requestID = 1;
      // return the new request id
      return requestID;
    }

    /**
     * return the current UTC date in yyyymmdd format
     */
    private String getDate()
    {
      return DateTime.UtcNow.Year.ToString() + DateTime.UtcNow.Month.ToString("00") + DateTime.UtcNow.Day.ToString("00");
    }

    /**
     * Add the missing tags to the message header, in this case the TargetSubID
     */
    private void setHeader(QuickFix.Message message, QuickFix.SessionID session)
    {
        message.getHeader().setField(new QuickFix.TargetSubID(settings.get(session).getString("TargetSubID")));
    }

    /**
     * Send a Message to the API
     */
    public void send(QuickFix.Message message, QuickFix.SessionID session)
    {
      try
      {
            // send the message to the api
            QuickFix.Session.sendToTarget(message, session);
      }
      catch (Exception e) { }
    }
    #endregion

    #region Example Trading functions
    public void exampleTrading(AccountsWindow accounts, RatesWindow rates, char direction)
    {
      exampleRunning = true;
      if (instruments == null) instruments = rates.symbols();
      foreach (QuickFix.Symbol instrument in rates.symbols())
      {
        // place a market order on each available account
        foreach (QuickFix.Account account in accounts.accounts())
        {
          // create a NewOrderSingle Market
          QuickFix44.NewOrderSingle order = new QuickFix44.NewOrderSingle(
            new QuickFix.ClOrdID(sessionID + "-" + DateTime.Now.Ticks + "-" + nextID().ToString()),
            new QuickFix.Side(direction),
            new QuickFix.TransactTime(),
            new QuickFix.OrdType(QuickFix.OrdType.MARKET)
          );
          order.set(account);
          order.set(instrument);
          // get the minimum quantity from the RatesWindow
          order.set(new QuickFix.OrderQty(rates.minQty(instrument)));
          order.set(new QuickFix.TimeInForce(QuickFix.TimeInForce.GOOD_TILL_CANCEL));
          order.set(new QuickFix.SecondaryClOrdID("fix_example_test"));
          // sent the order to the API
          send(order, sessionID);
          // write note to the log
          Console.WriteLine(
            "An order for {0:N0} {1} on {2} placed on {3}",
            order.getOrderQty().getValue(),
            ((order.getSide().getValue() == 2) ? "Sell" : "Buy"),
            order.getSymbol().getValue(),
            order.getAccount().getValue()
          );
        }
      }
    }
    #endregion

    #region Application member Functions
    /**
     * This method is called when quickfix creates a new session. A session comes into and remains in existence
     * for the life of the application. Sessions exist whether or not a counter party is connected to it. As soon
     * as a session is created, you can begin sending messages to it. If no one is logged on, the messages will be
     * sent at the time a connection is established with the counterparty.
     */
    public void onCreate(QuickFix.SessionID session)
    {
        if (session.ToString().Contains(_mdSession))
           this.sessionID_md = session;
        else
            this.sessionID = session;

        // send notification
        Console.WriteLine("Session created " + session);
    }

    /**
     * This callback notifies you when a valid logon has been established with a counter party. This is called
     * when a connection has been established and the FIX logon process has completed with both parties exchanging
     * valid logon messages.
     */
    public void onLogon(QuickFix.SessionID session)
    {
      // send notification
      Console.WriteLine("Login begun for " + this.username);
      // set the time that the current session started
      sessionStart = DateTime.Now;
      // configure and send a UserRequest to complete login
      QuickFix44.UserRequest userRequest = new QuickFix44.UserRequest();
      // set the UserRequestType to the custom value for retail
      userRequest.setInt(QuickFix.UserRequestType.FIELD, REQUEST_LIST_OF_TRADING_SESSIONS);
      // set the RequestID
      userRequest.setString(QuickFix.UserRequestID.FIELD, nextID().ToString());
      // set the Username
      userRequest.setString(QuickFix.Username.FIELD, this.username);
      // set the Password
      userRequest.setString(QuickFix.Password.FIELD, this.password);
      // send notification
      Console.WriteLine("Sending UserRequest");
      // send the request to the API
      send(userRequest, session);
    }

    /**
     * This callback notifies you when an FIX session is no longer online. This could happen during a normal
     * logout exchange or because of a forced termination or a loss of network connection.
     */
    public void onLogout(QuickFix.SessionID session)
    {
      // send notification
      Console.WriteLine("Logout " + session.ToString());
    }

    /**
     * This is one of the core entry points for your FIX application. Every application level request will come
     * through here. If, for example, your application is a sell-side OMS, this is where you will get your new
     * order requests. If you were a buy side, you would get your execution reports here. If a FieldNotFound
     * exception is thrown, the counterparty will receive a reject indicating a conditionally required field is
     * missing. The Message class will throw this exception when trying to retrieve a missing field, so you will
     * rarely need the throw this explicitly. You can also throw an UnsupportedMessageType exception. This will
     * result in the counterparty getting a reject informing them your application cannot process those types of
     * messages. An IncorrectTagValue can also be thrown if a field contains a value that is out of range or you
     * do not support.
     */
    public void fromApp(QuickFix.Message message, QuickFix.SessionID session)
    {
      try
      {
        // attempt to process the message through the MessageCracker root object
        // and send the result through the onMessage functions
        this.crack(message, session);
      }
      catch (Exception e) { Console.WriteLine(e.ToString()); }
    }

    /**
     * This callback notifies you when an administrative message is sent from a counterparty to your FIX engine.
     * This can be usefull for doing extra validation on logon messages such as for checking passwords. Throwing
     * a RejectLogon exception will disconnect the counterparty.
     */
    public void fromAdmin(QuickFix.Message message, QuickFix.SessionID session)
    {
      try
      {
        // attempt to process the message through the MessageCracker root object
        // and send the result through the onMessage functions
        this.crack(message, session);
      }
      catch (Exception e) { Console.WriteLine(e.ToString()); }
    }

    /**
     * This callback provides you with a peak at the administrative messages that are being sent from your FIX
     * engine to the counter party. This is normally not useful for an application however it is provided for
     * any logging you may wish to do. Notice that the FIX::Message is not const. This allows you to add fields
     * before an adminstrative message before it is sent out.
     */
    public void toAdmin(QuickFix.Message message, QuickFix.SessionID session)
    {
          // add the TargetSubID to the messsage
          setHeader(message, session);
    }

    /**
     * This is a callback for application messages that you are being sent to a counterparty. If you throw a
     * DoNotSend exception in this function, the application will not send the message. This is mostly useful if
     * the application has been asked to resend a message such as an order that is no longer relevant for the
     * current market. Messages that are being resent are marked with the PossDupFlag in the header set to true;
     * If a DoNotSend exception is thrown and the flag is set to true, a sequence reset will be sent in place of
     * the message. If it is set to false, the message will simply not be sent. Notice that the FIX::Message is
     * not const. This allows you to add fields before an application message before it is sent out.
     */
    public void toApp(QuickFix.Message message, QuickFix.SessionID session)
    {
        // add the TargetSubID to the messsage
        setHeader(message, session);
    }
    #endregion

    #region MessageCracker member functions
    /**
     * Retrieve and process the user requests. Initially part of the login process
     */
    public override void onMessage(QuickFix44.UserResponse response, QuickFix.SessionID session)
    {
      // send notification
      Console.WriteLine("UserResponse received");
      // check if the credentials used have been accepted
      if (response.getInt(QuickFix.UserStatus.FIELD) == QuickFix.UserStatus.LOGGED_IN)
      {
        // create a new TradingSessionStatusRequest
        QuickFix44.TradingSessionStatusRequest statusRequest = new QuickFix44.TradingSessionStatusRequest();
        // set the RequestID
        statusRequest.set(new QuickFix.TradSesReqID(this.username + "_TSSR_" + nextID()));
        // set the subscription type
        statusRequest.set(subscriptionType);
        // send notification
        Console.WriteLine("TradingSessionStatusRequest sent");
        // send the message to the API
        send(statusRequest, session);
      }
    }

    /**
     * Capture and process the trading session status updates, part of the login process
     */
    public override void onMessage(QuickFix44.TradingSessionStatus status, QuickFix.SessionID session)
    {
      // send notification
      Console.WriteLine("TradingSessionStatus received");
      sessionStatus = status;

      // subscribe to CollateralReports
      QuickFix44.CollateralInquiry collateralInq = new QuickFix44.CollateralInquiry();
      collateralInq.set(new QuickFix.CollInquiryID(nextID().ToString()));
      collateralInq.set(subscriptionType);
      send(collateralInq, session);

      // create a MarketDataRequest to subscribe
      QuickFix44.MarketDataRequest dataRequest = new QuickFix44.MarketDataRequest();
      dataRequest.set(new QuickFix.MDReqID(nextID().ToString()));
      dataRequest.set(new QuickFix.MarketDepth(1)); // top of book is only choice for retail
      dataRequest.set(new QuickFix.MDUpdateType(QuickFix.MDUpdateType.FULL_REFRESH));
      dataRequest.set(subscriptionType);
      // add the type of entries desired in the refresh
      // bid
      QuickFix44.MarketDataRequest.NoMDEntryTypes entryTypes;
      entryTypes = new QuickFix44.MarketDataRequest.NoMDEntryTypes();
      entryTypes.set(new QuickFix.MDEntryType(QuickFix.MDEntryType.BID));
      dataRequest.addGroup(entryTypes);
      // ask
      entryTypes = new QuickFix44.MarketDataRequest.NoMDEntryTypes();
      entryTypes.set(new QuickFix.MDEntryType(QuickFix.MDEntryType.OFFER));
      dataRequest.addGroup(entryTypes);
      // go through the sessionStatus in order to name each instrument to subscribe to
      for (uint g = 1; g <= sessionStatus.getField(new QuickFix.IntField(QuickFix.NoRelatedSym.FIELD)).getValue(); g++)
      {
        QuickFix44.SecurityList.NoRelatedSym relatedSymbols = new QuickFix44.SecurityList.NoRelatedSym();
        QuickFix44.SecurityList.NoRelatedSym symbolGroup = (QuickFix44.SecurityList.NoRelatedSym)sessionStatus.getGroup(g, relatedSymbols);
        QuickFix44.MarketDataRequest.NoRelatedSym instrument = new QuickFix44.MarketDataRequest.NoRelatedSym();

            instrument.set(symbolGroup.getSymbol());
            dataRequest.addGroup(instrument);

      }
      // send notification
      Console.WriteLine("MarketDataRequest sent");
      // send message to the API
      send(dataRequest, sessionID_md);
      // fire an event that the login is complete
      if (this.loginComplete != null) this.loginComplete();
    }

    /**
     * Retrieve and process the requests for collateral reports on this session, adding
     * each to the internal map
     */
    public override void onMessage(QuickFix44.CollateralReport report, QuickFix.SessionID session)
    {
      if (newAccountReq) // only if the CollateralReport is newly requested
      {
        // create a new RequestForPositions
        QuickFix44.RequestForPositions req = new QuickFix44.RequestForPositions(
          new QuickFix.PosReqID(nextID().ToString()),
          new QuickFix.PosReqType(QuickFix.PosReqType.POSITIONS),                                         // open positions
          report.getAccount(),                                                                            // the account
          new QuickFix.AccountType(
            QuickFix.AccountType.ACCOUNT_IS_CARRIED_ON_NON_CUSTOMER_SIDE_OF_BOOKS_AND_IS_CROSS_MARGINED), // this AccountType is required
          new QuickFix.ClearingBusinessDate(getDate()), // limits the scope to the current day, still max of 300 records
          new QuickFix.TransactTime()
        );
        req.set(subscriptionType); // set the subscription type
        // send to the API
        send(req, session);
        // create another RequestForPositions
        req = new QuickFix44.RequestForPositions(
          new QuickFix.PosReqID(nextID().ToString()),
           new QuickFix.PosReqType(QuickFix.PosReqType.TRADES),                                           // closed positions
          report.getAccount(),                                                                            // the account
          new QuickFix.AccountType(
            QuickFix.AccountType.ACCOUNT_IS_CARRIED_ON_NON_CUSTOMER_SIDE_OF_BOOKS_AND_IS_CROSS_MARGINED), // this AccountType is required
          new QuickFix.ClearingBusinessDate(getDate()), // limits the scope to the current day, still max of 300 records
         new QuickFix.TransactTime()
        );
        req.set(subscriptionType); // set the subscription type
        // send to the API
        send(req, session);
        // change whether these requests will be sent based on whether the current report is the last requested
        newAccountReq = !report.getLastRptRequested().getValue();
      }      
      // fire an event that a collateral report is updated
      if (this.messageRecieved != null) this.messageRecieved(report);
    }
  
    /**
     * Process market data snapshots, taking from each message the instrument update and adding to the 
     * internal map
     */
    public override void onMessage(QuickFix44.MarketDataSnapshotFullRefresh snapshot, QuickFix.SessionID session)
    {
      // fire an event that an instrument has updated
      if (this.messageRecieved != null && !exampleRunning) this.messageRecieved(snapshot);
    }

    /**
     * Process the Execution reports, adding them to the internal orders map
     */
    public override void onMessage(QuickFix44.ExecutionReport report, QuickFix.SessionID session)
    {
      // fire an event that a new message arrived
      if (this.messageRecieved != null) this.messageRecieved(report);
      // add a note regarding the order to the log window
      Console.WriteLine(
        "An order for {0:N0} {1} on {2} placed on {3} with ID {4} updated as {5}",
        report.getOrderQty().getValue(),
        ((report.getSide().getValue() == 2) ? "Sell" : "Buy"),
        report.getSymbol().getValue(),
        report.getAccount().getValue(),
        report.getOrderID().getValue(),
        report.getString(9051) // FXCMOrdStatus
     );
    }
  
    /**
     * Process the Position reports, adding them to the internal positoins map
     */
    public override void onMessage(QuickFix44.PositionReport report, QuickFix.SessionID session)
    {
      // fire an event that a new message arrived
      if (this.messageRecieved != null) this.messageRecieved(report);
      // write to the Console a note about the report
      try
      {
        //Console.WriteLine(
        //  "A position {0} updated on {1} for account {2} with PL {3:N2}",
        //  report.getString(9041), // FXCMPosID
        //  report.getSymbol().getValue(),
        //  report.getAccount().getValue(),
        //  report.getDouble(9052) // FXCMPosClosePNL
        //);
      }
      catch (Exception e)
      {
        Console.WriteLine(
          "A position {0} updated on {1} for account {2}",
          report.getString(9041), // FXCMPosID
          report.getSymbol().getValue(),
          report.getAccount().getValue()
        );
      }
    }

    /**
     * The acknowledgement of the CollateralInquiry. Triggers a value to inititate the subscription
     * to PositionReports
     */
    public override void onMessage(QuickFix44.CollateralInquiryAck ack, QuickFix.SessionID session)
    {
      newAccountReq = true;
    }

    /**
     * The acknowledgement of the RequestForPositions. The state answers whether there will be PositionReports
     * sent for the request.
     */
    public override void onMessage(QuickFix44.RequestForPositionsAck ack, QuickFix.SessionID session) { }
    #endregion
  }
}

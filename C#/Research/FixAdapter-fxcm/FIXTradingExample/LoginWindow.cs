using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuickFix44;
using System.Collections;

namespace FIXTradingExample
{
  public partial class LoginWindow : Form
  {
    delegate void SetTextCallback(String text);
    delegate void ToggleBtnCallback(Button btn, Boolean state);

    private RatesWindow ratesWindow = new RatesWindow();
    private TradesWindow tradeWindow = new TradesWindow();
    private AccountsWindow accountsWindow = new AccountsWindow();
    private QuickFix.SocketInitiator initiator;
    private ExampleApplication app;
    private System.IO.TextWriter originalOut = Console.Out;

    #region Controls
    /**
     * Constructor
     */ 
    public LoginWindow()
    {
      InitializeComponent();
      // display warning
      MessageBox.Show(
        "The FIX Protocol is designed for realtime transactions.\n" +
        "While attempts were made in order to be thread-safe, there\n" +
        "is a delay in the receipt and processing of ExecutionReport,\n" + 
        "CollateralReport, and PositionReport messages when redirecting the\n" +
        "Console due to both the volume of orders sent and the limitations of\n" +
        ".Net languages.",
        "FIXTradingExample", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /**
     * Login button
     */
    private void btnLogin_Click(object sender, EventArgs e)
    {
      // disable the login button
      toggleBtn(btnLogin, false);
      // enable the logout button
      toggleBtn(btnLogout, true);
      try
      {
        // load the settings from file
        QuickFix.SessionSettings settings = new QuickFix.SessionSettings("fix.cfg");
        // create a MessageStoreFactory from settings
        QuickFix.MessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
        // create a LogFactory from settings using a file instead of screen
        QuickFix.LogFactory logFactory = new QuickFix.FileLogFactory(settings);
        // create a MessageFactory
        QuickFix.MessageFactory messageFactory = new QuickFix.DefaultMessageFactory();
        // (re)initialize the application based on settings
        app = new ExampleApplication(settings);
        // set a listener for events
        app.loginComplete += new ExampleApplication.LoginComplete(loginComplete);
        app.messageRecieved += new ExampleApplication.MessageRecieved(processEvent);
        // (re)initialize the initiator
        initiator = new QuickFix.SocketInitiator(app, storeFactory, settings, logFactory, messageFactory);
        // start, or login, to the API through the initiator
        initiator.start();
        // display the supporting windows
        ratesWindow.Show();
        tradeWindow.Show();
        accountsWindow.Show();
      }
      catch (Exception evt) { Console.WriteLine(evt); }
    }

    /**
     * Start the Application exampleTrading function
     */ 
    private void btnRunExample_Click(object sender, EventArgs e)
    {
      // send short orders on first 15 instruments for each account
      app.exampleTrading(accountsWindow, ratesWindow, QuickFix.Side.SELL);
      // wait 5 seconds
      System.Threading.Thread.Sleep(5000);
      // send long orders on first 15 instruments for each account
      app.exampleTrading(accountsWindow, ratesWindow, QuickFix.Side.BUY);
    }
 
    /**
     * Logout button
     */
    private void btnLogout_Click(object sender, EventArgs e)
    {
      // change the enabled state of three of the control buttons
      toggleBtn(btnLogin, true);
      toggleBtn(btnRunExample, false);
      toggleBtn(btnLogout, false);
      // attempt to forcably log out of the initiator
      initiator.stop();
    }
    #endregion

    #region Events listened to
    /**
     * Handles the event fired by the Application when the login is complete
     */
    public void loginComplete()
    {
      // allow for the RubExample button to be clicked
      toggleBtn(btnRunExample, true);
    }

    /**
     * Receive QuickFix.Message objects from the Application in order to update the
     * respective windows.
     */ 
    private void processEvent(QuickFix.Message message)
    {
      if (message is QuickFix44.MarketDataSnapshotFullRefresh) ratesWindow.update((QuickFix44.MarketDataSnapshotFullRefresh)message);
      else if (message is QuickFix44.CollateralReport) accountsWindow.update((QuickFix44.CollateralReport)message);
      else if (message is QuickFix44.ExecutionReport) tradeWindow.update((QuickFix44.ExecutionReport)message);
      else if (message is QuickFix44.PositionReport) tradeWindow.update((QuickFix44.PositionReport)message);
      //Application.DoEvents(); // call for the interface to update
    }
    #endregion

    /**
     * Change the enabled state of a button, thread-safe
     */ 
    public void toggleBtn(Button btn, Boolean state)
    {
      if (btn.InvokeRequired)
      {
        ToggleBtnCallback d = new ToggleBtnCallback(toggleBtn);
        this.Invoke(d, new object[] { btn, state });
      }
      else
        btn.Enabled = state;
    }

    /**
     * Add test to the txtActions 'log' control, thread-safe
     */
    public void SetText(String text)
    {
      if (txtActions.InvokeRequired)
      {
        SetTextCallback d = new SetTextCallback(SetText);
        this.Invoke(d, new object[] { text });
      }
      else
        txtActions.AppendText(text);
    }

    private void chkRedirect_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox chkBox = (CheckBox)sender;
      if (chkBox.Checked)
      {
        // redirect the console to txtAction
        Console.SetOut(new TextBoxStreamWriter(this));
      }
      else
      {
        // redirect the console to the original
        Console.SetOut(originalOut);
      }
    }
  }
}
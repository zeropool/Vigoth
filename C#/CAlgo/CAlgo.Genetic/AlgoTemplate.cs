////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////                                                                                                        ////
////                        Name :  TEMPLATE FILE FOR CODING                                                ////
////                        Dated :  01-Mar-16                                                              ////
////                        ver   :  1.0                                                                    ////
////                        Updated : 01-Mar-16                                                             ////
////                                                                                                        ////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Globalization;
using System.IO;
using System.Threading;
using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;


namespace cAlgo
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.FullAccess)]

    public class SK_cBOT_Template : Robot
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        USER INPUT                                                                            ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Parameter("<--------------> FRIDAY <-------------->")]
        public string temp50 { get; set; }

        [Parameter("43. Close on Friday (yes or no)", DefaultValue = false)]
        public bool p_Flag_CloseFriday { get; set; }

        [Parameter("44. Close On Friday (x hours)", DefaultValue = 2, MinValue = 1, MaxValue = 10)]
        public int p_FridayClose_Hrs { get; set; }

        [Parameter("45. Write Data to CSV File ", DefaultValue = false)]
        public bool p_Flag_Create_CSV_File { get; set; }

        [Parameter("46. Folder Name on the Desktop ", DefaultValue = "BackTesting")]
        public string p_str_Folder_Name { get; set; }

        [Parameter("47. Live (No),   BackTesting (Yes)", DefaultValue = false)]
        public bool p_Flag_BackTesting { get; set; }

        ///////////////////////////////////
        // END OF USER INPUT          /////
        ///////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        GLOBAL VARIABLES                                                                      ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private int Current_TimeFrame;
        //For Indexng of MarketSeries
        private int Count_Bar = 0;
        private double Daily_Count_Bar = 0;

        ////////////////////////////////////////////////////////////////////////////////////////////
        // CSV FILE CREATION
        private static string str_DesktopFolder;
        private static string str_FolderPath;
        private static string str_FileName;
        private System.IO.FileStream File_Stream;
        private System.IO.StreamWriter File_Writer;
        //*Important : These File_Stream and File_Writer has to be closed On_Stop function. 
        //see On_Stop function in the END
        ////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////
        //  END OF GLOBAL VARIABLES   /////
        ///////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ON START                                                                              ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnStart()
        {
            //WRITE FIXED VALUE ON CHART SCREEN
            Create_Fixed_Display();

            //DISPLAY START DATE AND TIME
            string t_Date = string.Format("{0:ddd-d-MMMM-y,h:mm tt}", Server.Time);
            Draw_OnChart_C1(t_Date, 1, 5);

            Print("");
            Print("cBOT Start Date & Time : " + t_Date);

            //Get the Chart Time FRAME
            Current_TimeFrame = Get_TimeFrame(TimeFrame.ToString());
            //Set the Count Bar Value for MarketSeries
            Set_Count_Bar_Value();

            if (p_Flag_Create_CSV_File)
            {
                Create_CSV_File();
            }
            //END IF

        }
        //End FUNCTION On_Start

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ON       B A R                                                                        ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnBar()
        {
            // Put your core logic here
        }
        //END Function On_Bar

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ON       T I C K                                                                      ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnTick()
        {
            // Put your core logic here
        }
        //End FUNCTION On_TICK

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ON POSITION CLOSED                                                                    ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void OnPositionsClosed(PositionClosedEventArgs args)
        {
            var pos = args.Position;


            //if (pos.Label == label && pos.SymbolCode == Symbol.Code)
            //{
            if (pos.TradeType == TradeType.Buy)
            {
                //if (pos.Pips <= StopLoss_1)
                //{
                //Logic for counting Buy Positions Stop-Loss Hit
                //}
                //if (pos.Pips >= TakeProfit_1)
                //{
                //Logic for counting Buy Positions Take-Loss Hit
                //}
            }
            if (pos.TradeType == TradeType.Buy)
            {
                //if (pos.Pips <= SellStopLoss)
                //{
                //Logic for counting SELL Positions Stop-Loss Hit
                //}
                //if (pos.Pips >= SellTakeProfit)
                //{
                //Logic for counting SELL Positions TAKE-Loss Hit
                //}
            }
            //}

            //Refresh Order count
            //Refresh_Order_Count();
        }
        //END Function OnPositionsClosed



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        CLOSE ALL PENDING ORDERS                                                              ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //CLOSE-ALL PENDING-ORDERS OF THE LABEL DEFINED IN (t_Label)
        private void CloseAll_PendingOrders(string t_Label)
        {
            //Print Message and SERVER Date Time to Log files
            string tempText1 = string.Format("{0:ddd-d-MMM-y,h:mm tt}", Server.Time);
            //Print("Close-Selected ''Pending-Orders''. Server Date & Time = " + tempText1 + ",----> P-Order Label : " + t_Label);

            foreach (var pen in PendingOrders)
            {
                if (pen.Label == t_Label)
                {
                    CancelPendingOrder(pen);
                }
                //END IF
            }
            //END FOR_EACH
        }
        //END Function CLOSE_ALL_Pending_Orders
        ////////////////////////////////////////////////////////////////////////////////////////////
        //CLOSE-ALL PENDING-ORDERS IRRESPECTIVE OF THE LABEL
        private void CloseAll_PendingOrders()
        {
            foreach (var pen in PendingOrders)
            {
                CancelPendingOrderAsync(pen);
            }
            //END FOR-EACH
        }
        //END FUNCTION CloseAll_PendingOrders

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        CLOSE ALL POSITIONS                                                                   ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////       
        //CLOSE-ALL TRADES OF THE LABEL DEFINED IN (t_Label)
        private void CloseAll_Positions(string t_Label)
        {
            //Print Message and Date Time to Log files
            string tempText1 = string.Format("{0:ddd-d-MMM-y,h:mm tt}", Server.Time);
            //Print("Close-Selected ''Running-Positions''. Server Date & Time = " + tempText1 + ",----> Running Position Label : " + t_Label);

            foreach (var pos in Positions)
            {
                if (pos.Label == t_Label)
                {
                    ClosePosition(pos);
                }
                //END IF
            }
            //END FOR_EACH
        }
        //END FUNCTION CLOSE_ALL_Open_Position
        ////////////////////////////////////////////////////////////////////////////////////////////
        //CLOSE-ALL POSITIVE OR NEGATIVE TRADES IRRESPECTIVE OF THE LABEL
        private void CloseAll_Positions(bool Flag_Profit_Loss)
        {
            foreach (var pen in Positions)
            {
                //IF POSITIVE VALUE
                if (Flag_Profit_Loss)
                    if (pen.NetProfit >= 0)
                        ClosePositionAsync(pen);

                //IF NEGATIVE VALUE
                if (!Flag_Profit_Loss)
                    if (pen.NetProfit <= 0)
                        ClosePositionAsync(pen);
            }
            //END FOR-EACH
        }
        //END FUNCTION CloseAll_Positions
        ////////////////////////////////////////////////////////////////////////////////////////////
        //CLOSE PROFITABLE OR NEGATIVE TRADE THAT ARE ABOVE/BELOW THE TARGET VALUE (t_Target)
        private void CloseAll_Positions(int t_Target)
        {
            foreach (var pen in Positions)
            {
                //IF POSITIVE VALUE
                if (t_Target >= 0)
                    if (pen.NetProfit >= t_Target)
                        ClosePositionAsync(pen);

                //IF NEGATIVE VALUE
                if (t_Target < 0)
                    if (pen.NetProfit <= t_Target)
                        ClosePositionAsync(pen);
            }
            //END FOR-EACH
        }
        //END FUNCTION CloseAll_Positions
        ////////////////////////////////////////////////////////////////////////////////////////////  
        //CLOSE TRADE WITH DEFINED LABEL (t_str1) AND THOSE THAT ARE ABOVE/BELOW THE TARGET VALUE (t_Target )
        private void CloseAll_Positions(string t_str1, int t_Target)
        {
            foreach (var pen in Positions)
            {
                //IF POSITIVE VALUE
                if (t_Target >= 0)
                    if ((pen.Label == t_str1) && (pen.NetProfit >= t_Target))
                        ClosePositionAsync(pen);

                //IF NEGATIVE VALUE
                if (t_Target < 0)
                    if ((pen.Label == t_str1) && (pen.NetProfit <= t_Target))
                        ClosePositionAsync(pen);

            }
            //END FOR-EACH
        }
        //END FUNCTION CloseAll_Positions


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        WRITE CANDLE DATA TO CSV FILE                                                         ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
        protected void Write_To_CSV_File()
        {
            //>>>>>>>>>>>>>>>>>>>>>>
            //THIS FUNCTION WILL WRITE ALL THE DATA TO CSV FILE
            //>>>>>>>>>>>>>>>>>>>>>>

            ////////////////////////////////////////
            ///   WRITE DATA TO CSV FILE     ///////
            ////////////////////////////////////////
            if (p_Flag_Create_CSV_File)
            {

                //WRITE CURRENT DATA
                File_Writer.WriteLine(Concate_With_Comma());

            }
            //END IF

        }
        //End FUNCTION Write_To_CSV_File  

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        CREATE CSV FILE                                                                       ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////       
        protected void Create_CSV_File()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //Server Time Recod
            string str_temp1 = string.Format("{0:ddd-d-MMM-y}", Server.Time);

            //Desktop Folder PATH and NAME
            str_DesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            str_FolderPath = Path.Combine(str_DesktopFolder, p_str_Folder_Name);

            //Create Directory and make the file name
            Directory.CreateDirectory(str_FolderPath);
            str_FileName = Path.Combine(str_FolderPath, Symbol.Code + " " + TimeFrame + " " + str_temp1 + ".csv");

            //Print("File Path : " + str_FilePath);

            //Create or OVER RIDE Existing FILE and then Close it which is a must.
            File_Stream = File.Create(str_FileName);
            File_Stream.Close();

            //Open File to prevent .NET from locking it and preventing access by other processes
            File_Stream = File.Open(str_FileName, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);

            //Seek End of File to write
            File_Stream.Seek(0, SeekOrigin.End);

            //File Writer Stream to be created.
            File_Writer = new System.IO.StreamWriter(File_Stream, System.Text.Encoding.UTF8, 1);

            //Auto Flush to improve IO performance
            File_Writer.AutoFlush = true;
        }
        //End FUNCTION Create_CSV_File

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ON STOP                                                                               ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnStop()
        {
            string temp_Text = string.Format("{0:ddd-d-MMM-y,h:mm tt}", Server.Time);
            Print("cBOT ''onStop'' Stop Date & time : " + temp_Text);

            ////////////////////////////////////////
            ///   WRITE DATA TO CSV FILE     ///////
            ////////////////////////////////////////
            if (p_Flag_Create_CSV_File)
            {
                File_Writer.WriteLine(Concate_With_Comma());
            }
            //END IF

            ///////////////////////////////////////////
            //CLOSE FILE STREM AND WRITER
            //File_Stream.Close();
            //File_Writer.Close();
            // LOG FILE giving error on usign the above
            ////////////////////////////////////////////

            //BLANK LINE
            Print("");
        }
        //END Function On_STOP

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ADD COMMA TO THE STRING FUNCITON                                                       //////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private string Concate_With_Comma(params object[] parameters)
        {
            return string.Join(",", parameters.Select(p => p.ToString()));
        }
        //End of FUNCTION CONCAT_WITH_COMMA

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        GET TIME FRAME INTEGER VALUE                                                           //////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private int Get_TimeFrame(string temp_Str)
        {
            Print("METHOD CALLED : Get_TimeFRAME = " + temp_Str);

            bool temp_Flag_OK = false;

            if (temp_Str == "Minute")
            {
                temp_Flag_OK = true;
                return 1;
            }
            if (temp_Str == "Minute5")
            {
                temp_Flag_OK = true;
                return 5;
            }
            //End if
            if (temp_Str == "Minute10")
            {
                temp_Flag_OK = true;
                return 10;
            }
            //End if
            if (temp_Str == "Minute15")
            {
                temp_Flag_OK = true;
                return 15;
            }
            //End if
            if (temp_Str == "Minute20")
            {
                temp_Flag_OK = true;
                return 20;
            }
            //End if
            if (temp_Str == "Minute30")
            {
                temp_Flag_OK = true;
                return 30;
            }
            //End if
            if (temp_Str == "Hour")
            {
                temp_Flag_OK = true;
                return 60;
            }
            //End if
            if (temp_Str == "Hour4")
            {
                temp_Flag_OK = true;
                return 240;
            }
            //End if
            if (temp_Str == "Daily")
            {
                temp_Flag_OK = true;
                return 1440;
            }
            //End if

            //Handle ERROR
            if (temp_Flag_OK == false)
            {
                Print("");
                Print("<----ERROR---->  The Selected TIME FRAME is 'NOT' HANDLED by the cBOT  <----ERROR---->");
                Print("");
                Stop();
            }
            //End if

            return 0;
        }
        //END FUNCTION GET_TIME_FRAME

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        Set the Count Bar Value for Market Series Function                                     //////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Set_Count_Bar_Value()
        {
            Count_Bar = MarketSeries.Close.Count - 1;
            Daily_Count_Bar = 1;
            Print("Count_Bar Value = " + Count_Bar + ",     Daily_Count_Bar = " + Daily_Count_Bar);
            Print("");
        }
        //End FUNCTION Set_Count_Bar_Value

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                               SET TEXT, TAB AND NEXT LINE SETTING                           ///////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Draw_OnChart_C1(string t_Text, int Line_No, int Tab_Pos)
        {
            //CREATE A UNIQUE OBJECT NAME FOR THE METHOD ChartObjects.DrawText
            string tstr_1 = "";
            tstr_1 = Line_No.ToString() + Tab_Pos.ToString();

            ChartObjects.DrawText(tstr_1, my_NL(Line_No) + my_Tabs(Tab_Pos) + t_Text, StaticPosition.TopLeft, Colors.Aqua);
        }
        //END FUNCTION
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Draw_OnChart_C2(string t_Text, int Line_No, int Tab_Pos)
        {
            //CREATE A UNIQUE OBJECT NAME FOR THE METHOD ChartObjects.DrawText
            string tstr_1 = "";
            tstr_1 = Line_No.ToString() + Tab_Pos.ToString();

            ChartObjects.DrawText(tstr_1, my_NL(Line_No) + my_Tabs(Tab_Pos) + t_Text, StaticPosition.TopLeft, Colors.Beige);
        }
        //END FUNCTION
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static string my_Tabs(int n)
        {
            return new String('\t', n);
        }
        //END FUNCITON my_Tabs
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static string my_NL(int n)
        {
            return new String('\n', n);
        }
        //END FUNCTION my_NL
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Create_Fixed_Display()
        {
            ChartObjects.DrawText("Line0", "Basket Trading ver 3.2 (23-Dec-15), " + "Start Date/Time : ", StaticPosition.TopLeft, Colors.Yellow);

            ChartObjects.DrawText("Line1", my_NL(2) + my_Tabs(3) + "++++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "++++++++++", StaticPosition.TopLeft, Colors.Yellow);
            ChartObjects.DrawText("Line2", my_NL(3) + my_Tabs(3) + "1.EURO PAIRS" + my_Tabs(2) + "2.GBP PAIRS" + my_Tabs(2) + "3.USD PAIRS" + my_Tabs(2) + "4.JPY PAIRS" + my_Tabs(2) + "5.CHF PAIRS" + my_Tabs(2) + "6.CAD PAIRS" + my_Tabs(2) + "7.AUD PAIRS" + my_Tabs(2) + "8.NZD PAIRS", StaticPosition.TopLeft, Colors.Yellow);
            ChartObjects.DrawText("Line3", my_NL(4) + my_Tabs(3) + "++++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "+++++++++++" + my_Tabs(2) + "++++++++++", StaticPosition.TopLeft, Colors.Yellow);
            ChartObjects.DrawText("Line4", my_NL(5) + "Pen.Orders Placed :", StaticPosition.TopLeft, Colors.Yellow);
            ChartObjects.DrawText("Line5", my_NL(6) + "Profit / Loss :", StaticPosition.TopLeft, Colors.Yellow);
            ChartObjects.DrawText("Line6", my_NL(7) + "Count : Buy/Sell :", StaticPosition.TopLeft, Colors.Yellow);
            ChartObjects.DrawText("Line7", my_NL(8) + "Total Pending Orders :", StaticPosition.TopLeft, Colors.Yellow);


        }
        //END FUNCTION Create_Fixed_Display
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
    //END OF MAIN PUBLIC CLASS
}
//END OF MAIN cALGO ROBOT

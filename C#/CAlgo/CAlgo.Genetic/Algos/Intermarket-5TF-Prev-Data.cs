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

    public class MajorPairStrengthv4 : Robot
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
        [Parameter("46. Folder Name on the Desktop ", DefaultValue = "SK Intermarket v4")]
        public string p_str_Folder_Name { get; set; }
        [Parameter("47. Live (No),   BackTesting (Yes)", DefaultValue = false)]
        public bool p_Flag_BackTesting { get; set; }

        ///////////////////////////////////
        // END OF USER INPUT          /////
        ///////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        GLOBAL VARIABLES                                                                      ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //   #-------------- TIME FRAMES --------------#   
        // 5-min
        TimeFrame TF_5min = TimeFrame.Minute5;
        // 15 min
        TimeFrame TF_15min = TimeFrame.Minute15;
        // 1 Hr
        TimeFrame TF_1Hr = TimeFrame.Hour;
        // 4 Hr
        TimeFrame TF_4Hr = TimeFrame.Hour4;
        // Daily
        TimeFrame TF_D = TimeFrame.Daily;
        // Weekly
        TimeFrame TF_Wk = TimeFrame.Weekly;
        // 1-Month
        TimeFrame TF_Mt = TimeFrame.Monthly;
        // "#-------------- ATR VALUES --------------#"
        // 5-MIN (covering 1 hour) 
        int ATR_P_5min = 20;
        // 15-MIN (covering 2 hours)
        int ATR_P_15min = 20;
        // 1-HOUR (covering 3 hours)
        int ATR_P_1Hr = 20;
        // 4-HOUR (covering 12 hours)
        int ATR_P_4Hr = 20;
        // Daily-ATR (covering 5 days)
        int ATR_P_D = 20;
        // Weekly-ATR (covering 1 month)
        int ATR_P_Wk = 20;
        // Monthly (covering 4 months)
        int ATR_P_Mt = 20;

        MovingAverageType p_ATR_MA_Type = MovingAverageType.Simple;
        // -----------------------------------------------------------

        // PREVIOUS PRICES : INDEX
        private int LP1 = 4;

        // CONTAINS THE INDEX VALUES TO ACCESS OPEN PRICES : Current, Last, 3Months, 6 months
        private int[] LP1_Array_Open;
        private int[] LP1_Array_Close;
        private string[] LP1_TF_Name;

        //  DAY WEEK VALUE 
        private int Day_of_the_Week_1 = 0;
        private int Day_of_the_Week_2 = 0;

        private int Month_of_the_Year = 0;
        private string[] Month_Name;

        private bool Flag_New_Day = true;
        private bool Flag_is_Monday_Next = false;

        //For Indexng of MarketSeries
        private int Count_Bar = 0;
        //private double Daily_Count_Bar = 0;

        // COLORS  ---------------------------------------------------------
        private Colors Clr_Bk_1 = Colors.DimGray;
        private Colors Clr_Heading_1 = Colors.Yellow;
        private Colors Clr_PairListing = Colors.Aqua;
        private Colors Clr_Positive = Colors.LightGreen;
        private Colors Clr_Negative = Colors.MediumVioletRed;
        private Colors Clr_Above = Colors.CornflowerBlue;
        private Colors Clr_Below = Colors.WhiteSmoke;
        private Colors Clr_Border = Colors.LightGray;

        // ALL 28 PAIRS PRICES  [28,3] DAILY WEEKLY MONTHLY ----------------
        private double[] All_28Pair_Pip_Size;
        private string[] All_28Pair_Symbol_Code;

        //  -------   ATR VALUES   -----------------
        private double[,,] All_28Pair_ATR_Value;
        private double[,] GTotal_28Pair_ATR_Value;

        private double[,,] All_MajorPair_ATR_Value;
        private double[,] GTotal_MajorPair_ATR_Value;

        // 8 MAJOR PAIRS : DAILY, WEEKLY, MONTHLY
        private string[] MajorPair_Headings;
        private string[,] MajorPair_Combo;
        private int[,] Base_Currency;

        //  -------   CURRENT PRICES  --------------------------------------
        // ARRAYS FOR STORING PREVIOUS PRICES : OPEN, HIGH, LOW, CLOSE
        private double[,,] All_28Pair_Open_Price;
        private double[,,] All_28Pair_Close_Price;
        private double[,,] All_28Pair_HiLo_Price;

        private double[,,] All_28Pair_Total_Pips;
        private double[,,] All_MajorPair_Total_Pips;

        private double[,] GTotal_28Pair_Total_Pips;
        private double[,] GTotal_MajorPair_Total_Pips;

        private int[,] Sorted_MajorPair_Monthly_Total_Pips;
        private int[,] Sorted_MajorPair_Weekly_Total_Pips;
        private int[,] Sorted_MajorPair_Daily_Total_Pips;
        private int[,] Sorted_MajorPair_4Hour_Total_Pips;
        private int[,] Sorted_MajorPair_Hourly_Total_Pips;
        private int[,] Sorted_MajorPair_15min_Total_Pips;
        // -----------------------------------------------------------------

        //  -------   AVERAGE PIPS  ----------------------------------------
        private double[,] Avg_All_28Pair_Total_Pips;
        private double[,] Avg_All_MajorPair_Total_Pips;

        // KEEP TRACK OF 8-MAJOR PAIR, IF TOTAL PIPS HAVE 
        // CROSSED AVG.PIPS, IN ALL 7 TIME FRAMES
        private int[] Flag_TotalPips_Greater_AvgPips;
        private string[] DateTime_TotalPips_Greater_AvgPips;

        // ATR INDICATOR INSTANCE /////////////////////
        private AverageTrueRange ATR_Indicator_1;
        private AverageTrueRange ATR_Indicator_2;
        private AverageTrueRange ATR_Indicator_3;
        private AverageTrueRange ATR_Indicator_4;
        private AverageTrueRange ATR_Indicator_5;
        private AverageTrueRange ATR_Indicator_6;
        private AverageTrueRange ATR_Indicator_7;

        ///////////////////////////////////////////////
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
            //DISPLAY START DATE AND TIME
            string t_Date = string.Format("{0:ddd-d-MMMM-y, HH:MM}", Server.Time);
            Print("");
            Print("cBOT Start Date & Time : " + t_Date);

            // DISPLAY cBOT NAME ON CHART
            Draw_OnChart_C1("DBNAME01", (1), (1), "INTER-MARKET V4.0    BY /// S.KHAN (skhan.projects@gmail.com) ", Clr_Heading_1);

            //Set the Count Bar Value for MarketSeries
            Set_Count_Bar_Value();

            if (p_Flag_Create_CSV_File)
            {
                Create_CSV_File();
            }
            //END IF

            // DECLARE ALL ARRAYS ONCE ONLY ON START
            Declare_All_Arrays();
            // INITIALIZE ARRAY ON START
            Initialize_Array_OnStart_Only();

            //WRITE FIXED VALUE ON CHART SCREEN
            Create_Fixed_Display_1();
            Create_Fixed_Display_2();
            Create_Display_RowColumn();

            // START LINE, STOP LINE, COL #
            Display_Vertical_Lines(3, 75, 9);
            Display_Vertical_Lines(3, 75, 24);
            // LINE NO, START COL, STOP COL
            Display_Horizontal_Lines(30, 1, 24);
            Display_Horizontal_Lines(43, 1, 24);


            // LOAD SYMBOL CODE AND PIPS SIZE
            Load_28Pair_SymbolCode();
            Load_28Pair_PipSize();

            // LOAD ON START-ONLY : OPEN PRICES OF ALL TIME FRAME
            OnSTART_Load_28Pair_Open_Prices();


            // CURRENT PRICES     ---------------------------------------
            Load_28Pair_Open_Prices();
            Load_28Pair_Close_Prices();
            // CALCULATE 28-PAIRS - TOTAL PIPS
            Get_28Pair_TOTAL_Pips_from_Open();
            // GET 8-MAJOR PAIR - TOTAL PIPS
            Get_MajorPair_Total_Pips();

            //  ATR VALUES    -------------------------------------------
            Load_28Pair_ATR_Values();
            Get_MajorPair_ATR_Values();

            //Write_CSVFIle_MajorPair_Monthly_Total_Pips();

        }
        //End METHOD On_Start

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ON       B A R                                                                        ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnBar()
        {
            //Print("OnBar'' MEHTOD START :  D/T=  " + Server.Time);

            //SET THE DAY OF WEEK VALUE  MON=1, TUE=2, ........FRI=5
            Day_of_the_Week_1 = (int)Server.Time.DayOfWeek;

            // GET THE MONTH OF THE YEAR
            Month_of_the_Year = (int)Server.Time.Month;

            //CHECK CHANGE OF DAY
            if (Day_of_the_Week_1 != Day_of_the_Week_2)
                Flag_New_Day = true;
            else
                Flag_New_Day = false;

            //IF NEW DAY THEN GET NEW VALUES
            if (Flag_New_Day == true)
            {

                Flag_New_Day = false;
            }
            //END IF


            // CURRENT PRICES  -------------------------------------------------
            Load_28Pair_Open_Prices();
            Load_28Pair_Close_Prices();
            Load_28Pair_ATR_Values();
            // Get TOTAL PIPS
            Get_28Pair_TOTAL_Pips_from_Open();
            Get_MajorPair_Total_Pips();
            Get_MajorPair_ATR_Values();
            // AVERAGE
            Get_Avg_28Pair_Total_Pips();
            Get_Avg_MajorPair_Total_Pips();
            // SORT
            Sort_MajorPair_15min_TotalPips_Array();
            Sort_MajorPair_Hourly_TotalPips_Array();
            Sort_MajorPair_4Hour_TotalPips_Array();
            Sort_MajorPair_Daily_TotalPips_Array();
            Sort_MajorPair_Weekly_TotalPips_Array();
            Sort_MajorPair_Monthly_TotalPips_Array();
            // -----------------------------------------------------------------


            // DISPLAY  --------------------------------------------------------
            int t_Line = 5, t_Col = 1;
            //Display_MajorPair_15min_Total_Pips(t_Line, t_Col);
            Display_MajorPair_Hourly_Total_Pips(t_Line, t_Col);
            Display_MajorPair_4Hour_Total_Pips(t_Line + 14, t_Col);
            Display_MajorPair_Daily_Total_Pips(t_Line + 28, t_Col);
            Display_MajorPair_Weekly_Total_Pips(t_Line + 42, t_Col);
            Display_MajorPair_Monthly_Total_Pips(t_Line + 56, t_Col);
            // -----------------------------------------------------------------

            // IF TOTAL PIP > AVERAGE PIP IN ALL TIME FRAME --------------------
            Update_Array_AvgPips_Greater_then_TotalPips();
            Display_Array_AvgPips_Greater_then_TotalPips(61, 26);

            // -----------------------------------------------------------------

            //MAKE A COPY OF THE DAY TO BE COMPARED, ON THE NEXT BAR
            Day_of_the_Week_2 = Day_of_the_Week_1;

            //IF FRIDAY THEN RESET THE MONDAY FLAG
            if (Day_of_the_Week_1 == 5)
                Flag_is_Monday_Next = true;

            // IF DAY HAS CHANGED TO MONDAY FROM SUNDAY OR FRIDAY
            if (Flag_is_Monday_Next == true && Day_of_the_Week_1 == 1)
            {

                Flag_is_Monday_Next = false;
            }
            //END IF
        }
        //END METHOD On_Bar

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ON       T I C K                                                                      ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnTick()
        {
            // Put your core logic here
        }
        //End METHOD On_TICK

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 TEST_FUNCTION                                                                ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void TEST_FUNCTION()
        {
        }
        //END MEHTOD TEST_FUNCTION

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_Array_AvgPips_Greater_then_TotalPips                                 ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Array_AvgPips_Greater_then_TotalPips(int t_Row, int t_Col)
        {

            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0;
            double t_1 = 0;

            string tstr_1, tstr_Symbol_Code, tstr_Date, temp_1;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;


            // DISPLAY AVERAGE VALUES ---------------------------------------------------------------------------------

            // COLUMN HEADINGs
            Draw_OnChart_C1("AvgTPips01", (t_Line_no - 2), (t_Col_no), "TOTAL > AVG.PIP", Clr_Heading_1);
            Draw_OnChart_C1("AvgTPips02", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

            Draw_OnChart_C1("AvgTPips03", (t_Line_no - 2), (t_Col_no + t_Offset), "    ALL", Clr_Heading_1);
            Draw_OnChart_C1("AvgTPips04", (t_Line_no - 1), (t_Col_no + t_Offset), "TIMEFRAME", Clr_Heading_1);

            //LOOP TO DISPLAY AVERAGE VALUES
            for (int i = 0; i < 8; i++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = i.ToString();

                // GET SYMBOL CODE 
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[i];

                // GET THE VALUES FROM ARRAY
                t_1 = Flag_TotalPips_Greater_AvgPips[i];
                tstr_Date = DateTime_TotalPips_Greater_AvgPips[i];

                if (t_1 >= 5)
                {
                    tstr_1 = "YES";
                }
                else
                {
                    tstr_1 = "NO";
                }
                //END IF ELSE

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (tstr_1 == "YES")
                    t_Clr = Clr_Above;
                else
                    t_Clr = Clr_Below;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("AVGTPips05" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("AVGTPips06" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_1, t_Clr);

                if (tstr_1 == "YES")
                {
                    Draw_OnChart_C1("AVGTPips07" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_Date, t_Clr);
                }
                else
                {
                    Draw_OnChart_C1("AVGTPips07" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), "(Prev.Date) = " + tstr_Date, t_Clr);
                }
                //END IF ELSE

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3)
                    t_Line_no += 1;
            }
            //END FOR i

        }
        //END MEHTOD Display_Array_AvgPips_Greater_then_TotalPips




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Update_Array_AvgPips_Greater_then_TotalPips                                  ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Update_Array_AvgPips_Greater_then_TotalPips()
        {
            double t_1 = 0, t_2 = 0;
            int t_Count = 0;
            string t_Text;

            // FOR 8-MAJOR PAIRS
            for (int i = 0; i < 8; i++)
            {
                // 7-TIME FRAME : 0=5min, 1=15min, 2=1Hour, 3=4Hr, 5=Daily, 6=Weekly, 7=Monthly
                for (int j = 2; j < 7; j++)
                {
                    // TOTAL PIPS OF MAJOR PAIR : 1ST INDEX IS FOR CURRENT or 
                    // Previous Values, 2nd index is for MAJOR-PAIR, t_TF can be 5min, Daily, Monthly
                    t_1 = Math.Abs(All_MajorPair_Total_Pips[0, i, j]);
                    t_2 = Avg_All_MajorPair_Total_Pips[i, j];

                    if (t_1 >= t_2)
                        t_Count += 1;

                }
                //END FOR j

                // IF TOTALPIPS IN THE PARTICULAR TIME FRAME HAS CROSSED ITS 
                // AVG. PIPS IN THE SAME TIME FRAME
                if (t_Count >= 5)
                {
                    // SET THE FLAG TO TRUE
                    Flag_TotalPips_Greater_AvgPips[i] = 1;
                    // STORE THE DATE TIME
                    t_Text = string.Format("{0:ddd-d-MMM-y, HH:mm}", Server.Time);
                    DateTime_TotalPips_Greater_AvgPips[i] = t_Text;
                }
                else
                {
                    Flag_TotalPips_Greater_AvgPips[i] = 0;
                }
                //END IF ELSE

                //RESET THE COUNTER
                t_Count = 0;

            }
            //END FOR i



        }
        //END MEHTOD Update_Array_AvgPips_Greater_then_TotalPips


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Get_Avg_28Pair_Total_Pips                                                    ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Get_Avg_28Pair_Total_Pips()
        {
            double t_1 = 0;

            //Print("INSIDE : AVERAGE - MAJOR PAIRS");

            // LOOP FOR 8-MAJOR PAIRS
            for (int i = 0; i < 8; i++)
            {
                // LOOP FOR 7-TIME FRAME   
                for (int j = 0; j < 7; j++)
                {
                    // LOOP FOR PREVIOUS PRICES DATA
                    for (int k = 0; k < LP1; k++)
                    {
                        // CONVERT TO POSITIVE VALUES AND THEN ADD
                        if (All_28Pair_Total_Pips[k, i, j] >= 0)
                            t_1 += All_28Pair_Total_Pips[k, i, j];
                        else
                            t_1 += All_28Pair_Total_Pips[k, i, j] * -1;
                    }
                    //END FOR K

                    // FOR AVERAGE DIVIDE BY THE NO OF PREVIOUS PRICES ADDED
                    Avg_All_28Pair_Total_Pips[i, j] = Math.Round(t_1 / LP1, 0);

                    // RESET THE TOTAL TO 0
                    t_1 = 0;
                }
                //END FOR J
            }
            //END FOR I
        }
        //END MEHTOD Get_Avg_28Pair_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Get_Avg_MajorPair_Total_Pips                                                 ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Get_Avg_MajorPair_Total_Pips()
        {
            double t_1 = 0;

            // LOOP FOR 8-MAJOR PAIRS
            for (int i = 0; i < 8; i++)
            {
                // LOOP FOR 7-TIME FRAME   
                for (int j = 0; j < 7; j++)
                {
                    // LOOP FOR PREVIOUS PRICES DATA
                    for (int k = 0; k < LP1; k++)
                    {
                        // CONVERT TO POSITIVE VALUES AND THEN ADD
                        if (All_MajorPair_Total_Pips[k, i, j] >= 0)
                            t_1 += All_MajorPair_Total_Pips[k, i, j];
                        else
                            t_1 += All_MajorPair_Total_Pips[k, i, j] * -1;
                    }
                    //END FOR K

                    // FOR AVERAGE DIVIDE BY THE NO OF PREVIOUS PRICES ADDED
                    Avg_All_MajorPair_Total_Pips[i, j] = Math.Round(t_1 / LP1, 0);

                    // RESET THE TOTAL TO 0
                    t_1 = 0;
                }
                //END FOR J
            }
            //END FOR I
        }
        //END MEHTOD Get_Avg_MajorPair_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Write_CSVFIle__MajorPair_Monthly_Total_Pips                                  ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Write_CSVFIle_MajorPair_Monthly_Total_Pips()
        {
            int t_TF;

            double t_Total_Pip = 0;

            string tstr_TPips, tstr_Symbol_Code, tstr_CompleteRow;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 6;

            // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 8; i++)
            {
                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                //t_1 = Sorted_MajorPair_Monthly_Total_Pips[b, i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = MajorPair_Headings[i];
                tstr_CompleteRow = tstr_Symbol_Code + ",";

                // LOOP TO ACCESS PREVIOUS PRICES
                for (int b = 0; b < LP1; b++)
                {
                    // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                    t_Total_Pip = All_MajorPair_Total_Pips[b, i, t_TF];
                    tstr_TPips = t_Total_Pip.ToString("0");

                    // ADD TO STRING ALL PREVIOUS PRICES OF ONE MAJOR PAIR ONLY
                    tstr_CompleteRow += tstr_TPips + ",";
                }
                //END FOR b

                // WRITE MAJOR PARI : POSITION, SYMBOL CODE, TOTAL PIPS
                //WRITE CURRENT DATA
                File_Writer.WriteLine(Concate_With_Comma(tstr_CompleteRow));

                // RESET THE STRING TO BLANK
                tstr_CompleteRow = "";
            }
            // END FOR i
        }
        //END MEHTOD Write_CSVFIle__MajorPair_Monthly_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Return_Pair_Index_Position                                                   ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private int Return_Pair_Index_Position(string tstr_Pair)
        {
            int t_index = 0;
            bool t_Flag = true;
            Symbol t_Symbol;

            while (t_Flag == true)
            {
                t_Symbol = Get_28Pair_Symbol(t_index);

                if (tstr_Pair == t_Symbol.Code.ToString())
                {
                    t_Flag = false;
                }
                //END IF

                t_index += 1;

                // IF PAIR IS NOT MATCHED : BREAK THE WHILE LOOP
                if (t_index >= 30)
                    t_Flag = false;
            }
            //END WHILE

            // GO ONE BACK AS THE WHILE LOOPS ADD ONE EXTRA ON EXIT
            t_index -= 1;

            return t_index;
        }
        //END MEHTOD Return_Pair_Index_Position

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Return_Name_of_the_Month                                                     ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private string Return_Name_of_the_Month(int t_Month)
        {
            string t_str1 = "";

            // IF NEGATIVE NUMBER e.g. -1, it means Dec of the PREVIOUS YEAR
            if (t_Month < 0)
                t_Month += 13;

            t_str1 = Month_Name[t_Month];

            return t_str1;
        }
        //END MEHTOD Return_Name_of_the_Month

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_MajorPair_15min_TotalPips_Array                                         ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_15min_TotalPips_Array()
        {
            int t_1 = 0;
            int t_TF;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[8];
            t_Value = new double[8];

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 1;

            // LOOP TO DISPLAY LAST 4 VALUES
            for (int b = 0; b < LP1; b++)
            {

                //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
                for (int i = 0; i < 8; i++)
                {
                    // COPY IN TEMP ARRAY : serial#, Pip value
                    t_Index[i] = i;
                    t_Value[i] = All_MajorPair_Total_Pips[b, i, t_TF];
                }
                //END FOR

                // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
                bool change = true;
                while (change == true)
                {
                    change = false;

                    // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                    for (int i = 0; i < 7; i++)
                    {
                        if (t_Value[i] < t_Value[i + 1])
                        {
                            change = true;

                            //SWAP FIRST INDEX VALUES (COUNTER) OF THE TEMP ARRAY
                            t_1 = t_Index[i + 1];
                            t_Index[i + 1] = t_Index[i];
                            t_Index[i] = t_1;

                            //SWAP 2ND INDEX VALUES (TOTAL PIP) OF THE TEMP ARRAY
                            t_2 = t_Value[i + 1];
                            t_Value[i + 1] = t_Value[i];
                            t_Value[i] = t_2;
                        }
                        //END IF
                    }
                    //END FOR
                }
                //END WHILE SORTING

                //LOOP FOR 8-MAJOR PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
                for (int i = 0; i < 8; i++)
                {
                    Sorted_MajorPair_15min_Total_Pips[b, i] = t_Index[i];
                }
                // END FOR
            }
            // END FOR B
        }
        //END METHOD Sort_MajorPair_15min_TotalPips_Array

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_MajorPair_Hourly_TotalPips_Array                                        ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_Hourly_TotalPips_Array()
        {
            int t_1 = 0;
            int t_TF;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[8];
            t_Value = new double[8];

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 2;

            // LOOP TO DISPLAY LAST 4 VALUES
            for (int b = 0; b < LP1; b++)
            {

                //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
                for (int i = 0; i < 8; i++)
                {
                    // COPY IN TEMP ARRAY : serial#, Pip value
                    t_Index[i] = i;
                    t_Value[i] = All_MajorPair_Total_Pips[b, i, t_TF];
                }
                //END FOR

                // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
                bool change = true;
                while (change == true)
                {
                    change = false;

                    // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                    for (int i = 0; i < 7; i++)
                    {
                        if (t_Value[i] < t_Value[i + 1])
                        {
                            change = true;

                            //SWAP FIRST INDEX VALUES (COUNTER) OF THE TEMP ARRAY
                            t_1 = t_Index[i + 1];
                            t_Index[i + 1] = t_Index[i];
                            t_Index[i] = t_1;

                            //SWAP 2ND INDEX VALUES (TOTAL PIP) OF THE TEMP ARRAY
                            t_2 = t_Value[i + 1];
                            t_Value[i + 1] = t_Value[i];
                            t_Value[i] = t_2;
                        }
                        //END IF
                    }
                    //END FOR
                }
                //END WHILE SORTING

                //LOOP FOR 8-MAJOR PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
                for (int i = 0; i < 8; i++)
                {
                    Sorted_MajorPair_Hourly_Total_Pips[b, i] = t_Index[i];
                }
                // END FOR
            }
            // END FOR B
        }
        //END METHOD Sort_MajorPair_Hourly_TotalPips_Array

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_MajorPair_4Hour_TotalPips_Array                                         ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_4Hour_TotalPips_Array()
        {
            int t_1 = 0;
            int t_TF;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[8];
            t_Value = new double[8];

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 3;

            // LOOP TO DISPLAY LAST 4 VALUES
            for (int b = 0; b < LP1; b++)
            {

                //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
                for (int i = 0; i < 8; i++)
                {
                    // COPY IN TEMP ARRAY : serial#, Pip value
                    t_Index[i] = i;
                    t_Value[i] = All_MajorPair_Total_Pips[b, i, t_TF];
                }
                //END FOR

                // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
                bool change = true;
                while (change == true)
                {
                    change = false;

                    // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                    for (int i = 0; i < 7; i++)
                    {
                        if (t_Value[i] < t_Value[i + 1])
                        {
                            change = true;

                            //SWAP FIRST INDEX VALUES (COUNTER) OF THE TEMP ARRAY
                            t_1 = t_Index[i + 1];
                            t_Index[i + 1] = t_Index[i];
                            t_Index[i] = t_1;

                            //SWAP 2ND INDEX VALUES (TOTAL PIP) OF THE TEMP ARRAY
                            t_2 = t_Value[i + 1];
                            t_Value[i + 1] = t_Value[i];
                            t_Value[i] = t_2;
                        }
                        //END IF
                    }
                    //END FOR
                }
                //END WHILE SORTING

                //LOOP FOR 8-MAJOR PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
                for (int i = 0; i < 8; i++)
                {
                    Sorted_MajorPair_4Hour_Total_Pips[b, i] = t_Index[i];
                }
                // END FOR
            }
            // END FOR B
        }
        //END METHOD Sort_MajorPair_4Hour_TotalPips_Array

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_MajorPair_Daily_TotalPips_Array                                         ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_Daily_TotalPips_Array()
        {
            int t_1 = 0;
            int t_TF;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[8];
            t_Value = new double[8];

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 4;

            // LOOP TO DISPLAY LAST 4 VALUES
            for (int b = 0; b < LP1; b++)
            {

                //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
                for (int i = 0; i < 8; i++)
                {
                    // COPY IN TEMP ARRAY : serial#, Pip value
                    t_Index[i] = i;
                    t_Value[i] = All_MajorPair_Total_Pips[b, i, t_TF];
                }
                //END FOR

                // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
                bool change = true;
                while (change == true)
                {
                    change = false;

                    // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                    for (int i = 0; i < 7; i++)
                    {
                        if (t_Value[i] < t_Value[i + 1])
                        {
                            change = true;

                            //SWAP FIRST INDEX VALUES (COUNTER) OF THE TEMP ARRAY
                            t_1 = t_Index[i + 1];
                            t_Index[i + 1] = t_Index[i];
                            t_Index[i] = t_1;

                            //SWAP 2ND INDEX VALUES (TOTAL PIP) OF THE TEMP ARRAY
                            t_2 = t_Value[i + 1];
                            t_Value[i + 1] = t_Value[i];
                            t_Value[i] = t_2;
                        }
                        //END IF
                    }
                    //END FOR
                }
                //END WHILE SORTING

                //LOOP FOR 8-MAJOR PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
                for (int i = 0; i < 8; i++)
                {
                    Sorted_MajorPair_Daily_Total_Pips[b, i] = t_Index[i];
                }
                // END FOR
            }
            // END FOR B
        }
        //END METHOD Sort_MajorPair_Daily_TotalPips_Array


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_MajorPair_Weekly_TotalPips_Array                                        ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_Weekly_TotalPips_Array()
        {
            int t_1 = 0;
            int t_TF;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[8];
            t_Value = new double[8];

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 5;

            // LOOP TO DISPLAY LAST 4 VALUES
            for (int b = 0; b < LP1; b++)
            {

                //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
                for (int i = 0; i < 8; i++)
                {
                    // COPY IN TEMP ARRAY : serial#, Pip value
                    t_Index[i] = i;
                    t_Value[i] = All_MajorPair_Total_Pips[b, i, t_TF];
                }
                //END FOR

                // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
                bool change = true;
                while (change == true)
                {
                    change = false;

                    // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                    for (int i = 0; i < 7; i++)
                    {
                        if (t_Value[i] < t_Value[i + 1])
                        {
                            change = true;

                            //SWAP FIRST INDEX VALUES (COUNTER) OF THE TEMP ARRAY
                            t_1 = t_Index[i + 1];
                            t_Index[i + 1] = t_Index[i];
                            t_Index[i] = t_1;

                            //SWAP 2ND INDEX VALUES (TOTAL PIP) OF THE TEMP ARRAY
                            t_2 = t_Value[i + 1];
                            t_Value[i + 1] = t_Value[i];
                            t_Value[i] = t_2;
                        }
                        //END IF
                    }
                    //END FOR
                }
                //END WHILE SORTING

                //LOOP FOR 8-MAJOR PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
                for (int i = 0; i < 8; i++)
                {
                    Sorted_MajorPair_Weekly_Total_Pips[b, i] = t_Index[i];
                }
                // END FOR
            }
            // END FOR B
        }
        //END METHOD Sort_MajorPair_Weekly_TotalPips_Array



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_MajorPair_Monthly_TotalPips_Array                                       ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_Monthly_TotalPips_Array()
        {
            int t_1 = 0;
            int t_TF;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[8];
            t_Value = new double[8];

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 6;

            // LOOP TO DISPLAY LAST 4 VALUES
            for (int b = 0; b < LP1; b++)
            {

                //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
                for (int i = 0; i < 8; i++)
                {
                    // COPY IN TEMP ARRAY : serial#, Pip value
                    t_Index[i] = i;
                    t_Value[i] = All_MajorPair_Total_Pips[b, i, t_TF];
                }
                //END FOR

                // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
                bool change = true;
                while (change == true)
                {
                    change = false;

                    // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                    for (int i = 0; i < 7; i++)
                    {
                        if (t_Value[i] < t_Value[i + 1])
                        {
                            change = true;

                            //SWAP FIRST INDEX VALUES (COUNTER) OF THE TEMP ARRAY
                            t_1 = t_Index[i + 1];
                            t_Index[i + 1] = t_Index[i];
                            t_Index[i] = t_1;

                            //SWAP 2ND INDEX VALUES (TOTAL PIP) OF THE TEMP ARRAY
                            t_2 = t_Value[i + 1];
                            t_Value[i + 1] = t_Value[i];
                            t_Value[i] = t_2;
                        }
                        //END IF
                    }
                    //END FOR
                }
                //END WHILE SORTING

                //LOOP FOR 8-MAJOR PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
                for (int i = 0; i < 8; i++)
                {
                    Sorted_MajorPair_Monthly_Total_Pips[b, i] = t_Index[i];
                }
                // END FOR
            }
            // END FOR B
        }
        //END METHOD Sort_MajorPair_Monthly_TotalPips_Array

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_15min_Total_Pips                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_15min_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_2 = 0;
            double t_ATR;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, temp_1, tstr_TFrame, tstr_GrandTotal, tstr_ATR;
            Colors t_Clr;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 1;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;


            // DISPLAY AVERAGE VALUES ---------------------------------------------------------------------------------

            // COLUMN HEADINGs
            Draw_OnChart_C1("AvgPips01", (t_Line_no - 2), (t_Col_no), "AVERAGE", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips02", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

            Draw_OnChart_C1("AvgPips03", (t_Line_no - 2), (t_Col_no + t_Offset), "15-min", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips04", (t_Line_no - 1), (t_Col_no + t_Offset), "AVG-Pips", Clr_Heading_1);

            //LOOP TO DISPLAY AVERAGE VALUES
            for (int i = 0; i < 8; i++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = i.ToString();

                // SORT AS PER THE CURRENT SORTED MAJOR PAIR VALUES
                t_1 = Sorted_MajorPair_15min_Total_Pips[0, i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Avg_All_MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // GET TOTAL PIP FOR COMPARISON WITH AVERAGE TO SET THE COLOR
                t_2 = Math.Abs(All_MajorPair_Total_Pips[0, t_1, t_TF]);

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_2 >= t_Total_Pip)
                    t_Clr = Clr_Above;
                else
                    t_Clr = Clr_Below;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("AVGPips05" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("AVGPips06" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3)
                    t_Line_no += 1;
            }
            //END FOR I

            // DISPLAY : AVERAGE OF 28 PAIRS TOTAL PIPS : CURRENT MONTH
            if (GTotal_28Pair_Total_Pips[0, t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;
            tstr_GrandTotal = (GTotal_28Pair_Total_Pips[0, t_TF] / 28).ToString("0");
            Draw_OnChart_C1("AvgPips07", t_Line_no, (t_Col_no), "Avg of 28-Pairs", t_Clr);
            Draw_OnChart_C1("AvgPips08", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);



            // DISPLAY TOTAL PIPS  ---------------------------------------------------------------------------------
            // RESET ROW COL POSITION TO DISPLAY THE NEXT LOOP VALUES
            t_Line_no = t_Row;
            t_Col_no = t_Col_no + 4;
            // LOOP TO DISPLAY LAST x VALUES
            for (int l = 0; l < LP1; l++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = l.ToString();

                // GET THE TIME FRAME NAME
                tstr_TFrame = LP1_TF_Name[l];

                // COLUMN HEADINGs
                Draw_OnChart_C1("PrvMPips01" + temp_1, (t_Line_no - 2), (t_Col_no), tstr_TFrame, Clr_Heading_1);
                Draw_OnChart_C1("PrvMPips02" + temp_1, (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips03" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset), "15-min", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips04" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips05" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset + 1), "15-min", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips06" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset + 1), "ATR", Clr_Heading_1);

                // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
                for (int i = 0; i < 8; i++)
                {
                    // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                    t_1 = Sorted_MajorPair_15min_Total_Pips[l, i];

                    // GET SYMBOL CODE AS PER THE t_Index
                    tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                    // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                    t_Total_Pip = All_MajorPair_Total_Pips[l, t_1, t_TF];
                    tstr_TPips = t_Total_Pip.ToString("0");

                    // GET ATR VALUE
                    t_ATR = All_MajorPair_ATR_Value[l, t_1, t_TF];
                    tstr_ATR = t_ATR.ToString();

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= t_ATR)
                        t_Clr = Clr_Above;

                    // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                    Draw_OnChart_C1("PrvMPips07" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                    Draw_OnChart_C1("PrvMPips08" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // DRAW ATR VALUES ON CHART
                    Draw_OnChart_C1("PrvMPips10" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                    // INC. THE LINE #
                    t_Line_no += 1;

                    // LEAVE A BLANK LINE
                    if (i == 3)
                        t_Line_no += 1;
                }
                //END FOR I
                // ----------------------------------------------------------------------------------------------------------

                // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL 28PAIRS : DAILY
                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (GTotal_28Pair_Total_Pips[l, t_TF] >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
                tstr_GrandTotal = GTotal_28Pair_Total_Pips[l, t_TF].ToString("0");
                tstr_ATR = GTotal_28Pair_ATR_Value[l, t_TF].ToString("");
                Draw_OnChart_C1("PrvMPips11" + temp_1, t_Line_no, (t_Col_no), "Total 28-Pairs", t_Clr);
                Draw_OnChart_C1("PrvMPips12" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);
                Draw_OnChart_C1("PrvMPips13" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                // INCREASE THE LINE SPACE FOR NEXT SET OF TIMEFRAME VALUES
                t_Line_no = t_Row;
                t_Col_no = t_Col_no + 5;
            }
            // END FOR L
        }
        //END MEHTOD Display_MajorPair_15min_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_Hourly_Total_Pips                                          ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_Hourly_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_2 = 0;
            double t_ATR;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, temp_1, tstr_TFrame, tstr_GrandTotal, tstr_ATR;
            Colors t_Clr;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 2;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;


            // DISPLAY AVERAGE VALUES ---------------------------------------------------------------------------------

            // COLUMN HEADINGs
            Draw_OnChart_C1("AvgPips01", (t_Line_no - 2), (t_Col_no), "AVERAGE", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips02", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

            Draw_OnChart_C1("AvgPips03", (t_Line_no - 2), (t_Col_no + t_Offset), "1-Hour", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips04", (t_Line_no - 1), (t_Col_no + t_Offset), "AVG-Pips", Clr_Heading_1);

            //LOOP TO DISPLAY AVERAGE VALUES
            for (int i = 0; i < 8; i++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = i.ToString();

                // SORT AS PER THE CURRENT SORTED MAJOR PAIR VALUES
                t_1 = Sorted_MajorPair_Hourly_Total_Pips[0, i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Avg_All_MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // GET TOTAL PIP FOR COMPARISON WITH AVERAGE TO SET THE COLOR
                t_2 = Math.Abs(All_MajorPair_Total_Pips[0, t_1, t_TF]);

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_2 >= t_Total_Pip)
                    t_Clr = Clr_Above;
                else
                    t_Clr = Clr_Below;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("AVGPips05" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("AVGPips06" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3)
                    t_Line_no += 1;
            }
            //END FOR I

            // DISPLAY : AVERAGE OF 28 PAIRS TOTAL PIPS : CURRENT MONTH
            if (GTotal_28Pair_Total_Pips[0, t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;
            tstr_GrandTotal = (GTotal_28Pair_Total_Pips[0, t_TF] / 28).ToString("0");
            Draw_OnChart_C1("AvgPips07", t_Line_no, (t_Col_no), "Avg of 28-Pairs", t_Clr);
            Draw_OnChart_C1("AvgPips08", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);



            // DISPLAY TOTAL PIPS  ---------------------------------------------------------------------------------
            // RESET ROW COL POSITION TO DISPLAY THE NEXT LOOP VALUES
            t_Line_no = t_Row;
            t_Col_no = t_Col_no + 4;
            // LOOP TO DISPLAY LAST x VALUES
            for (int l = 0; l < LP1; l++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = l.ToString();

                // GET THE TIME FRAME NAME
                tstr_TFrame = LP1_TF_Name[l];

                // COLUMN HEADINGs
                Draw_OnChart_C1("PrvMPips01" + temp_1, (t_Line_no - 2), (t_Col_no), tstr_TFrame, Clr_Heading_1);
                Draw_OnChart_C1("PrvMPips02" + temp_1, (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips03" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset), "1-Hour", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips04" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips05" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset + 1), "1-Hour", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips06" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset + 1), "ATR", Clr_Heading_1);

                // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
                for (int i = 0; i < 8; i++)
                {
                    // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                    t_1 = Sorted_MajorPair_Hourly_Total_Pips[l, i];

                    // GET SYMBOL CODE AS PER THE t_Index
                    tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                    // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                    t_Total_Pip = All_MajorPair_Total_Pips[l, t_1, t_TF];
                    tstr_TPips = t_Total_Pip.ToString("0");

                    // GET ATR VALUE
                    t_ATR = All_MajorPair_ATR_Value[l, t_1, t_TF];
                    tstr_ATR = t_ATR.ToString();

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= t_ATR)
                        t_Clr = Clr_Above;

                    // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                    Draw_OnChart_C1("PrvMPips07" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                    Draw_OnChart_C1("PrvMPips08" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // DRAW ATR VALUES ON CHART
                    Draw_OnChart_C1("PrvMPips10" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                    // INC. THE LINE #
                    t_Line_no += 1;

                    // LEAVE A BLANK LINE
                    if (i == 3)
                        t_Line_no += 1;
                }
                //END FOR I
                // ----------------------------------------------------------------------------------------------------------

                // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL 28PAIRS : DAILY
                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (GTotal_28Pair_Total_Pips[l, t_TF] >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
                tstr_GrandTotal = GTotal_28Pair_Total_Pips[l, t_TF].ToString("0");
                tstr_ATR = GTotal_28Pair_ATR_Value[l, t_TF].ToString("");
                Draw_OnChart_C1("PrvMPips11" + temp_1, t_Line_no, (t_Col_no), "Total 28-Pairs", t_Clr);
                Draw_OnChart_C1("PrvMPips12" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);
                Draw_OnChart_C1("PrvMPips13" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                // INCREASE THE LINE SPACE FOR NEXT SET OF TIMEFRAME VALUES
                t_Line_no = t_Row;
                t_Col_no = t_Col_no + 5;
            }
            // END FOR L
        }
        //END MEHTOD Display_MajorPair_Hourly_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_4Hour_Total_Pips                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_4Hour_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_2 = 0;
            double t_ATR;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, temp_1, tstr_TFrame, tstr_GrandTotal, tstr_ATR;
            Colors t_Clr;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 3;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;


            // DISPLAY AVERAGE VALUES ---------------------------------------------------------------------------------

            // COLUMN HEADINGs
            Draw_OnChart_C1("AvgPips01", (t_Line_no - 2), (t_Col_no), "AVERAGE", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips02", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

            Draw_OnChart_C1("AvgPips03", (t_Line_no - 2), (t_Col_no + t_Offset), "4-Hour", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips04", (t_Line_no - 1), (t_Col_no + t_Offset), "AVG-Pips", Clr_Heading_1);

            //LOOP TO DISPLAY AVERAGE VALUES
            for (int i = 0; i < 8; i++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = i.ToString();

                // SORT AS PER THE CURRENT SORTED MAJOR PAIR VALUES
                t_1 = Sorted_MajorPair_4Hour_Total_Pips[0, i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Avg_All_MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // GET TOTAL PIP FOR COMPARISON WITH AVERAGE TO SET THE COLOR
                t_2 = Math.Abs(All_MajorPair_Total_Pips[0, t_1, t_TF]);

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_2 >= t_Total_Pip)
                    t_Clr = Clr_Above;
                else
                    t_Clr = Clr_Below;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("AVGPips05" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("AVGPips06" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3)
                    t_Line_no += 1;
            }
            //END FOR I

            // DISPLAY : AVERAGE OF 28 PAIRS TOTAL PIPS : CURRENT MONTH
            if (GTotal_28Pair_Total_Pips[0, t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            tstr_GrandTotal = (GTotal_28Pair_Total_Pips[0, t_TF] / 28).ToString("0");
            Draw_OnChart_C1("AvgPips07", t_Line_no, (t_Col_no), "Avg of 28-Pairs", t_Clr);
            Draw_OnChart_C1("AvgPips08", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);



            // DISPLAY TOTAL PIPS  ---------------------------------------------------------------------------------
            // RESET ROW COL POSITION TO DISPLAY THE NEXT LOOP VALUES
            t_Line_no = t_Row;
            t_Col_no = t_Col_no + 4;
            // LOOP TO DISPLAY LAST x VALUES
            for (int l = 0; l < LP1; l++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = l.ToString();

                // GET THE TIME FRAME NAME
                tstr_TFrame = LP1_TF_Name[l];

                // COLUMN HEADINGs
                Draw_OnChart_C1("PrvMPips01" + temp_1, (t_Line_no - 2), (t_Col_no), tstr_TFrame, Clr_Heading_1);
                Draw_OnChart_C1("PrvMPips02" + temp_1, (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips03" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset), "4-Hour", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips04" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips05" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset + 1), "4-Hour", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips06" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset + 1), "ATR", Clr_Heading_1);

                // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
                for (int i = 0; i < 8; i++)
                {
                    // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                    t_1 = Sorted_MajorPair_4Hour_Total_Pips[l, i];

                    // GET SYMBOL CODE AS PER THE t_Index
                    tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                    // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                    t_Total_Pip = All_MajorPair_Total_Pips[l, t_1, t_TF];
                    tstr_TPips = t_Total_Pip.ToString("0");

                    // GET ATR VALUE
                    t_ATR = All_MajorPair_ATR_Value[l, t_1, t_TF];
                    tstr_ATR = t_ATR.ToString();

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= t_ATR)
                        t_Clr = Clr_Above;

                    // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                    Draw_OnChart_C1("PrvMPips07" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                    Draw_OnChart_C1("PrvMPips08" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // DRAW ATR VALUES ON CHART
                    Draw_OnChart_C1("PrvMPips10" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                    // INC. THE LINE #
                    t_Line_no += 1;

                    // LEAVE A BLANK LINE
                    if (i == 3)
                        t_Line_no += 1;
                }
                //END FOR I
                // ----------------------------------------------------------------------------------------------------------

                // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL 28PAIRS : DAILY
                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (GTotal_28Pair_Total_Pips[l, t_TF] >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
                tstr_GrandTotal = GTotal_28Pair_Total_Pips[l, t_TF].ToString("0");
                tstr_ATR = GTotal_28Pair_ATR_Value[l, t_TF].ToString("");

                Draw_OnChart_C1("PrvMPips11" + temp_1, t_Line_no, (t_Col_no), "Total 28-Pairs", t_Clr);
                Draw_OnChart_C1("PrvMPips12" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);
                Draw_OnChart_C1("PrvMPips13" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                // INCREASE THE LINE SPACE FOR NEXT SET OF TIMEFRAME VALUES
                t_Line_no = t_Row;
                t_Col_no = t_Col_no + 5;
            }
            // END FOR L
        }
        //END MEHTOD Display_MajorPair_4Hour_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_Daily_Total_Pips                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_Daily_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_2 = 0;
            double t_ATR;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, temp_1, tstr_TFrame, tstr_GrandTotal, tstr_ATR;
            Colors t_Clr;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 4;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;


            // DISPLAY AVERAGE VALUES ---------------------------------------------------------------------------------

            // COLUMN HEADINGs
            Draw_OnChart_C1("AvgPips01", (t_Line_no - 2), (t_Col_no), "AVERAGE", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips02", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

            Draw_OnChart_C1("AvgPips03", (t_Line_no - 2), (t_Col_no + t_Offset), "Daily", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips04", (t_Line_no - 1), (t_Col_no + t_Offset), "AVG-Pips", Clr_Heading_1);

            //LOOP TO DISPLAY AVERAGE VALUES
            for (int i = 0; i < 8; i++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = i.ToString();

                // SORT AS PER THE CURRENT SORTED MAJOR PAIR VALUES
                t_1 = Sorted_MajorPair_Daily_Total_Pips[0, i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Avg_All_MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // GET TOTAL PIP FOR COMPARISON WITH AVERAGE TO SET THE COLOR
                t_2 = Math.Abs(All_MajorPair_Total_Pips[0, t_1, t_TF]);

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_2 >= t_Total_Pip)
                    t_Clr = Clr_Above;
                else
                    t_Clr = Clr_Below;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("AVGPips05" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("AVGPips06" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3)
                    t_Line_no += 1;
            }
            //END FOR I

            // DISPLAY : AVERAGE OF 28 PAIRS TOTAL PIPS : CURRENT MONTH
            if (GTotal_28Pair_Total_Pips[0, t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            tstr_GrandTotal = (GTotal_28Pair_Total_Pips[0, t_TF] / 28).ToString("0");
            Draw_OnChart_C1("AvgPips07", t_Line_no, (t_Col_no), "Avg of 28-Pairs", t_Clr);
            Draw_OnChart_C1("AvgPips08", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);



            // DISPLAY TOTAL PIPS  ---------------------------------------------------------------------------------
            // RESET ROW COL POSITION TO DISPLAY THE NEXT LOOP VALUES
            t_Line_no = t_Row;
            t_Col_no = t_Col_no + 4;
            // LOOP TO DISPLAY LAST x VALUES
            for (int l = 0; l < LP1; l++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = l.ToString();

                // GET THE TIME FRAME NAME
                tstr_TFrame = LP1_TF_Name[l];

                // COLUMN HEADINGs
                Draw_OnChart_C1("PrvMPips01" + temp_1, (t_Line_no - 2), (t_Col_no), tstr_TFrame, Clr_Heading_1);
                Draw_OnChart_C1("PrvMPips02" + temp_1, (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips03" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset), "Daily", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips04" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips05" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset + 1), "Daily", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips06" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset + 1), "ATR", Clr_Heading_1);

                // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
                for (int i = 0; i < 8; i++)
                {
                    // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                    t_1 = Sorted_MajorPair_Daily_Total_Pips[l, i];

                    // GET SYMBOL CODE AS PER THE t_Index
                    tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                    // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                    t_Total_Pip = All_MajorPair_Total_Pips[l, t_1, t_TF];
                    tstr_TPips = t_Total_Pip.ToString("0");

                    // GET ATR VALUE
                    t_ATR = All_MajorPair_ATR_Value[l, t_1, t_TF];
                    tstr_ATR = t_ATR.ToString();

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= t_ATR)
                        t_Clr = Clr_Above;

                    // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                    Draw_OnChart_C1("PrvMPips07" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                    Draw_OnChart_C1("PrvMPips08" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // DRAW ATR VALUES ON CHART
                    Draw_OnChart_C1("PrvMPips10" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                    // INC. THE LINE #
                    t_Line_no += 1;

                    // LEAVE A BLANK LINE
                    if (i == 3)
                        t_Line_no += 1;
                }
                //END FOR I
                // ----------------------------------------------------------------------------------------------------------

                // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL 28PAIRS : DAILY
                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (GTotal_28Pair_Total_Pips[l, t_TF] >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
                tstr_GrandTotal = GTotal_28Pair_Total_Pips[l, t_TF].ToString("0");
                tstr_ATR = GTotal_28Pair_ATR_Value[l, t_TF].ToString("");

                Draw_OnChart_C1("PrvMPips11" + temp_1, t_Line_no, (t_Col_no), "Total 28-Pairs", t_Clr);
                Draw_OnChart_C1("PrvMPips12" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);
                Draw_OnChart_C1("PrvMPips13" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                // INCREASE THE LINE SPACE FOR NEXT SET OF TIMEFRAME VALUES
                t_Line_no = t_Row;
                t_Col_no = t_Col_no + 5;
            }
            // END FOR L
        }
        //END MEHTOD Display_MajorPair_Daily_Total_Pips


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_Weekly_Total_Pips                                          ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_Weekly_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_2 = 0;
            double t_ATR;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, temp_1, tstr_TFrame, tstr_GrandTotal, tstr_ATR;
            Colors t_Clr;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 5;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;


            // DISPLAY AVERAGE VALUES ---------------------------------------------------------------------------------

            // COLUMN HEADINGs
            Draw_OnChart_C1("AvgPips01", (t_Line_no - 2), (t_Col_no), "AVERAGE", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips02", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

            Draw_OnChart_C1("AvgPips03", (t_Line_no - 2), (t_Col_no + t_Offset), "Weekly", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips04", (t_Line_no - 1), (t_Col_no + t_Offset), "AVG-Pips", Clr_Heading_1);

            //LOOP TO DISPLAY AVERAGE VALUES
            for (int i = 0; i < 8; i++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = i.ToString();

                // SORT AS PER THE CURRENT SORTED MAJOR PAIR VALUES
                t_1 = Sorted_MajorPair_Weekly_Total_Pips[0, i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Avg_All_MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // GET TOTAL PIP FOR COMPARISON WITH AVERAGE TO SET THE COLOR
                t_2 = Math.Abs(All_MajorPair_Total_Pips[0, t_1, t_TF]);

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_2 >= t_Total_Pip)
                    t_Clr = Clr_Above;
                else
                    t_Clr = Clr_Below;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("AVGPips05" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("AVGPips06" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3)
                    t_Line_no += 1;
            }
            //END FOR I

            // DISPLAY : AVERAGE OF 28 PAIRS TOTAL PIPS : CURRENT MONTH
            if (GTotal_28Pair_Total_Pips[0, t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            tstr_GrandTotal = (GTotal_28Pair_Total_Pips[0, t_TF] / 28).ToString("0");
            Draw_OnChart_C1("AvgPips07", t_Line_no, (t_Col_no), "Avg of 28-Pairs", t_Clr);
            Draw_OnChart_C1("AvgPips08", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);



            // DISPLAY TOTAL PIPS  ---------------------------------------------------------------------------------
            // RESET ROW COL POSITION TO DISPLAY THE NEXT LOOP VALUES
            t_Line_no = t_Row;
            t_Col_no = t_Col_no + 4;
            // LOOP TO DISPLAY LAST x VALUES
            for (int l = 0; l < LP1; l++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = l.ToString();

                // GET THE TIME FRAME NAME
                tstr_TFrame = LP1_TF_Name[l];

                // COLUMN HEADINGs
                Draw_OnChart_C1("PrvMPips01" + temp_1, (t_Line_no - 2), (t_Col_no), tstr_TFrame, Clr_Heading_1);
                Draw_OnChart_C1("PrvMPips02" + temp_1, (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips03" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset), "Week", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips04" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips05" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset + 1), "Week", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips06" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset + 1), "ATR", Clr_Heading_1);

                // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
                for (int i = 0; i < 8; i++)
                {
                    // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                    t_1 = Sorted_MajorPair_Weekly_Total_Pips[l, i];

                    // GET SYMBOL CODE AS PER THE t_Index
                    tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                    // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                    t_Total_Pip = All_MajorPair_Total_Pips[l, t_1, t_TF];
                    tstr_TPips = t_Total_Pip.ToString("0");

                    // GET ATR VALUE
                    t_ATR = All_MajorPair_ATR_Value[l, t_1, t_TF];
                    tstr_ATR = t_ATR.ToString();

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= t_ATR)
                        t_Clr = Clr_Above;

                    // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                    Draw_OnChart_C1("PrvMPips07" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                    Draw_OnChart_C1("PrvMPips08" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // DRAW ATR VALUES ON CHART
                    Draw_OnChart_C1("PrvMPips10" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                    // INC. THE LINE #
                    t_Line_no += 1;

                    // LEAVE A BLANK LINE
                    if (i == 3)
                        t_Line_no += 1;
                }
                //END FOR I
                // ----------------------------------------------------------------------------------------------------------

                // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL 28PAIRS : DAILY
                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (GTotal_28Pair_Total_Pips[l, t_TF] >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
                tstr_GrandTotal = GTotal_28Pair_Total_Pips[l, t_TF].ToString("0");
                tstr_ATR = GTotal_28Pair_ATR_Value[l, t_TF].ToString("");

                Draw_OnChart_C1("PrvMPips11" + temp_1, t_Line_no, (t_Col_no), "Total 28-Pairs", t_Clr);
                Draw_OnChart_C1("PrvMPips12" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);
                Draw_OnChart_C1("PrvMPips13" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                // INCREASE THE LINE SPACE FOR NEXT SET OF TIMEFRAME VALUES
                t_Line_no = t_Row;
                t_Col_no = t_Col_no + 5;
            }
            // END FOR L
        }
        //END MEHTOD Display_MajorPair_Weekly_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_Monthly_Total_Pips                                         ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_Monthly_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_2 = 0;
            double t_ATR;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, temp_1, tstr_TFrame, tstr_GrandTotal, tstr_ATR;
            Colors t_Clr;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 6;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;


            // DISPLAY AVERAGE VALUES ---------------------------------------------------------------------------------

            // COLUMN HEADINGs
            Draw_OnChart_C1("AvgPips01", (t_Line_no - 2), (t_Col_no), "AVERAGE", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips02", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

            Draw_OnChart_C1("AvgPips03", (t_Line_no - 2), (t_Col_no + t_Offset), "Month", Clr_Heading_1);
            Draw_OnChart_C1("AvgPips04", (t_Line_no - 1), (t_Col_no + t_Offset), "AVG-Pips", Clr_Heading_1);

            //LOOP TO DISPLAY AVERAGE VALUES
            for (int i = 0; i < 8; i++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = i.ToString();

                // SORT AS PER THE CURRENT SORTED MAJOR PAIR VALUES
                t_1 = Sorted_MajorPair_Monthly_Total_Pips[0, i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Avg_All_MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // GET TOTAL PIP FOR COMPARISON WITH AVERAGE TO SET THE COLOR
                t_2 = Math.Abs(All_MajorPair_Total_Pips[0, t_1, t_TF]);

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_2 >= t_Total_Pip)
                    t_Clr = Clr_Above;
                else
                    t_Clr = Clr_Below;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("AVGPips05" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("AVGPips06" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3)
                    t_Line_no += 1;
            }
            //END FOR I

            // DISPLAY : AVERAGE OF 28 PAIRS TOTAL PIPS : CURRENT MONTH
            if (GTotal_28Pair_Total_Pips[0, t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            tstr_GrandTotal = (GTotal_28Pair_Total_Pips[0, t_TF] / 28).ToString("0");
            Draw_OnChart_C1("AvgPips07", t_Line_no, (t_Col_no), "Avg of 28-Pairs", t_Clr);
            Draw_OnChart_C1("AvgPips08", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);



            // DISPLAY TOTAL PIPS  ---------------------------------------------------------------------------------
            // RESET ROW COL POSITION TO DISPLAY THE NEXT LOOP VALUES
            t_Line_no = t_Row;
            t_Col_no = t_Col_no + 4;
            // LOOP TO DISPLAY LAST x VALUES
            for (int l = 0; l < LP1; l++)
            {
                // CONVERT t_Last_Price to STRING FOR UNIQUE OBJECT NAME IN Draw_OnChart_C1 METHOD
                temp_1 = l.ToString();

                // GET THE TIME FRAME NAME
                tstr_TFrame = LP1_TF_Name[l];

                // COLUMN HEADINGs
                Draw_OnChart_C1("PrvMPips01" + temp_1, (t_Line_no - 2), (t_Col_no), tstr_TFrame, Clr_Heading_1);
                Draw_OnChart_C1("PrvMPips02" + temp_1, (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips03" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset), "Month", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips04" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

                Draw_OnChart_C1("PrvPMPips05" + temp_1, (t_Line_no - 2), (t_Col_no + t_Offset + 1), "Month", Clr_Heading_1);
                Draw_OnChart_C1("PrvPMPips06" + temp_1, (t_Line_no - 1), (t_Col_no + t_Offset + 1), "ATR", Clr_Heading_1);

                // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
                for (int i = 0; i < 8; i++)
                {
                    // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                    t_1 = Sorted_MajorPair_Monthly_Total_Pips[l, i];

                    // GET SYMBOL CODE AS PER THE t_Index
                    tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                    // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                    t_Total_Pip = All_MajorPair_Total_Pips[l, t_1, t_TF];
                    tstr_TPips = t_Total_Pip.ToString("0");

                    // GET ATR VALUE
                    t_ATR = All_MajorPair_ATR_Value[l, t_1, t_TF];
                    tstr_ATR = t_ATR.ToString();

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= t_ATR)
                        t_Clr = Clr_Above;


                    // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                    Draw_OnChart_C1("PrvMPips07" + temp_1, t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                    Draw_OnChart_C1("PrvMPips08" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                    // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                    if (t_Total_Pip >= 0)
                        t_Clr = Clr_Positive;
                    else
                        t_Clr = Clr_Negative;

                    // DRAW ATR VALUES ON CHART
                    Draw_OnChart_C1("PrvMPips10" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                    // INC. THE LINE #
                    t_Line_no += 1;

                    // LEAVE A BLANK LINE
                    if (i == 3)
                        t_Line_no += 1;
                }
                //END FOR I
                // ----------------------------------------------------------------------------------------------------------

                // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL 28PAIRS : DAILY
                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (GTotal_28Pair_Total_Pips[l, t_TF] >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
                tstr_GrandTotal = GTotal_28Pair_Total_Pips[l, t_TF].ToString("0");
                tstr_ATR = GTotal_28Pair_ATR_Value[l, t_TF].ToString("");

                Draw_OnChart_C1("PrvMPips11" + temp_1, t_Line_no, (t_Col_no), "Total 28-Pairs", t_Clr);
                Draw_OnChart_C1("PrvMPips12" + temp_1, t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);
                Draw_OnChart_C1("PrvMPips13" + temp_1, t_Line_no, (t_Col_no + t_Offset + 1), tstr_ATR, t_Clr);

                // INCREASE THE LINE SPACE FOR NEXT SET OF TIMEFRAME VALUES
                t_Line_no = t_Row;
                t_Col_no = t_Col_no + 5;
            }
            // END FOR L
        }
        //END MEHTOD Display_MajorPair_Monthly_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Get_MajorPair_Total_Pips                                                     ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Get_MajorPair_Total_Pips()
        {
            string tstr_s1;
            int t_index;
            double t_Total = 0, t_GrandTotal = 0;

            // LOOP FOR PREVIOUS PRICES : LP IS A GLOBAL VARIABLE TO SET THE LOOP LIMIT
            for (int l = 0; l < LP1; l++)
            {
                // FOR : 5MIN, 15MIN, 1HOUR, 4HOUR, DAILY, WEEKLY, MONTHLY
                for (int k = 0; k < 7; k++)
                {
                    // 8 - MAJOR PAIR
                    for (int i = 0; i < 8; i++)
                    {
                        // 7 - SUB PAIR
                        for (int j = 0; j < 7; j++)
                        {
                            tstr_s1 = MajorPair_Combo[i, j];
                            // MEHTOD CALL
                            t_index = Return_Pair_Index_Position(tstr_s1);

                            // GET 15-MINS TOTAL PIPS
                            t_Total += (All_28Pair_Total_Pips[l, t_index, k] * Base_Currency[i, j]);
                            All_MajorPair_Total_Pips[l, i, k] = t_Total;
                        }
                        //END FOR j

                        //RESET
                        t_Total = 0;

                        // GRAND TOTAL OF ALL VALUES
                        t_GrandTotal += All_MajorPair_Total_Pips[l, i, k];
                        GTotal_MajorPair_Total_Pips[l, k] = t_GrandTotal;
                    }
                    //END FOR i

                    //RESET
                    t_GrandTotal = 0;
                }
                //END FOR k
            }
            // END FOR l
        }
        //END MEHTOD Get_MajorPair_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Get_MajorPair_ATR_Values                                                     ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Get_MajorPair_ATR_Values()
        {
            string tstr_s1;
            int t_index;
            double t_Total = 0, t_GrandTotal = 0;

            // LOOP FOR PREVIOUS PRICES : LP IS A GLOBAL VARIABLE TO SET THE LOOP LIMIT
            for (int l = 0; l < LP1; l++)
            {
                // FOR : 5MIN, 15MIN, 1HOUR, 4HOUR, DAILY, WEEKLY, MONTHLY
                for (int k = 0; k < 7; k++)
                {
                    // 8 - MAJOR PAIR
                    for (int i = 0; i < 8; i++)
                    {
                        // 7 - SUB PAIR
                        for (int j = 0; j < 7; j++)
                        {
                            tstr_s1 = MajorPair_Combo[i, j];
                            // MEHTOD CALL
                            t_index = Return_Pair_Index_Position(tstr_s1);

                            // GET 15-MINS TOTAL PIPS
                            t_Total += (All_28Pair_ATR_Value[l, t_index, k]);
                            All_MajorPair_ATR_Value[l, i, k] = t_Total;
                        }
                        //END FOR j

                        //RESET
                        t_Total = 0;

                        // GRAND TOTAL OF ALL VALUES
                        t_GrandTotal += All_MajorPair_ATR_Value[l, i, k];
                        GTotal_MajorPair_ATR_Value[l, k] = t_GrandTotal;
                    }
                    //END FOR i

                    //RESET
                    t_GrandTotal = 0;
                }
                //END FOR k
            }
            // END FOR l
        }
        //END MEHTOD Get_MajorPair_ATR_Values

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Load_28Pair_ATR_Values                                                       ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_ATR_Values()
        {
            double t_PipSize;
            double t_0 = 0, t_1 = 0, t_2 = 0, t_3 = 0, t_4 = 0, t_5 = 0, t_6 = 0;
            Symbol t_Symbol;
            string tstr_Symbol_Code;
            int t_ind;

            // LOOP FOR PREVIOUS PRICES : LP IS A GLOBAL VARIABLE TO SET THE LOOP LIMIT
            for (int l = 0; l < LP1; l++)
            {
                t_ind = LP1_Array_Open[l];

                //LOOP FOR 28 PAIRS
                for (int i = 0; i < 28; i++)
                {
                    // GET SYMBOL
                    t_Symbol = Get_28Pair_Symbol(i);
                    tstr_Symbol_Code = t_Symbol.Code.ToString();
                    t_PipSize = t_Symbol.PipSize;

                    //GET A TEMP VARIABLE FOR MARKETDATA FOR THE SYMBOL AND TIME FRAME SPECIFIED BY USER
                    // 5-MIN
                    var temp_1 = MarketData.GetSeries(tstr_Symbol_Code, TF_5min);
                    ATR_Indicator_1 = Indicators.AverageTrueRange(temp_1, ATR_P_5min, p_ATR_MA_Type);
                    // 15-MIN
                    var temp_2 = MarketData.GetSeries(tstr_Symbol_Code, TF_15min);
                    ATR_Indicator_2 = Indicators.AverageTrueRange(temp_2, ATR_P_15min, p_ATR_MA_Type);
                    // 1-HOUR
                    var temp_3 = MarketData.GetSeries(tstr_Symbol_Code, TF_1Hr);
                    ATR_Indicator_3 = Indicators.AverageTrueRange(temp_3, ATR_P_1Hr, p_ATR_MA_Type);
                    // 4-HOUR
                    var temp_4 = MarketData.GetSeries(tstr_Symbol_Code, TF_4Hr);
                    ATR_Indicator_4 = Indicators.AverageTrueRange(temp_4, ATR_P_4Hr, p_ATR_MA_Type);
                    // Daily
                    var temp_5 = MarketData.GetSeries(tstr_Symbol_Code, TF_D);
                    ATR_Indicator_5 = Indicators.AverageTrueRange(temp_5, ATR_P_D, p_ATR_MA_Type);
                    // Weekly
                    var temp_6 = MarketData.GetSeries(tstr_Symbol_Code, TF_Wk);
                    ATR_Indicator_6 = Indicators.AverageTrueRange(temp_6, ATR_P_Wk, p_ATR_MA_Type);
                    // Monthly
                    var temp_7 = MarketData.GetSeries(tstr_Symbol_Code, TF_Mt);
                    ATR_Indicator_7 = Indicators.AverageTrueRange(temp_7, ATR_P_Mt, p_ATR_MA_Type);

                    //STORE ATR VALUE IN THE ARRAY.  ARRAY STARTS FROM 0 INDEX
                    // 5-MIN
                    All_28Pair_ATR_Value[l, i, 0] = Math.Round(ATR_Indicator_1.Result.Last(t_ind) / t_PipSize, 0);
                    t_0 += All_28Pair_ATR_Value[l, i, 0];
                    // 15-MIN
                    All_28Pair_ATR_Value[l, i, 1] = Math.Round(ATR_Indicator_2.Result.Last(t_ind) / t_PipSize, 0);
                    t_1 += All_28Pair_ATR_Value[l, i, 1];
                    // 1-HOUR
                    All_28Pair_ATR_Value[l, i, 2] = Math.Round(ATR_Indicator_3.Result.Last(t_ind) / t_PipSize, 0);
                    t_2 += All_28Pair_ATR_Value[l, i, 2];
                    // 4-HOUR
                    All_28Pair_ATR_Value[l, i, 3] = Math.Round(ATR_Indicator_4.Result.Last(t_ind) / t_PipSize, 0);
                    t_3 += All_28Pair_ATR_Value[l, i, 3];
                    // DAILY
                    All_28Pair_ATR_Value[l, i, 4] = Math.Round(ATR_Indicator_5.Result.Last(t_ind) / t_PipSize, 0);
                    t_4 += All_28Pair_ATR_Value[l, i, 4];
                    // WEEKLY
                    All_28Pair_ATR_Value[l, i, 5] = Math.Round(ATR_Indicator_6.Result.Last(t_ind) / t_PipSize, 0);
                    t_5 += All_28Pair_ATR_Value[l, i, 5];
                    // MONTHLY
                    All_28Pair_ATR_Value[l, i, 6] = Math.Round(ATR_Indicator_7.Result.Last(t_ind) / t_PipSize, 0);
                    t_6 += All_28Pair_ATR_Value[l, i, 6];
                }
                //END FOR i

                //UPDATE THE GRANDTOTAL OF "TOTAL ATR VALUE" 
                GTotal_28Pair_ATR_Value[l, 0] = t_0;
                GTotal_28Pair_ATR_Value[l, 1] = t_1;
                GTotal_28Pair_ATR_Value[l, 2] = t_2;
                GTotal_28Pair_ATR_Value[l, 3] = t_3;
                GTotal_28Pair_ATR_Value[l, 4] = t_4;
                GTotal_28Pair_ATR_Value[l, 5] = t_5;
                GTotal_28Pair_ATR_Value[l, 6] = t_6;

                //RESET
                t_0 = 0;
                t_1 = 0;
                t_2 = 0;
                t_3 = 0;
                t_4 = 0;
                t_5 = 0;
                t_6 = 0;
            }
            // END FOR l
        }
        //END MEHTOD Load_28Pair_ATR_Values

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Get_28Pair_TOTAL_Pips_from_Open                                              ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Get_28Pair_TOTAL_Pips_from_Open()
        {
            //Print("Inside : TOTAL_Pips_from_Open");

            double t_PipSize;
            double t_0 = 0, t_1 = 0, t_2 = 0, t_3 = 0, t_4 = 0, t_5 = 0, t_6 = 0;
            double t_Close_P1, t_Close_P2, t_Close_P3, t_Close_P4, t_Close_P5, t_Close_P6, t_Close_P7;
            double t_Open_P1, t_Open_P2, t_Open_P3, t_Open_P4, t_Open_P5, t_Open_P6, t_Open_P7;

            // LOOP FOR PREVIOUS PRICES : LP IS A GLOBAL VARIABLE TO SET THE LOOP LIMIT
            for (int l = 0; l < LP1; l++)
            {
                //LOOP FOR 28 PAIRS
                for (int i = 0; i < 28; i++)
                {
                    // LOAD PIP SIZE
                    t_PipSize = All_28Pair_Pip_Size[i];

                    // ----------     LOAD CLOSE PRICE : ALL TIME FRAMES
                    t_Close_P1 = All_28Pair_Close_Price[l, i, 0];
                    t_Close_P2 = All_28Pair_Close_Price[l, i, 1];
                    t_Close_P3 = All_28Pair_Close_Price[l, i, 2];
                    t_Close_P4 = All_28Pair_Close_Price[l, i, 3];
                    t_Close_P5 = All_28Pair_Close_Price[l, i, 4];
                    t_Close_P6 = All_28Pair_Close_Price[l, i, 5];
                    t_Close_P7 = All_28Pair_Close_Price[l, i, 6];

                    // ----------     LOAD OPEN PRICES : ALL TRIME FRAMES
                    t_Open_P1 = All_28Pair_Open_Price[l, i, 0];
                    t_Open_P2 = All_28Pair_Open_Price[l, i, 1];
                    t_Open_P3 = All_28Pair_Open_Price[l, i, 2];
                    t_Open_P4 = All_28Pair_Open_Price[l, i, 3];
                    t_Open_P5 = All_28Pair_Open_Price[l, i, 4];
                    t_Open_P6 = All_28Pair_Open_Price[l, i, 5];
                    t_Open_P7 = All_28Pair_Open_Price[l, i, 6];

                    //STORE THE OPEN.LAST VALUE IN THE ARRAY.  ARRAY STARTS FROM 0 INDEX
                    // 5-MIN
                    All_28Pair_Total_Pips[l, i, 0] = Math.Round(((t_Close_P1 - t_Open_P1) / t_PipSize), 0);
                    t_0 += All_28Pair_Total_Pips[l, i, 0];
                    // 15-MIN
                    All_28Pair_Total_Pips[l, i, 1] = Math.Round(((t_Close_P2 - t_Open_P2) / t_PipSize), 0);
                    t_1 += All_28Pair_Total_Pips[l, i, 1];
                    // 1-HOUR
                    All_28Pair_Total_Pips[l, i, 2] = Math.Round(((t_Close_P3 - t_Open_P3) / t_PipSize), 0);
                    t_2 += All_28Pair_Total_Pips[l, i, 2];
                    // 4-HOUR
                    All_28Pair_Total_Pips[l, i, 3] = Math.Round(((t_Close_P4 - t_Open_P4) / t_PipSize), 0);
                    t_3 += All_28Pair_Total_Pips[l, i, 3];
                    // DAILY
                    All_28Pair_Total_Pips[l, i, 4] = Math.Round(((t_Close_P5 - t_Open_P5) / t_PipSize), 0);
                    t_4 += All_28Pair_Total_Pips[l, i, 4];
                    // WEEKLY
                    All_28Pair_Total_Pips[l, i, 5] = Math.Round(((t_Close_P6 - t_Open_P6) / t_PipSize), 0);
                    t_5 += All_28Pair_Total_Pips[l, i, 5];
                    // MONTHLY
                    All_28Pair_Total_Pips[l, i, 6] = Math.Round(((t_Close_P7 - t_Open_P7) / t_PipSize), 0);
                    t_6 += All_28Pair_Total_Pips[l, i, 6];

                    //UPDATE THE GRANDTOTAL OF "TOTAL PIPS" MOVED FROM OPEN PRICES : DAILY, WEEKLY, MONTHLY
                    GTotal_28Pair_Total_Pips[l, 0] = t_0;
                    GTotal_28Pair_Total_Pips[l, 1] = t_1;
                    GTotal_28Pair_Total_Pips[l, 2] = t_2;
                    GTotal_28Pair_Total_Pips[l, 3] = t_3;
                    GTotal_28Pair_Total_Pips[l, 4] = t_4;
                    GTotal_28Pair_Total_Pips[l, 5] = t_5;
                    GTotal_28Pair_Total_Pips[l, 6] = t_6;
                }
                //END FOR i

                //RESET
                t_0 = 0;
                t_1 = 0;
                t_2 = 0;
                t_3 = 0;
                t_4 = 0;
                t_5 = 0;
                t_6 = 0;
            }
            // END FOR L
        }
        //END MEHTOD Get_28Pair_TOTAL_Pips_from_Open

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Load_28Pair_HiLo_Prices                                                      ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_HiLo_Prices()
        {
            //Print("Inside : -PREVIOUS- : Close AND HiLo Prices");

            //double t_1;
            Symbol t_Symbol;
            string tstr_Symbol_Code;
            int t_ind;

            // LOOP FOR PREVIOUS PRICES : LP IS A GLOBAL VARIABLE TO SET THE LOOP LIMIT
            for (int l = 0; l < LP1; l++)
            {
                t_ind = LP1_Array_Close[l];

                //LOOP FOR 28 PAIRS
                for (int i = 0; i < 28; i++)
                {
                    // GET SYMBOL
                    t_Symbol = Get_28Pair_Symbol(i);
                    tstr_Symbol_Code = t_Symbol.Code.ToString();

                    //GET 5-MIN OPEN PRICES FOR THE SYMBOL
                    var temp_1 = MarketData.GetSeries(tstr_Symbol_Code, TF_5min);
                    //GET 15-MIN OPEN PRICES FOR THE SYMBOL
                    var temp_2 = MarketData.GetSeries(tstr_Symbol_Code, TF_15min);
                    //GET 1-HOUR OPEN PRICES FOR THE SYMBOL
                    var temp_3 = MarketData.GetSeries(tstr_Symbol_Code, TF_1Hr);
                    //GET 4-hOUR OPEN PRICES FOR THE SYMBOL
                    var temp_4 = MarketData.GetSeries(tstr_Symbol_Code, TF_4Hr);
                    //GET DAILY OPEN PRICES FOR THE SYMBOL
                    var temp_5 = MarketData.GetSeries(tstr_Symbol_Code, TF_D);
                    //GET Weekly OPEN PRICES FOR THE SYMBOL
                    var temp_6 = MarketData.GetSeries(tstr_Symbol_Code, TF_Wk);
                    //GET Monthly OPEN PRICES FOR THE SYMBOL
                    var temp_7 = MarketData.GetSeries(tstr_Symbol_Code, TF_Mt);

                    //  ------------  HI-LO PRICES 
                    // 5-MIN
                    All_28Pair_HiLo_Price[l, i, 0] = temp_1.High.Last(t_ind);
                    All_28Pair_HiLo_Price[l, i, 1] = temp_1.Low.Last(t_ind);
                    // 15-MIN
                    All_28Pair_HiLo_Price[l, i, 2] = temp_2.High.Last(t_ind);
                    All_28Pair_HiLo_Price[l, i, 3] = temp_2.Low.Last(t_ind);
                    // 1-HOUR
                    All_28Pair_HiLo_Price[l, i, 4] = temp_3.High.Last(t_ind);
                    All_28Pair_HiLo_Price[l, i, 5] = temp_3.Low.Last(t_ind);
                    // 4-HOUR
                    All_28Pair_HiLo_Price[l, i, 6] = temp_4.High.Last(t_ind);
                    All_28Pair_HiLo_Price[l, i, 7] = temp_4.Low.Last(t_ind);
                    // DAILY
                    All_28Pair_HiLo_Price[l, i, 8] = temp_5.High.Last(t_ind);
                    All_28Pair_HiLo_Price[l, i, 9] = temp_5.Low.Last(t_ind);
                    // WEEKLY
                    All_28Pair_HiLo_Price[l, i, 10] = temp_6.High.Last(t_ind);
                    All_28Pair_HiLo_Price[l, i, 11] = temp_6.Low.Last(t_ind);
                    // MONTHLY
                    All_28Pair_HiLo_Price[l, i, 12] = temp_7.High.Last(t_ind);
                    All_28Pair_HiLo_Price[l, i, 13] = temp_7.Low.Last(t_ind);
                }
                //END FOR i
            }
            // END FOR l
        }
        //END METHOD Load_28Pair_HiLo_Prices


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Load_28Pair_Close_Prices                                                     ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_Close_Prices()
        {
            //Print("Inside : -PREVIOUS- : Close AND HiLo Prices");

            //double t_1;
            Symbol t_Symbol;
            string tstr_Symbol_Code;
            int t_ind;

            // LOOP FOR PREVIOUS PRICES : LP IS A GLOBAL VARIABLE TO SET THE LOOP LIMIT
            for (int l = 0; l < LP1; l++)
            {
                t_ind = LP1_Array_Close[l];

                //LOOP FOR 28 PAIRS
                for (int i = 0; i < 28; i++)
                {
                    // GET SYMBOL
                    t_Symbol = Get_28Pair_Symbol(i);
                    tstr_Symbol_Code = t_Symbol.Code.ToString();

                    //GET 5-MIN OPEN PRICES FOR THE SYMBOL
                    var temp_1 = MarketData.GetSeries(tstr_Symbol_Code, TF_5min);
                    //GET 15-MIN OPEN PRICES FOR THE SYMBOL
                    var temp_2 = MarketData.GetSeries(tstr_Symbol_Code, TF_15min);
                    //GET 1-HOUR OPEN PRICES FOR THE SYMBOL
                    var temp_3 = MarketData.GetSeries(tstr_Symbol_Code, TF_1Hr);
                    //GET 4-hOUR OPEN PRICES FOR THE SYMBOL
                    var temp_4 = MarketData.GetSeries(tstr_Symbol_Code, TF_4Hr);
                    //GET DAILY OPEN PRICES FOR THE SYMBOL
                    var temp_5 = MarketData.GetSeries(tstr_Symbol_Code, TF_D);
                    //GET Weekly OPEN PRICES FOR THE SYMBOL
                    var temp_6 = MarketData.GetSeries(tstr_Symbol_Code, TF_Wk);
                    //GET Monthly OPEN PRICES FOR THE SYMBOL
                    var temp_7 = MarketData.GetSeries(tstr_Symbol_Code, TF_Mt);

                    //  -----------   CLOSE PRICES
                    // 5-MIN
                    All_28Pair_Close_Price[l, i, 0] = temp_1.Close.Last(t_ind);
                    // 15-MIN
                    All_28Pair_Close_Price[l, i, 1] = temp_2.Close.Last(t_ind);
                    // 1-HOUR
                    All_28Pair_Close_Price[l, i, 2] = temp_3.Close.Last(t_ind);
                    // 4-HOUR
                    All_28Pair_Close_Price[l, i, 3] = temp_4.Close.Last(t_ind);
                    // DAILY
                    All_28Pair_Close_Price[l, i, 4] = temp_5.Close.Last(t_ind);
                    // WEEKLY
                    All_28Pair_Close_Price[l, i, 5] = temp_6.Close.Last(t_ind);
                    // MONTHLY
                    All_28Pair_Close_Price[l, i, 6] = temp_7.Close.Last(t_ind);
                }
                //END FOR i
            }
            // END FOR l
        }
        //END METHOD Load_28Pair_Close_Prices

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                            Load_28Pair_Open_Prices                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_Open_Prices()
        {
            //Print("Inside : CURRENT : Load 28Pair Open Prices");

            Symbol t_Symbol;
            string tstr_Symbol_Code;
            int t_ind;

            // LOOP FOR PREVIOUS PRICES : LP IS A GLOBAL VARIABLE TO SET THE LOOP LIMIT
            for (int l = 0; l < LP1; l++)
            {
                t_ind = LP1_Array_Open[l];

                for (int i = 0; i < 28; i++)
                {
                    // GET SYMBOL
                    t_Symbol = Get_28Pair_Symbol(i);
                    tstr_Symbol_Code = t_Symbol.Code.ToString();

                    //GET 5-MIN OPEN PRICES FOR THE SYMBOL
                    var temp_1 = MarketData.GetSeries(tstr_Symbol_Code, TF_5min);
                    //GET 15-MIN OPEN PRICES FOR THE SYMBOL
                    var temp_2 = MarketData.GetSeries(tstr_Symbol_Code, TF_15min);
                    //GET 1-HOUR OPEN PRICES FOR THE SYMBOL
                    var temp_3 = MarketData.GetSeries(tstr_Symbol_Code, TF_1Hr);
                    //GET 4-hOUR OPEN PRICES FOR THE SYMBOL
                    var temp_4 = MarketData.GetSeries(tstr_Symbol_Code, TF_4Hr);
                    //GET DAILY OPEN PRICES FOR THE SYMBOL
                    var temp_5 = MarketData.GetSeries(tstr_Symbol_Code, TF_D);
                    //GET Weekly OPEN PRICES FOR THE SYMBOL
                    var temp_6 = MarketData.GetSeries(tstr_Symbol_Code, TF_Wk);
                    //GET Monthly OPEN PRICES FOR THE SYMBOL
                    var temp_7 = MarketData.GetSeries(tstr_Symbol_Code, TF_Mt);

                    ///  -----------   OPEN PRICES
                    // 5-MIN
                    All_28Pair_Open_Price[l, i, 0] = temp_1.Open.Last(t_ind);
                    // 15-MIN
                    All_28Pair_Open_Price[l, i, 1] = temp_2.Open.Last(t_ind);
                    // 1-HOUR
                    All_28Pair_Open_Price[l, i, 2] = temp_3.Open.Last(t_ind);
                    // 4-HOUR
                    All_28Pair_Open_Price[l, i, 3] = temp_4.Open.Last(t_ind);
                    // DAILY
                    All_28Pair_Open_Price[l, i, 4] = temp_5.Open.Last(t_ind);
                    // WEEKLY
                    All_28Pair_Open_Price[l, i, 5] = temp_6.Open.Last(t_ind);
                    // MONTHLY
                    All_28Pair_Open_Price[l, i, 6] = temp_7.Open.Last(t_ind);

                }
                //END FOR i

                //Print("LP1 INDEX VALUE = " + t_ind);

            }
            // END FOR l

        }
        //END METHOD Load_28Pair_Open_Prices

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                            OnSTART_Load_28Pair_Open_Prices                                   ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void OnSTART_Load_28Pair_Open_Prices()
        {
            Print("Inside : FIRST TIME ONLY : GET 28-PAIR OPEN PRICES ON START");

            Symbol t_Symbol;
            string tstr_Symbol_Code;
            double t_1;

            // GET 5 PAIRS OPEN PRICES
            for (int i = 0; i < 28; i++)
            {
                // GET SYMBOL
                t_Symbol = Get_28Pair_Symbol(i);
                tstr_Symbol_Code = t_Symbol.Code.ToString();


                //GET 5-MIN OPEN PRICES FOR THE SYMBOL
                var temp_1 = MarketData.GetSeries(tstr_Symbol_Code, TF_5min);
                //GET 15-MIN OPEN PRICES FOR THE SYMBOL
                var temp_2 = MarketData.GetSeries(tstr_Symbol_Code, TF_15min);
                //GET 1-HOUR OPEN PRICES FOR THE SYMBOL
                var temp_3 = MarketData.GetSeries(tstr_Symbol_Code, TF_1Hr);
                //GET 4-hOUR OPEN PRICES FOR THE SYMBOL
                var temp_4 = MarketData.GetSeries(tstr_Symbol_Code, TF_4Hr);
                //GET DAILY OPEN PRICES FOR THE SYMBOL
                var temp_5 = MarketData.GetSeries(tstr_Symbol_Code, TF_D);
                //GET Weekly OPEN PRICES FOR THE SYMBOL
                var temp_6 = MarketData.GetSeries(tstr_Symbol_Code, TF_Wk);
                //GET Monthly OPEN PRICES FOR THE SYMBOL
                var temp_7 = MarketData.GetSeries(tstr_Symbol_Code, TF_Mt);

                ///  -----------   OPEN PRICES
                // 5-MIN
                t_1 = temp_1.Open.LastValue;
                // 15-MIN
                t_1 = temp_2.Open.LastValue;
                // 1-HOUR
                t_1 = temp_3.Open.LastValue;
                // 4-HOUR
                t_1 = temp_4.Open.LastValue;
                // DAILY
                t_1 = temp_5.Open.LastValue;
                // WEEKLY
                t_1 = temp_6.Open.LastValue;
                // MONTHLY
                t_1 = temp_7.Open.LastValue;

                Print(i + ". " + tstr_Symbol_Code + " =  " + t_1);
            }
            //END FOR i
        }
        //END METHOD OnSTART_Load_28Pair_Open_Prices


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                          Load_28Pair_PipSize                                                 ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_PipSize()
        {
            Print("Inside : Load 28Pair Pip-Size");

            Symbol t_Symbol;

            // LOOP FOR 28 PAIRS
            for (int i = 0; i < 28; i++)
            {
                // GET SYMBOL
                t_Symbol = Get_28Pair_Symbol(i);

                All_28Pair_Pip_Size[i] = t_Symbol.PipSize;
            }
            //END FOR
        }
        //END METHOD Load_28Pair_PipSize

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                          Load_28Pair_SymbolCode                                              ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_SymbolCode()
        {
            Print("Inside : Load 28Pair Symbol-Code");

            string tstr_Symbol_Code;
            Symbol t_Symbol;

            // LOOP FOR 28 PAIRS
            for (int i = 0; i < 28; i++)
            {
                // GET SYMBOL
                t_Symbol = Get_28Pair_Symbol(i);
                tstr_Symbol_Code = t_Symbol.Code.ToString();

                All_28Pair_Symbol_Code[i] = tstr_Symbol_Code;
            }
            //END FOR
        }
        //END METHOD Load_28Pair_SymbolCode

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
        //END METHOD CLOSE_ALL_Pending_Orders
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
        //END METHOD CloseAll_PendingOrders

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
        //END METHOD CLOSE_ALL_Open_Position
        ////////////////////////////////////////////////////////////////////////////////////////////
        //CLOSE-ALL POSITIVE OR NEGATIVE TRADES IRRESPECTIVE OF THE LABEL
        private void CloseAll_Positions(bool Flag_Profit_Loss)
        {
            foreach (var pen in Positions)
            {
                //CLOSE ALL PROFITABLE TRADE
                if (Flag_Profit_Loss)
                    if (pen.NetProfit >= 0)
                        ClosePositionAsync(pen);

                //CLOSE ALL LOSS TRADE
                if (!Flag_Profit_Loss)
                    if (pen.NetProfit <= 0)
                        ClosePositionAsync(pen);
            }
            //END FOR-EACH
        }
        //END METHOD CloseAll_Positions
        ////////////////////////////////////////////////////////////////////////////////////////////
        //CLOSE PROFITABLE OR NEGATIVE TRADE THAT ARE ABOVE/BELOW THE TARGET VALUE (t_Target)
        private void CloseAll_Positions(int t_Target)
        {
            foreach (var pen in Positions)
            {
                //IF POSITIVE VALUE : CLOSE ALL GREATER THEN TARGET PRICE
                if (t_Target >= 0)
                    if (pen.NetProfit >= t_Target)
                        ClosePositionAsync(pen);

                //IF NEGATIVE VALUE : CLOSE ALL LESS THEN THE TARGET PRICE
                if (t_Target < 0)
                    if (pen.NetProfit <= t_Target)
                        ClosePositionAsync(pen);
            }
            //END FOR-EACH
        }
        //END METHOD CloseAll_Positions
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
        //END METHOD CloseAll_Positions

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
        //End METHOD Write_To_CSV_File  

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ADD COMMA TO THE STRING FUNCITON                                                       //////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private string Concate_With_Comma(params object[] parameters)
        {
            return string.Join(",", parameters.Select(p => p.ToString()));
        }
        //End METHOD CONCAT_WITH_COMMA

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
        //End METHOD Create_CSV_File

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

            //BLANK LINE
            Print("");
        }
        //END METHOD On_STOP

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        Get_28Pair_Symbol                                                                     ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private Symbol Get_28Pair_Symbol(int t_Pair)
        {
            switch (t_Pair)
            {
                //////////////////////////////////////////////
                ///  JPY PAIRS x 7
                //////////////////////////////////////////////
                case 0:
                    return MarketData.GetSymbol("GBPJPY");
                    break;
                case 1:
                    return MarketData.GetSymbol("USDJPY");
                    break;
                case 2:
                    return MarketData.GetSymbol("CADJPY");
                    break;
                case 3:
                    return MarketData.GetSymbol("AUDJPY");
                    break;
                case 4:
                    return MarketData.GetSymbol("NZDJPY");
                    break;
                case 5:
                    return MarketData.GetSymbol("EURJPY");
                    break;
                case 6:
                    return MarketData.GetSymbol("CHFJPY");
                    break;
                //////////////////////////////////////////////
                ///  EUR PAIRS x 6
                //////////////////////////////////////////////
                case 7:
                    return MarketData.GetSymbol("EURNZD");
                    break;
                case 8:
                    return MarketData.GetSymbol("EURCAD");
                    break;
                case 9:
                    return MarketData.GetSymbol("EURAUD");
                    break;
                case 10:
                    return MarketData.GetSymbol("EURUSD");
                    break;
                case 11:
                    return MarketData.GetSymbol("EURGBP");
                    break;
                case 12:
                    return MarketData.GetSymbol("EURCHF");
                    break;
                //////////////////////////////////////////////
                ///  GBP PAIRS x 5
                //////////////////////////////////////////////
                case 13:
                    return MarketData.GetSymbol("GBPNZD");
                    break;
                case 14:
                    return MarketData.GetSymbol("GBPAUD");
                    break;
                case 15:
                    return MarketData.GetSymbol("GBPCAD");
                    break;
                case 16:
                    return MarketData.GetSymbol("GBPCHF");
                    break;
                case 17:
                    return MarketData.GetSymbol("GBPUSD");
                    break;
                //////////////////////////////////////////////
                ///  AUD PAIRS x 4
                //////////////////////////////////////////////
                case 18:
                    return MarketData.GetSymbol("AUDUSD");
                    break;
                case 19:
                    return MarketData.GetSymbol("AUDCHF");
                    break;
                case 20:
                    return MarketData.GetSymbol("AUDNZD");
                    break;
                case 21:
                    return MarketData.GetSymbol("AUDCAD");
                    break;
                //////////////////////////////////////////////
                ///  NZD PAIRS x 5
                //////////////////////////////////////////////    
                case 22:
                    return MarketData.GetSymbol("NZDCHF");
                    break;
                case 23:
                    return MarketData.GetSymbol("NZDUSD");
                    break;
                case 24:
                    return MarketData.GetSymbol("NZDCAD");
                    break;
                //////////////////////////////////////////////
                ///  USD PAIRS x 2
                //////////////////////////////////////////////
                case 25:
                    return MarketData.GetSymbol("USDCAD");
                    break;
                case 26:
                    return MarketData.GetSymbol("USDCHF");
                    break;
                //////////////////////////////////////////////
                ///  CAD PAIRS x 1
                //////////////////////////////////////////////
                case 27:
                    return MarketData.GetSymbol("CADCHF");
                    break;
            }
            //SWITCH

            return Symbol;
        }
        //END METHOD Get_Pair_Symbol


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        Set the Count Bar Value for Market Series Function                                     //////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Set_Count_Bar_Value()
        {
            Count_Bar = MarketSeries.Close.Count - 1;
            //Daily_Count_Bar = 1;
            //Print("Count_Bar Value = " + Count_Bar + ",     Daily_Count_Bar = " + Daily_Count_Bar);
            //Print("");
        }
        //End METHOD Set_Count_Bar_Value
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                               SET TEXT, TAB AND NEXT LINE SETTING                           ///////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Draw_OnChart_C1(string t_PreFix, int Line_No, int Tab_Pos, string t_text, Colors Draw_Color)
        {
            //CREATE A UNIQUE OBJECT NAME FOR THE METHOD ChartObjects.DrawText
            string tstr_1 = "";
            tstr_1 = t_PreFix + Line_No.ToString() + Tab_Pos.ToString();

            ChartObjects.DrawText(tstr_1, my_NL(Line_No) + my_Tabs(Tab_Pos) + t_text, StaticPosition.TopLeft, Draw_Color);
        }
        //END METHOD
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static string my_Tabs(int n)
        {
            return new String('\t', n);
        }
        //END METHOD my_Tabs
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static string my_NL(int n)
        {
            return new String('\n', n);
        }
        //END METHOD my_NL 

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Create_Fixed_Display_1()
        {
            //int c1 = 0, c2 = 0;
            // c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0, c9 = 0;
            //int r1 = 0;
            // r2 = 0, r3 = 0, r4 = 0, r5 = 0, r6 = 0, r7 = 0, r8 = 0, r9 = 0;

            //Heading # 1
            //r1 = 1;
            //c1 = 3;
            //ChartObjects.DrawText("a00", my_NL(r1 + 0) + my_Tabs(c1) + "Line 1", StaticPosition.TopLeft, Colors.Yellow);

            //Heading # 2
            //c2 = c1 + 1;
            //ChartObjects.DrawText("b00", my_NL(r1 + 0) + my_Tabs(c2) + "Line 1", StaticPosition.TopLeft, Colors.Yellow);
        }
        //END METHOD Create_Fixed_Display_1

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Create_Fixed_Display_2()
        {
            //int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0, c9 = 0;
            //int r1 = 0, r2 = 0, r3 = 0, r4 = 0, r5 = 0, r6 = 0, r7 = 0, r8 = 0, r9 = 0;
        }
        //END METHOD Create_Fixed_Display_2
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Create_Display_RowColumn()
        {
            //int r1, c1;
            string t_text = "";

            // DISPLAY LINE # 
            for (int i = 0; i <= 80; i++)
            {
                t_text = i.ToString();
                Draw_OnChart_C1("Line", i, 0, t_text, Clr_Bk_1);
            }
            //END FOR

            // DISPLAY LINE # 
            for (int i = 0; i <= 50; i++)
            {
                t_text = "C#";
                t_text = t_text + "." + i.ToString();
                Draw_OnChart_C1("Line", 0, (i), t_text, Clr_Bk_1);
            }
            //END FOR
        }
        //END METHOD Create_Display_RowColumn
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Vertical_Lines(int t_Start_Line, int t_Stop_Line, int t_Col)
        {
            //FIRST LOOP 
            for (int i = t_Start_Line; i < t_Stop_Line; i++)
            {
                Draw_OnChart_C1("VL" + i.ToString(), i, t_Col, " ||", Clr_Border);
            }
            //END FOR
        }
        //END FUNCTION Display_Major_Flag_Values
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Horizontal_Lines(int t_Line, int t_Start_Col, int t_Stop_Col)
        {
            //FIRST LOOP 
            for (int i = t_Start_Col; i < t_Stop_Col; i++)
            {
                Draw_OnChart_C1("VL" + i.ToString(), t_Line, i, "=======", Clr_Border);
            }
            //END FOR
        }
        //END FUNCTION Display_Major_Flag_Values

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                                Declare_All_Arrays                                            ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Declare_All_Arrays()
        {

            // ATR VALUES (IN PIPS)  ----------------------------------
            All_28Pair_ATR_Value = new double[LP1, 28, 7];
            GTotal_28Pair_ATR_Value = new double[LP1, 7];

            All_MajorPair_ATR_Value = new double[LP1, 8, 7];
            GTotal_MajorPair_ATR_Value = new double[LP1, 7];

            // 28-PAIRS   ----------------------------------------------    
            All_28Pair_Pip_Size = new double[28];
            All_28Pair_Symbol_Code = new string[28];

            // 8-MAJOR PAIRS   -----------------------------------------    
            // MAJOR PAIR RELATED VARIABLES
            MajorPair_Headings = new string[8];
            MajorPair_Combo = new string[8, 7];
            Base_Currency = new int[8, 7];


            //  CURRENT PRICES  ----------------------------------------
            // LP1 IS THE HISTORY OF PREVIOUS PRICES. 
            // 28 PAirs, 7 TimeFrames (5min, 15min, .....)
            All_28Pair_Open_Price = new double[LP1, 28, 7];
            All_28Pair_Close_Price = new double[LP1, 28, 7];
            All_28Pair_HiLo_Price = new double[LP1, 28, 14];

            //  TOTAL PIPS  --------------------------------------------
            All_28Pair_Total_Pips = new double[LP1, 28, 7];
            GTotal_28Pair_Total_Pips = new double[LP1, 7];

            All_MajorPair_Total_Pips = new double[LP1, 8, 7];
            GTotal_MajorPair_Total_Pips = new double[LP1, 7];

            Sorted_MajorPair_Monthly_Total_Pips = new int[LP1, 8];
            Sorted_MajorPair_Weekly_Total_Pips = new int[LP1, 8];
            Sorted_MajorPair_Daily_Total_Pips = new int[LP1, 8];
            Sorted_MajorPair_4Hour_Total_Pips = new int[LP1, 8];
            Sorted_MajorPair_Hourly_Total_Pips = new int[LP1, 8];
            Sorted_MajorPair_15min_Total_Pips = new int[LP1, 8];

            // NAMES OF THE MONTH
            Month_Name = new string[12];

            // CONTAINS THE INDEX VALUES TO ACCESS PRICES
            // CURRENT YEAR
            LP1_Array_Open = new int[LP1];
            LP1_Array_Close = new int[LP1];
            LP1_TF_Name = new string[LP1];

            //  AVERAGE PIPS   --------------------------------------------
            Avg_All_28Pair_Total_Pips = new double[28, 7];
            Avg_All_MajorPair_Total_Pips = new double[8, 7];

            // KEEP TRACK OF 8-MAJOR PAIR, IF TOTAL PIPS HAVE 
            // CROSSED AVG.PIPS, IN ALL 7 TIME FRAMES
            Flag_TotalPips_Greater_AvgPips = new int[8];
            DateTime_TotalPips_Greater_AvgPips = new string[8];

        }
        //END METHOD Declare_All_Arrays


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                                Initialize_Array_OnStart_Only                                 ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Initialize_Array_OnStart_Only()
        {

            //INITIALIZATION OF MAJOR PAIR NAMES
            MajorPair_Headings[0] = "EUR-PAIRS";
            MajorPair_Headings[1] = "GBP-PAIRS";
            MajorPair_Headings[2] = "USD-PAIRS";
            MajorPair_Headings[3] = "JPY-PAIRS";
            MajorPair_Headings[4] = "CHF-PAIRS";
            MajorPair_Headings[5] = "CAD-PAIRS";
            MajorPair_Headings[6] = "AUD-PAIRS";
            MajorPair_Headings[7] = "NZD-PAIRS";

            // 0-EURO PAIRS
            MajorPair_Combo[0, 0] = "EURUSD";
            MajorPair_Combo[0, 1] = "EURJPY";
            MajorPair_Combo[0, 2] = "EURGBP";
            MajorPair_Combo[0, 3] = "EURAUD";
            MajorPair_Combo[0, 4] = "EURNZD";
            MajorPair_Combo[0, 5] = "EURCHF";
            MajorPair_Combo[0, 6] = "EURCAD";
            Base_Currency[0, 0] = 1;
            Base_Currency[0, 1] = 1;
            Base_Currency[0, 2] = 1;
            Base_Currency[0, 3] = 1;
            Base_Currency[0, 4] = 1;
            Base_Currency[0, 5] = 1;
            Base_Currency[0, 6] = 1;

            // 1-GBP PAIRS
            MajorPair_Combo[1, 0] = "GBPUSD";
            MajorPair_Combo[1, 1] = "GBPJPY";
            MajorPair_Combo[1, 2] = "EURGBP";
            MajorPair_Combo[1, 3] = "GBPAUD";
            MajorPair_Combo[1, 4] = "GBPNZD";
            MajorPair_Combo[1, 5] = "GBPCHF";
            MajorPair_Combo[1, 6] = "GBPCAD";
            Base_Currency[1, 0] = 1;
            Base_Currency[1, 1] = 1;
            Base_Currency[1, 2] = -1;
            Base_Currency[1, 3] = 1;
            Base_Currency[1, 4] = 1;
            Base_Currency[1, 5] = 1;
            Base_Currency[1, 6] = 1;

            // 2-USD PAIRS
            MajorPair_Combo[2, 0] = "EURUSD";
            MajorPair_Combo[2, 1] = "GBPUSD";
            MajorPair_Combo[2, 2] = "AUDUSD";
            MajorPair_Combo[2, 3] = "NZDUSD";
            MajorPair_Combo[2, 4] = "USDJPY";
            MajorPair_Combo[2, 5] = "USDCHF";
            MajorPair_Combo[2, 6] = "USDCAD";
            Base_Currency[2, 0] = -1;
            Base_Currency[2, 1] = -1;
            Base_Currency[2, 2] = -1;
            Base_Currency[2, 3] = -1;
            Base_Currency[2, 4] = 1;
            Base_Currency[2, 5] = 1;
            Base_Currency[2, 6] = 1;

            // 3-JPY PAIRS
            MajorPair_Combo[3, 0] = "EURJPY";
            MajorPair_Combo[3, 1] = "USDJPY";
            MajorPair_Combo[3, 2] = "GBPJPY";
            MajorPair_Combo[3, 3] = "AUDJPY";
            MajorPair_Combo[3, 4] = "NZDJPY";
            MajorPair_Combo[3, 5] = "CHFJPY";
            MajorPair_Combo[3, 6] = "CADJPY";
            Base_Currency[3, 0] = -1;
            Base_Currency[3, 1] = -1;
            Base_Currency[3, 2] = -1;
            Base_Currency[3, 3] = -1;
            Base_Currency[3, 4] = -1;
            Base_Currency[3, 5] = -1;
            Base_Currency[3, 6] = -1;

            // 4-CHF PAIRS
            MajorPair_Combo[4, 0] = "EURCHF";
            MajorPair_Combo[4, 1] = "USDCHF";
            MajorPair_Combo[4, 2] = "GBPCHF";
            MajorPair_Combo[4, 3] = "AUDCHF";
            MajorPair_Combo[4, 4] = "NZDCHF";
            MajorPair_Combo[4, 5] = "CADCHF";
            MajorPair_Combo[4, 6] = "CHFJPY";
            Base_Currency[4, 0] = -1;
            Base_Currency[4, 1] = -1;
            Base_Currency[4, 2] = -1;
            Base_Currency[4, 3] = -1;
            Base_Currency[4, 4] = -1;
            Base_Currency[4, 5] = -1;
            Base_Currency[4, 6] = 1;

            // 5-CAD PAIRS
            MajorPair_Combo[5, 0] = "EURCAD";
            MajorPair_Combo[5, 1] = "USDCAD";
            MajorPair_Combo[5, 2] = "GBPCAD";
            MajorPair_Combo[5, 3] = "AUDCAD";
            MajorPair_Combo[5, 4] = "NZDCAD";
            MajorPair_Combo[5, 5] = "CADCHF";
            MajorPair_Combo[5, 6] = "CADJPY";
            Base_Currency[5, 0] = -1;
            Base_Currency[5, 1] = -1;
            Base_Currency[5, 2] = -1;
            Base_Currency[5, 3] = -1;
            Base_Currency[5, 4] = -1;
            Base_Currency[5, 5] = 1;
            Base_Currency[5, 6] = 1;


            // 6-AUD PAIRS
            MajorPair_Combo[6, 0] = "EURAUD";
            MajorPair_Combo[6, 1] = "GBPAUD";
            MajorPair_Combo[6, 2] = "AUDUSD";
            MajorPair_Combo[6, 3] = "AUDJPY";
            MajorPair_Combo[6, 4] = "AUDNZD";
            MajorPair_Combo[6, 5] = "AUDCHF";
            MajorPair_Combo[6, 6] = "AUDCAD";
            Base_Currency[6, 0] = -1;
            Base_Currency[6, 1] = -1;
            Base_Currency[6, 2] = 1;
            Base_Currency[6, 3] = 1;
            Base_Currency[6, 4] = 1;
            Base_Currency[6, 5] = 1;
            Base_Currency[6, 6] = 1;


            // 7-NZD PAIRS
            MajorPair_Combo[7, 0] = "EURNZD";
            MajorPair_Combo[7, 1] = "GBPNZD";
            MajorPair_Combo[7, 2] = "AUDNZD";
            MajorPair_Combo[7, 3] = "NZDUSD";
            MajorPair_Combo[7, 4] = "NZDJPY";
            MajorPair_Combo[7, 5] = "NZDCHF";
            MajorPair_Combo[7, 6] = "NZDCAD";
            Base_Currency[7, 0] = -1;
            Base_Currency[7, 1] = -1;
            Base_Currency[7, 2] = -1;
            Base_Currency[7, 3] = 1;
            Base_Currency[7, 4] = 1;
            Base_Currency[7, 5] = 1;
            Base_Currency[7, 6] = 1;


            // NAME OF THE MONTHS
            Month_Name[0] = "1.Jan";
            Month_Name[1] = "2.Feb";
            Month_Name[2] = "3.Mar";
            Month_Name[3] = "4.Apr";
            Month_Name[4] = "5.May";
            Month_Name[5] = "6.June";
            Month_Name[6] = "7.Jul";
            Month_Name[7] = "8.Aug";
            Month_Name[8] = "9.Sep";
            Month_Name[9] = "10.Oct";
            Month_Name[10] = "11.Nov";
            Month_Name[11] = "12.Dec";


            //---------------------------------------------------
            // CURRENT MONTH : OPEN AND CLOSE PRICES
            LP1_Array_Open[0] = 0;
            LP1_Array_Close[0] = 0;

            // INITIALIZE THE INDEX FOR ACCESSING PRICES
            for (int i = 1; i < LP1; i++)
            {
                LP1_Array_Open[i] = i;
            }
            //END FOR
            for (int i = 1; i < LP1; i++)
            {
                LP1_Array_Close[i] = i;
            }
            //END FOR

            LP1_TF_Name[0] = "Current";
            for (int i = 1; i < LP1; i++)
            {
                LP1_TF_Name[i] = "Prev-" + i.ToString();
            }
            //END FOR
            //---------------------------------------------------


        }
        //END METHOD Initialize_Array_OnStart_Only

    }
    //END OF MAIN PUBLIC CLASS
}
//END OF MAIN cALGO ROBOT

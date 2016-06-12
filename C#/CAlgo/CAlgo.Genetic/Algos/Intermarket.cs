////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////                                                                                                        ////
////                        Name :  INTER-MARKET                                                            ////
////                        Dated :  09-Mar-16                                                              ////
////                        Description: Used To Identify Over all strength                                 ////
////                        Ratios of the 8 majors.                                                         ////
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

    public class SK_InterMarket_v1 : Robot
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        USER INPUT                                                                            ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Parameter("#-------------- TIME FRAMES --------------#")]
        public string temp30 { get; set; }

        [Parameter("20. 1st-TIME FRAME (5-MIN) ", DefaultValue = "Minute5")]
        public TimeFrame p_TimeFrame_1 { get; set; }
        [Parameter("21. 2nd-TIME FRAME (15-MIN) ", DefaultValue = "Minute15")]
        public TimeFrame p_TimeFrame_2 { get; set; }
        [Parameter("22. 3rd-TIME FRAME (1-Hour) ", DefaultValue = "Hour")]
        public TimeFrame p_TimeFrame_3 { get; set; }
        [Parameter("23. 4th-TIME FRAME (4-Hour) ", DefaultValue = "Hour4")]
        public TimeFrame p_TimeFrame_4 { get; set; }
        [Parameter("24. 5th-TIME FRAME (Daily) ", DefaultValue = "Daily")]
        public TimeFrame p_TimeFrame_5 { get; set; }
        [Parameter("25. 6th-TIME FRAME (Weekly) ", DefaultValue = "Weekly")]
        public TimeFrame p_TimeFrame_6 { get; set; }
        [Parameter("26. 7th-TIME FRAME (Monthly) ", DefaultValue = "Monthly")]
        public TimeFrame p_TimeFrame_7 { get; set; }

        [Parameter("#-------------- DISPLAY ATR VALUES --------------#")]
        public string temp40 { get; set; }

        [Parameter("30. 5-MIN, Period (80) = ", DefaultValue = 80, MinValue = 1)]
        public int p_ATR_Period_1 { get; set; }
        [Parameter("31. 15-MIN, Period (40) = ", DefaultValue = 40, MinValue = 1)]
        public int p_ATR_Period_2 { get; set; }
        [Parameter("32. 1-HOUR, Period (20) = ", DefaultValue = 20, MinValue = 1)]
        public int p_ATR_Period_3 { get; set; }
        [Parameter("33. 4-HOUR, Period (10) = ", DefaultValue = 10, MinValue = 1)]
        public int p_ATR_Period_4 { get; set; }
        [Parameter("34. Daily-ATR, Period (5) = ", DefaultValue = 5, MinValue = 1)]
        public int p_ATR_Period_5 { get; set; }
        [Parameter("35. Weekly-ATR, Period (6) = ", DefaultValue = 4, MinValue = 1)]
        public int p_ATR_Period_6 { get; set; }
        [Parameter("36. Monthly, Period (7) = ", DefaultValue = 3, MinValue = 1)]
        public int p_ATR_Period_7 { get; set; }

        [Parameter("37. ATR MA Type  ", DefaultValue = MovingAverageType.Simple)]
        public MovingAverageType p_ATR_MA_Type { get; set; }


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

        private int Day_of_the_Week_1 = 0;
        private int Day_of_the_Week_2 = 0;
        private bool Flag_New_Day = true;
        private bool Flag_is_Monday_Next = false;


        // DISPLAY LINE AND COLUMN POSITION
        int Row_1 = 0, Col_1 = 0;

        // TIME FRAME
        private int Current_TimeFrame;

        //For Indexng of MarketSeries
        private int Count_Bar = 0;
        private double Daily_Count_Bar = 0;

        // COLORS
        private Colors Clr_Bk_1 = Colors.DimGray;
        private Colors Clr_Heading_1 = Colors.Yellow;
        private Colors Clr_PairListing = Colors.Aqua;
        private Colors Clr_Positive = Colors.LightGreen;
        private Colors Clr_Negative = Colors.MediumVioletRed;

        // ALL 28 PAIRS PRICES  [28,3] DAILY WEEKLY MONTHLY /////////////////////
        private double[,] All_28Pair_Open_Price;
        private double[,] All_28Pair_Close_Price;
        private double[,] All_28Pair_HiLo_Price;
        private double[,] All_28Pair_ATR_Value;

        private double[] All_28Pair_Pip_Size;
        private string[] All_28Pair_Symbol_Code;

        // ALL 28 PAIRS TOTAL PIPS FROM OPEN PRICES : DAILY, WEEKLY, MONTHLY
        private double[,] All_28Pair_Total_Pip;
        private double[,] All_28Pair_13RD_ATR_Value;

        // INDEX POSITION OF THE PAIR AFTER SORTING
        private int[] Sorted_Daily_Total_Pips;
        private int[] Sorted_Weekly_Total_Pips;
        private int[] Sorted_Monthly_Total_Pips;

        // ALL 7 TIME FRAMES : 5min, 15min, 1Hr, 4Hr, D, W, M
        private double[] GrandTotal_Total_Pips;
        private double[] GrandTotal_HiLo_Pips;
        private double[] GrandTotal_ATR_Values;

        // 8 MAJOR PAIRS : DAILY, WEEKLY, MONTHLY
        private string[] MajorPair_Headings;
        private string[,] MajorPair_Combo;
        private int[,] Base_Currency;

        private double[,] MajorPair_Total_Pips;
        private double[,] MajorPair_HiLo_Pips;
        private double[,] MajorPair_ATR_Value;
        private double[,] MajorPair_13RD_ATR_Value;

        private int[] Sorted_MajorPair_5min_Total_Pips;
        private int[] Sorted_MajorPair_15min_Total_Pips;
        private int[] Sorted_MajorPair_1Hr_Total_Pips;
        private int[] Sorted_MajorPair_4Hr_Total_Pips;
        private int[] Sorted_MajorPair_Daily_Total_Pips;
        private int[] Sorted_MajorPair_Weekly_Total_Pips;
        private int[] Sorted_MajorPair_Monthly_Total_Pips;

        // ALL 7 TIME FRAMES : 5min, 15min, 1Hr, 4Hr, D, W, M
        private double[] MajorPair_GrandTotal_Total_Pips;



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
            string t_Date = string.Format("{0:ddd-d-MMMM-y, h:mm tt}", Server.Time);
            Print("");
            Print("cBOT Start Date & Time : " + t_Date);

            // DISPLAY cBOT NAME ON CHART
            Draw_OnChart_C1("DBNAME01", (16), (1), "INTERMARKET V1.0  BY ///S.KHAN", Clr_Heading_1);

            //Get the Chart Time FRAME
            Current_TimeFrame = Get_TimeFrame(TimeFrame.ToString());
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

            // LOAD SYMBOL CODE AND PIPS SIZE
            Load_28Pair_SymbolCode();
            Load_28Pair_PipSize();
            // LOAD PRICES & ATR VALUES
            Load_28Pair_Open_Prices();
            Load_28Pair_Close_HiLo_Prices();
            Load_28Pair_ATR_Values();

            //GET TOTAL PIPS FROM OPEN
            Get_28Pair_TOTAL_Pips_from_Open();

            // SORT THE TOTAL PIPS
            Sort_Daily_TotalPips_Array();
            Sort_Weekly_TotalPips_Array();
            Sort_Monthly_TotalPips_Array();


            // 8-MAJOR PAIRS : GET & DISPLAY
            Get_MajorPair_Total_Pips();

            // SORT THE 8 MAJOR PAIR ARRAYS
            Sort_MajorPair_5min_TotalPips_Array();
            Sort_MajorPair_15min_TotalPips_Array();
            Sort_MajorPair_1Hr_TotalPips_Array();
            Sort_MajorPair_4Hr_TotalPips_Array();
            Sort_MajorPair_Daily_TotalPips_Array();
            Sort_MajorPair_Weekly_TotalPips_Array();
            Sort_MajorPair_Monthly_TotalPips_Array();


        }
        //End METHOD On_Start

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                        ON       B A R                                                                        ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected override void OnBar()
        {
            Print("OnBar'' MEHTOD START :  D/T=  " + Server.Time);

            // COLUMN HEADINGs


            //SET THE DAY OF WEEK VALUE  MON=1, TUE=2, ........FRI=5
            Day_of_the_Week_1 = (int)Server.Time.DayOfWeek;

            //CHECK CHANGE OF DAY
            if (Day_of_the_Week_1 != Day_of_the_Week_2)
                Flag_New_Day = true;
            else
                Flag_New_Day = false;

            //IF NEW DAY THEN LOAD OPEN PRICES AND OTHER VALUES
            if (Flag_New_Day == true)
            {
                Load_28Pair_Open_Prices();
                Load_28Pair_ATR_Values();
                Flag_New_Day = false;
            }
            //END IF

            //LOAD OPEN PRICE AND ATR VALUES
            Load_28Pair_Open_Prices();
            Load_28Pair_ATR_Values();

            // LOAD PRICES
            Load_28Pair_Close_HiLo_Prices();

            //GET TOTAL PIPS FROM OPEN
            Get_28Pair_TOTAL_Pips_from_Open();

            //SORT THE ARRAYS
            Sort_Daily_TotalPips_Array();
            Sort_Weekly_TotalPips_Array();
            Sort_Monthly_TotalPips_Array();

            // DAILY : DISPLAY THE TOTAL PIPS AND 1/3RD ATR VALUES ON CHART
            //Display_Daily_Total_Pips();
            //Display_Daily_13RD_ATR_Values();
            // WEEKLY : DISPLAY THE TOTAL PIPS AND 1/3RD ATR VALUES ON CHART
            //Display_Weekly_Total_Pips();
            //Display_Weekly_13RD_ATR_Values();
            // MONTHLY : DISPLAY THE TOTAL PIPS AND 1/3RD ATR VALUES ON CHART
            //Display_Monthly_Total_Pips();
            //Display_Monthly_13RD_ATR_Values();


            // -------------------------------- 8-MAJOR PAIR
            // 8 MAJOR PAIR : DAILY
            Get_MajorPair_Total_Pips();

            // SORT THE 8 MAJOR PAIR ARRAYS
            Sort_MajorPair_5min_TotalPips_Array();
            Sort_MajorPair_15min_TotalPips_Array();
            Sort_MajorPair_1Hr_TotalPips_Array();
            Sort_MajorPair_4Hr_TotalPips_Array();
            Sort_MajorPair_Daily_TotalPips_Array();
            Sort_MajorPair_Weekly_TotalPips_Array();
            Sort_MajorPair_Monthly_TotalPips_Array();


            // DISPLAY 8 MAJOR PAIRS
            Row_1 = 4;
            Col_1 = 1;
            Display_MajorPair_5min_Total_Pips(Row_1, Col_1);
            Display_MajorPair_15min_Total_Pips(Row_1, Col_1 + 4);
            Display_MajorPair_1Hr_Total_Pips(Row_1, Col_1 + 8);
            Display_MajorPair_4Hr_Total_Pips(Row_1, Col_1 + 12);
            Display_MajorPair_Daily_Total_Pips(Row_1, Col_1 + 16);
            Display_MajorPair_Weekly_Total_Pips(Row_1, Col_1 + 20);
            Display_MajorPair_Monthly_Total_Pips(Row_1, Col_1 + 24);


            //MAKE A COPY OF THE DAY TO BE COMPARED, ON THE NEXT BAR
            Day_of_the_Week_2 = Day_of_the_Week_1;

            //IF FRIDAY THEN RESET THE MONDAY FLAG
            if (Day_of_the_Week_1 == 5)
                Flag_is_Monday_Next = true;

            // IF DAY HAS CHANGED TO MONDAY FROM SUNDAY OR FRIDAY
            if (Flag_is_Monday_Next == true && Day_of_the_Week_1 == 1)
            {
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
        ////                                 Sort_MajorPair_5min_TotalPips_Array                                          ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_5min_TotalPips_Array()
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
            t_TF = 0;

            //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
            for (int i = 0; i < 8; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = MajorPair_Total_Pips[i, t_TF];
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
                Sorted_MajorPair_5min_Total_Pips[i] = t_Index[i];
            }
            // END FOR
        }
        //END METHOD Sort_MajorPair_5min_TotalPips_Array      

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

            //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
            for (int i = 0; i < 8; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = MajorPair_Total_Pips[i, t_TF];
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
                Sorted_MajorPair_15min_Total_Pips[i] = t_Index[i];
            }
            // END FOR
        }
        //END METHOD Sort_MajorPair_15min_TotalPips_Array  

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_MajorPair_1Hr_TotalPips_Array                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_1Hr_TotalPips_Array()
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

            //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
            for (int i = 0; i < 8; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = MajorPair_Total_Pips[i, t_TF];
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
                Sorted_MajorPair_1Hr_Total_Pips[i] = t_Index[i];
            }
            // END FOR
        }
        //END METHOD Sort_MajorPair_1Hr_TotalPips_Array  

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_MajorPair_4Hr_TotalPips_Array                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_MajorPair_4Hr_TotalPips_Array()
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

            //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
            for (int i = 0; i < 8; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = MajorPair_Total_Pips[i, t_TF];
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
                Sorted_MajorPair_4Hr_Total_Pips[i] = t_Index[i];
            }
            // END FOR
        }
        //END METHOD Sort_MajorPair_4Hr_TotalPips_Array  

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

            //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
            for (int i = 0; i < 8; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = MajorPair_Total_Pips[i, t_TF];
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
                Sorted_MajorPair_Daily_Total_Pips[i] = t_Index[i];
            }
            // END FOR
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

            //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
            for (int i = 0; i < 8; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = MajorPair_Total_Pips[i, t_TF];
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
                Sorted_MajorPair_Weekly_Total_Pips[i] = t_Index[i];
            }
            // END FOR
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

            //LOOP FOR 8-MAJOR PAIRS : COPY VALUES
            for (int i = 0; i < 8; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = MajorPair_Total_Pips[i, t_TF];
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
                Sorted_MajorPair_Monthly_Total_Pips[i] = t_Index[i];
            }
            // END FOR
        }
        //END METHOD Sort_MajorPair_Monthly_TotalPips_Array

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_5min_Total_Pips                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_5min_Total_Pips(int t_Row, int t_Col)
        {

            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 0;

            // COLUMN HEADINGs
            Draw_OnChart_C1("5min04", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);
            Draw_OnChart_C1("5min05", (t_Line_no - 2), (t_Col_no + t_Offset), "5-MIN", Clr_Heading_1);
            Draw_OnChart_C1("5min06", (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

            // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND  TOTAL PIPS ON CHART
            for (int i = 0; i < 8; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_MajorPair_5min_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET 5-min TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("5min01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("5min02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR I

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (MajorPair_GrandTotal_Total_Pips[t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = MajorPair_GrandTotal_Total_Pips[t_TF].ToString("0");
            Draw_OnChart_C1("5min03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_MajorPair_5min_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_15min_Total_Pips                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_15min_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 1;

            // COLUMN HEADINGs
            Draw_OnChart_C1("15min04", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);
            Draw_OnChart_C1("15min05", (t_Line_no - 2), (t_Col_no + t_Offset), "15-MIN", Clr_Heading_1);
            Draw_OnChart_C1("15min06", (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

            // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 8; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_MajorPair_15min_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET 15-min TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("15min01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("15min02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR I

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (MajorPair_GrandTotal_Total_Pips[t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = MajorPair_GrandTotal_Total_Pips[t_TF].ToString("0");
            Draw_OnChart_C1("15min03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_MajorPair_15min_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_1Hr_Total_Pips                                             ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_1Hr_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 2;

            // COLUMN HEADINGs
            Draw_OnChart_C1("1Hr04", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);
            Draw_OnChart_C1("1Hr05", (t_Line_no - 2), (t_Col_no + t_Offset), "1-HR", Clr_Heading_1);
            Draw_OnChart_C1("1Hr06", (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

            // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 8; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_MajorPair_1Hr_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET 1Hr TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("1Hr01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("1Hr02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR I

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (MajorPair_GrandTotal_Total_Pips[t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = MajorPair_GrandTotal_Total_Pips[t_TF].ToString("0");
            Draw_OnChart_C1("1Hr03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_MajorPair_1Hr_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_4Hr_Total_Pips                                             ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_4Hr_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 3;

            // COLUMN HEADINGs
            Draw_OnChart_C1("4Hr04", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);
            Draw_OnChart_C1("4Hr05", (t_Line_no - 2), (t_Col_no + t_Offset), "4-HR", Clr_Heading_1);
            Draw_OnChart_C1("4Hr06", (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

            // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 8; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_MajorPair_4Hr_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET 4Hr TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("4Hr01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("4Hr02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR I

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (MajorPair_GrandTotal_Total_Pips[t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = MajorPair_GrandTotal_Total_Pips[t_TF].ToString("0");
            Draw_OnChart_C1("4Hr03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_MajorPair_4Hr_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_Daily_Total_Pips                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_Daily_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 4;


            // COLUMN HEADINGs
            Draw_OnChart_C1("DMPips04", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);
            Draw_OnChart_C1("DMPips05", (t_Line_no - 2), (t_Col_no + t_Offset), "DAILY", Clr_Heading_1);
            Draw_OnChart_C1("DMPips06", (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

            // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 8; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_MajorPair_Daily_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET DAILY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("DMPips01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("DMPips02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR I

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (MajorPair_GrandTotal_Total_Pips[t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = MajorPair_GrandTotal_Total_Pips[t_TF].ToString("0");
            Draw_OnChart_C1("DMPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_MajorPair_Daily_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_Weekly_Total_Pips                                          ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_Weekly_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 5;


            // COLUMN HEADINGs
            Draw_OnChart_C1("WPips04", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);
            Draw_OnChart_C1("WPips05", (t_Line_no - 2), (t_Col_no + t_Offset), "WEEKLY", Clr_Heading_1);
            Draw_OnChart_C1("WMPips06", (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

            // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 8; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_MajorPair_Weekly_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("WMPips01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("WMPips02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR I

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (MajorPair_GrandTotal_Total_Pips[t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = MajorPair_GrandTotal_Total_Pips[t_TF].ToString("0");
            Draw_OnChart_C1("WMPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_MajorPair_Weekly_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_MajorPair_Monthly_Total_Pips                                          ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_MajorPair_Monthly_Total_Pips(int t_Row, int t_Col)
        {
            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;
            int t_TF;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = t_Row;
            t_Col_no = t_Col;
            t_Offset = 2;

            //SET TIME FRAME  0=5MIN, 1=15MIN, 2=1HR, 3=4HR, 4=D, 5=W, 6=M.
            t_TF = 6;


            // COLUMN HEADINGs
            Draw_OnChart_C1("MPips04", (t_Line_no - 1), (t_Col_no), "MAJOR PAIR", Clr_Heading_1);
            Draw_OnChart_C1("MPips05", (t_Line_no - 2), (t_Col_no + t_Offset), "MONTHLY", Clr_Heading_1);
            Draw_OnChart_C1("MPips06", (t_Line_no - 1), (t_Col_no + t_Offset), "T-Pips", Clr_Heading_1);

            // LOOP FOR 8 MAJOR-PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 8; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_MajorPair_Monthly_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + MajorPair_Headings[t_1];

                // GET WEEKLY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = MajorPair_Total_Pips[t_1, t_TF];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("MPips01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("MPips02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 3 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR I

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (MajorPair_GrandTotal_Total_Pips[t_TF] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = MajorPair_GrandTotal_Total_Pips[t_TF].ToString("0");
            Draw_OnChart_C1("MPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_MajorPair_Weekly_Total_Pips




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Get_MajorPair_Total_Pips                                                     ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Get_MajorPair_Total_Pips()
        {
            string tstr_s1;
            int t_index;
            double t_Total = 0, t_GrandTotal = 0;

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
                        t_Total += (All_28Pair_Total_Pip[t_index, k] * Base_Currency[i, j]);
                        MajorPair_Total_Pips[i, k] = t_Total;
                    }
                    //END FOR j

                    //RESET
                    t_Total = 0;

                    // GRAND TOTAL OF ALL VALUES
                    t_GrandTotal += MajorPair_Total_Pips[i, k];
                    MajorPair_GrandTotal_Total_Pips[k] = t_GrandTotal;
                }
                //END FOR i

                //RESET
                t_GrandTotal = 0;
            }
            //END FOR k


        }
        //END MEHTOD Get_MajorPair_Total_Pips


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
        ////                                 Sort_Monthly_TotalPips_Array                                                 ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_Monthly_TotalPips_Array()
        {
            int t_1 = 0;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[28];
            t_Value = new double[28];

            //LOOP FOR 28 PAIRS : COPY VALUES
            for (int i = 0; i < 28; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = All_28Pair_Total_Pip[i, 6];
            }
            //END FOR

            // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
            bool change = true;
            while (change == true)
            {
                change = false;

                // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                for (int i = 0; i < 27; i++)
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

            //LOOP FOR 28 PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
            for (int i = 0; i < 28; i++)
            {
                Sorted_Monthly_Total_Pips[i] = t_Index[i];
            }
            // END FOR
        }
        //END METHOD Sort_Monthly_TotalPips_Array

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_Weekly_TotalPips_Array                                                  ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_Weekly_TotalPips_Array()
        {
            int t_1 = 0;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[28];
            t_Value = new double[28];

            //LOOP FOR 28 PAIRS : COPY VALUES
            for (int i = 0; i < 28; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = All_28Pair_Total_Pip[i, 5];
            }
            //END FOR

            // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
            bool change = true;
            while (change == true)
            {
                change = false;

                // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                for (int i = 0; i < 27; i++)
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

            //LOOP FOR 28 PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
            for (int i = 0; i < 28; i++)
            {
                Sorted_Weekly_Total_Pips[i] = t_Index[i];
            }
            // END FOR
        }
        //END METHOD Sort_Weekly_TotalPips_Array

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Sort_Daily_TotalPips_Array                                                   ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Sort_Daily_TotalPips_Array()
        {
            int t_1 = 0;
            double t_2 = 0;

            //  TEMP ARRAY FOR STORING INDEX VALUE AND ARRAY VALUE
            int[] t_Index;
            double[] t_Value;
            t_Index = new int[28];
            t_Value = new double[28];

            //LOOP FOR 28 PAIRS : COPY VALUES
            for (int i = 0; i < 28; i++)
            {
                // COPY IN TEMP ARRAY : serial#, Pip value
                t_Index[i] = i;
                t_Value[i] = All_28Pair_Total_Pip[i, 4];
            }
            //END FOR

            // SORT THE TEMP ARRAY INTO DESCENDING ORDER 
            bool change = true;
            while (change == true)
            {
                change = false;

                // COMPARE VALUES [LOOP WILL RUN ONE LESS]
                for (int i = 0; i < 27; i++)
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

            //LOOP FOR 28 PAIRS : COPY FROM TEMP ARRAY TO SORTED ARRAY
            for (int i = 0; i < 28; i++)
            {
                Sorted_Daily_Total_Pips[i] = t_Index[i];
            }
            // END FOR
        }
        //END METHOD Sort_Daily_TotalPips_Array

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_Monthly_13RD_ATR_Values                                              ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Monthly_13RD_ATR_Values()
        {
            Print("Inside : Display -MONTHLY 13RD- Total Pips");

            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_GrandTotal = 0;

            string tstr_TPips, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = 4;
            t_Col_no = 14;
            t_Offset = 0;

            // HEADING OF COLUMN
            Draw_OnChart_C1("DT13RD03", (t_Line_no - 2), (t_Col_no + t_Offset), "1/3RD", Clr_Heading_1);
            Draw_OnChart_C1("DT13RD03", (t_Line_no - 1), (t_Col_no + t_Offset), "ATR", Clr_Heading_1);

            // LOOP FOR 28 PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 28; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_Monthly_Total_Pips[i];

                // GET DAILY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Math.Round(All_28Pair_ATR_Value[t_1, 6] / 4, 0);
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);

                Draw_OnChart_C1("DT13RD02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 5 || i == 21)
                    t_Line_no += 1;
            }
            //END FOR

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (GrandTotal_ATR_Values[6] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            t_GrandTotal = Math.Round(GrandTotal_ATR_Values[6] / 4, 0);
            tstr_GrandTotal = t_GrandTotal.ToString("0");
            Draw_OnChart_C1("DTPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_Monthly_13RD_ATR_Values

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_Weekly_13RD_ATR_Values                                               ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Weekly_13RD_ATR_Values()
        {
            Print("Inside : Display -WEEKLY 13RD- Total Pips");

            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_GrandTotal = 0;

            string tstr_TPips, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = 4;
            t_Col_no = 9;
            t_Offset = 0;

            // HEADING OF COLUMN
            Draw_OnChart_C1("DT13RD03", (t_Line_no - 2), (t_Col_no + t_Offset), "1/3RD", Clr_Heading_1);
            Draw_OnChart_C1("DT13RD03", (t_Line_no - 1), (t_Col_no + t_Offset), "ATR", Clr_Heading_1);

            // LOOP FOR 28 PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 28; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_Weekly_Total_Pips[i];

                // GET DAILY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Math.Round(All_28Pair_ATR_Value[t_1, 5] / 3, 0);
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);

                Draw_OnChart_C1("DT13RD02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 5 || i == 21)
                    t_Line_no += 1;
            }
            //END FOR

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (GrandTotal_ATR_Values[5] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            t_GrandTotal = Math.Round(GrandTotal_ATR_Values[5] / 3, 0);
            tstr_GrandTotal = t_GrandTotal.ToString("0");
            Draw_OnChart_C1("DTPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_Weekly_13RD_ATR_Values

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_Daily_13RD_ATR_Values                                                ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Daily_13RD_ATR_Values()
        {
            Print("Inside : Display -DAILY 13RD- Total Pips");

            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0, t_GrandTotal = 0;

            string tstr_TPips, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = 4;
            t_Col_no = 4;
            t_Offset = 0;

            // HEADING OF COLUMN
            Draw_OnChart_C1("DT13RD03", (t_Line_no - 2), (t_Col_no + t_Offset), "1/3RD", Clr_Heading_1);
            Draw_OnChart_C1("DT13RD03", (t_Line_no - 1), (t_Col_no + t_Offset), "ATR", Clr_Heading_1);

            // LOOP FOR 28 PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 28; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_Daily_Total_Pips[i];

                // GET DAILY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = Math.Round(All_28Pair_ATR_Value[t_1, 4] / 2, 0);
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);

                Draw_OnChart_C1("DT13RD02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 5 || i == 21)
                    t_Line_no += 1;
            }
            //END FOR

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (GrandTotal_ATR_Values[4] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            t_GrandTotal = Math.Round(GrandTotal_ATR_Values[4] / 2, 0);
            tstr_GrandTotal = t_GrandTotal.ToString("0");
            Draw_OnChart_C1("DTPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_Daily_13RD_ATR_Values

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_Monthly_Total_Pips                                                   ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Monthly_Total_Pips()
        {
            Print("Inside : Display -MONTHLY- Total Pips");

            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = 4;
            t_Col_no = 11;
            t_Offset = 2;

            // COLUMN HEADINGs
            Draw_OnChart_C1("DTPips04", (t_Line_no - 1), (t_Col_no), "Symbol Pair", Clr_Heading_1);
            Draw_OnChart_C1("DTPips05", (t_Line_no - 2), (t_Col_no + t_Offset), "Monthly", Clr_Heading_1);
            Draw_OnChart_C1("DTPips05", (t_Line_no - 1), (t_Col_no + t_Offset), "Pips", Clr_Heading_1);

            // LOOP FOR 28 PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 28; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_Monthly_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + All_28Pair_Symbol_Code[t_1];

                // GET DAILY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = All_28Pair_Total_Pip[t_1, 6];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("DTPips01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("DTPips02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 5 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (GrandTotal_Total_Pips[6] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = GrandTotal_Total_Pips[6].ToString("0");
            Draw_OnChart_C1("DTPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_Monthly_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_Weekly_Total_Pips                                                    ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Weekly_Total_Pips()
        {
            Print("Inside : Display -WEEKLY- Total Pips");

            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = 4;
            t_Col_no = 6;
            t_Offset = 2;

            // COLUMN HEADINGs
            Draw_OnChart_C1("DTPips04", (t_Line_no - 1), (t_Col_no), "Symbol Pair", Clr_Heading_1);
            Draw_OnChart_C1("DTPips05", (t_Line_no - 2), (t_Col_no + t_Offset), "Weekly", Clr_Heading_1);
            Draw_OnChart_C1("DTPips05", (t_Line_no - 1), (t_Col_no + t_Offset), "Pips", Clr_Heading_1);

            // LOOP FOR 28 PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 28; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_Weekly_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + All_28Pair_Symbol_Code[t_1];

                // GET DAILY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = All_28Pair_Total_Pip[t_1, 5];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("DTPips01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("DTPips02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 5 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (GrandTotal_Total_Pips[5] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = GrandTotal_Total_Pips[5].ToString("0");
            Draw_OnChart_C1("DTPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);

        }
        //END MEHTOD Display_Weekly_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Display_Daily_Total_Pips                                                     ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Display_Daily_Total_Pips()
        {
            Print("Inside : Display -DAILY- Total Pips");

            int t_Line_no = 0, t_Col_no = 0, t_Offset = 0, t_1 = 0;
            double t_Total_Pip = 0;

            string tstr_TPips, tstr_Symbol_Code, tstr_GrandTotal;
            Colors t_Clr;

            // SET THE LINE # AND COLUMN #
            t_Line_no = 4;
            t_Col_no = 1;
            t_Offset = 2;

            // COLUMN HEADINGs
            Draw_OnChart_C1("DTPips04", (t_Line_no - 1), (t_Col_no), "Symbol Pair", Clr_Heading_1);
            Draw_OnChart_C1("DTPips05", (t_Line_no - 2), (t_Col_no + t_Of fset), "Daily", Clr_Heading_1);
            Draw_OnChart_C1("DTPips05", (t_Line_no - 1), (t_Col_no + t_Offset), "Pips", Clr_Heading_1);

            // LOOP FOR 28 PAIRS : DISPLAY SYMBOL CODE AND TOTAL PIPS ON CHART
            for (int i = 0; i < 28; i++)
            {

                // GET THE SYMBOL INDEX FROM THE SORTED TEMP ARRAY
                t_1 = Sorted_Daily_Total_Pips[i];

                // GET SYMBOL CODE AS PER THE t_Index
                tstr_Symbol_Code = i.ToString("0") + ".  " + All_28Pair_Symbol_Code[t_1];

                // GET DAILY TOTAL PIPS MOVED FROM OPEN AND CONVERT TO STRING
                t_Total_Pip = All_28Pair_Total_Pip[t_1, 4];
                tstr_TPips = t_Total_Pip.ToString("0");

                // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
                if (t_Total_Pip >= 0)
                    t_Clr = Clr_Positive;
                else
                    t_Clr = Clr_Negative;

                // DRAW ON CHART(OBJ_NAME, LINE#, COL#, Text_To_Display, ColorName);
                Draw_OnChart_C1("DTPips01", t_Line_no, (t_Col_no), tstr_Symbol_Code, Clr_PairListing);
                Draw_OnChart_C1("DTPips02", t_Line_no, (t_Col_no + t_Offset), tstr_TPips, t_Clr);

                // INC. THE LINE #
                t_Line_no += 1;

                // LEAVE A BLANK LINE
                if (i == 5 || i == 21)
                    t_Line_no += 1;

            }
            //END FOR

            // ON THE LAST LINE DISPLAY THE GRAND TOTAL OF ALL PAIRS : DAILY
            // SET COLOR NAME ON POSITIVE OR NEGATIVE TOTAL PIP FROM OPEN
            if (GrandTotal_Total_Pips[4] >= 0)
                t_Clr = Clr_Positive;
            else
                t_Clr = Clr_Negative;

            // DISPLAY GRAND_TOTAL OF TOTAL_DAILY_PIPS    
            tstr_GrandTotal = GrandTotal_Total_Pips[4].ToString("0");
            Draw_OnChart_C1("DTPips03", t_Line_no, (t_Col_no + t_Offset), tstr_GrandTotal, t_Clr);



        }
        //END MEHTOD Display_Daily_Total_Pips

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Get_28Pair_TOTAL_Pips_from_Open                                              ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Get_28Pair_TOTAL_Pips_from_Open()
        {
            Print("Inside : Get_28Pair : TOTAL_Pips_from_Open");

            double t_PipSize;
            double t_0 = 0, t_1 = 0, t_2 = 0, t_3 = 0, t_4 = 0, t_5 = 0, t_6 = 0;

            double t_5m = 0, t_15m = 0, t_1hr = 0, t_4hr = 0;

            double t_D = 0, t_W = 0, t_M = 0;

            double t_Close_Price;

            //LOOP FOR 28 PAIRS
            for (int i = 0; i < 28; i++)
            {
                // LOAD PIP SIZE
                t_PipSize = All_28Pair_Pip_Size[i];
                // LOAD CLOSE PRICE : SAME FOR ALL TIME FRAMES
                t_Close_Price = All_28Pair_Close_Price[i, 0];


                // LOAD THE PRICES OPEN AND CLOSE : DAILY, WEEKLY, MONTHLY
                // 5-MIN OPEN AND CLOSE PRICES
                t_5m = All_28Pair_Open_Price[i, 0];
                // 15-MIN OPEN AND CLOSE PRICES
                t_15m = All_28Pair_Open_Price[i, 1];
                // 1-HOUR OPEN AND CLOSE PRICES
                t_1hr = All_28Pair_Open_Price[i, 2];
                // 4-HOUR OPEN AND CLOSE PRICES
                t_4hr = All_28Pair_Open_Price[i, 3];
                // DAILY OPEN AND CLOSE PRICES
                t_D = All_28Pair_Open_Price[i, 4];
                // WEEKLY OPEN AND CLOSE PRICES
                t_W = All_28Pair_Open_Price[i, 5];
                // MONTHLY OPEN AND CLOSE PRICES
                t_M = All_28Pair_Open_Price[i, 6];



                //STORE THE OPEN.LAST VALUE IN THE ARRAY.  ARRAY STARTS FROM 0 INDEX
                // 5-MIN
                All_28Pair_Total_Pip[i, 0] = Math.Round((t_Close_Price - t_5m) / t_PipSize, 0);
                t_0 += All_28Pair_Total_Pip[i, 0];
                // 15-MIN
                All_28Pair_Total_Pip[i, 1] = Math.Round((t_Close_Price - t_15m) / t_PipSize, 0);
                t_1 += All_28Pair_Total_Pip[i, 1];
                // 1-HOUR
                All_28Pair_Total_Pip[i, 2] = Math.Round((t_Close_Price - t_1hr) / t_PipSize, 0);
                t_2 += All_28Pair_Total_Pip[i, 2];
                // 4-HOUR
                All_28Pair_Total_Pip[i, 3] = Math.Round((t_Close_Price - t_4hr) / t_PipSize, 0);
                t_3 += All_28Pair_Total_Pip[i, 3];
                // DAILY
                All_28Pair_Total_Pip[i, 4] = Math.Round((t_Close_Price - t_D) / t_PipSize, 0);
                t_4 += All_28Pair_Total_Pip[i, 4];
                // WEEKLY
                All_28Pair_Total_Pip[i, 5] = Math.Round((t_Close_Price - t_W) / t_PipSize, 0);
                t_5 += All_28Pair_Total_Pip[i, 5];
                // MONTHLY
                All_28Pair_Total_Pip[i, 6] = Math.Round((t_Close_Price - t_M) / t_PipSize, 0);
                t_6 += All_28Pair_Total_Pip[i, 6];



                //UPDATE THE GRANDTOTAL OF "TOTAL PIPS" MOVED FROM OPEN PRICES : DAILY, WEEKLY, MONTHLY
                GrandTotal_Total_Pips[0] = t_0;
                GrandTotal_Total_Pips[1] = t_1;
                GrandTotal_Total_Pips[2] = t_2;
                GrandTotal_Total_Pips[3] = t_3;
                GrandTotal_Total_Pips[4] = t_4;
                GrandTotal_Total_Pips[5] = t_5;
                GrandTotal_Total_Pips[6] = t_6;
            }
            //END FOR
        }
        //END MEHTOD Get_28Pair_TOTAL_Pips_from_Open

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Load_28Pair_ATR_Values                                                       ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_ATR_Values()
        {
            Print("Inside : Load_28Pair_ATR_Values");

            double t_PipSize;
            double t_0 = 0, t_1 = 0, t_2 = 0, t_3 = 0, t_4 = 0, t_5 = 0, t_6 = 0;
            Symbol t_Symbol;
            string tstr_Symbol_Code;

            //LOOP FOR 28 PAIRS
            for (int i = 0; i < 28; i++)
            {
                // GET SYMBOL
                t_Symbol = Get_28Pair_Symbol(i);
                tstr_Symbol_Code = t_Symbol.Code.ToString();
                t_PipSize = t_Symbol.PipSize;


                //GET A TEMP VARIABLE FOR MARKETDATA FOR THE SYMBOL AND TIME FRAME SPECIFIED BY USER
                // 5-MIN
                var temp_1 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_1);
                ATR_Indicator_1 = Indicators.AverageTrueRange(temp_1, p_ATR_Period_1, p_ATR_MA_Type);
                // 15-MIN
                var temp_2 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_2);
                ATR_Indicator_2 = Indicators.AverageTrueRange(temp_2, p_ATR_Period_2, p_ATR_MA_Type);
                // 1-HOUR
                var temp_3 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_3);
                ATR_Indicator_3 = Indicators.AverageTrueRange(temp_3, p_ATR_Period_3, p_ATR_MA_Type);
                // 4-HOUR
                var temp_4 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_4);
                ATR_Indicator_4 = Indicators.AverageTrueRange(temp_4, p_ATR_Period_4, p_ATR_MA_Type);
                // Daily
                var temp_5 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_5);
                ATR_Indicator_5 = Indicators.AverageTrueRange(temp_5, p_ATR_Period_5, p_ATR_MA_Type);
                // Weekly
                var temp_6 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_6);
                ATR_Indicator_6 = Indicators.AverageTrueRange(temp_6, p_ATR_Period_6, p_ATR_MA_Type);
                // Monthly
                var temp_7 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_7);
                ATR_Indicator_7 = Indicators.AverageTrueRange(temp_7, p_ATR_Period_7, p_ATR_MA_Type);


                //STORE THE OPEN.LAST VALUE IN THE ARRAY.  ARRAY STARTS FROM 0 INDEX
                // 5-MIN
                All_28Pair_ATR_Value[i, 0] = Math.Round(ATR_Indicator_1.Result.LastValue / t_PipSize, 0);
                t_0 += All_28Pair_ATR_Value[i, 0];
                // 15-MIN
                All_28Pair_ATR_Value[i, 1] = Math.Round(ATR_Indicator_2.Result.LastValue / t_PipSize, 0);
                t_1 += All_28Pair_ATR_Value[i, 1];
                // 1-HOUR
                All_28Pair_ATR_Value[i, 2] = Math.Round(ATR_Indicator_3.Result.LastValue / t_PipSize, 0);
                t_2 += All_28Pair_ATR_Value[i, 2];
                // 4-HOUR
                All_28Pair_ATR_Value[i, 3] = Math.Round(ATR_Indicator_4.Result.LastValue / t_PipSize, 0);
                t_3 += All_28Pair_ATR_Value[i, 3];
                // DAILY
                All_28Pair_ATR_Value[i, 4] = Math.Round(ATR_Indicator_5.Result.LastValue / t_PipSize, 0);
                t_4 += All_28Pair_ATR_Value[i, 4];
                // WEEKLY
                All_28Pair_ATR_Value[i, 5] = Math.Round(ATR_Indicator_6.Result.LastValue / t_PipSize, 0);
                t_5 += All_28Pair_ATR_Value[i, 5];
                // MONTHLY
                All_28Pair_ATR_Value[i, 6] = Math.Round(ATR_Indicator_7.Result.LastValue / t_PipSize, 0);
                t_6 += All_28Pair_ATR_Value[i, 6];


                //UPDATE THE GRANDTOTAL OF "TOTAL ATR" VALUES : DAILY, WEEKLY, MONTHLY
                GrandTotal_ATR_Values[0] = t_0;
                GrandTotal_ATR_Values[1] = t_1;
                GrandTotal_ATR_Values[2] = t_2;
                GrandTotal_ATR_Values[3] = t_3;
                GrandTotal_ATR_Values[4] = t_4;
                GrandTotal_ATR_Values[5] = t_5;
                GrandTotal_ATR_Values[6] = t_6;
            }
            //END FOR
        }
        //END MEHTOD Load_28Pair_ATR_Values

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                 Load_28Pair_Close_HiLo_Prices                                                ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_Close_HiLo_Prices()
        {
            Print("Inside : Load_28Pair : Close AND HiLo Prices");

            double t_1;
            Symbol t_Symbol;
            string tstr_Symbol_Code;

            //LOOP FOR 28 PAIRS
            for (int i = 0; i < 28; i++)
            {
                // GET SYMBOL
                t_Symbol = Get_28Pair_Symbol(i);
                tstr_Symbol_Code = t_Symbol.Code.ToString();

                //GET 5-MIN OPEN PRICES FOR THE SYMBOL
                var temp_1 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_1);
                //GET 15-MIN OPEN PRICES FOR THE SYMBOL
                var temp_2 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_2);
                //GET 1-HOUR OPEN PRICES FOR THE SYMBOL
                var temp_3 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_3);
                //GET 4-hOUR OPEN PRICES FOR THE SYMBOL
                var temp_4 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_4);
                //GET DAILY OPEN PRICES FOR THE SYMBOL
                var temp_5 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_5);
                //GET Weekly OPEN PRICES FOR THE SYMBOL
                var temp_6 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_6);
                //GET Monthly OPEN PRICES FOR THE SYMBOL
                var temp_7 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_7);

                //STORE THE CLOSE PRICES : SAME FOR ALL TIME FRAMES
                t_1 = temp_1.Close.LastValue;
                // 5-MIN
                All_28Pair_Close_Price[i, 0] = t_1;
                // 15-MIN
                All_28Pair_Close_Price[i, 1] = t_1;
                // 1-HOUR
                All_28Pair_Close_Price[i, 2] = t_1;
                // 4-HOUR
                All_28Pair_Close_Price[i, 3] = t_1;
                // DAILY
                All_28Pair_Close_Price[i, 4] = t_1;
                // WEEKLY
                All_28Pair_Close_Price[i, 5] = t_1;
                // MONTHLY
                All_28Pair_Close_Price[i, 6] = t_1;

                //STORE THE HI-LO PRICES IN THE ARRAY
                // 5-MIN
                All_28Pair_HiLo_Price[i, 0] = temp_1.High.LastValue;
                All_28Pair_HiLo_Price[i, 1] = temp_1.Low.LastValue;
                // 15-MIN
                All_28Pair_HiLo_Price[i, 2] = temp_2.High.LastValue;
                All_28Pair_HiLo_Price[i, 3] = temp_2.Low.LastValue;
                // 1-HOUR
                All_28Pair_HiLo_Price[i, 4] = temp_3.High.LastValue;
                All_28Pair_HiLo_Price[i, 5] = temp_3.Low.LastValue;
                // 4-HOUR
                All_28Pair_HiLo_Price[i, 6] = temp_4.High.LastValue;
                All_28Pair_HiLo_Price[i, 7] = temp_4.Low.LastValue;
                // DAILY
                All_28Pair_HiLo_Price[i, 8] = temp_5.High.LastValue;
                All_28Pair_HiLo_Price[i, 9] = temp_5.Low.LastValue;
                // WEEKLY
                All_28Pair_HiLo_Price[i, 10] = temp_6.High.LastValue;
                All_28Pair_HiLo_Price[i, 11] = temp_6.Low.LastValue;
                // MONTHLY
                All_28Pair_HiLo_Price[i, 12] = temp_7.High.LastValue;
                All_28Pair_HiLo_Price[i, 13] = temp_7.Low.LastValue;


            }
            //END FOR
        }
        //END METHOD Load_28Pair_Close_Price

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                            Load_28Pair_Open_Prices                                           ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_Open_Prices()
        {
            Print("Inside : Load_28Pair_Open_Prices");

            Symbol t_Symbol;
            string tstr_Symbol_Code;

            // LOOP FOR 28 PAIRS
            for (int i = 0; i < 28; i++)
            {
                // GET SYMBOL
                t_Symbol = Get_28Pair_Symbol(i);
                tstr_Symbol_Code = t_Symbol.Code.ToString();

                //GET 5-MIN OPEN PRICES FOR THE SYMBOL
                var temp_1 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_1);
                //GET 15-MIN OPEN PRICES FOR THE SYMBOL
                var temp_2 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_2);
                //GET 1-HOUR OPEN PRICES FOR THE SYMBOL
                var temp_3 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_3);
                //GET 4-hOUR OPEN PRICES FOR THE SYMBOL
                var temp_4 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_4);
                //GET DAILY OPEN PRICES FOR THE SYMBOL
                var temp_5 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_5);
                //GET Weekly OPEN PRICES FOR THE SYMBOL
                var temp_6 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_6);
                //GET Monthly OPEN PRICES FOR THE SYMBOL
                var temp_7 = MarketData.GetSeries(tstr_Symbol_Code, p_TimeFrame_7);

                //STORE THE OPEN PRICES IN THE ARRAY
                // 5-MIN
                All_28Pair_Open_Price[i, 0] = temp_1.Open.LastValue;
                // 15-MIN
                All_28Pair_Open_Price[i, 1] = temp_2.Open.LastValue;
                // 1-HOUR
                All_28Pair_Open_Price[i, 2] = temp_3.Open.LastValue;
                // 4-HOUR
                All_28Pair_Open_Price[i, 3] = temp_4.Open.LastValue;
                // DAILY
                All_28Pair_Open_Price[i, 4] = temp_5.Open.LastValue;
                // WEEKLY
                All_28Pair_Open_Price[i, 5] = temp_6.Open.LastValue;
                // MONTHLY
                All_28Pair_Open_Price[i, 6] = temp_7.Open.LastValue;


            }
            //END FOR

        }
        //END METHOD Get_Daily_Pips_from_Open

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                          Load_28Pair_PipSize                                                 ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Load_28Pair_PipSize()
        {
            Print("Inside : Load_28Pair_PipSize");

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
            Print("Inside : Load_28Pair_SymbolCode");

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
        //END METHOD OnPositionsClosed

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
        //END METHOD CloseAll_Positions
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

            ///////////////////////////////////////////
            //CLOSE FILE STREM AND WRITER
            //File_Stream.Close();
            //File_Writer.Close();
            // LOG FILE giving error on usign the above
            ////////////////////////////////////////////

            //BLANK LINE
            Print("");
        }
        //END METHOD On_STOP

        //// GET PAIR SYMBOL  /////////////////////////////////////////////////////
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
                ///  CAD PAIRS x 5
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
        //END METHOD GET_TIME_FRAME
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
            for (int i = 0; i <= 50; i++)
            {
                t_text = i.ToString();
                Draw_OnChart_C1("Line", i, 0, t_text, Clr_Bk_1);
            }
            //END FOR



            // DISPLAY LINE # 
            for (int i = 0; i <= 30; i++)
            {
                t_text = "C#";
                t_text = t_text + "." + i.ToString();
                Draw_OnChart_C1("Line", 0, (i), t_text, Clr_Bk_1);
            }
            //END FOR


        }
        //END METHOD Create_Display_RowColumn

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                                Declare_All_Arrays                                            ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Declare_All_Arrays()
        {

            // STORE MARKET PRICES OF 28 PAIRS
            All_28Pair_Open_Price = new double[28, 7];
            All_28Pair_Close_Price = new double[28, 7];
            All_28Pair_HiLo_Price = new double[28, 14];

            All_28Pair_ATR_Value = new double[28, 7];
            All_28Pair_13RD_ATR_Value = new double[28, 7];

            All_28Pair_Pip_Size = new double[28];
            All_28Pair_Symbol_Code = new string[28];

            //ALL 28 PAIRS TOTAL PIPS FROM OPEN PRICES : DAILY, WEEKLY, MONTHLY
            All_28Pair_Total_Pip = new double[28, 7];
            Sorted_Daily_Total_Pips = new int[28];
            Sorted_Weekly_Total_Pips = new int[28];
            Sorted_Monthly_Total_Pips = new int[28];

            // GRAND TOTALS :
            // ALL 7 TIME FRAMES : 5min, 15min, 1Hr, 4Hr, D, W, M
            GrandTotal_Total_Pips = new double[7];
            GrandTotal_HiLo_Pips = new double[7];
            GrandTotal_ATR_Values = new double[7];

            // -----------------------------------    8-MAJOR PAIRS
            // MAJOR PAIR RELATED VARIABLES
            MajorPair_Headings = new string[8];
            MajorPair_Combo = new string[8, 7];
            Base_Currency = new int[8, 7];

            MajorPair_Total_Pips = new double[8, 7];
            MajorPair_HiLo_Pips = new double[8, 7];
            MajorPair_ATR_Value = new double[8, 7];
            MajorPair_13RD_ATR_Value = new double[8, 7];

            // ALL 7 TIME FRAMES : 5min, 15min, 1Hr, 4Hr, D, W, M
            Sorted_MajorPair_5min_Total_Pips = new int[8];
            Sorted_MajorPair_15min_Total_Pips = new int[8];
            Sorted_MajorPair_1Hr_Total_Pips = new int[8];
            Sorted_MajorPair_4Hr_Total_Pips = new int[8];
            Sorted_MajorPair_Daily_Total_Pips = new int[8];
            Sorted_MajorPair_Weekly_Total_Pips = new int[8];
            Sorted_MajorPair_Monthly_Total_Pips = new int[8];


            // ALL 7 TIME FRAMES : 5min, 15min, 1Hr, 4Hr, D, W, M
            MajorPair_GrandTotal_Total_Pips = new double[7];

        }
        //END METHOD Declare_All_Arrays


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////                                                Initialize_Array_OnStart_Only                                 ///////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Initialize_Array_OnStart_Only()
        {

            // STROING  0 TO 27 IN ARRAY FOR FIRST TIME ONLY
            for (int i = 0; i < 28; i++)
            {
                // PAIR NUMBERING FROM 0 TO 27
                Sorted_Daily_Total_Pips[i] = i;
                Sorted_Weekly_Total_Pips[i] = i;
                Sorted_Monthly_Total_Pips[i] = i;
            }
            //END FOR

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



        }
       

    }
    
}



















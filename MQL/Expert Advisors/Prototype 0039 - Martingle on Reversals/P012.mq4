//+----------------------------------------------------------------------+
//|                                                        The black Box |
//|                               Copyright 2016, Vigoth Capital Systems |
//|                                          https://forexdrones.com     |
//+-----------------------------------------------------------------------+
#property copyright "Copyright 2016, Vigoth Capital Systems"
#property link      "https://forexdrones.com"
#property version   "2.3"
#property strict


extern color  TextColor           = clrWhite;
extern color  BuyArrowColor       = clrCornflowerBlue;
extern color  SellArrowColor      = clrSalmon;
extern string A1                  = "Trades settings";
extern double Lots                = 0.1;
extern int    StopLoss            = 50;
extern int    TakeProfit          = 500;
extern bool   ReverseSignal       = false;
extern int    MagicNum            = 12345;
extern string A2                  = "Breakeven settings";
extern bool   BreakevenDeals      = true;
extern int    BreakevenStart      = 20;
extern int    BreakevenStep       = 5;
extern string A3                  = "Trailing bar settings";
extern bool   Trailing            = false;
extern int    TrailingStart       = 20;
extern int    TrailingStop        = 25;
extern int    TrailingStep        = 5;
extern string A4                  = "Trailing Hi/Low settings";
extern bool   TrailingHiLow       = true;
input ENUM_TIMEFRAMES TimeFrame   = 15;
extern int    BarCount            = 3;
extern int    IndentHiLow         = 15;
extern string A5                  = "Japanese Candle Pattern";
extern bool   Hammer              = false;
extern bool   HangingMan          = true;
extern bool   Engulfing           = false;
extern bool   MorningStar         = true;
extern bool   EveningStar         = false;
extern bool   DarkCloudCover      = false;
extern bool   Piercing            = false;
extern bool   ShootingStar        = true;
extern bool   InvertedHammer      = false;
extern bool   Harami              = false;
extern bool   Tweezer             = true;
extern bool   BeltHoldLine        = false;
extern bool   UpsideGapTwoCrows   = true;
extern bool   ThreeCrows          = true;
extern bool   MatHold             = true;
extern bool   CounterattackLines  = true;
extern bool   SeparatingLines     = false;
extern bool   GravestoneDoji      = true;
extern bool   LongLeggedDoji      = true;
extern bool   Doji                = false;
extern bool   TasukiGap           = true;
extern bool   SideBySideWhite     = true;
extern bool   ThreeMethods        = false;
extern bool   Gap                 = false;
extern bool   ThreeWhiteSoldiers  = false;
extern bool   AdvanceBlock        = false;
extern bool   Stalled             = false;
extern bool   ThreeLineStrike     = true;
extern bool   OnNeckLine          = false;


int FontSize=9,BarHistory=7,PeriodBH=1440;
double OOP,SL,TP,Lotsi=0,spread,BuyProfit=0,SellProfit=0,BuyPrice,SellPrice,BuyStop,SellStop,LastOrderLot,LastOrderBuyPrice,LastOrderSellPrice;
int ticket2,ticket3,MaxTries=1,Dec,LastOrderType=0,i,cnt=0,ticket,mode=0,digit=0,total,OrderToday=0,LastVol,CandleBuy=0,CBuy=0,CandleSell=0,CSell=0;
string Text,Font="Tahoma";
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
int OnInit()
  {
   if(Digits==3 || Digits==5)
     {
      TakeProfit         *= 10;
      StopLoss           *= 10;
      BreakevenStart     *= 10;
      BreakevenStep      *= 10;
      TrailingStart      *= 10;
      TrailingStop       *= 10;
      TrailingStep       *= 10;
      IndentHiLow        *= 10;
     };

   return(INIT_SUCCEEDED);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void OnDeinit(const int reason)
  {
   ObjectsDeleteAll();
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
int start()
  {
   if(TrailingHiLow==true)TrailHiLow();
   if(BreakevenDeals==true)breakeven();
   if(Trailing==true)TrailingSL();
   double loss=0;
   if(value_profit()<0)
      loss=(-1*value_profit()*100)/AccountBalance();
   string  txt3=(DoubleToStr(loss,2));

   double profit=0;
   if(value_profit()>0)
      profit=(1*value_profit()*100)/AccountBalance();
   string  txt2=(DoubleToStr(profit,2));

   int spread=MarketInfo(Symbol(),MODE_SPREAD);

   SetLabel("Label1","   Trading information",TextColor,5,26);
   SetLabel("Label0","   ………………………………………………",TextColor,5,32);
   SetLabel("Label","   ………………………………………………",TextColor,5,157);
   SetLabel("Label2","   Drawdown: ",TextColor,5,46);
   SetLabel("Label3","   Profit: ",TextColor,5,59);
   SetLabel("Label4","   Today: ",TextColor,5,72);
   SetLabel("Label8","   Yesterday: ",TextColor,5,85);
   SetLabel("Label5","   Current month: ",TextColor,5,98);
   SetLabel("Label6","   Previous month: ",TextColor,5,111);
   SetLabel("Label7","   Total profit: ",TextColor,5,124);
   SetLabel("Label78","   Spread current: ",TextColor,5,137);
   SetLabel("Label79","   Volatility: ",TextColor,5,150);
   SetLabel1("Label12",txt3,TextColor,115,46);
   SetLabel1("Label13",txt2,TextColor,115,59);
   SetLabel1("Label14",DoubleToStr(Profit(0),2),TextColor,115,72);
   SetLabel1("Label18",DoubleToStr(Profit(1),2),TextColor,115,85);
   SetLabel1("Label15",DoubleToStr(ProfitMons(0),2),TextColor,115,98);
   SetLabel1("Label16",DoubleToStr(ProfitMons(1),2),TextColor,115,111);
   SetLabel1("Label17",DoubleToStr(TotalProfit(),2),TextColor,115,124);
   SetLabel1("Label178",spread,TextColor,115,137);
   SetLabel1("Label179",Volatily(),TextColor,115,150);
   SetLabel2("Label22","%",TextColor,175,46);
   SetLabel2("Label23","%",TextColor,175,59);
   SetLabel2("Label24",AccountCurrency(),TextColor,175,72);
   SetLabel2("Label28",AccountCurrency(),TextColor,175,85);
   SetLabel2("Label25",AccountCurrency(),TextColor,175,98);
   SetLabel2("Label26",AccountCurrency(),TextColor,175,111);
   SetLabel2("Label27",AccountCurrency(),TextColor,175,124);
   SetLabel2("Label278","point",TextColor,168,137);
   SetLabel2("Label279","point",TextColor,168,150);


   Lotsi=Lots;
   if(Lotsi<MarketInfo(Symbol(),MODE_MINLOT)) Lotsi=MarketInfo(Symbol(),MODE_MINLOT);
   spread=MarketInfo(Symbol(),MODE_SPREAD);


   if(Volume[0]<=10 && (Volume[0]<LastVol || Volume[0]==1))
     {

      Text=" ";
      CandleBuy=-1; CBuy=-1;
      CandleSell=-1; CSell=-1;
      Condition(0);
      if(HangingMan && Text=="HangedMan") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Hammer && Text=="Hammer") {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(MorningStar && Text=="MorningStar") {CBuy=1; CreateTextObject(Time[1], 0, TextColor, Text);}
      if(EveningStar && Text=="EveningStar") {CSell=1; CreateTextObject(Time[1], 0, TextColor, Text);}
      if(Engulfing && Text=="Engulfing" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Engulfing && Text=="Engulfing" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(DarkCloudCover && Text=="DarkCloudCover") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Piercing && Text=="Piercing") {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(ShootingStar && Text=="ShootingStar") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(InvertedHammer && Text=="InvertedHammer") {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Harami && Text=="Harami" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Harami && Text=="Harami" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Tweezer && Text=="Tweezer") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Tweezer && Text=="Tweezer") {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(BeltHoldLine && Text=="BeltHoldLine" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(BeltHoldLine && Text=="BeltHoldLine" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(UpsideGapTwoCrows && Text=="UpsideGapTwoCrows") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(ThreeCrows && Text=="ThreeCrows") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(MatHold && Text=="MatHold") {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(CounterattackLines && Text=="CounterattackLines"   &&  CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(CounterattackLines  &&  Text=="CounterattackLines"  &&  CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(SeparatingLines && Text=="SeparatingLines" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(SeparatingLines && Text=="SeparatingLines" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(GravestoneDoji && Text=="GravestoneDoji") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(LongLeggedDoji && Text=="LongLeggedDoji" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(LongLeggedDoji && Text=="LongLeggedDoji" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Doji && Text=="Doji" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Doji && Text=="Doji" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(TasukiGap && Text=="TasukiGap" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(TasukiGap && Text=="TasukiGap" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(SideBySideWhite && Text=="SideBySideWhite" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(SideBySideWhite && Text=="SideBySideWhite" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(ThreeMethods && Text=="ThreeMethods"  && CandleSell>0) {CSell=1; CreateTextObject(Time[1], 0, TextColor, Text);}
      if(ThreeMethods && Text=="ThreeMethods"  &&  CandleBuy>0) {CBuy=1; CreateTextObject(Time[1], 0, TextColor, Text);}
      if(Gap && Text=="Gap" &&  CandleBuy>0) {CBuy=1; CreateTextObject(Time[1], 0, TextColor, Text);}
      if(Gap && Text=="Gap" && CandleSell>0) {CSell=1; CreateTextObject(Time[1], 0, TextColor, Text);}
      if(ThreeWhiteSoldiers && Text=="ThreeWhiteSoldiers") {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(AdvanceBlock && Text=="AdvanceBlock") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(Stalled && Text=="Stalled") {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(ThreeLineStrike && Text=="ThreeLineStrike" && CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(ThreeLineStrike && Text=="ThreeLineStrike" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(OnNeckLine   &&   Text=="OnNeckLine"    &&   CandleSell>0) {CSell=1; CreateTextObject(Time[1],0,TextColor,Text);}
      if(OnNeckLine && Text=="OnNeckLine" && CandleBuy>0) {CBuy=1; CreateTextObject(Time[1],0,TextColor,Text);}

      if(ScanTradesOpen(MagicNum)==0 && CBuy>0)
        {
         BuyOpen();
        }

      if(ScanTradesOpen(MagicNum)==0 && CSell>0)
        {
         SellOpen();
        }
      if(ReverseSignal==true)
        {
         if(CountBuy()>0 && CSell>0)CloseAll();
         if(CountSell()>0 && CBuy>0)CloseAll();
        }
     }
   LastVol=Volume[0];

   return(0);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void BuyOpen()
  {
   if(AccountFreeMarginCheck(Symbol(),OP_BUY,Lots)<=0 || GetLastError()==134)
     {
      Print("It is impossible to open the order Buy, not enough money.");
      return;
     }
   RefreshRates();
   ticket=OrderSend(Symbol(),OP_BUY,Lots,Ask,0,0,0,NULL,MagicNum,0,clrBlue);
   if(ticket>0)
     {
      TP=NormalizeDouble(Bid+TakeProfit*Point,Digits);
      SL=NormalizeDouble(Bid-StopLoss*Point,Digits);
      double minstoplevel=MarketInfo(Symbol(),MODE_STOPLEVEL);
      double stoploss=NormalizeDouble(Bid-minstoplevel*Point,Digits);
      if(SL>stoploss)SL=stoploss;
      RefreshRates();
      if(TakeProfit!=0 && StopLoss!=0)
        {
         ticket=OrderModify(ticket,OrderOpenPrice(),SL,TP,0);
        }
      if(TakeProfit==0 && StopLoss!=0)
        {
         ticket=OrderModify(ticket,OrderOpenPrice(),SL,0,0);
        }
      if(TakeProfit!=0 && StopLoss==0)
        {
         ticket=OrderModify(ticket,OrderOpenPrice(),0,TP,0);
        }
     }
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void SellOpen()
  {
   if(AccountFreeMarginCheck(Symbol(),OP_SELL,Lots)<=0 || GetLastError()==134)
     {
      Print("It is impossible to open the order Sell, not enough money.");
      return;
     }
   RefreshRates();
   ticket=OrderSend(Symbol(),OP_SELL,Lots,Bid,0,0,0,NULL,MagicNum,0,clrRed);
   if(ticket>0)
     {
      TP=NormalizeDouble(Ask-TakeProfit*Point,Digits);
      SL=NormalizeDouble(Ask+StopLoss*Point,Digits);
      double minstoplevel=MarketInfo(Symbol(),MODE_STOPLEVEL);
      double stoploss=NormalizeDouble(Ask+minstoplevel*Point,Digits);
      if(SL<stoploss)SL=stoploss;
      RefreshRates();
      if(TakeProfit!=0 && StopLoss!=0)
        {
         ticket=OrderModify(ticket,OrderOpenPrice(),SL,TP,0);
        }
      if(TakeProfit==0 && StopLoss!=0)
        {
         ticket=OrderModify(ticket,OrderOpenPrice(),SL,0,0);
        }
      if(TakeProfit!=0 && StopLoss==0)
        {
         ticket=OrderModify(ticket,OrderOpenPrice(),0,TP,0);
        }
     }
  }
// ---- Scan Trades opened
int ScanTradesOpen(int MagicNum)
  {
   total=OrdersTotal();
   int numords=0;

   for(cnt=0; cnt<total; cnt++)
     {
      OrderSelect(cnt,SELECT_BY_POS);
      if(OrderSymbol()==Symbol() && (OrderType()==OP_BUY || OrderType()==OP_SELL) && OrderMagicNumber()==MagicNum)
        {
         LastOrderLot=OrderLots();
         if(OrderType()==OP_BUY) LastOrderType=1;
         if(OrderType()==OP_SELL) LastOrderType=2;
         numords++;
        }
     }
   return(numords);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double GetUpperShadowHeight(int ai_0)
  {
   return (MathAbs(High[ai_0] - MathMax(Close[ai_0], Open[ai_0])));
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double GetLowerShadowHeight(int ai_0)
  {
   return (MathAbs(MathMin(Close[ai_0], Open[ai_0]) - Low[ai_0]));
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double GetBodyHeight(int ai_0)
  {
   return (MathAbs(Close[ai_0] - Open[ai_0]));
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double GetAllHeight(int ai_0)
  {
   return (MathAbs(High[ai_0] - Low[ai_0]));
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsHigher(int ai_0)
  {
   if(High[ai_0] >= High[ai_0 + 1] + 2.0 * Point && High[ai_0] >= High[ai_0 + 2] + 2.0 * Point && High[ai_0] >= High[ai_0 + 3] + 2.0 * Point) return (TRUE);
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsLower(int ai_0)
  {
   if(Low[ai_0] + 2.0 * Point*Dec < Low[ai_0 + 1] && Low[ai_0] + 2.0 * Point*Dec < Low[ai_0 + 2] && Low[ai_0] + 2.0 * Point*Dec < Low[ai_0 + 3]) return (TRUE);
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
int IsYing(int ai_0)
  {
   if(Close[ai_0] < Open[ai_0]) return (1);
   return (0);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
int IsYang(int ai_0)
  {
   if(Close[ai_0] > Open[ai_0]) return (1);
   return (0);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double GetLowCloseOpen(int ai_0)
  {
   return (MathMin(Close[ai_0], Open[ai_0]));
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double GetHighCloseOpen(int ai_0)
  {
   return (MathMax(Close[ai_0], Open[ai_0]));
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
int AlmostSameBodyHeight(int ai_0,int ai_4)
  {
   if(MathAbs(GetBodyHeight(ai_0) - GetBodyHeight(ai_4)) < 5.0 * Point*Dec) return (1);
   return (0);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void CreateTextObject(int a_datetime_0,double a_price_4,color a_color_12,string a_text_16)
  {
   string l_name_24;
   l_name_24=TimeToStr(TimeCurrent());

   if(CandleSell>0)
     {
      ObjectCreate(l_name_24,OBJ_ARROW,0,0,0,0,0);
      ObjectSet(l_name_24,OBJPROP_COLOR,clrSalmon);
      ObjectSet(l_name_24,OBJPROP_ARROWCODE,234);
      ObjectSet(l_name_24,OBJPROP_TIME1,Time[1]);
      ObjectSet(l_name_24,OBJPROP_PRICE1,High[1]+20*Point);
      ObjectCreate(l_name_24+" Sell",OBJ_TEXT,0,a_datetime_0,High[1]+110*Point);
      ObjectSetText(l_name_24+" Sell",a_text_16,FontSize);
      ObjectSet(l_name_24+" Sell",OBJPROP_COLOR,TextColor);
      
     }
   if(CandleBuy>0)
     {
      ObjectCreate(l_name_24,OBJ_ARROW,0,0,0,0,0);
      ObjectSet(l_name_24,OBJPROP_COLOR,clrCornflowerBlue);
      ObjectSet(l_name_24,OBJPROP_ARROWCODE,233);
      ObjectSet(l_name_24,OBJPROP_TIME1,Time[1]);
      ObjectSet(l_name_24,OBJPROP_PRICE1,Low[1]-20*Point);
      ObjectCreate(l_name_24+" Buy",OBJ_TEXT,0,a_datetime_0,Low[1]-110*Point);
      ObjectSetText(l_name_24+" Buy",a_text_16,FontSize);
      ObjectSet(l_name_24+" Buy",OBJPROP_COLOR,TextColor);
     }
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsHammer(int ai_0)
  {
   if(GetAllHeight(ai_0)>=10.0*Point*Dec && GetUpperShadowHeight(ai_0)<GetAllHeight(ai_0)/5.0 && GetLowerShadowHeight(ai_0)>2.0*GetBodyHeight(ai_0) && GetUpperShadowHeight(ai_0)>0.0*Point*Dec)
      if(IsLower(ai_0)) return (TRUE);
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsHangMan(int ai_0)
  {
   if(GetAllHeight(ai_0)>=10.0*Point*Dec && GetUpperShadowHeight(ai_0)<GetAllHeight(ai_0)/5.0 && GetLowerShadowHeight(ai_0)>1.0*GetBodyHeight(ai_0))
      if(IsHigher(ai_0)) return (TRUE);
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsDoji(int ai_0)
  {
   if(MathAbs(Open[ai_0] - Close[ai_0]) < 3.0 * Point) return (TRUE);
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsInvertHammer(int ai_0)
  {
   if(GetLowerShadowHeight(ai_0)<GetAllHeight(ai_0)/5.0)
     {
      if(GetUpperShadowHeight(ai_0)>2.0*GetBodyHeight(ai_0))
         if(IsLower(ai_0)) return (TRUE);
     }
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsInvertHammerCFM(int ai_unused_0)
  {
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsThree_Crows(int ai_0)
  {
   if(High[ai_0+1]>High[ai_0+2] && IsYing(ai_0+2) && IsYing(ai_0+1) && IsYing(ai_0) && Open[ai_0+1]<Open[ai_0+2] && Close[ai_0+
      1] < Close[ai_0 + 2] && Open[ai_0] < Open[ai_0 + 1] && Close[ai_0] < Close[ai_0 + 1]) return (TRUE);
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
bool IsThree_White_Soldiers(int ai_0)
  {
   if(IsYang(ai_0+3) && IsYang(ai_0+2) && IsYang(ai_0+1) && Open[ai_0+2]>Open[ai_0+3]+GetBodyHeight(ai_0+3)/2.0 && Open[ai_0+1]>Open[ai_0+2]+
      GetBodyHeight(ai_0 + 2) / 2.0 && Close[ai_0 + 2] > Close[ai_0 + 3] && Close[ai_0 + 1] > Close[ai_0 + 2] && High[ai_0 + 2] > High[ai_0 + 3] && High[ai_0 + 1] > High[ai_0 + 2] && GetUpperShadowHeight(ai_0+1) < 10.0*Dec*Point && GetUpperShadowHeight(ai_0+2) < 10.0*Dec*Point && GetUpperShadowHeight(ai_0+3) < 10.0*Dec*Point && AlmostSameBodyHeight(ai_0 + 3, ai_0 + 2) && AlmostSameBodyHeight(ai_0 + 2, ai_0 + 1)) return (TRUE);
   return (FALSE);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
int Condition(int ai_0)
  {
   int l_count_4;
   if(!IsDoji(ai_0+2))
     {
      if(IsYang(ai_0+2)!=IsYang(ai_0+1))
        {
         if(MathMax(Close[ai_0+1],Open[ai_0+1])>MathMax(Close[ai_0+2],Open[ai_0+2]) && MathMin(Close[ai_0+1],Open[ai_0+1])<MathMin(Close[ai_0+2],Open[ai_0+2]))
           {
            if(IsLower(ai_0+2) ||  IsLower(ai_0+1) && IsYang(ai_0+1)) {Text="Engulfing"; CandleBuy=1;return(0);}
            if(IsHigher(ai_0+2)|| IsHigher(ai_0+1) && IsYing(ai_0+1)) {Text="Engulfing"; CandleSell=1;return(0);}
            if(GetBodyHeight(ai_0+2)>=15.0*Point*Dec || IsLower(ai_0+1) && IsYang(ai_0+1)) {Text="Engulfing"; CandleBuy=1;return(0);}
            if(GetBodyHeight(ai_0+2)>=15.0*Point*Dec || IsHigher(ai_0+1) && IsYing(ai_0+1)) {Text="Engulfing"; CandleSell=1;return(0);}
           }
        }
     }
   if(IsDoji(ai_0+2))
     {
      if(MathMax(Close[ai_0+1],Open[ai_0+1])>MathMax(Close[ai_0+2],Open[ai_0+2]) && MathMin(Close[ai_0+1],Open[ai_0+1])<MathMin(Close[ai_0+2],Open[ai_0+2]))
        {
         if(IsLower(ai_0+2) ||  IsLower(ai_0+1) && IsYang(ai_0+1)) Text="Äîäæè ïîãëîùåíèå áàé";
         if(IsHigher(ai_0+2)|| IsHigher(ai_0+1) && IsYing(ai_0+1)) Text="Äîäæè ïîãëîùåíèå ñåëë";
        }
     }
   if(IsYang(ai_0+2) && IsYing(ai_0+1) && IsHigher(ai_0+2) && GetBodyHeight(ai_0+2)>=10.0*Point*Dec && Open[ai_0+1]>High[ai_0+2] && Close[ai_0+1]<Open[ai_0+
      2]+(Close[ai_0+2]-(Open[ai_0+2]))/2.0 && GetLowCloseOpen(ai_0+1)>GetLowCloseOpen(ai_0+2)) {Text="DarkCloudCover"; CandleSell=1; return(0);}
   if(MathAbs(Close[ai_0+2]-(Open[ai_0+2]))>15.0*Point*Dec)
     {
      if(MathMax(Close[ai_0+1],Open[ai_0+1])<MathMax(Close[ai_0+2],Open[ai_0+2]) && MathMin(Close[ai_0+1],Open[ai_0+1])>MathMin(Close[ai_0+2],Open[ai_0+
         2]))
        {
         if((IsYang(ai_0 + 2) && IsHigher(ai_0 + 2)) ||(IsYang(ai_0 + 2) )) {Text="Harami"; CandleSell=1; return(0);}
         if((IsYing(ai_0 + 2) && IsLower(ai_0 + 2)) || (IsYing(ai_0 + 2) )) {Text="Harami"; CandleBuy=1; return(0);}
        }
     }

   if(IsHammer(ai_0+1)) {Text="Hammer"; CandleBuy=1;return(0);}
   if(IsHangMan(ai_0+1)) {Text="HangedMan"; CandleSell=1; return(0);}
   if(IsInvertHammer(ai_0+1)) {Text="InvertedHammer"; CandleBuy=1; return(0);}
   if(IsInvertHammerCFM(ai_0+1)) {Text="InvertedHammer"; CandleBuy=1; return(0);}
   if(IsYang(ai_0+1) && IsYing(ai_0+2) && GetBodyHeight(ai_0+2)>=10.0*Point*Dec && Open[ai_0+1]<Low[ai_0+2] && Close[ai_0+1]>Close[ai_0+2]+(Open[ai_0+
      2]-(Close[ai_0+2]))/2.0 && GetHighCloseOpen(ai_0+1)<GetHighCloseOpen(ai_0+2)) {Text="Piercing"; CandleBuy=1; return(0);}
   if(IsYing(ai_0+3) && IsYang(ai_0+1) && IsLower(ai_0+3))
     {
      if(GetLowCloseOpen(ai_0+3)>GetHighCloseOpen(ai_0+2) || GetLowCloseOpen(ai_0+1)>GetHighCloseOpen(ai_0+2) && GetHighCloseOpen(ai_0+1)>GetLowCloseOpen(ai_0+
         3) && GetBodyHeight(ai_0+2)<=10.0*Point*Dec && GetBodyHeight(ai_0+3)>=8.0*Point*Dec && GetBodyHeight(ai_0+1)>=8.0*Point*Dec) {Text="MorningStar"; CandleBuy=1;return(0);}
     }
   if(IsYang(ai_0+3) && IsYing(ai_0+1) && IsHigher(ai_0+3))
     {
      if(GetHighCloseOpen(ai_0+3)<GetLowCloseOpen(ai_0+2) || GetHighCloseOpen(ai_0+1)<GetLowCloseOpen(ai_0+2) && GetLowCloseOpen(ai_0+1)<GetHighCloseOpen(ai_0+
         3) && GetBodyHeight(ai_0+2)<=10.0*Point*Dec && GetBodyHeight(ai_0+3)>8.0*Point*Dec && GetBodyHeight(ai_0+1)>8.0*Point*Dec) {Text="EveningStar";  CandleSell=1;return(0);}
     }
   if(GetLowerShadowHeight(ai_0+1)<GetAllHeight(ai_0+1)/5.0)
     {
      if(GetUpperShadowHeight(ai_0+1)>2.0*GetBodyHeight(ai_0+1))
      if(IsHigher(ai_0+1)) {Text="ShootingStar";  CandleSell=1; return(0);}
     }
   if(IsHigher(ai_0+2) && High[ai_0+2]==High[ai_0+1] || High[ai_0+3]==High[ai_0+1] || High[ai_0+
      4]==High[ai_0+1]) {Text="Tweezer"; CandleSell=1; return(0);}
   if(IsLower(ai_0+2) && Low[ai_0+2]==Low[ai_0+1] || Low[ai_0+3]==Low[ai_0+1] || Low[ai_0+
      4]==Low[ai_0+1]) {Text="Tweezer"; CandleBuy=1; return(0);}

   if(GetBodyHeight(ai_0+1)>=10.0*Point*Dec && IsYang(ai_0+1) && GetLowerShadowHeight(ai_0+1)==0.0 && GetBodyHeight(ai_0+1)>GetAllHeight(ai_0+
      1)/2.0) {Text="BeltHoldLine";  CandleBuy=1; return(0);}
   if(GetBodyHeight(ai_0+1)>=10.0*Point*Dec && IsYing(ai_0+1) && GetUpperShadowHeight(ai_0+1)==0.0 && GetBodyHeight(ai_0+1)>GetAllHeight(ai_0+
      1)/2.0) {Text="BeltHoldLine";  CandleSell=1; return(0);}

   if(IsHigher(ai_0+3) && IsYang(ai_0+3) && IsYing(ai_0+2) && IsYing(ai_0+1) && Open[ai_0+2]>Open[ai_0+3] && Open[ai_0+1]>Open[ai_0+2] && Close[ai_0+
      1]<Close[ai_0+2] && GetLowCloseOpen(ai_0+1)>GetHighCloseOpen(ai_0+3) && GetLowCloseOpen(ai_0+2)>GetHighCloseOpen(ai_0+3)) {Text="UpsideGapTwoCrows";  CandleSell=1;return(0);}
   if(IsYang(ai_0+5) && IsYing(ai_0+4) && IsYing(ai_0+3) && IsYing(ai_0+2) && IsYang(ai_0+1) && Open[ai_0+4]<Close[ai_0+1] && 
      GetBodyHeight(ai_0+5)>=5.0*Point*Dec && GetBodyHeight(ai_0+1)>=5.0*Point*Dec) {Text="MatHold";  CandleBuy=1; return(0);}
   if(IsThree_Crows(ai_0+1)) {Text="ThreeCrows"; CandleSell=1; return(0);}
   if(GetBodyHeight(ai_0+1)>5.0*Point && GetBodyHeight(ai_0+2)>5.0*Point)
     {
      if(IsHigher(ai_0 + 1) && IsYang(ai_0 + 2) && IsYing(ai_0 + 1) && GetHighCloseOpen(ai_0 + 1) - GetHighCloseOpen(ai_0 + 2)>= 2.0 * Point*Dec && Close[ai_0 + 2]> Close[ai_0 + 1] && GetBodyHeight(ai_0 + 2)>= 10.0 * Point*Dec) {Text="CounterattackLines";  CandleSell=1; return(0);}
      if(IsLower(ai_0 + 1) && IsYing(ai_0 + 2) && IsYang(ai_0 + 1) && GetLowCloseOpen(ai_0 + 2) - GetLowCloseOpen(ai_0 + 1) >= 2.0 * Point*Dec && Close[ai_0 + 2] < Close[ai_0 + 1] && GetBodyHeight(ai_0 + 2) >= 10.0 * Point*Dec) {Text="CounterattackLines";  CandleBuy=1; return(0);}
     }
   if(GetBodyHeight(ai_0+1)>5.0*Point && GetBodyHeight(ai_0+2)>5.0*Point)
     {
      if(IsYang(ai_0 + 2) && IsYing(ai_0 + 1) && Open[ai_0 + 2] - (Open[ai_0 + 1]) >= -2.0 * Point*Dec && GetBodyHeight(ai_0 + 2) >= 2.0 * Point*Dec) {Text="SeparatingLines"; CandleSell=1; return(0);}
      if(IsYing(ai_0 + 2) && IsYang(ai_0 + 1) && Open[ai_0 + 1] - (Open[ai_0 + 2]) >= -2.0 * Point*Dec && GetBodyHeight(ai_0 + 2) >= 2.0 * Point*Dec) {Text="SeparatingLines";  CandleBuy=1; return(0);}
     }
   if(Close[ai_0+1]==Open[ai_0+1] && GetLowerShadowHeight(ai_0+1)==0.0) {Text="GravestoneDoji"; CandleSell=1; return(0);}

   if(IsHigher(ai_0 + 1) && MathAbs(Close[ai_0 + 1] -(Open[ai_0 + 1])) < 2.0 * Point*Dec && GetAllHeight(ai_0 + 1)>10.0 * Point*Dec && High[ai_0 + 1]>High[ai_0 + 2]) {Text="LongLeggedDoji"; CandleSell=1; return(0);}
   if(IsLower(ai_0 + 1) && MathAbs(Close[ai_0 + 1] -(Open[ai_0 + 1])) < 2.0 * Point*Dec && GetAllHeight(ai_0 + 1)> 10.0 * Point*Dec && Low[ai_0 + 1] < Low[ai_0 + 2]) {Text="LongLeggedDoji"; CandleBuy=1; return(0);}

   if(GetBodyHeight(ai_0+ 2)>10.0 * Point*Dec && IsHigher(ai_0+ 2)|| IsHigher(ai_0 + 1) && IsYang(ai_0 + 2) && MathAbs(Close[ai_0 + 1] -(Open[ai_0 + 1]))<1.0 * Point*Dec) {Text="Doji"; CandleSell=1; return(0);}
   if(GetBodyHeight(ai_0 + 2)>10.0 * Point*Dec && IsLower(ai_0 + 2)|| IsLower(ai_0 + 1) && IsYing(ai_0 + 2) && MathAbs(Close[ai_0 + 1] -(Open[ai_0 + 1]))<1.0 * Point*Dec) {Text="Doji"; CandleBuy=1; return(0);}

   if(IsHigher(ai_0+3) || IsHigher(ai_0+2) && (IsYang(ai_0+3) && IsYang(ai_0+2) && IsYing(ai_0+1)) && Low[ai_0+
      1]-(Low[ai_0+3])>=2.0*Point && Open[ai_0+2]-(Close[ai_0+3])>0.1*Point*Dec && Close[ai_0+1]<Open[ai_0+2] && MathAbs(GetBodyHeight(ai_0+
      1)-GetBodyHeight(ai_0+2))<5.0*Point*Dec) {Text="TasukiGap";   CandleBuy=1; return(0);}
   if(IsLower(ai_0+3) || IsLower(ai_0+2) && (IsYing(ai_0+3) && IsYing(ai_0+2) && IsYang(ai_0+1)) && High[ai_0+
      3]-(High[ai_0+1])>=2.0*Point && Close[ai_0+3]-(Open[ai_0+2])>0.1*Point*Dec && Close[ai_0+1]>Open[ai_0+2] && MathAbs(GetBodyHeight(ai_0+
      1)-GetBodyHeight(ai_0+2))<5.0*Point*Dec) {Text="TasukiGap"; CandleSell=1; return(0);}

   if(IsHigher(ai_0+3) && (IsYang(ai_0+3) && IsYang(ai_0+2) && IsYang(ai_0+1)) && MathAbs(Open[ai_0+1]-Open[ai_0+
      2])<3.0*Point*Dec && MathAbs(GetBodyHeight(ai_0+1)-GetBodyHeight(ai_0+2))<10.0*Point*Dec) {Text="SideBySideWhite"; CandleBuy=1; return(0);}
   if(IsLower(ai_0+3) && (IsYing(ai_0+3) && IsYang(ai_0+2) && IsYang(ai_0+1)) && MathAbs(Open[ai_0+1]-Open[ai_0+
      2])<3.0*Point*Dec && MathAbs(GetBodyHeight(ai_0+1)-GetBodyHeight(ai_0+2))<10.0*Point*Dec) {Text="SideBySideWhite"; CandleSell=1; return(0);}

   if(IsHigher(ai_0+5) && IsYang(ai_0+5) && IsYang(ai_0+1) && IsYing(ai_0+2) && IsYing(ai_0+3) && IsYing(ai_0+4) && GetBodyHeight(ai_0+5)>5.0*Point && 
      GetBodyHeight(ai_0+1)>5.0*Point*Dec && Open[ai_0+5]<Close[ai_0+1]) {Text="ThreeMethods"; CandleBuy=1; return(0);}
   if(IsLower(ai_0+5) && IsYing(ai_0+5) && IsYing(ai_0+1) && IsYang(ai_0+2) && IsYang(ai_0+3) && IsYang(ai_0+4) && GetBodyHeight(ai_0+5)>5.0*Point && 
      GetBodyHeight(ai_0+1)>5.0*Point*Dec && Open[ai_0+5]>Close[ai_0+1]) {Text="ThreeMethods";  CandleSell=1; return(0);}

   if(IsHigher(ai_0 + 1) && IsYang(ai_0 + 1) && IsYang(ai_0 + 2) && Open[ai_0 + 1] -(Close[ai_0 + 2]) >= 1 * Point*Dec) {Text="Gap"; CandleBuy=1; return(0);}
   if(IsLower(ai_0 + 1) && IsYing(ai_0 + 1) && IsYing(ai_0 + 2) && Close[ai_0 + 2] - (Open[ai_0 + 1]) >= 1 * Point*Dec) {Text="Gap"; CandleSell=1; return(0);}


   if(IsThree_White_Soldiers(ai_0)) {Text="ThreeWhiteSoldiers"; CandleBuy=1; return(0);}

   if(IsYang(ai_0+3) && IsYang(ai_0+2) && IsYang(ai_0+1) && Open[ai_0+2]>Open[ai_0+3]+GetBodyHeight(ai_0+3)/2.0 && Open[ai_0+1]>Open[ai_0+2]+
      GetBodyHeight(ai_0+2)/2.0 && Close[ai_0+2]>Close[ai_0+3] && Close[ai_0+1]>Close[ai_0+2] && High[ai_0+2]>High[ai_0+3] && High[ai_0+1]>High[ai_0+2] && GetBodyHeight(ai_0+3)>GetBodyHeight(ai_0+2) && GetBodyHeight(ai_0+2)>GetBodyHeight(ai_0+1)) {Text="AdvanceBlock"; CandleSell=1; return(0);}

   if(IsYang(ai_0+3) && IsYang(ai_0+2) && IsYang(ai_0+1) && Open[ai_0+2]>Open[ai_0+3]+GetBodyHeight(ai_0+3)/2.0 && Open[ai_0+1]>Open[ai_0+2]+
      GetBodyHeight(ai_0+2)/2.0 && Close[ai_0+2]>Close[ai_0+3] && Close[ai_0+1]>Close[ai_0+2] && High[ai_0+2]>High[ai_0+3] && High[ai_0+1]>High[ai_0+2] && GetBodyHeight(ai_0+3)<GetBodyHeight(ai_0+2)/2 && GetBodyHeight(ai_0+1)<GetBodyHeight(ai_0+2)/2) {Text="Stalled";  CandleSell=1; return(0);}

   if(IsYang(ai_0+1) && IsThree_Crows(ai_0+2) && Close[ai_0+1]>Open[ai_0+2]) {Text="ThreeLineStrike"; CandleSell=1; return(0);}
   if(IsYing(ai_0+1) && IsThree_White_Soldiers(ai_0+1) && Close[ai_0+1]<Open[ai_0+2]) {Text="ThreeLineStrike"; CandleBuy=1; return(0);}

   if(IsYing(ai_0+2) && IsYang(ai_0+1) && Close[ai_0+1]<Open[ai_0+2]-(Open[ai_0+2]-(Close[ai_0+
      2]))/2.0 && Open[ai_0+1]<GetLowCloseOpen(ai_0+2)) {Text="OnNeckLine";  CandleSell=1; return(0);}
   if(IsYang(ai_0+2) && IsYing(ai_0+1) && Close[ai_0+1]>Open[ai_0+2]+(Close[ai_0+2]-(Open[ai_0+
      2]))/2.0 && Open[ai_0+1]>GetHighCloseOpen(ai_0+2)) {Text="OnNeckLine";  CandleBuy=1; return(0);}

   return (0);
  }
//+------------------------------------------------------------------+
void CloseAll()
  {
   int total = OrdersTotal() - 1;
   for(int i = total; i >= 0; i--)
     {
      if(OrderSelect(i,SELECT_BY_POS,MODE_TRADES))
        {
         if(OrderSymbol()==Symbol() && OrderMagicNumber()==MagicNum)
           {
            if(OrderType()==OP_SELL)
               ticket=OrderClose(OrderTicket(),OrderLots(),MarketInfo(OrderSymbol(),MODE_ASK),0,clrNONE);
            else
            if(OrderType()==OP_BUY)
               ticket=OrderClose(OrderTicket(),OrderLots(),MarketInfo(OrderSymbol(),MODE_BID),0,clrNONE);

           }
        }
     }
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
int CountBuy()
  {
   int count = 0;
   for(int i = OrdersTotal() - 1; i >= 0; i --)
     {
      if(OrderSelect(i,SELECT_BY_POS,MODE_TRADES))
        {
         if(OrderSymbol()==Symbol() && OrderType()==OP_BUY && OrderMagicNumber()==MagicNum)
            count++;
        }
     }
   return (count);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
int CountSell()
  {
   int count = 0;
   for(int i = OrdersTotal() - 1; i >= 0; i --)
     {
      if(OrderSelect(i,SELECT_BY_POS,MODE_TRADES))
        {
         if(OrderSymbol()==Symbol() && OrderType()==OP_SELL && OrderMagicNumber()==MagicNum)
            count++;
        }
     }
   return (count);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double profhistory(string t,int x,int m)
  {
   string sym=""; datetime z=0; double prof=0;
   if(t=="") sym=Symbol(); else sym=t;
   for(int i=OrdersHistoryTotal()-1; i>=0; i--)
      if(OrderSelect(i,SELECT_BY_POS,MODE_HISTORY)==true)
         if(OrderSymbol()==sym && (OrderMagicNumber()==m || m==-1) && OrderType()<=1)
            if(x==-1 || OrderType()==x)
            if(OrderCloseTime()>z) {z=OrderCloseTime(); prof=OrderProfit();}
   return(prof);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double Profit(int Bar)
  {
   double OProfit=0;
   for(int i=0; i<OrdersHistoryTotal(); i++)
     {
      if(!(OrderSelect(i,SELECT_BY_POS,MODE_HISTORY))) break;
      if((OrderSymbol()==Symbol()) || (Symbol()==OrderSymbol()) || (Symbol()=="0" && OrderSymbol()==Symbol()))
         if(OrderCloseTime()>=iTime(Symbol(),PERIOD_D1,Bar) && OrderCloseTime()<iTime(Symbol(),PERIOD_D1,Bar)+86400) OProfit+=OrderProfit();
     }
   return (OProfit);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double ProfitMons(int Bar)
  {
   double OProfit=0;
   for(int i=0; i<OrdersHistoryTotal(); i++)
     {
      if(!(OrderSelect(i,SELECT_BY_POS,MODE_HISTORY))) break;
      if((OrderSymbol()==Symbol()) || (Symbol()==OrderSymbol()) || (Symbol()=="0" && OrderSymbol()==Symbol()))
         if(OrderCloseTime()>=iTime(Symbol(),PERIOD_MN1,Bar) && OrderCloseTime()<iTime(Symbol(),PERIOD_MN1,Bar)+2592000) OProfit+=OrderProfit();
     }
   return (OProfit);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double ProfitIFStopInCurrency(string sy="",int op=-1,int mn=-1)
  {
   if(sy=="0") sy=Symbol();
   int    i,k=OrdersTotal();
   int    m=0;
   double l;
   double p;
   double t;
   double v;
   double s=0;

   for(i=0; i<k; i++)
     {
      if(OrderSelect(i,SELECT_BY_POS,MODE_TRADES))
        {
         if((OrderSymbol()==sy || sy=="") && (mn<0 || OrderMagicNumber()==mn))
           {
            if((OrderType()==OP_BUY || OrderType()==OP_SELL) && (op<0 || OrderType()==op))
              {
               l=MarketInfo(OrderSymbol(), MODE_LOTSIZE);
               p=MarketInfo(OrderSymbol(), MODE_POINT);
               t=MarketInfo(OrderSymbol(), MODE_TICKSIZE);
               v=MarketInfo(OrderSymbol(), MODE_TICKVALUE);
               if(OrderType()==OP_BUY)
                 {
                  if(m==0) s-=(OrderOpenPrice()-OrderStopLoss())/p*v*OrderLots();
                  if(m==1) s-=(OrderOpenPrice()-OrderStopLoss())/p*v/t/l*OrderLots();
                  if(m==2) s-=(OrderOpenPrice()-OrderStopLoss())/p*v*OrderLots();
                  s+=OrderCommission()+OrderSwap();
                 }
               if(OrderType()==OP_SELL)
                 {
                  if(OrderStopLoss()>0)
                    {
                     if(m==0) s-=(OrderStopLoss()-OrderOpenPrice())/p*v*OrderLots();
                     if(m==1) s-=(OrderStopLoss()-OrderOpenPrice())/p*v/t/l*OrderLots();
                     if(m==2) s-=(OrderStopLoss()-OrderOpenPrice())/p*v*OrderLots();
                     s+=OrderCommission()+OrderSwap();
                    }
                  else s=-AccountBalance();
                 }
              }
           }
        }
     }
   if(AccountBalance()+s<0) s=-AccountBalance();
   return(s);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void SetLabel(string nm,string tx,color cl,int xd,int yd,int cr=0,int fs=9)
  {
   if(ObjectFind(nm)<0) ObjectCreate(nm,OBJ_LABEL,0,0,0);
   ObjectSetText(nm,tx,fs,Font,cl);
   ObjectSet(nm,OBJPROP_COLOR,cl);
   ObjectSet(nm,OBJPROP_XDISTANCE,xd);
   ObjectSet(nm,OBJPROP_YDISTANCE,yd);
   ObjectSet(nm,OBJPROP_CORNER,cr);
   ObjectSet(nm,OBJPROP_FONTSIZE,fs);
   ObjectSet(nm,OBJPROP_BACK,false);
   ObjectSet(nm,OBJPROP_SELECTABLE,false);
   ObjectSet(nm,OBJPROP_READONLY,false);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void SetLabel1(string nm,string tx,color cl,int xd,int yd,int cr=0,int fs=9)
  {
   if(ObjectFind(nm)<0) ObjectCreate(nm,OBJ_LABEL,0,0,0);
   ObjectSetText(nm,tx,fs,Font,cl);
   ObjectSet(nm,OBJPROP_COLOR,cl);
   ObjectSet(nm,OBJPROP_XDISTANCE,xd);
   ObjectSet(nm,OBJPROP_YDISTANCE,yd);
   ObjectSet(nm,OBJPROP_CORNER,cr);
   ObjectSet(nm,OBJPROP_FONTSIZE,fs);
   ObjectSet(nm,OBJPROP_BACK,false);
   ObjectSet(nm,OBJPROP_SELECTABLE,false);
   ObjectSet(nm,OBJPROP_READONLY,false);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void SetLabel2(string nm,string tx,color cl,int xd,int yd,int cr=0,int fs=9)
  {
   if(ObjectFind(nm)<0) ObjectCreate(nm,OBJ_LABEL,0,0,0);
   ObjectSetText(nm,tx,fs,Font,cl);
   ObjectSet(nm,OBJPROP_COLOR,cl);
   ObjectSet(nm,OBJPROP_XDISTANCE,xd);
   ObjectSet(nm,OBJPROP_YDISTANCE,yd);
   ObjectSet(nm,OBJPROP_CORNER,cr);
   ObjectSet(nm,OBJPROP_FONTSIZE,fs);
   ObjectSet(nm,OBJPROP_BACK,false);
   ObjectSet(nm,OBJPROP_SELECTABLE,false);
   ObjectSet(nm,OBJPROP_READONLY,false);
  }
//+------------------------------------------------------------------+
double TotalProfit()
  {
     {
      double OProfit=0;
      for(int i=0; i<OrdersHistoryTotal(); i++)
        {
         if(!(OrderSelect(i,SELECT_BY_POS,MODE_HISTORY))) break;
         if((OrderSymbol()==Symbol()) || (Symbol()==OrderSymbol()) || (Symbol()=="0" && OrderSymbol()==Symbol()))
            if(OrderCloseTime()>=iTime(Symbol(),PERIOD_MN1,1200))OProfit+=OrderProfit();
        }
      return (OProfit);
     }

  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double value_profit()
  {
   double ID=0;
   int OT=OrdersTotal();
   if(OT>0)
     {
      for(int i=OT-1; i>=0; i--)
        {
         if(OrderSelect(i,SELECT_BY_POS,MODE_TRADES))
           {
            if(OrderSymbol()==Symbol())
               ID+=OrderProfit()+OrderSwap()+OrderCommission();
           }
        }
     }
   return(ID);
  }
//+------------------------------------------------------------------+
double GetLowestPrice()
  {
   double price,lowest=1000000;

   for(int i=1; i<=BarCount; i++)
     {
      price=iLow(Symbol(),TimeFrame,i);
      if(price<lowest)
         lowest=price;
     }
   return (lowest);
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
double GetHighestPrice()
  {
   double price,highest=0;

   for(int i=1; i<=BarCount; i++)
     {
      price=iHigh(Symbol(),TimeFrame,i);
      if(price>highest)
         highest=price;
     }
   return (highest);
  }
//+------------------------------------------------------------------+
void TrailHiLow()
  {
   double ST_Buy,ST_Sell;

   for(int i=0; i<OrdersTotal(); i++)
     {
      if(OrderSelect(i,SELECT_BY_POS,MODE_TRADES))
        {
         if(OrderSymbol()==Symbol() && OrderMagicNumber()==MagicNum)
           {
            if(OrderType()==OP_BUY)
              {
               ST_Buy=NormalizeDouble(GetLowestPrice()-IndentHiLow*Point,Digits);
               SL=OrderStopLoss();
               OOP=OrderOpenPrice();
               if(SL<ST_Buy && OOP<ST_Buy && ST_Buy!=SL && Bid>ST_Buy)
                 {
                  ticket3=OrderModify(OrderTicket(),OrderOpenPrice(),ST_Buy,OrderTakeProfit(),0,clrNONE);
                 }
              }

            if(OrderType()==OP_SELL)
              {
               ST_Sell=NormalizeDouble(GetHighestPrice()+IndentHiLow*Point,Digits);
               SL=OrderStopLoss();
               OOP=OrderOpenPrice();
               if(SL>ST_Sell && OOP>ST_Sell && ST_Sell!=SL && Ask<ST_Sell)
                 {
                  ticket3=OrderModify(OrderTicket(),OrderOpenPrice(),ST_Sell,OrderTakeProfit(),0,clrNONE);
                 }
              }
           }
        }
     }
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void breakeven()
  {
   double minstoplevel=MarketInfo(Symbol(),MODE_STOPLEVEL);
   for(int i=0; i<OrdersTotal(); i++)
     {
      if(OrderSelect(i,SELECT_BY_POS,MODE_TRADES))
        {
         double NoLoss;
         if(OrderSymbol()==Symbol() && OrderMagicNumber()==MagicNum)
           {
            if(OrderType()==OP_BUY)
              {
               if(OrderStopLoss()<OrderOpenPrice() || OrderStopLoss()==0)
                 {
                  NoLoss=NormalizeDouble(OrderOpenPrice()+BreakevenStep*Point,Digits);
                  if(Bid>NormalizeDouble(OrderOpenPrice()+(BreakevenStart*Point+BreakevenStep*Point),Digits))
                     ticket2=OrderModify(OrderTicket(),OrderOpenPrice(),NoLoss,OrderTakeProfit(),0,clrNONE);
                 }
              }
            if(OrderType()==OP_SELL)
              {
               if(OrderStopLoss()>OrderOpenPrice() || OrderStopLoss()==0)
                 {
                  NoLoss=NormalizeDouble(OrderOpenPrice()-BreakevenStep*Point,Digits);
                  if(Ask<NormalizeDouble(OrderOpenPrice() -(BreakevenStart*Point+BreakevenStep*Point),Digits))
                     ticket2=OrderModify(OrderTicket(),OrderOpenPrice(),NoLoss,OrderTakeProfit(),0,clrNONE);
                 }
              }
           }
        }
     }
  }
//+------------------------------------------------------------------+
//|                                                                  |
//+------------------------------------------------------------------+
void TrailingSL()
  {
   for(int i=0; i<OrdersTotal(); i++)
     {
      if(OrderSelect(i,SELECT_BY_POS,MODE_TRADES))
         if(OrderSymbol()==Symbol() && OrderMagicNumber()==MagicNum)
           {
            if(OrderType()==OP_BUY)
              {
               if(OrderStopLoss()!=0)
                 {
                  if(Bid>NormalizeDouble(OrderOpenPrice()+TrailingStart*Point,Digits) && Bid>NormalizeDouble(OrderStopLoss()+TrailingStop*Point+TrailingStep*Point,Digits) && OrderStopLoss()<NormalizeDouble(Bid-TrailingStep*Point,Digits) && OrderStopLoss()!=NormalizeDouble(Bid-TrailingStep*Point,Digits))
                     ticket=OrderModify(OrderTicket(),OrderOpenPrice(),NormalizeDouble(Bid-TrailingStep*Point,Digits),OrderTakeProfit(),0,clrNONE);
                 }
               if(OrderStopLoss()==0)
                 {
                  if(Bid>NormalizeDouble(OrderOpenPrice()+TrailingStart*Point,Digits) && Bid>NormalizeDouble(OrderOpenPrice()+TrailingStop*Point+TrailingStep*Point,Digits) && OrderOpenPrice()<NormalizeDouble(Bid-TrailingStep*Point,Digits) && OrderOpenPrice()!=NormalizeDouble(Bid-TrailingStep*Point,Digits))
                     ticket=OrderModify(OrderTicket(),OrderOpenPrice(),NormalizeDouble(Bid-TrailingStep*Point,Digits),OrderTakeProfit(),0,clrNONE);
                 }
              }

            if(OrderType()==OP_SELL)
              {
               if(OrderStopLoss()!=0)
                 {
                  if(Ask<NormalizeDouble(OrderOpenPrice()-TrailingStart*Point,Digits) && Ask<NormalizeDouble(OrderStopLoss()-TrailingStop*Point-TrailingStep*Point,Digits) && OrderStopLoss()>NormalizeDouble(Ask+TrailingStep*Point,Digits) && OrderStopLoss()!=NormalizeDouble(Ask+TrailingStep*Point,Digits))
                     ticket=OrderModify(OrderTicket(),OrderOpenPrice(),NormalizeDouble(Ask+TrailingStep*Point,Digits),OrderTakeProfit(),0,clrNONE);
                 }
               if(OrderStopLoss()==0)
                 {
                  if(Ask<NormalizeDouble(OrderOpenPrice()-TrailingStart*Point,Digits) && Ask<NormalizeDouble(OrderOpenPrice()-TrailingStop*Point-TrailingStep*Point,Digits) && OrderOpenPrice()>NormalizeDouble(Ask+TrailingStep*Point,Digits) && OrderOpenPrice()!=NormalizeDouble(Ask+TrailingStep*Point,Digits))
                     ticket=OrderModify(OrderTicket(),OrderOpenPrice(),NormalizeDouble(Ask+TrailingStep*Point,Digits),OrderTakeProfit(),0,clrNONE);
                 }
              }
           }
     }
  }
//+------------------------------------------------------------------+
int Volatily()
  {
   int tf=PeriodBH;
   int res=0,i=0;
   BarHistory=int(MathMin(iBars(_Symbol,tf),BarHistory));
   for(i=0;i<BarHistory;i++)
      res+=int(MathAbs(iHigh(_Symbol,tf,i)-iLow(_Symbol,tf,i))/_Point);
   res=int(res/BarHistory);
   return(res);
  }  
//+------------------------------------------------------------------+

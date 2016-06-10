import _thread
import hashlib
import hmac
import json
import time
import urllib.request
import urllib
from time import strftime


class API():
 
    def __init__(self, key, secret, nonce=''):
       
        key = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"
        print("Using API key: " + key)
        self.key = key
        self.secret = secret
        if nonce != '':
            self.nonce = int(nonce)
        else:
            self.nonce = None

    def get_info(self):
        """ Retrieve account/API key info. """
        params = {"method":"getInfo"}
        return self._send_private(params)

    def trans_history(self, paramDict=None):
        """ Retrieve your transaction history.  None of the API method
            arguments are required.  Pass any method arguments you want to
            use as a dictionary.
            Arguments:
                from,count,from_id,end_id,order,since,end,pair,active
            Example:
            api.trans_history({"from":666})
        """
        params = {"method":"TransHistory"}
        if(paramDict is not None):
            params.update(paramDict)
        return self._send_private(params)

    def trade_history(self, paramDict=None):
        """ Retrieve your trade history.  None of the API method arguments are
            required.  Pass any method arguments you want to use as a
            dictionary.
            Arguments:
                from,count,from_id,end_id,order,since,end,pair,active
        """
        params = {"method":"TradeHistory"}
        if(paramDict is not None):
            params.update(paramDict)
        return self._send_private(params)

    def order_list(self, paramDict=None):
        """ Retrieve your order list.  None of the API method arguments are
            required.  Pass any method arguments you want to use as a
            dictionary.
            Arguments:
                from,count,from_id,end_id,order,since,end,pair
        """
        params = {"method":"OrderList"}
        if(paramDict is not None):
            params.update(paramDict)
        return self._send_private(params)

    def trade(self, buySell, amount, pair, rate, nonce=0):
        """ Execute a trade to the argument pair. """
        params = {"method":"Trade",
                  "pair":pair,
                  "type":buySell,
                  "rate":rate,
                  "amount":amount}
        return self._send_private(params, nonce)

    def cancel_order(self, orderId):
        """ Cancel the argument order """
        params = {"method":"CancelOrder",
                  "order_id":orderId}
        return self._send_private(params)

    def ticker(self, pair):
        """Retrieve argument pair ticker. Pairs are in ltc_btc format."""
        return self._send_public(pair, "ticker")

    def trades(self, pair):
        """Retrieve argument pair trades. Pairs are in ltc_btc format."""
        return self._send_public(pair, "trades")

    def depth(self, pair):
        """Retrieve market depth for argument pair.
        Pairs are in ltc_btc format."""
        return self._send_public(pair, "depth")

    def _send_private(self, params, nonce=0):
        """ Send a request to the private API using your API key and secret."""
        try:
            
            params.update(nonce=int(time.time())+nonce)                    
            params = urllib.urlencode(params)
            crypto = hmac.new(self.secret, params, hashlib.sha512)
            sign = crypto.hexdigest()
            header = self._get_header(sign)
            conn = urllib.HTTPSConnection("btc-e.com")
            conn.request("POST", "/tapi", params, header)
            response = conn.getresponse()
            try:
                response = json.load(response)
            except ValueError:
                response = {'success':0, 'error':'No JSON in response. BTC-e down.'}
            conn.close()
            return response
        except:
            return {'success':0, 'error':'Connection failed.'}

    def _get_header(self, sign):
        """ Get a header for private API with the sign header
            set as sign argument.
        """
        return {"Content-type": "application/x-www-form-urlencoded",
                "Key":self.key,
                "Sign":sign}

    def _send_public(self, pair, method):
        """ Send a request to the public API """
        try:
            conn = urllib.HTTPSConnection("https://api-fxpractice.oanda.com/v1/prices?instruments=")
            url = "v1/prices?instruments=" + pair
            conn.request("GET", url)
            response = conn.getresponse()
            try:
                response = json.load(response)
            except ValueError:
                response = {'success':0, 'error':'No JSON in response. BTC-e down.'}
            conn.close()
            return response
        except:
            return {'success':0, 'error':'Connection failed.'}
    def _get_nonce(self):
        """ Generate a nonce. """
        if self.nonce is not None:
            self.nonce = self.nonce + 1
        else:
            self.nonce = 1
        return self.nonce



FEE = 1.002
_LAST_OUTPUT = ''

key = ''
secret = ''

btce = API(key, secret)

def time_now():
    return strftime("%Y-%m-%d %H:%M:%S")


def write(data, timeNow=0):
    """
    Writes ONLY NEW data to a text file
    """
    global _LAST_OUTPUT
    if _LAST_OUTPUT != data:
        f = open('log.txt', 'a')
        f.write(time_now() + ' ' + data + '|| Delta ' + str(time.time() - timeNow) + '\n')
        f.close()
        # output to console
        print(time_now() + ' ' + data + '|| Delta ' + str(time.time() - timeNow))
        _LAST_OUTPUT = data


def market_maker_btc_ltc_usd():
    depth_ltc_btc = btce.depth('ltc_btc')
    depth_btc_usd = btce.depth('btc_usd')
    depth_ltc_usd = btce.depth('ltc_usd')

    # for buy cycle
    btc_usd_ask = depth_btc_usd['asks'][0][0]
    btc_usd_ask_size = depth_btc_usd['asks'][0][1]
    ltc_btc_ask = depth_ltc_btc['asks'][0][0]
    ltc_btc_ask_size = depth_ltc_btc['asks'][0][1]
    ltc_usd_bid = depth_ltc_usd['bids'][0][0]
    ltc_usd_bid_size = depth_ltc_usd['bids'][0][1]

    # for sell cycle
    btc_usd_bid = depth_btc_usd['bids'][0][0]
    btc_usd_bid_size = depth_btc_usd['bids'][0][1]
    ltc_usd_ask = depth_ltc_usd['asks'][0][0]
    ltc_usd_ask_size = depth_ltc_usd['asks'][0][1]
    ltc_btc_bid = depth_ltc_btc['bids'][0][0]
    ltc_btc_bid_size = depth_ltc_btc['bids'][0][1]

    def scan_buy_cycle_ltc_btc():
        syn_ltc_btc_ask = ltc_btc_bid + 0.1

        x1 = 0
        x2 = 0
        if btc_usd_ask_size <= ltc_usd_bid_size and btc_usd_ask_size <= ltc_btc_ask_size:
            x1 = btc_usd_ask_size
        elif ltc_usd_bid_size <= ltc_btc_ask_size and ltc_usd_bid_size <= btc_usd_ask_size:
            x2 = ltc_usd_bid_size

        x = 0
        if x1 > 0:
            x = x1
        elif x2 > 0:
            # take the LTC size and convert it to BTC (using no fees)
            u = x2 * ltc_usd_bid
            x = u / btc_usd_ask

        # Buy x BTC at current USD
        u = x * btc_usd_ask / FEE
        # Buy LTC with the BTC
        l = (x / ltc_btc_ask) / FEE
        # Sell the LTC for USD
        b = l * ltc_usd_bid / FEE

        profit = b - u

        data = {'profit': profit,
                'size': x}

        return data

    def scan_sell_cycle_ltc_btc():
        syn_ltc_btc_bid = ltc_btc_ask - 0.1

        x1 = 0
        x2 = 0
        if btc_usd_bid_size <= ltc_usd_ask_size:
            x1 = btc_usd_bid_size
        else:
            x2 = ltc_usd_ask_size

        x = 0
        if x1 > 0:
            # BTC bid size is the limiting size
            x = x1
        elif x2 > 0:
            # take the LTC size and convert it to BTC (using no fees)
            u = x2 * ltc_usd_ask  # get USD
            x = u / btc_usd_bid

        # Sell x BTC at current USD
        u = x * btc_usd_bid / FEE
        # Buy with USD LTC
        l = (u / ltc_usd_ask) / FEE
        # Sell the LTC for BTC
        b = (l * syn_ltc_btc_bid) / FEE

        profit = b - x

        data = {'profit': profit,
                'size': x}

        return data

    p1 = scan_sell_cycle_ltc_btc()
    p2 = scan_buy_cycle_ltc_btc()
    write('Sell Cycle paper profit: ' + str(p1['profit']) + ' BTC \t Buy Cycle paper profit: ' + str(
        p2['profit']) + ' USD')


def scan_btc_ltc_usd():
    """
    Slow and dirty, scan always whole orderbooks for arbitrage opportunity
    Use smallest common size to calculate trade and profit
    """

    delta_buy = 0.0001
    delta_sell = 0.0001

    depth_ltc_btc = btce.depth('ltc_btc')
    depth_btc_usd = btce.depth('btc_usd')
    depth_ltc_usd = btce.depth('ltc_usd')

    # for buy cycle
    btc_usd_ask = depth_btc_usd['asks'][0][0]
    btc_usd_ask_size = depth_btc_usd['asks'][0][1]
    ltc_btc_ask = depth_ltc_btc['asks'][0][0]
    ltc_btc_ask_size = depth_ltc_btc['asks'][0][1]
    ltc_usd_bid = depth_ltc_usd['bids'][0][0] - delta_sell  # because often problematic pair
    ltc_usd_bid_size = depth_ltc_usd['bids'][0][1]

    # for sell cycle
    btc_usd_bid = depth_btc_usd['bids'][0][0]
    btc_usd_bid_size = depth_btc_usd['bids'][0][1]
    ltc_usd_ask = depth_ltc_usd['asks'][0][0] + delta_buy  # because often problematic pair
    ltc_usd_ask_size = depth_ltc_usd['asks'][0][1]
    ltc_btc_bid = depth_ltc_btc['bids'][0][0]
    ltc_btc_bid_size = depth_ltc_btc['bids'][0][1]

    def execute_buy_cycle(profit, size):

        if size > 0.05:
            size = 0.01

        # Buy size BTC at current USD
        u = size * btc_usd_ask / FEE
        # Buy l LTC with size BTC
        l = round((size / ltc_btc_ask), 8)  # for sending the order
        l2 = (size / ltc_btc_ask) / FEE  # for calculating the profit and the next order size
        # Sell the LTC for USD
        b = l2 * ltc_usd_bid
        b2 = l2 * ltc_usd_bid / FEE

        leg1 = btce.trade('buy', size, 'btc_usd', btc_usd_ask, 0)  # buy size BTC at the ask and pay with USD
        leg2 = btce.trade('buy', l, 'ltc_btc', ltc_btc_ask, 1)  # buy l LTC using size BTC
        leg3 = btce.trade('sell', l, 'ltc_usd', ltc_usd_bid, 2)  # sell l LTC and get USD

        write('\nLeg1: ' + str(leg1) + '\nLeg2: ' + str(leg2) + '\nLeg3: ' + str(leg3))

        time.sleep(10)

    def execute_sell_cycle(profit, size):

        if size > 0.05:
            size = 0.01

        # values for which arbitrage works. NOTE: FEE REMOVED to calculate proper size, FEE will be done by BTCe
        u = size * btc_usd_bid / FEE
        l = round((u / ltc_usd_ask), 8)
        l2 = (u / ltc_usd_ask) / FEE
        # b = round((l2*ltc_btc_bid),8) # what I need to calculate in order to buy/sell
        b2 = (l2 * ltc_btc_bid) / FEE

        leg1 = btce.trade('sell', size, 'btc_usd', btc_usd_bid, 0)  # sell size BTC at the bid to get u USD
        leg2 = btce.trade('buy', l, 'ltc_usd', ltc_usd_ask, 1)  # buy l LTCs at the ask for u USD
        leg3 = btce.trade('sell', l, 'ltc_btc', ltc_btc_bid, 2)  # sell l LTCs at the bid for b BTC

        write('\nLeg1: ' + str(leg1) + '\nLeg2: ' + str(leg2) + '\nLeg3: ' + str(leg3))

        time.sleep(10)  # otherwise problem with nonce value when sending orders too quickly

    def buy_cycle():
        x1 = 0
        x2 = 0
        x3 = 0
        if btc_usd_ask_size <= ltc_usd_bid_size and btc_usd_ask_size <= ltc_btc_ask_size:
            x1 = btc_usd_ask_size
        elif ltc_usd_bid_size <= ltc_btc_ask_size and ltc_usd_bid_size <= btc_usd_ask_size:
            x2 = ltc_usd_bid_size
        elif ltc_btc_ask_size <= ltc_usd_bid_size and ltc_btc_ask_size <= btc_usd_ask_size:
            x3 = ltc_btc_ask_size
        else:
            write('Error x1 x2 x3')

        # calculating position sizes depending on smallest denominator determined above
        # starting position is x = the amount of BTC going to be bought
        x = 0
        if x1 > 0:
            x = x1
        elif x2 > 0:
            # take the LTC size and convert it to BTC (using no fees)
            u = x2 * ltc_usd_bid  # get USD
            x = u / btc_usd_ask
        elif x3 > 0:
            # take the LTC size and convert it to BTC
            x = x3 * ltc_btc_ask

        # Buy x BTC at current USD
        u = x * btc_usd_ask / FEE

        # Buy LTC with the BTC
        l = (x / ltc_btc_ask) / FEE

        # Sell the LTC for USD
        b = l * ltc_usd_bid / FEE

        profit = b - u  # in USD

        data = {'profit': profit,
                'size': x
                }

        return data

    def sell_cycle():
        # look for smallest denominator, better: put it in a vector and use SORT
        x1 = 0
        x2 = 0
        x3 = 0
        if btc_usd_bid_size <= ltc_usd_ask_size and btc_usd_bid_size <= ltc_btc_bid_size:
            x1 = btc_usd_bid_size
        elif ltc_usd_ask_size <= ltc_btc_bid_size and ltc_usd_ask_size <= btc_usd_bid_size:
            x2 = ltc_usd_ask_size
        elif ltc_btc_bid_size <= ltc_usd_ask_size and ltc_btc_bid_size <= btc_usd_bid_size:
            x3 = ltc_btc_bid_size
        else:
            write('Error x1 x2 x3')

        # calculating position sizes depending on smallest denominator determined above
        # starting position is x = the amount of BTC going to be sold
        x = 0
        if x1 > 0:
            x = x1
        elif x2 > 0:
            # take the LTC size and convert it to BTC (using no fees)
            u = x2 * ltc_usd_ask  # get USD
            x = u / btc_usd_bid
        elif x3 > 0:
            # take the LTC size and convert it to BTC
            x = x3 * ltc_btc_bid

        # Sell x BTC at current USD
        u = x * btc_usd_bid / FEE

        # Buy with USD LTC
        l = (u / ltc_usd_ask) / FEE

        # Sell the LTC for BTC
        b = (l * ltc_btc_bid) / FEE

        profit = b - x  # in BTC

        data = {'profit': profit,
                'size': x
                }

        return data  # return profit and size to use

    ### definition main
    p1 = sell_cycle()
    p2 = buy_cycle()

    write(
        '0 Sell cycle: ' + str(round(p1['profit'], 8)) + ' BTC | Buy cycle: ' + str(round(p2['profit'], 8)) + ' USD || '
        + str(btc_usd_bid) + '(' + str(btc_usd_bid_size) + ') ' + str(btc_usd_ask) + '(' + str(
            btc_usd_ask_size) + ') ' '|'
        + str(ltc_btc_bid) + '(' + str(ltc_btc_bid_size) + ') ' + str(ltc_btc_ask) + '(' + str(
            ltc_btc_ask_size) + ') ' '|'
        + str(ltc_usd_bid) + '(' + str(ltc_usd_bid_size) + ') ' + str(ltc_usd_ask) + '(' + str(ltc_usd_ask_size) + ')')

    # BTC # don't fight for the very small opportunities, risk that the leg get's not filled is substantial
    if p1['profit'] > 0.001:
        # initiate sell cycle arbitrage, for now simply with minimum size 0.01
        btc_usd_ltc()
        # execute_sell_cycle(p1['profit'],p1['size'])
    elif p2['profit'] > 0.1:  # USD
        # initate arbitrage, for now only with size 0.01
        btc_usd_ltc()
        # execute_buy_cycle(p2['profit'],p2['size'])
    else:
        return -1


def invert(ab):
    """
    Give me a currency pair a/b and it will return the pair b/a
    """
    ba = {}
    ba['ask'] = 1 / ab['bid']
    ba['bid'] = 1 / ab['ask']
    ba['ask_size'] = ab['bid_size'] * ab['bid']
    ba['bid_size'] = ab['ask_size'] * ab['ask']
    ba['name'] = ab['name']

    if ab['invert'] == 1:
        ba['invert'] = 0
    else:
        ba['invert'] = 1

    return ba


def arb_sell(ab, bc, ca, size):
    x = size * ab['bid'] / FEE
    y = x * bc['bid'] / FEE
    z = y * ca['bid'] / FEE

    return z - size


def arb_buy(ab, bc, ca, size):
    x = size / ca['ask'] / FEE
    y = x / bc['ask'] / FEE
    z = y / ab['ask'] / FEE

    return z - size


def size_sell(ab, bc, ca):
    """
    Gives you the largest possible trading size for the arbitrage in terms of a (of ab)
    """
    x = 0
    if ab['bid_size'] <= bc['bid_size'] * bc['bid'] * ca['bid'] and ab['bid_size'] <= ca['bid_size'] * ca['bid']:
        x = ab['bid_size']
    elif bc['bid_size'] * bc['bid'] * ca['bid'] <= ca['bid_size'] * ca['bid'] and bc['bid_size'] * bc['bid'] * ca[
        'bid'] <= ab['bid_size']:
        x = bc['bid_size'] * bc['bid'] * ca['bid']
    else:
        x = ca['bid_size'] * ca['bid']

    return x


def size_buy(ab, bc, ca):
    """
    Gives you the largest possible trading size for the arbitrage in terms of a (of ab)
    """
    x = 0
    if ab['ask_size'] <= bc['ask_size'] * bc['ask'] * ca['ask'] and ab['ask_size'] <= ca['ask_size'] * ca['ask']:
        x = ab['ask_size']
    elif bc['ask_size'] * bc['ask'] * ca['ask'] <= ca['ask_size'] * ca['ask'] and bc['ask_size'] * bc['ask'] * ca[
        'ask'] <= ab['ask_size']:
        x = bc['ask_size'] * bc['ask'] * ca['ask']
    else:
        x = ca['ask_size'] * ca['ask']

    return x


def execute_buy(ab, bc, ca, size):
    """
    Sends the triangular orders, after sending orders wait otherwise problem with nonce value not increasing fast
    enough (because nonce value increases only every second)
    Size has to be in term of a of a/b pair
    ab CAN NEVER BE AN INVERSE
    """

    if size > 0.2:
        size = 0.2

    x = round(size, 8)  # I buy x of A in the first trade and get C
    y = round(x / bc['bid'] / FEE, 8)  # and receive y of B. I sell those y of B in the second trade
    z = round(y * ab['bid'] / FEE, 8)  # and receive z of C. I sell those z of C in the third trade

    write('x' + str(x) + ' y' + str(y) + ' z' + str(z))

    if ca['invert'] == 0:
        leg1 = btce.trade('buy', x, ca['name'], ca['ask'], 0)
    else:
        leg1 = btce.trade('sell', x, ca['name'], invert(ca)['bid'], 0)

    if bc['invert'] == 0:
        leg2 = btce.trade('buy', y, bc['name'], bc['ask'], 1)
    else:
        leg2 = btce.trade('sell', y, bc['name'], invert(bc)['bid'], 1)

    if ca['invert'] == 0:
        leg3 = btce.trade('buy', z, ab['name'], ab['ask'], 1)
    else:
        leg3 = btce.trade('sell', z, ab['name'], invert(ab)['bid'], 1)

    write('\nLeg1: ' + str(leg1) + '\nLeg2: ' + str(leg2) + '\nLeg3: ' + str(leg3))
    time.sleep(10)  # otherwise problem with nonce value when sending orders too quickly


def execute_sell(ab, bc, ca, size):
    """
    Sends the triangular orders, after sending orders wait otherwise problem with nonce value not increasing fast
    enough (because nonce value increases only every second)
    Size has to be in term of a of a/b pair
    ab CAN NEVER BE AN INVERSE
    """

    if size > 0.2:
        size = 0.2

    x = round(size, 8)  # I sell x of A in the first trade
    y = round(x * ab['bid'] / FEE, 8)  # and receive y of B. I sell those y of B in the second trade
    z = round(y * bc['bid'] / FEE, 8)  # and receive z of C. I sell those z of C in the third trade

    write('x' + str(x) + ' y' + str(y) + ' z' + str(z))

    if ab['invert'] == 0:
        leg1 = btce.trade('sell', x, ab['name'], ab['bid'], 0)  # sell size BTC at the bid to get u USD
    else:
        leg1 = btce.trade('buy', x, ab['name'], invert(ab)['ask'], 0)

    if bc['invert'] == 0:
        leg2 = btce.trade('sell', y, bc['name'], bc['bid'], 1)
    else:
        leg2 = btce.trade('buy', y, bc['name'], invert(bc)['ask'], 1)

    if ca['invert'] == 0:
        leg3 = btce.trade('sell', z, ca['name'], ca['bid'], 1)
    else:
        leg3 = btce.trade('buy', z, ca['name'], invert(ca)['ask'], 1)

    write('\nLeg1: ' + str(leg1) + '\nLeg2: ' + str(leg2) + '\nLeg3: ' + str(leg3))
    time.sleep(10)  # otherwise problem with nonce value when sending orders too quickly


def btc_rur_ltc():
    name1 = 'btc_rur'
    name2 = 'ltc_rur'
    name3 = 'ltc_btc'

    depth_ab = btce.depth(name1)
    depth_bc = btce.depth(name2)
    depth_ca = btce.depth(name3)

    ab_bid = depth_ab['bids'][0][0]
    ab_bid_size = depth_ab['bids'][0][1]
    ab_ask = depth_ab['asks'][0][0]
    ab_ask_size = depth_ab['asks'][0][1]

    bc_bid = depth_bc['bids'][0][0]
    bc_bid_size = depth_bc['bids'][0][1]
    bc_ask = depth_bc['asks'][0][0]
    bc_ask_size = depth_bc['asks'][0][1]

    ca_bid = depth_ca['bids'][0][0]
    ca_bid_size = depth_ca['bids'][0][1]
    ca_ask = depth_ca['asks'][0][0]
    ca_ask_size = depth_ca['asks'][0][1]

    ab = {'bid': ab_bid,
          'ask': ab_ask,
          'bid_size': ab_bid_size,
          'ask_size': ab_ask_size,
          'name': name1,
          'invert': 0}
    bc = {'bid': bc_bid,
          'ask': bc_ask,
          'bid_size': bc_bid_size,
          'ask_size': bc_ask_size,
          'name': name2,
          'invert': 0}
    ca = {'bid': ca_bid,
          'ask': ca_ask,
          'bid_size': ca_bid_size,
          'ask_size': ca_ask_size,
          'name': name3,
          'invert': 0}

    bc = invert(bc)  # Set manually!

    size1 = size_sell(ab, bc, ca)
    size2 = size_buy(ab, bc, ca)

    profit1 = arb_sell(ab, bc, ca, size1)
    profit2 = arb_buy(ab, bc, ca, size2)

    write('3 Sell cycle: ' + str(round(profit1, 6)) + '(' + str(round(size1, 6)) + ') BTC | Buy cycle: ' + str(
        round(profit2, 5)) + '(' + str(round(size2, 5)) + ') BTC || '
          + str(ab_bid) + '(' + str(ab_bid_size) + ') ' + str(ab_ask) + '(' + str(ab_ask_size) + ') ' '|'
          + str(bc_bid) + '(' + str(bc_bid_size) + ') ' + str(bc_ask) + '(' + str(bc_ask_size) + ') ' '|'
          + str(ca_bid) + '(' + str(ca_bid_size) + ') ' + str(ca_ask) + '(' + str(ca_ask_size) + ')')

    if profit1 > 0.001 and size1 > 0.01:
        # initiate sell cycle arbitrage, for now simply with minimum size 0.01
        execute_sell(ab, bc, ca, size1)
    elif profit2 > 0.001 and size2 > 0.01:
        # initiate arbitrage, for now only with size 0.01
        execute_buy(ab, bc, ca, size2)
    else:
        return -1


def btc_eur_usd():
    name1 = 'btc_eur'
    name2 = 'eur_usd'
    name3 = 'btc_usd'

    depth_ab = btce.depth(name1)
    depth_bc = btce.depth(name2)
    depth_ca = btce.depth(name3)

    ab_bid = depth_ab['bids'][0][0]
    ab_bid_size = depth_ab['bids'][0][1]
    ab_ask = depth_ab['asks'][0][0]
    ab_ask_size = depth_ab['asks'][0][1]

    bc_bid = depth_bc['bids'][0][0]
    bc_bid_size = depth_bc['bids'][0][1]
    bc_ask = depth_bc['asks'][0][0]
    bc_ask_size = depth_bc['asks'][0][1]

    ca_bid = depth_ca['bids'][0][0]
    ca_bid_size = depth_ca['bids'][0][1]
    ca_ask = depth_ca['asks'][0][0]
    ca_ask_size = depth_ca['asks'][0][1]

    ab = {'bid': ab_bid,
          'ask': ab_ask,
          'bid_size': ab_bid_size,
          'ask_size': ab_ask_size,
          'name': name1,
          'invert': 0}
    bc = {'bid': bc_bid,
          'ask': bc_ask,
          'bid_size': bc_bid_size,
          'ask_size': bc_ask_size,
          'name': name2,
          'invert': 0}
    ca = {'bid': ca_bid,
          'ask': ca_ask,
          'bid_size': ca_bid_size,
          'ask_size': ca_ask_size,
          'name': name3,
          'invert': 0}

    ca = invert(ca)

    size1 = size_sell(ab, bc, ca)
    size2 = size_buy(ab, bc, ca)

    profit1 = arb_sell(ab, bc, ca, size1)
    profit2 = arb_buy(ab, bc, ca, size2)

    write('2 Sell cycle: ' + str(round(profit1, 5)) + '(' + str(round(size1, 5)) + ') BTC | Buy cycle: ' + str(
        round(profit2, 5)) + '(' + str(round(size2, 5)) + ') BTC || '
          + str(ab_bid) + '(' + str(ab_bid_size) + ') ' + str(ab_ask) + '(' + str(ab_ask_size) + ') ' '|'
          + str(bc_bid) + '(' + str(bc_bid_size) + ') ' + str(bc_ask) + '(' + str(bc_ask_size) + ') ' '|'
          + str(ca_bid) + '(' + str(ca_bid_size) + ') ' + str(ca_ask) + '(' + str(ca_ask_size) + ')')

    if profit1 > 0.001 and size1 > 0.01:
        # initiate sell cycle arbitrage, for now simply with minimum size 0.01
        execute_sell(ab, bc, ca, size1)
    elif profit2 > 0.001 and size2 > 0.01:
        # initiate arbitrage, for now only with size 0.01
        execute_buy(ab, bc, ca, size2)
    else:
        return -1


def btc_usd_ltc():
    ticker1 = btce.ticker('ltc_btc')
    timeNow = ticker1['ticker']['server_time']

    depth_ltc_btc = btce.depth('ltc_btc')
    depth_btc_usd = btce.depth('btc_usd')
    depth_ltc_usd = btce.depth('ltc_usd')

    btc_usd_bid = depth_btc_usd['bids'][0][0]
    btc_usd_bid_size = depth_btc_usd['bids'][0][1]
    btc_usd_ask = depth_btc_usd['asks'][0][0]
    btc_usd_ask_size = depth_btc_usd['asks'][0][1]

    ltc_btc_bid = depth_ltc_btc['bids'][0][0]
    ltc_btc_bid_size = depth_ltc_btc['bids'][0][1]
    ltc_btc_ask = depth_ltc_btc['asks'][0][0]
    ltc_btc_ask_size = depth_ltc_btc['asks'][0][1]

    ltc_usd_bid = depth_ltc_usd['bids'][0][0]
    ltc_usd_bid_size = depth_ltc_usd['bids'][0][1]
    ltc_usd_ask = depth_ltc_usd['asks'][0][0]
    ltc_usd_ask_size = depth_ltc_usd['asks'][0][1]

    btc_usd = {'bid': btc_usd_bid,
               'ask': btc_usd_ask,
               'bid_size': btc_usd_bid_size,
               'ask_size': btc_usd_ask_size,
               'name': 'btc_usd',
               'invert': 0}
    ltc_usd = {'bid': ltc_usd_bid,
               'ask': ltc_usd_ask,
               'bid_size': ltc_usd_bid_size,
               'ask_size': ltc_usd_ask_size,
               'name': 'ltc_usd',
               'invert': 0}
    ltc_btc = {'bid': ltc_btc_bid,
               'ask': ltc_btc_ask,
               'bid_size': ltc_btc_bid_size,
               'ask_size': ltc_btc_ask_size,
               'name': 'ltc_btc',
               'invert': 0}

    bc = invert(ltc_usd);

    size1 = size_sell(btc_usd, bc, ltc_btc)
    size2 = size_buy(btc_usd, bc, ltc_btc)

    profit1 = arb_sell(btc_usd, bc, ltc_btc, size1)
    profit2 = arb_buy(btc_usd, bc, ltc_btc, size2)

    write('1 Sell ' + str(round(profit1, 9)) + '(' + str(round(size1, 6)) + ') BTC | Buy ' + str(
        round(profit2, 9)) + '(' + str(round(size2, 6)) + ') BTC || '
          + str(btc_usd_bid) + '(' + str(btc_usd_bid_size) + ') ' + str(btc_usd_ask) + '(' + str(
        btc_usd_ask_size) + ') ' '|'
          + str(bc['bid']) + '(' + str(bc['bid_size']) + ') ' + str(bc['ask']) + '(' + str(bc['ask_size']) + ') ' '|'
          + str(ltc_btc_bid) + '(' + str(ltc_btc_bid_size) + ') ' + str(ltc_btc_ask) + '(' + str(
        ltc_btc_ask_size) + ')', timeNow)

    if profit1 > 0.0001 and size1 >= 0.01:
        # if size1 <= 0.02 and size1 > 0.01:
        # initiate sell cycle arbitrage, for now simply with minimum size 0.01
        execute_sell(btc_usd, invert(ltc_usd), ltc_btc, size1)
    elif profit2 > 0.0001 and size2 >= 0.01:
        # initiate arbitrage, for now only with size 0.01
        execute_buy(btc_usd, invert(ltc_usd), ltc_btc, size2)
    else:
        return -1


def main():
    """main funtion, called at the start of the program"""

    def run1(sleeptime, lock):
        while True:
            lock.acquire()
            btc_usd_ltc()
            # scan_btc_ltc_usd()
            lock.release()
            time.sleep(sleeptime)

    def run2(sleeptime, lock):
        while True:
            lock.acquire()
            # btc_usd_ltc()
            btc_eur_usd()
            # btc_rur_ltc()
            # scan_btc_ltc_usd()
            lock.release()
            time.sleep(sleeptime)

    def run3(sleeptime, lock):
        while True:
            lock.acquire()
            # btc_usd_ltc()
            # btc_eur_usd()
            btc_rur_ltc()
            # scan_btc_ltc_usd()
            lock.release()
            time.sleep(sleeptime)

    lock = _thread.allocate_lock()
    _thread.start_new_thread(run1, (0.01, lock))
    # thread.start_new_thread(run2, (0.01, lock))
    # thread.start_new_thread(run3, (0.01, lock))

    while True:
        pass


if __name__ == "__main__":
    main()





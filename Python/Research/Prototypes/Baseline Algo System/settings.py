import os
from decimal import Decimal

ENVIRONMENTS = {
    "streaming": {
        "real": "stream-fxtrade.oanda.com",
        "practice": "stream-fxpractice.oanda.com",
        "sandbox": "stream-sandbox.oanda.com"
    },
    "api": {
        "real": "api-fxtrade.oanda.com",
        "practice": "api-fxpractice.oanda.com",
        "sandbox": "api-sandbox.oanda.com"
    }
}

CSV_DATA_DIR = "C:\\Users\\SHLBND\\PycharmProjects\\vigoth\\GenData"
OUTPUT_RESULTS_DIR = "C:\\Users\\SHLBND\PycharmProjects\\vigoth\\GenData"
GENERATE_PAIRS = ["GBPUSD", "EURUSD"]

DOMAIN = "practice"
STREAM_DOMAIN = "practice"
API_DOMAIN = "practice"
ACCESS_TOKEN = "9a83e2c3fa7b2a1ff1e6818211e5d879-a9e3d5f9590f0983eb3602cf2699361b"
ACCOUNT_ID = "7901935"

BASE_CURRENCY = "GBP"
EQUITY = Decimal("100000.00")

from __future__ import print_function

import settings
from backtest.backtest import Backtest
from data.price import HistoricCSVPriceHandler
from execution.execution import SimulatedExecution
from portfolio.portfolio import Portfolio
from strategy.strategy import MovingAverageCrossStrategy

if __name__ == "__main__":
    pairs = ["GBPUSD", "EURUSD"]

    strategy_params = {
        "short_window": 5,
        "long_window": 60
    }

    backtest = Backtest(
        pairs, HistoricCSVPriceHandler,
        MovingAverageCrossStrategy, strategy_params,
        Portfolio, SimulatedExecution,
        equity=settings.EQUITY
    )
    backtest.simulate_trading()

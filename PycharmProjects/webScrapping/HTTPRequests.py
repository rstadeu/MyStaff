import requests


url ="https://finance.yahoo.com/quote/AAPL?p=AAPL"

response = requests.get(url)

indicators = ["Previous Close",
               "Open",
               "Bid",
               "Ask",
               "Day's Range",
               "52 Week Range",
               "Volume",
               "Avg. Volume",
               "Market Cap",
               "Beta",
               "PE Ratio (TTM)",
               "EPS (TTM)",
               "Earnings Date",
               "Forward Dividend & Yield",
               "Ex-Dividend Date",
               "1y Target Est"]

print(response)

print(response.status_code)

html_text = response.text

for i in range(0, len(indicators)):
    if(indicators[i] != "Day's Range" and indicators[i] != "Forward Dividend & Yield" ):
        split_list = html_text.split(indicators[i])
    elif(indicators[i] == "Forward Dividend & Yield"):
        split_list = html_text.split("DIVIDEND_AND_YIELD")
    else:
        split_list = html_text.split("DAYS_RANGE")
    after_cleaned = split_list[1].split("-->")[1]
    final_str = after_cleaned.split("<!--")
    print(indicators[i]," ", final_str[0])

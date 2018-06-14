import requests
import re

url = "https://www.codewars.com/users/rstadeu"

response = requests.get(url)

html_text = response.text

split_list = html_text.split("Member Since:")

after_cleaning = split_list[1].split("<b>")[0]
final_str = after_cleaning.split("</div>")[0]

print(after_cleaning)

print(final_str[4:])
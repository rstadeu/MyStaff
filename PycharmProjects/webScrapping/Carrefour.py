import time
import re
import requests
from selenium import webdriver
import carrefour_page



#carrefour_page.ini_webdriver()
carrefour_page.open_carrefour()
carrefour_page.click_menu()
carrefour_page.click_food()
carrefour_page.click_mercado()
carrefour_page.click_acougue()


time.sleep(1)
carrefour_page.scroll_page()

while carrefour_page.test_element():
    carrefour_page.scroll_page_to_end()

product_box = carrefour_page.list_of_products()

for product in product_box:
    product_text = product.text
    product_line = product_text.split('\n')
    if(product_line[1] != 'Item indisponível'):
        #print(product.text+'\n')
        if(product_line[1].startswith('De')):
            print(product_line[0]+'\n'+product_line[1][4:]+'\n'+product_line[3]+'\n')
        else:
            print(product_line[0]+'\n'+product_line[2]+'\n')



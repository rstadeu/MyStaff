import time
import re
import requests
from selenium import webdriver
from selenium.common.exceptions import NoSuchElementException

chrome_path = r"C:\Users\Roberto\Desktop\chromedriver_win32\chromedriver.exe"
driver = webdriver.Chrome(chrome_path)
def open_carrefour():
    driver.get("https://www.carrefour.com.br/")
    time.sleep(1)
def click_menu():
    driver.find_element_by_xpath("""/html/body/main/div/header/div/div[2]/a""").click()
    time.sleep(1)
def click_food():
    driver.find_element_by_xpath("""/html/body/main/div/header/div/div[2]/nav/ul/li[1]/ul[1]/li[1]/span""").click()
    time.sleep(1)
def click_mercado():
    driver.find_element_by_xpath("""/html/body/main/div/header/div/div[2]/nav/ul/li[1]/ul[1]/li[2]/div[1]/div[2]/a""").click()
def click_acougue():
    driver.find_element_by_xpath("""//*[@id="boxes-menulateral"]/ul/li[1]/a/p""").click()
def scroll_page():
    driver.execute_script("window.scrollTo(0, 200);")
    time.sleep(1)

def test_element():
    try:
        time.sleep (1)
        driver.execute_script ("window.scrollTo(0, document.body.scrollHeight - 200);")
        time.sleep (1)
        driver.find_element_by_xpath("""//*[@id="loadNextPage"]""")
    except NoSuchElementException:
        return False
    return True
def scroll_page_to_end():
    driver.find_element_by_xpath ("""//*[@id="loadNextPage"]""").click()

def list_of_products():
   return driver.find_elements_by_xpath("""//*[@id="block-content-full-grid"]""")



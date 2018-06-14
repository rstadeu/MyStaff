import time
import re
import pyodbc
from selenium import webdriver

cnxn = pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                      "Server=den1.mssql1.gear.host;"
                      "Database=groceriesshop;"
                      "UID=groceriesshop;"
                      "PWD=Ok2R--796Q1K;"
                      "Trusted_Connection=yes;")

chrome_path = r"C:\Users\Roberto\Desktop\chromedriver_win32\chromedriver.exe"
driver = webdriver.Chrome(chrome_path)
driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()

time.sleep(5)

driver.find_element_by_xpath("""//*[@id="content-wrap"]/div[1]/div/div/div/ul/nav/ul/li[5]/a""").click()

for i in range(0, 52):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)

with open(r'C:\Users\Roberto\Desktop\extra.txt', 'a') as the_file:
    the_file.write(driver.page_source)
#print(driver.page_source)

html_text = driver.page_source

m = re.findall('<div class="panel-product".+>', html_text)
the_file = open(r'C:\Users\Roberto\Desktop\ListaFinalExtra.txt', 'a')

# driver.close()
for w in m:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join (re.findall (' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str (w)))[12:-1] + "\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')



driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="content-wrap"]/div[1]/div/div/div/ul/nav/ul/li[2]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
baby_page = driver.page_source

b = re.findall('<div class="panel-product".+>', baby_page)

for w in b:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join (re.findall (' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str (w)))[12:-1] + "\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="content-wrap"]/div[1]/div/div/div/ul/nav/ul/li[3]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
perfumaria_page = driver.page_source

p = re.findall('<div class="panel-product".+>', perfumaria_page)
for w in p:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join (re.findall (' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str (w)))[12:-1] + "\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="content-wrap"]/div[1]/div/div/div/ul/nav/ul/li[4]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
limpeza_page = driver.page_source

l = re.findall('<div class="panel-product".+>', limpeza_page)

for w in l:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join (re.findall (' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str (w)))[12:-1] + "\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="content-wrap"]/div[1]/div/div/div/ul/nav/ul/li[6]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
bebidas_page = driver.page_source

be = re.findall('<div class="panel-product".+>', bebidas_page)

for w in be:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write("Categoria: " + ''.join (re.findall (' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str (w)))[12:-1] + "\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="content-wrap"]/div[1]/div/div/div/ul/nav/ul/li[7]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
carne_page = driver.page_source

c = re.findall('<div class="panel-product".+>', carne_page)

for w in c:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1] +"\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="content-wrap"]/div[1]/div/div/div/ul/nav/ul/li[8]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
feira_page = driver.page_source

f = re.findall('<div class="panel-product".+>', feira_page)

for w in f:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1] +"\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="cat-more"]/div/div[7]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
padaria_page = driver.page_source

p = re.findall('<div class="panel-product".+>', padaria_page)

for w in p:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1] +"\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="cat-more"]/div/div[6]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
congelados_page = driver.page_source

c = re.findall('<div class="panel-product".+>', congelados_page)

for w in c:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1] +"\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

driver.get("https://www.extra.com.br/")

time.sleep(3)
driver.find_element_by_xpath("""//*[@id="navbar-collapse"]/div/nav/ul/li[9]/a""").click()
time.sleep(5)
driver.find_element_by_xpath("""//*[@id="cat-more"]/div/div[3]/a""").click()

for i in range(0, 50):
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    time.sleep(3)
alcolicos_page = driver.page_source

a = re.findall('<div class="panel-product".+>', alcolicos_page)

for w in a:
    print("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    the_file.write ("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1] +"\n")
    print("Categoria: " + ''.join(re.findall(' categoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"',str(w)))[12:-1])
    the_file.write("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1]+"\n")
    print("Sub-categoria: " + ''.join(re.findall(' subcategoria="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -.,]+"', str(w)))[15:-1])
    the_file.write("Produto: "+''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1]+"\n")
    print("Produto: " + ''.join(re.findall(' produto-nome="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -]+"', str(w)))[15:-1])
    the_file.write("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1] +"\n")
    print("Preço: " + ''.join(re.findall(' produto-preco="[A-Za-zà-úÀ-ÚóáãõÓÁçÇ0-9 -., ]+"', str(w)))[16:-1])

    print ("++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
    the_file.write('++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n')
    print ("========================================================")
    the_file.write('========================================================\n')

the_file.close()
driver.quit()

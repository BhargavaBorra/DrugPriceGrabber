from os import getenv
import pymssql
import pyodbc
import pandas as pd
import requests
from lxml import html

drug_config = 'C:\ConfigFiles\Drug.xlsx'
Website_config = 'C:\ConfigFiles\Websites.xlsx'
Drug_data = pd.ExcelFile (drug_config)
df1 = Drug_data.parse('Sheet1')

Pharm_data = pd.ExcelFile (Website_config)
df2 = Pharm_data.parse('Sheet1')


conn = pyodbc.connect(r'Driver={SQL Server};Server=.;Database=DrugPriceGrabber;Trusted_Connection=yes;')
#conn = pymssql.connect(server, database)
cursor = conn.cursor()
cursor.execute("truncate table PriceComp")
for index,row in df1.iterrows():
	drug = row['Drug Name']
	for index,row in df2.iterrows():
		Pharma_name= row['PharmacyName']
		zipcode= str(row['Zipcode'])
		url = row['Website']+drug
		#print(url)
		price_xpath= row['xpath']
		pageContent=requests.get(url)
		tree = html.fromstring(pageContent.content)
		price=str(tree.xpath(price_xpath))
		#print(drug+' '+Pharma_name+' '+price+' '+url+' '+zipcode)
		cursor.execute("INSERT INTO PriceComp(DrugName,PharmaName,Price,Websiteurl,Zipcode) VALUES (?, ?, ?, ?, ?)", drug, Pharma_name, price, url, zipcode)
		conn.commit()

conn.close()
import os

pkgList = ['--upgrade pip', 'requests', 'pyodbc', 'lxml', 'pandas', 'pymssql']

for item in pkgList:
    cmd = "python -m pip install " + item
    os.system(cmd)

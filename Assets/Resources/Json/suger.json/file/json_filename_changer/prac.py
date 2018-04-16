#!/usr/bin/env python
# coding: UTF-8
import sys
import os
import re
#指定する画像フォルダ
files = os.listdir('./')
for file in files:
    json = re.compile('json')
    if json.search(file):
        name = file
        newname = name[-23:]
        os.rename(file, newname)
    else:
        pass

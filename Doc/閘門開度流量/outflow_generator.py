### 已知一個水位值之下，部分開度對應之流量值，利用多項式插值法產生剩餘開度對應之流量值。
import numpy as np
import csv

# 已知開度
known_attributes = np.array([0.5, 1, 1.5, 2, 3, 3.5, 4, 5, 6, 7, 8])

#r = 10 # 讀取資料行數(水位)
for r in range(1,92):   
    with open('OUTFLOW.csv', newline='') as csvfile: 
        rows = list(csv.reader(csvfile))
        known_values = np.zeros(11)
        known_values[0] = rows[r][5]
        known_values[1] = rows[r][10]
        known_values[2] = rows[r][15]
        known_values[3] = rows[r][20]
        known_values[4] = rows[r][30]
        known_values[5] = rows[r][35]
        known_values[6] = rows[r][40]
        known_values[7] = rows[r][50]
        known_values[8] = rows[r][60]
        known_values[9] = rows[r][70]
        known_values[10] = rows[r][80]
        
    # 所有開度
    all_attributes = np.linspace(0.1, 8.0, 80)
    
    # 使用多項式插值法
    interpolated_values = np.interp(all_attributes, known_attributes, known_values)
    
    # 將結果寫入CSV檔案
    with open('result.csv', 'a+', newline='') as csvfile:
        writer = csv.writer(csvfile)
        writer.writerow(interpolated_values)
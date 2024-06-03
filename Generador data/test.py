import uuid
import time
# Provide the 
date_str = '2024-06-02'
date = time.strptime(date_str, '%Y-%m-%d')
timestamp = int(time.mktime(date))
uuid1 = uuid.uuid1(timestamp=timestamp)

print("UUID 1 for timestamp", timestamp, ":", uuid1)



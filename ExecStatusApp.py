import requests
import time
import math

def app_exec_stat_post(timeStamp, sourceMachine, appName, task, status, prop1, prop2, prop3):
    API_ENDPOINT = "https://execstatusapp20191220061912.azurewebsites.net/api/ExecStats"
    #timeStamp = datetime.now()
    data = {"Id": str(timeStamp),
        "SourceMachine": sourceMachine,
        "AppName": appName,
        "Task": task,
        "Status": status,
        "prop1": prop1,
        "prop2": prop2,
        "prop3": prop3}
    
    #make a post request
    r = requests.post(url = API_ENDPOINT, data = data, timeout=30)
    
    # get message sent 
    message = r.text 
    print("Message sent:%s"%message) 
    
def app_exec_stat_get():
    API_ENDPOINT = "https://execstatusapp20191220061912.azurewebsites.net/api/ExecStats"

    #get all items
    r=requests.get(url = API_ENDPOINT)

    #print data received 
    data = r.json()
    print(data)
    
def app_exec_stat_get_id(timeStamp):
    API_ENDPOINT = "https://execstatusapp20191220061912.azurewebsites.net/api/ExecStats/" + timeStamp 

    #get all items
    r=requests.get(url = API_ENDPOINT)

    #print data received 
    data = r.json()
    print(data)
    
def app_exec_stat_put(timeStamp, sourceMachine, appName, task, status, prop1, prop2, prop3):
    API_ENDPOINT = "https://execstatusapp20191220061912.azurewebsites.net/api/ExecStats/" + timeStamp
    data = {"Id": timeStamp,
        "SourceMachine": sourceMachine,
        "AppName": appName,
        "Task": task,
        "Status": status,
        "prop1": prop1,
        "prop2": prop2,
        "prop3": prop3}
    
    #make a put request
    r = requests.put(url = API_ENDPOINT, data = data, timeout=30)
    
    # get message sent 
    message = r.text 
    print("Message sent:%s"%message)
    
def app_exec_stat_delete(timeStamp):
    API_ENDPOINT = "https://execstatusapp20191220061912.azurewebsites.net/api/ExecStats/" + timeStamp
    
    #delete specified item
    r=requests.delete(url = API_ENDPOINT)

    #print data received 
    data = r.json()
    print(data)
    
#print("post 2 test items:")
#app_exec_stat_post("time1","testpy", "test", "test entry1", 0, 1, 2, 3)  
#app_exec_stat_post("time2", "testpy", "test", "test entry2", 0, 1, 2, 3)
   
#print('get all db items:')
#app_exec_stat_get()

#print("get time1:")
#app_exec_stat_get_id("time1")

#print("delete time1:")
#app_exec_stat_delete("time1")

#print("get time2")
#app_exec_stat_get_id("time2")

#print("delete time2:")
#app_exec_stat_delete("time2")

#create and test API for current epoch time
print("\n\ntest epoch time:\n")
current_time = str(math.floor(time.time()))
print("post epoch time")
app_exec_stat_post(current_time, "testpy", "test", "test epoch", 0, 1, 2, 3)
print("get entry")
app_exec_stat_get_id(current_time)
print("delete entry")
app_exec_stat_delete(current_time)

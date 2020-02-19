#File: ExecStatusApp.ps1
#Author: Andrea Lanz
#Description: A PowerShell script that defines function to interact with the
#             ExecStatusApp RESTful API

$URL_ENDPOINT = 'https://execstatusapp.azurewebsites.net/api/ExecStats'

#get request
function app_exec_stat_get {
	Invoke-RestMethod -Uri $URL_ENDPOINT
}

#get request by id
function app_exec_stat_get_id {
    param([string] $id)
    Invoke-RestMethod -Uri "$URL_ENDPOINT/$id"
}

#post request (note that the default Id is the current time)
function app_exec_stat_post {
    param([string] $id = ([int] (Get-Date (Get-Date).ToUniversalTime() -UFormat %s)).ToString(), 
    [string] $AppName = "N/A", [string] $SourceMachine = "N/A", [string] $Status = "0", 
    [string] $Task = "N/A", [string] $prop1 = "1", [string] $prop2 = "2", [string] $prop3 = "3")
    
    #define JSON message
    $message = @{
        Id = $id
        AppName = $AppName
        SourceMachine = $SourceMachine
        Status = $Status
        Task = $Task
        prop1 = $prop1
        prop2 = $prop2
        prop3 = $prop3
    }
    #convert to JSON
    $jsonMessage = $message | ConvertTo-Json

    #define command parameters
    $params = @{
        Uri = $URL_ENDPOINT
        Method = 'POST'
        Body = $jsonMessage
        ContentType = 'application/json'
    }
    Invoke-RestMethod @params
}

#put request
function app_exec_stat_put {
    param([string] $id, 
    [string] $AppName = "N/A", [string] $SourceMachine = "N/A", [string] $Status = "0", 
    [string] $Task = "N/A", [string] $prop1 = "1", [string] $prop2 = "2", [string] $prop3 = "3")
    
    #define JSON message
    $message = @{
        Id = $id
        AppName = $AppName
        SourceMachine = $SourceMachine
        Status = $Status
        Task = $Task
        prop1 = $prop1
        prop2 = $prop2
        prop3 = $prop3
    }
    #convert to JSON
    $jsonMessage = $message | ConvertTo-Json

    #define command parameters
    $params = @{
        Uri = $URL_ENDPOINT
        Method = 'PUT'
        Body = $jsonMessage
        ContentType = 'application/json'
    }
    Invoke-RestMethod @params
}

#get request by task 
function app_exec_stat_get_activity {
    param([string] $task)
    Invoke-RestMethod -Uri $URL_ENDPOINT'Activity/'$task
}

#delete request
function app_exec_stat_delete {
    param([string] $id)
    Invoke-RestMethod -Uri "$URL_ENDPOINT/$id" -Method Delete
}


#TEST CASES

#test post method
echo "`nTest Post method"
app_exec_stat_post -id "1234567" -AppName "app1" -SourceMachine "machine1" -Status "0" `
-Task "task1" -prop1 "1" -prop2 "2" -prop3 "3"

app_exec_stat_post -id "12345678" -AppName "app2" -SourceMachine "machine2" -Status "0" `
-Task "task2" -prop1 "1" -prop2 "2" -prop3 "3"

#test get method
echo "`nGet all items"
app_exec_stat_get

#test get by task
echo "`nGet by task"
app_exec_stat_get_activity -task "task2"

#delete entries
echo "`nDelete entry"
app_exec_stat_delete -id "1234567"
app_exec_stat_delete -id "12345678"


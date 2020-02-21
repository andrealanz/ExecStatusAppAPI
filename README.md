# WWT Automation ExecStatusApp API

### Author: Andrea Lanz

A project that focuses on defining API calls using three different languages: C#, PowerShell, and Python. Note that each languages defines GET, POST, PUT, and DELETE http requests. These API calls interact with a RESTFUL web app which interacts with a SQL Server Database. See the repository for [ExecStatusApp](https://github.com/andrealanz/ExecStatusApp) for more information about the RESTful web app and the structure of its underlying database.

#### C#
See the **[ExecStatusAPI](https://github.com/andrealanz/ExecStatusAppAPI/tree/master/ExecStatusAPI)** folder, which stores a Visual Studio C# project which defines ExecStatusApp API calls. A class is defined for the client functions as well as a class that holds ExecStatApp data.

#### PowerShell
See the **[ExecStatusApp.ps1](https://github.com/andrealanz/ExecStatusAppAPI/blob/master/ExecStatusApp.ps1)** script, which defines functions that create GET, POST, PUT, and DELETE requests. Note that each function accepts parameters as strings.

#### Python
See the **[ExecStatusApp.py](https://github.com/andrealanz/ExecStatusAppAPI/blob/master/ExecStatusApp.py)** script, which defines functions that create GET, POST, PUT, and DELETE requests.


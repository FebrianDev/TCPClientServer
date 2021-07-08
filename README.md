# TCPClientServer
This project is a realtime chat simulation using Nodejs as server and C# Unity as client with TCP Protocol

## Work Flow
1. Server running
2. Client running and connect to server
3. Client input message/data and send it to server
4. Server broadcasts the data to all client
5. Client receives the data sent by the server
6. All data logs are recorded by Server and saved into .txt

## Flowchart
![Flowchart](https://raw.githubusercontent.com/FebrianDev/TCPClientServer/main/Flowchart.png)

## Prerequisites
Download **[npm](https://www.npmjs.com/package/download) & [nodejs](https://nodejs.dev/download)**

## How to Run

Before continue please the complete [prerequisites](#prerequisites)

**Open your git terminal and clone this repo**

 ```bash
git clone https://github.com/FebrianDev/TCPClientServer.git
```
**Run server in your git terminal**
```bash
ls
cd TCPServer
npm start
```
Server will always run, if you want to turn off press **Ctrl + C**

**Run Client**
* Open folder **TCPClient**
* Open folder **Build**
* Double click **TCPClient.exe**

Client can only run if the server is active, if the server is down the client cannot send messages

## Result
When Server Running & Client Communication

![result](https://raw.githubusercontent.com/FebrianDev/TCPClientServer/main/result.png)

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Contact
M. Dwi Febrian - febrian26022001@gmail.com



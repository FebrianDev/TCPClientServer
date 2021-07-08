# TCPClientServer
This project is a realtime chat simulation using Nodejs as server and C# Unity as client with TCP Protocol

## Work Flow Server
1. Server running
2. Server waiting client for join
3. Server accept client for join
4. Server stored client in array
5. Server received data from client and stored data in array
6. Server broadcast data from client to all client
7. If server shutdown, destroy all client in array and save data message in array to txt

## Work Flow Client
1. Client join to server
2. Client send data message to server
3. Client received data from server
4. Client prints data received from server

## Flowchart
![Flowchart](https://raw.githubusercontent.com/FebrianDev/TCPClientServer/main/Flowchart2.png)

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



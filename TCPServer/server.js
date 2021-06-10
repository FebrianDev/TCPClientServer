//add module node js
const net = require('net') //module create server
const fs = require('fs') // module input system

const HOST = '127.0.0.1' //host server
const PORT = 3000 // port server

let messages = [] // array for save data messages client
let clients = [] // array for save client

// create server
const server = net.createServer( (client) => {
    //push client to array clients
    clients.push(client)

    //get data from client
    client.on('data',  (data) => {
        console.log('DATA ' + client.remoteAddress + ': ' + data)

        //send data to all client
        for (let i = 0; i < clients.length; i++) clients[i].write(data)

        //push data messages to array messages
        messages.push(`${data}\n`)
    })

    //if client leave to room
    client.on('end',  () => {
        console.log('CLOSED: ' + client.remoteAddress + ' ' + client.remotePort)
    })
})

//if server shutdown
process.on('SIGINT', () => {
    //destroy all client
    for (var i in clients) {
        clients[i].destroy()
    }

    //if server close
    server.close( () => {

        //save all data messages to file data.txt
        messages.forEach(msg => {
            try {
                fs.appendFileSync('data.txt', msg)
            } catch (e) {
                console.log(e.message)
            }
        })

        console.log('server closed.')
        process.exit()
    })
})

//server running
server.listen(PORT, HOST, () => {
    console.log('Server listening on ' + HOST + ':' + PORT)
})
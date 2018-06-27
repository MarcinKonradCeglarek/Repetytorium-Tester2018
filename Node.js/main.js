var http = require("http");

http.createServer(function (request, response) {
    // Send the HTTP header 
    // HTTP Status: 200 : OK
    // Content Type: text/plain
    response.writeHead(200, {'Content-Type': 'text/plain'});
    
    // Send the response body as "Hello World"
<<<<<<< HEAD
    response.end('Hello Worlt\n');
=======
    response.end('Hello World10666\n');
>>>>>>> 58b3c3abd44976f254df1ae1997df5dc5b148b11
 }).listen(8081);
 
 // Console will print the message
 console.log('Server running at http://127.0.0.1:8081/');
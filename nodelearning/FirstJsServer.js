const { createServer } = require("node:http");
const HTMLDecoderEncoder = require("html-encoder-decoder");
const hostname = "127.0.0.1";
const port = 8080;

const server = createServer((req, res) => {
  res.statusCode = 200;
  res.setHeader("Content-Type", "text/html");
  res.write(
    HTMLDecoderEncoder.decode(
      "<!DOCTYPE html><html><body><h1>Hello World</h1><p>Mij first javascript server running under npm</p></body></html>"
    )
  );

  if (req !== null) {
    res.write(req.url);
    res.write(JSON.stringify(req.headers));
  }

  res.end();
});

server.listen(port, hostname, () => {
  console.log(`Server running at http://${hostname}:${port}/`);
});

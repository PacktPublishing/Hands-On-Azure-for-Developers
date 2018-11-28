let http = require("http");
let appInsights = require("applicationinsights");

appInsights.setup("60ce4968-3f13-4fdf-9904-74aebec88735");
appInsights.start();
let client = appInsights.defaultClient;

client.trackEvent({name: "my custom event", properties: {customProperty: "custom property value"}});
client.trackException({exception: new Error("handled exceptions can be logged with this method")});
client.trackMetric({name: "custom metric", value: 3});
client.trackTrace({message: "trace message"});
client.trackDependency({target:"http://dbname", name:"select customers proc", data:"SELECT * FROM Customers", duration:231, resultCode:0, success: true, dependencyTypeName: "ZSQL"});
client.trackRequest({name:"GET /customers", url:"http://myserver/customers", duration:309, resultCode:200, success:true});


http.createServer( (req, res) => {
  client.trackNodeHttpRequest({request: req, response: res});
}).listen(1337, "127.0.0.1");

console.log('Server running at http://127.0.0.1:1337/');
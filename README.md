Simple tools for experimenting with network communications written primarily for Windows in .NET. To get the latest working build head to https://ci.appveyor.com/project/tewarid/nettools/build/artifacts.

#### Firewall Tool
Add/remove exceptions to/from Windows Firewall.

#### ICMP Tool
Send/receive ICMP messages using raw sockets. Requires admin privilege.

#### Serial Tool
Send/receive data using a serial port.

#### Sniffer Tool
Elementary tool that sniffs IPv4 packets using raw sockets. Requires admin privilege.

#### TCP Tool
Send/receive data over TCP/IP.

#### UDP Tool
Send/receive data using UDP/IP.

#### WebSocket Tool
Send/receive data using [WebSockets](https://msdn.microsoft.com/en-us/library/system.net.websockets.websocket.aspx). Requires Windows 8 or better.

#### WebSocket Server Tool
Self-hosted WCF service that echoes back whatever message is sent to it. Supports SSL. Requires Windows 8 or better.

#### WebSocketSharp Tool
Send/receive data using WebSockets. Uses [WebSocketSharp](https://github.com/sta/websocket-sharp), so works with Windows 7 or better. WebSocketSharp uses TCP sockets, need to use HTTP proxy so that [Fiddler](http://www.telerik.com/fiddler) is able to capture session.

#### WebSocketSharp Server Tool
Self-hosted service that uses [WebSocketSharp](https://github.com/sta/websocket-sharp), so works with Windows 7 or better.

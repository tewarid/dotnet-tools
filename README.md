Simple tools for experimenting with network communications written primarily for Windows in .NET. To get the latest working build binary package head to https://ci.appveyor.com/project/tewarid/nettools/build/artifacts.

### Firewall Tool
Add/remove exceptions to/from Windows Firewall.

### ICMP Tool
Send/receive ICMP messages using raw sockets. Requires admin privilege.

### Serial Tool
Send/receive data using a serial port.

### TCP Tool
Send/receive data over TCP/IP.

### UDP Tool
Send/receive data using UDP/IP.

### WebSocketSharp Tool
Send/receive data using WebSockets. Uses [WebSocketSharp](https://github.com/sta/websocket-sharp) and works with Windows 7 or better. One downside is that since WebSocketSharp uses a TCP socket, [Fiddler](http://www.telerik.com/fiddler) is unable to record the session. Use Wireshark instead.

### WebSocket Tool
Send/receive data using [WebSockets](https://msdn.microsoft.com/en-us/library/system.net.websockets.websocket.aspx). Requires Windows 8 or better.

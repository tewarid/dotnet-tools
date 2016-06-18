Simple tools for experimenting with network communications written primarily for Windows in .NET. To get the latest working build head to https://ci.appveyor.com/project/tewarid/nettools/build/artifacts. To build them yourselves, clone the repo, and use the free Visual Studio Express for Desktop 2015. I recommend having around the excellent [Sysinternals Suite](https://technet.microsoft.com/en-us/sysinternals/bb842062) of utilities.

#### Firewall Tool
Add/remove exceptions to/from Windows Firewall.

#### ICMP Tool
Interactive client that uses raw sockets to send and receive ICMP messages. Requires admin privilege.

#### Route Tool
Interactive client to add, view, and delete IP v4 routes on Windows. Requires PowerShell, which is available by default on Windows 7 and beyond. Requires admin privilege.

#### Serial Tool
Interactive client that may be used to open a serial port, and send and receive data.

#### Sniffer Tool
Elementary tool that sniffs IPv4 packets using raw sockets. Requires admin privilege.

#### TCP Client Tool
Interactive TCP/IP client that may be used to establish IPv4 TCP sessions, and send and receive data. It can also be used as a rudimentary listener/server.

#### TCP Listener Tool
Interactive TCP/IP client that may be used as a rudimentary listener/server.

#### UDP Tool
Interactive UDP/IP client that may be used to establish IPv4 UDP sockets, and send and receive datagrams.

#### WebSocket Tool
Interactive [WebSocket](https://msdn.microsoft.com/en-us/library/system.net.websockets.websocket.aspx) client that may be used to establish WebSocket sessions, and send and receive data. It is built with .NETs native implementation of WebSockets, and requires Windows 8 or better.

#### WebSocket Server Tool
Self-hosted WCF service that echoes back whatever message is sent to it. Supports SSL. Requires Windows 8 or better.

#### WebSocketSharp Tool
Interactive WebSocket client that may be used to establish WebSocket sessions, and send and receive data. It is built with [WebSocketSharp](https://github.com/sta/websocket-sharp) and works on Windows 7 or better. An HTTP proxy may be specified so WebSocket sessions can be debugged using [Fiddler](http://www.telerik.com/fiddler).

#### WebSocketSharp Server Tool
Self-hosted service built with [WebSocketSharp](https://github.com/sta/websocket-sharp), and works with Windows 7 or better. Data can be sent to and received from WebSocket clients. Supports SSL.

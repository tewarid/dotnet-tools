# Networking Tools [![Build status](https://ci.appveyor.com/api/projects/status/d3bn7jnje8rtts7v?svg=true)](https://ci.appveyor.com/project/tewarid/nettools)

[![Join the chat at https://gitter.im/tewarid-net-tools/Lobby](https://badges.gitter.im/tewarid-net-tools/Lobby.svg)](https://gitter.im/tewarid-net-tools/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Simple tools for experimenting with network communications written primarily for Windows in .NET. To get the latest working build head to https://dl.bintray.com/tewarid/net-tools/. To build them yourselves, clone the repository, and use the latest version of Visual Studio. To initialize submodules, run `git submodule update --init --recursive`.

## Bluetooth Serial Client Tool

Interactive client that may be used to open a Bluetooth serial socket, send, and receive data. It is built with [32feet.NET](https://www.nuget.org/packages/32feet.NET), a .NET library layered over Windows Bluetooth socket API.

## Bluetooth Serial Server Tool

Simulate a Bluetooth serial listener/server on Windows. It is built with [32feet.NET](https://www.nuget.org/packages/32feet.NET), a .NET library layered over Windows Bluetooth socket API.

## Firewall Tool

Add/remove exceptions to/from Windows Firewall.

## HTTP Listener Tool

Simple HTTP/s server built using [System.Net.HttpListener](https://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx). You can use it to serve static content and to test REST clients.

It can respond to HTTP requests with content, content type, and status code derived from a file stored in a folder. For example, if a folder has a single file called `200.json`, it will respond to an HTTP request for that folder with a status code of 200, a content type of `application/json`, and body containing the contents of the file.

If it finds a file with status code 302 in its name, it redirect the client to the URL contained in the file. It does not return any content for the HEAD HTTP request.

File extension to content type mapping is performed using the [Media Type Map](https://www.nuget.org/packages/MediaTypeMap/) library.

## ICMP Tool

Interactive client that uses raw sockets to send/receive ICMP messages. Requires administrative privilege.

## Route Tool

Interactive client to add, view, and delete IP v4 routes on Windows. Requires PowerShell, which is available by default on Windows 7 and beyond. Requires administrative privilege.

## Serial Tool

Interactive client that may be used to open a serial port, send, and receive data.

## Sniffer Tool

Elementary tool that sniffs IPv4 packets using raw sockets. Requires administrative privilege.

## TCP Client Tool

Interactive TCP/IP client that may be used to establish IPv4 TCP sessions, send, and receive data.

## TCP Listener Tool

Interactive TCP/IP client that may be used as a rudimentary listener/server.

## UDP Tool

Interactive UDP/IP client that may be used to establish IPv4 UDP sockets, send, and receive datagrams.

## WebSocket Tool

Interactive [WebSocket](https://msdn.microsoft.com/en-us/library/system.net.websockets.websocket.aspx) client that may be used to establish WebSocket sessions, send, and receive data. It is built with .NET's native implementation of WebSockets, and requires at least [Windows 8](https://msdn.microsoft.com/en-us/library/windows/desktop/hh437448.aspx).

## WebSocket Server Tool

Provides an interactive WebSocket server based on System.Net.HttpListener, or a self-hosted WCF service. WCF service is configured through `App.config` to run at port 8087, and in code to run at end point specified by user. Supports SSL. Requires at least [Windows 8](https://msdn.microsoft.com/en-us/library/windows/desktop/hh437448.aspx).

## WebSocketSharp Tool

Interactive WebSocket client that may be used to establish WebSocket sessions, send, and receive data. It is built with [WebSocketSharp](https://github.com/sta/websocket-sharp) and works on Windows 7 or better. An HTTP proxy may be specified so WebSocket sessions can be debugged using [Fiddler](http://www.telerik.com/fiddler). This tool will go away when [usage share](http://gs.statcounter.com/os-version-market-share/windows/desktop/worldwide) of Windows 8 and beyond surpasses 80% of all Windows installations, or Windows 7 begins to support WebSockets.

## WebSocketSharp Server Tool

Self-hosted service built with [WebSocketSharp](https://github.com/sta/websocket-sharp), and works with Windows 7 or better. Data can be sent to and received from WebSocket clients. Supports SSL. This tool will go away when [usage share](http://gs.statcounter.com/os-version-market-share/windows/desktop/worldwide) of Windows 8 and beyond surpasses 80% of all Windows installations.

## Similar Tools

* [Hercules SETUP utility](http://www.hw-group.com/products/hercules/index_en.html)

* [Telerik Fiddler](https://www.telerik.com/fiddler)

* [Tera Term](https://ttssh2.osdn.jp/)

## Troubleshooting Tools

* netstat

* [Sysinternals Suite](https://technet.microsoft.com/en-us/sysinternals/bb842062)

* TCP View (part of Sysinternals Suite)

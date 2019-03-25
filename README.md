# Networking Tools [![Build status](https://ci.appveyor.com/api/projects/status/d3bn7jnje8rtts7v?svg=true)](https://ci.appveyor.com/project/tewarid/nettools) [![Codacy Badge](https://api.codacy.com/project/badge/Grade/9272afa7d6494d7fa5a885e8e02a2999)](https://www.codacy.com/app/tewarid/net-tools?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=tewarid/net-tools&amp;utm_campaign=Badge_Grade) [![Join the chat at https://gitter.im/tewarid-net-tools/Lobby](https://badges.gitter.im/tewarid-net-tools/Lobby.svg)](https://gitter.im/tewarid-net-tools/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Simple tools for experimenting with network communications written primarily for Windows in .NET.

## Download

To download the latest build, see releases section of this GitHub project. For older builds, head to https://dl.bintray.com/tewarid/net-tools/.

## Build from source

To build all the tools, clone this repository, and initialize submodules

```bash
git clone https://github.com/tewarid/net-tools.git
cd net-tools
git submodule update --init --recursive
```

Then, open the solution file `NeTools.sln` using Visual Studio 2017 and build.

To build from the command line, open Developer Command Prompt for VS 2017, change to the `net-tools` directory, and run

```bash
nuget restore NetTools.sln
msbuild NeTools.sln
```

You may have to download nuget from nuget.org.

### Mono

A solution file is available for building some of the tools for Linux or macOS using [Mono](https://www.mono-project.com/download/stable/).

Use the msbuild version supplied by Mono to build

```bash
msbuild NetTools.Mono.sln
```

### .NET Core

A solution file is available to build some of the tools for Windows using .NET Core

```powershell
dotnet build NetTools.NetCore.sln
```

You can also use Visual Studio 2019 Preview to build.

## AMQP 1.0 Client Tool

A minimal interactive AMQP 1.0 client based on the [AMQPNetLite](https://github.com/Azure/amqpnetlite) library.

## Bluetooth Serial Client Tool

Interactive client that may be used to open a Bluetooth serial socket, send, and receive data. It is built with [32feet.NET](https://www.nuget.org/packages/32feet.NET), a .NET library layered over Windows Bluetooth socket API.

## Bluetooth Serial Server Tool

Simulate a Bluetooth serial listener/server on Windows. It is built with [32feet.NET](https://www.nuget.org/packages/32feet.NET), a .NET library layered over Windows Bluetooth socket API.

## Encoding Tool

Convert data or text to or from various formats such as Base64, and encoded HTML, XML, or URL.

## Firewall Tool

Add exceptions to Windows Firewall using native COM library `NetFwTypeLib`. With contributions from Bruno Silveira.

## Git Tool

A simple wrapper around command line Git, that allows running multiple commands on several cloned repos at once. A command can reference all or part of the output of the previous command with `{{OUT:start,length}}` where `start` is zero-indexed. Several repos can be cloned from GitHub or GitLab at once. A customizable cheatsheet is available in [cheatsheet.md](GitTool/cheatsheet.md). Any line starting with `$ git ` is assumed to be a git command and displayed in the tool.

## HTTP Request Tool

Simple interactive HTTP(S) client built using [System.Net.HttpWebRequest](https://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.aspx).

## HTTP Listener Tool

Simple HTTP(S) server built using [System.Net.HttpListener](https://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx).

## ICMP Tool

Interactive client that uses raw sockets to send/receive ICMP messages. Requires administrative privilege.

## MQTT Client Tool

Simple interactive MQTT 3.1.1 client based on the [MQTTnet](https://github.com/chkr1011/MQTTnet) library.

## Route Tool

Interactive client to add, view, and delete IP v4 routes on Windows. Requires PowerShell, which is available by default on Windows 7 and beyond. Requires administrative privilege.

## Serial Tool

Interactive client that may be used to open a serial port, send, and receive data.

## SMTP Client Tool

A simple SMTP client.

## SMTP Server Tool

A simple SMTP server based on the [SmtpServer](https://www.nuget.org/packages/SmtpServer/) library that logs messages to a text box.

## Sniffer Tool

An elementary tool that sniffs IPv4 packets using raw sockets. Requires administrative privilege.

## TCP Client Tool

Interactive TCP/IP client that may be used to establish IPv4 TCP sessions, send, and receive data.

## TCP Listener Tool

Interactive TCP/IP client that may be used as a rudimentary listener/server.

## UDP Tool

Interactive UDP/IP client that may be used to establish IPv4 UDP sockets, send, and receive datagrams.

## WebSocket Tool

Interactive [WebSocket](https://msdn.microsoft.com/en-us/library/system.net.websockets.websocket.aspx) client that may be used to establish WebSocket sessions, send, and receive data. It is built with .NET's native implementation of WebSockets, and requires at least Windows 8.

## WebSocket Server Tool

Interactive WebSocket server based on either System.Net.HttpListener or a self-hosted WCF service. WCF service is configured through `App.config` to run at port 8087, and in code to run at end point specified by user. Supports SSL. Requires at least Windows 8.

## WebSocketSharp Tool

Interactive WebSocket client that may be used to establish WebSocket sessions, send, and receive data. It is built with [WebSocketSharp](https://github.com/sta/websocket-sharp) and works on Windows 7, or better. An HTTP proxy may be specified so WebSocket sessions can be debugged using [Fiddler](http://www.telerik.com/fiddler).

## WebSocketSharp Server Tool

Self-hosted service built with [WebSocketSharp](https://github.com/sta/websocket-sharp), and works on Windows 7, or better. Data can be sent to and received from WebSocket clients. Supports SSL.

## Related Tools

* [ncat](https://nmap.org/ncat/)
* [SoapUI](https://www.soapui.org/)
* [Telerik Fiddler](https://www.telerik.com/fiddler)
* [Tera Term](https://ttssh2.osdn.jp/)

## Useful Tools

* netstat
* tcpdump
* [Sysinternals Suite](https://technet.microsoft.com/en-us/sysinternals/bb842062)
  * TCP View
* WinDump
* Wireshark (recommend replacing WinPcap with [npcap](https://nmap.org/npcap/) on Windows)

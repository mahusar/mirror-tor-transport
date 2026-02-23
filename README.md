Tor transport for Mirror Networking as a .onion hidden service.

### Mirror Tor Transport
A Unity transport layer for Mirror Networking that routes connections through Tor, allowing anyone to connect anonymously via a `.onion` address.

### How it works
Instead of connecting directly, the client performs a SOCKS5 handshake through the local Tor proxy before handing the connected socket to Mirror. The server 
runs as a Tor hidden service, getting a `.onion` address that players use to connect.

### Requirements
- Unity 2021.3.45f2
- Mirror Networking 86.12.2
- Tor running locally on `127.0.0.1:9050`

### Installation
Windows:
- Install Tor standalone via [Expert Bundle](https://www.torproject.org/download/tor/)
- Add torrc config file: SocksPort 9050 | ControlPort 9051 | DataDirectory tor_data | HiddenServiceDir C:\Tor\hidden\ | HiddenServiceVersion 3 | HiddenServicePort 7777 127.0.0.1:7777
- Run \tor.exe -f torrc   

Unity:
- Install Mirror 86.12.2
- Copy the `TOR/` folder into your Assets
- Replace `TelepathyTransport` on your NetworkManager with `TorTelepathyTransport`
- Add `UnityMainThreadDispatcher` component to your NetworkManager GameObject
- Use `Net/` folder for conn tests

### Usage
Hosting:
- Run Tor as a hidden service pointing to port 7777
- Share the generated `.onion` address with players

Connecting:
- Make sure Tor is running on port 9050
- Enter the `.onion` address and connect

### Latency expectations
Tor routes through 3 relays worldwide so expect 400-800ms RTT.

![Alt text](Assets/Screens/MirrorTor.png)

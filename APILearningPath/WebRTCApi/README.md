# WebRTC API Example

This project demonstrates peer-to-peer communication using WebRTC with a SignalR signaling server.

## Features

- Peer-to-peer connections
- Video/Audio streaming
- Data channels
- Signaling server
- NAT traversal
- Connection negotiation

## Project Structure

```
WebRTCApi/
├── Hubs/
│   └── SignalingHub.cs     # SignalR hub for signaling
├── wwwroot/
│   └── js/
│       └── webrtc.js      # WebRTC client implementation
├── Program.cs             # Application entry point
└── appsettings.json      # Configuration file
```

## Getting Started

1. Navigate to the project directory:
   ```bash
   cd WebRTCApi
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

3. Access the application at `http://localhost:5006`

## Implementation Details

### 1. Signaling Server (SignalR Hub)
```csharp
public class SignalingHub : Hub
{
    // Send offer to peer
    public async Task SendOffer(string peerId, string offer)
    {
        await Clients.Client(peerId).SendAsync("ReceiveOffer", offer);
    }

    // Send answer to peer
    public async Task SendAnswer(string peerId, string answer)
    {
        await Clients.Client(peerId).SendAsync("ReceiveAnswer", answer);
    }

    // Send ICE candidate
    public async Task SendIceCandidate(string peerId, string candidate)
    {
        await Clients.Client(peerId).SendAsync("ReceiveIceCandidate", candidate);
    }
}
```

### 2. WebRTC Client Implementation
```javascript
const pc = new RTCPeerConnection(configuration);

// Create offer
async function createOffer() {
    const offer = await pc.createOffer();
    await pc.setLocalDescription(offer);
    await signalR.invoke("SendOffer", peerId, offer);
}

// Handle incoming video stream
pc.ontrack = (event) => {
    videoElement.srcObject = event.streams[0];
};

// Set up data channel
const dataChannel = pc.createDataChannel("chat");
dataChannel.onmessage = (event) => {
    console.log("Received:", event.data);
};
```

## Features Demonstrated

1. Media Streaming
   - Video calls
   - Audio calls
   - Screen sharing

2. Data Channels
   - Text chat
   - File transfer
   - Custom data exchange

3. Connection Management
   - Peer discovery
   - ICE candidate exchange
   - Connection state handling

## Testing

1. Open the application in two different browsers
2. Click "Start Call" in one browser
3. Accept the call in the other browser
4. Test video, audio, and chat features

## Security Considerations

- STUN/TURN server configuration
- Secure signaling (HTTPS)
- Peer authentication
- Data encryption

## Learning Resources

1. [WebRTC API Reference](https://developer.mozilla.org/en-US/docs/Web/API/WebRTC_API)
2. [WebRTC Samples](https://webrtc.github.io/samples/)
3. [SignalR with WebRTC](https://docs.microsoft.com/en-us/aspnet/core/signalr/webrtc)
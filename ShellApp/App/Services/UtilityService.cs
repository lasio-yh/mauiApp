namespace ShalomCake.Services;

public class UtilityService
{
    public delegate void PushHandler(object args);
    public PushHandler _push;

    private TcpClient _tcpClient;
    private UdpClient _udpClient;

    Thread _worker;

    /// <summary>
    /// TCP 클라이언트를 생성합니다.
    /// </summary>
    /// <param name="ipAddress">remote IPAddress</param>
    /// <param name="port">Port</param>
    /// <returns>ResultMapModel</returns>
    public MessageItem CreateTcpClient(string ipAddress, int port)
    {
        try
        {
            _tcpClient = new TcpClient();
            _tcpClient.ConnectAsync(ipAddress, port);
            return new MessageItem { ResultId = "0x00", ResultMessage = "Succes" };
        }
        catch (Exception ex)
        {
            return new MessageItem { ResultId = "0x01", ResultMessage = ex.Message };
        }
    }

    /// <summary>
    /// 데이터 수신을 시작합니다.
    /// </summary>
    /// <returns>ResultMapModel</returns>
    public MessageItem StartReceiveTcpClient(PushHandler callBack)
    {
        try
        {
            _worker = new Thread(new ThreadStart(ReceiveTcpClient));
            _worker.Start();
            _push = callBack;
            return new MessageItem { ResultId = "0x00", ResultMessage = "Succes" };
        }
        catch (Exception ex)
        {
            return new MessageItem { ResultId = "0x01", ResultMessage = ex.Message };
        }
    }

    /// <summary>
    /// 데이터 수신을 중지합니다.
    /// </summary>
    /// <returns>ResultMapModel</returns>
    public MessageItem StopReceiveTcpClient()
    {
        try
        {
            if (_tcpClient != null)
            {
                _tcpClient.Close();
                _tcpClient = null;
            }

            if (_worker != null)
                _worker = null;

            return new MessageItem { ResultId = "0x00", ResultMessage = "Succes" };
        }
        catch (Exception ex)
        {
            return new MessageItem { ResultId = "0x01", ResultMessage = ex.Message };
        }
    }

    /// <summary>
    /// 데이터를 전송합니다.
    /// </summary>
    /// <returns>ResultMapModel</returns>
    public MessageItem SendTcpClient(string data)
    {
        try
        {
            var stream = _tcpClient.GetStream();
            var buffer = Encoding.UTF8.GetBytes(data);
            stream.WriteAsync(buffer, 0, buffer.Length);
            return new MessageItem { ResultId = "0x00", ResultMessage = "Succes" };
        }
        catch (Exception ex)
        {
            return new MessageItem { ResultId = "0x01", ResultMessage = ex.Message };
        }
    }

    /// <summary>
    /// 데이터를 수신합니다.
    /// </summary>
    private void ReceiveTcpClient()
    {
        try
        {
            while (_tcpClient.Connected)
            {
                var outbuf = new byte[255];
                var nbytes = 0;
                var data = string.Empty;
                var stream = _tcpClient.GetStream();
                var mem = new MemoryStream();
                while ((nbytes = stream.Read(outbuf, 0, outbuf.Length)) > 0)
                {
                    mem.Write(outbuf, 0, nbytes);
                }
                stream.Close();
                data = Encoding.UTF8.GetString(mem.ToArray());
                _push(data);
                Thread.Sleep(100);
            }
        }
        catch (Exception ex)
        {
            Thread.Sleep(1000);
        }
    }

    /// <summary>
    /// UDP Client 를 생성합니다.
    /// </summary>
    /// <returns>ResultMapModel</returns>
    public MessageItem CreateUdpClient(int port)
    {
        try
        {
            var endPoint = new IPEndPoint(IPAddress.Any, port);
            _udpClient = new UdpClient(endPoint);
            return new MessageItem { ResultId = "0x00", ResultMessage = "Succes" };
        }
        catch (Exception ex)
        {
            return new MessageItem { ResultId = "0x01", ResultMessage = ex.Message };
        }
    }

    /// <summary>
    /// 데이터를 전송합니다.
    /// </summary>
    /// <returns>ResultMapModel</returns>
    public async Task<MessageItem> SendUdpClient(byte[] buffer, int length)
    {
        try
        {
            if(_udpClient == null)
                return new MessageItem { ResultId = "0x01", ResultMessage = "Not Found" };

            var sendTask = await _udpClient.SendAsync(buffer, length);
            var recvTask = await _udpClient.ReceiveAsync();
            return new MessageItem { ResultId = "0x00", ResultMessage = "Succes" };
        }
        catch (Exception ex)
        {
            return new MessageItem { ResultId = "0x01", ResultMessage = ex.Message };
        }
    }

    /// <summary>
    /// GET HTTP 메시지를 요청합니다.
    /// </summary>
    /// <param name="uri">요청 uri.</param>
    /// <param name="token">인증 token.</param>
    /// <returns>ResultMapModel</returns>
    public async Task<MessageItem> HttpGetRequest(string uri, string token)
    {
        try
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            var stream = await client.GetStringAsync(new Uri(uri));
            return new MessageItem { ResultId = "0x00", ResultMessage = stream };
        }
        catch (Exception ex)
        {
            return new MessageItem { ResultId = "0x01", ResultMessage = ex.Message };
        }
    }

    /// <summary>
    /// POST HTTP 메시지를 요청합니다.
    /// </summary>
    /// <param name="uri">요청 uri.</param>
    /// <param name="body">요청 메시지</param>
    /// <param name="token">인증 token.</param>
    /// <returns>ResultMapModel</returns>
    public async Task<MessageItem> HttpPostRequest(string uri, string body, string token)
    {
        try
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
            var stream = await client.PostAsync(new Uri(uri), httpContent);
            return new MessageItem { ResultId = "0x00", ResultMessage = stream.Content.ToString() };
        }
        catch (Exception ex)
        {
            return new MessageItem { ResultId = "0x01", ResultMessage = ex.Message };
        }
    }
}
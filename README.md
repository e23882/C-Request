# CSharp-Request Quick Start

```csharp
Request qq = new Request();
foreach (var cookieItem in Cookie)
{
    qq.Cookie.Add(cookieItem);
}
qq.Params.Add("chatID", chatRoomID);
qq.Params.Add("Mobile", mobileID);
qq.Params.Add("ChannelType", "1");
qq.Params.Add("LoadCount", "25");

result = qq.Post(URLTable["InitialGroupChat"]);
return result;
```

namespace fastenapipoc;

public class MyEndpoint : MyBaseEndpoint<EmptyRequest, object>
{
    public IMyService? MyService { get; set; }

    public MyEndpoint() : base(AuthenticationScheme.AnonymousRequest, new[] { "firstapp" }) => Get("/test/", "endpoint1");

    public override async Task HandleAsync(EmptyRequest _, CancellationToken ct)
    {
        await SendAsync(new { test = MyService?.Value });
    }
}
namespace fastenapipoc;

public abstract class MyBaseEndpoint<TRequest, TResponse> : Endpoint<TRequest, TResponse>
    where TRequest : notnull, new()
    where TResponse : notnull, new()
{
    private readonly AuthenticationScheme _authenticationScheme;
    private readonly IEnumerable<string> _deployments;
    private Http _http;
    private string _route = string.Empty;

    protected MyBaseEndpoint(AuthenticationScheme authenticationScheme,
                             IEnumerable<string> deployments)
    {
        _authenticationScheme = authenticationScheme;
        _deployments = deployments;
    }

    protected void Post(string baseRoute, string routePattern)
    {
        _http = Http.POST;
        _route = string.Concat(baseRoute, routePattern);
    }

    protected void Get(string baseRoute, string routePattern)
    {
        _http = Http.GET;
        _route = string.Concat(baseRoute, routePattern);
    }

    public override void Configure()
    {
        AuthSchemes(_authenticationScheme.ToString());
        Tags(_deployments.Select(q => q.ToString()).ToArray());
        Verbs(_http);
        Routes(_route);
        AllowAnonymous();
    }
}
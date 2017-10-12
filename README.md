# Float
This is a C# wrapper for the Float api: http://dev.float.com/

# Float Authorization

Float requires an auth token on all their requests. They also request that you include a User-Agent header. There are two ways to set these.

## Config File

The first way is in the config file like this:

```
<appSettings>
	<add key="FloatAuthToken" value="TOKEN" />
	<add key="FloatUserAgent" value="AGENT" />
</appSettings>
```

## In Code

The second way is in code:

```
FloatConfig.AuthToken = "TOKEN";
FloatConfig.UserAgent = "AGENT";
```
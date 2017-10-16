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

# How it works

The code has a mechanism for detecting changes and only sending changed fields in creates and updates. The only exception are collections. If an object includes a collection, it will always be sent. (Note: if anyone wants to update this please do and create a pull request.)

When getting objects from the api, it will automatically set all the properties to clean. Any changes will be tracked and updated on update.

# Issues

Please add any issues you find and I will do my best to fix them.
<p align="center">
  <h3 align="center"><b>Test Polly Retry</b></h3>
  <p align="center">Test project for example of using Polly Retry </p>
</p>

### Summary
Polly is a .NET library that includes Retry. It allows us to automatically retry failed operations, improving the reliability of our services. This strategy is particularly effective when combined with exponential backoff, as detailed in this [Microsoft article](https://learn.microsoft.com/pt-br/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly).

---

### Download and install

```bash
# Download
$ git clone LINK-GITHUB-PROJECT && cd test-polly-retry

# Install libs and dependencies
$ dotnet restore

# Build application
$ dotnet build
```

---

### How to use

```bash
# Start
dotnet run api/api.csproj
```

Run on: [localhost](http://localhost:5000/index.html)

### How to test

In domain/Infrastructure/LocalExternalService, at line 20, you can pass the URL for testing

---
### License

This work is licensed under [MIT License.](/LICENSE.md)
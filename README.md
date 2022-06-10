# UnoGrpcWebAssemblyDemo

I am trying to do a sample of Uno Platform using gRPC-Web.

Therefore I got inspired by [the content provided by this article](https://azure.github.io/AppService/2021/03/15/How-to-use-gRPC-Web-with-Blazor-WebAssembly-on-App-Service.html). I followed the instructions of the article and created a BlazorApp which used a weather service with gRPC-Web. After that I also included an other service, the counter service, as seen in [this gRPC-Web example](https://github.com/grpc/grpc-dotnet/tree/master/examples/Counter).

After everthing was working, I added a Uno Platform WebAssembly App to replace the BlazorApp client. This is the current state of the project.

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /home/simple-api
COPY . .
RUN dotnet publish -c Release -o /stage-publish


FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /home/simple-api/runtime-publish
COPY --from=build-env /stage-publish .
EXPOSE 80

ENTRYPOINT ["dotnet", "SimpleApi.Api.dll"]
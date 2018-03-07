FROM microsoft/dotnet:2.0-runtime
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "meshaccount_windows.dll"]

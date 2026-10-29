FROM mcr.microsoft.com AS build
WORKDIR /src
COPY ["WebApplication1.csproj", "."]
RUN dotnet restore "./WebApplication1.csproj"
COPY . .
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "WebApplication1.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
ARG GITSHA=TEST
RUN echo "GITSHA is ${GITSHA}"
WORKDIR /src
COPY platform-api.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app --version-suffix ${GITSHA}

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "platform-api.dll"]
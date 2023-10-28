FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TicTacToeZero/TicTacToeZero.csproj", "TicTacToeZero/"]
RUN dotnet restore "TicTacToeZero/TicTacToeZero.csproj"
COPY . .
WORKDIR "/src/TicTacToeZero"
RUN dotnet build "TicTacToeZero.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicTacToeZero.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicTacToeZero.dll"]

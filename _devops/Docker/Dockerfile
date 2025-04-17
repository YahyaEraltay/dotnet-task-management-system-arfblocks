# .NET 8 SDK ile build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Proje dosyalarını kopyala
COPY . /app/

# Bağımlılıkları restore et
RUN dotnet restore

# Projeyi build et
RUN dotnet publish -c Release -o /out

# .NET 8 runtime kullanarak çalıştırma aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Build aşamasında oluşturulan dosyaları kopyala
COPY --from=build /out ./

# Container başlatıldığında çalıştırılacak komut
ENTRYPOINT ["dotnet", "ApiWithMiddleware.dll"]
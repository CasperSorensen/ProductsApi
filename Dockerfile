FROM mcr.microsoft.com/dotnet/core/sdk:3.1
COPY . /products_api
WORKDIR /products_api
RUN dotnet restore
WORKDIR /products_api/src/ProductsApi
EXPOSE 5001/tcp
ENTRYPOINT [ "dotnet", "run", "--no-restore", "--urls", "http://0.0.0.0:5001"]

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY . ./
# RUN dotnet restore

# # Copy everything else and build
# # COPY /src ./
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "ProductsApi.dll"]

# Stage 1: Build and Publish
FROM mcr.microsoft.com/dotnet/sdk:9.0.200 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the files and build the app
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Serve the Blazor WebAssembly app with Nginx
FROM nginx:latest AS final
WORKDIR /usr/share/nginx/html

# Remove default Nginx files
RUN rm -rf ./*

# Copy the published Blazor WebAssembly files
COPY --from=build /app/publish/wwwroot ./

# Expose port 80 for web traffic
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
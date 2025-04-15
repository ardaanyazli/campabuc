FROM mcr.microsoft.com/dotnet/sdk-9/0-alpine as build
WORKDIR /src

COPY *.sln/ ./
COPY campabuc.api/ ./campabuc.api/
COPY campabuc.data/ ./campabuc.data/
COPY campabuc.model/ ./campabuc.model/

WORKDIR /src/cmapabuc.api/
RUN dotnet restore

FROM build as dev

WORKDIR /app
EXPOSE 5000
EXPOSE 5001
ENTRYPOINT ['dotnet','watch', 'run','--project','/app/campabuc.api/campabuc.api.csproj']

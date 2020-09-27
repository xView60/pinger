Quick Install for Linux:

git clone https://github.com/xView60/pinger.git

cd pinger/bin/Release/netcoreapp3.1/linux-x64/publish/

./dotnet

Compiling for other distributions of linux:

Install the .NET CLI from Microsoft first

Follow the instructions for your distribution: https://dotnet.microsoft.com/download

Compile the source code:

dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained false
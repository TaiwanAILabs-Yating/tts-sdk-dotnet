#!/bin/bash
if [ -d "./publish" ]; then
  echo "Remove existing publish directory...\n"
  rm -rf ./publish
fi

dotnet build TtsClient.sln \
  --configuration Release \
  --no-restore \
  --output ./publish
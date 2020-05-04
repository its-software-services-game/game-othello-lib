#!/bin/bash

dotnet build

coverlet ./GameOthelloLib/bin/Debug/netcoreapp3.1/GameOthelloLib.dll \
--format "lcov" \
--target "dotnet" \
--targetargs "test --no-build"
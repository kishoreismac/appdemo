# Script to run tests with code coverage and generate HTML report

Write-Host "Running tests with code coverage..." -ForegroundColor Cyan

# Run tests with coverage
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./TestResults/

# Generate HTML report
Write-Host "`nGenerating HTML coverage report..." -ForegroundColor Cyan
reportgenerator -reports:"TestResults\coverage.cobertura.xml" -targetdir:"TestResults\CoverageReport" -reporttypes:Html

# Open the report in browser
Write-Host "`nOpening coverage report in browser..." -ForegroundColor Green
Start-Process "TestResults\CoverageReport\index.html"

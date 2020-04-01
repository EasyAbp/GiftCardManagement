# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of projects
$projects = (

    "src/EasyAbp.GiftCardManagement.Application",
    "src/EasyAbp.GiftCardManagement.Application.Contracts",
    "src/EasyAbp.GiftCardManagement.Domain",
    "src/EasyAbp.GiftCardManagement.Domain.Shared",
    "src/EasyAbp.GiftCardManagement.EntityFrameworkCore",
    "src/EasyAbp.GiftCardManagement.HttpApi",
    "src/EasyAbp.GiftCardManagement.HttpApi.Client",
    "src/EasyAbp.GiftCardManagement.MongoDB",
    "src/EasyAbp.GiftCardManagement.Web"
)
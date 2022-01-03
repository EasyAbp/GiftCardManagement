# GiftCardManagement

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FAbpVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FEasyAbp%2FGiftCardManagement%2Fmaster%2FDirectory.Build.props)](https://abp.io)
[![NuGet](https://img.shields.io/nuget/v/EasyAbp.GiftCardManagement.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.GiftCardManagement.Domain.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.GiftCardManagement.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.GiftCardManagement.Domain.Shared)
[![Discord online](https://badgen.net/discord/online-members/S6QaezrCRq?label=Discord)](https://discord.gg/S6QaezrCRq)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/GiftCardManagement?style=social)](https://www.github.com/EasyAbp/GiftCardManagement)

An abp application module where you can create gift cards and your app user can use them to exchange something.

## Online Demo

We have launched an online demo for this module: [https://giftcard.samples.easyabp.io](https://giftcard.samples.easyabp.io)

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-nuget-packages))

    * EasyAbp.GiftCardManagement.Application
    * EasyAbp.GiftCardManagement.Application.Contracts
    * EasyAbp.GiftCardManagement.Domain
    * EasyAbp.GiftCardManagement.Domain.Shared
    * EasyAbp.GiftCardManagement.EntityFrameworkCore
    * EasyAbp.GiftCardManagement.HttpApi
    * EasyAbp.GiftCardManagement.HttpApi.Client
    * (Optional) EasyAbp.GiftCardManagement.MongoDB
    * (Optional) EasyAbp.GiftCardManagement.Web

1. Add `DependsOn(typeof(GiftCardManagementXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-module-dependencies))

1. Add `builder.ConfigureGiftCardManagement();` to the `OnModelCreating()` method in **MyProjectMigrationsDbContext.cs**.

1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC&DB=EF#add-database-migration).

## Usage

1. Add permissions to the roles you want.

1. Create a gift card template.

1. Create a gift card.

1. Handle the gift card consumption distributed event. See the document: [Handling Consumption Event](/docs/Handling-Consumption-Event.md).

1. Try to consume the gift card.

![GiftCards](/docs/images/GiftCards.png)
![BatchCreate](/docs/images/BatchCreate.png)
![Consumption](/docs/images/Consumption.png)

## Roadmap

- [ ] Consumption rollback feature.
- [ ] Improve management pages.
- [ ] Unit tests.

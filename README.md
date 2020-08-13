# 10MinuteMail.net

[![Build Status](https://travis-ci.com/Zaczero/10MinuteMail.net.svg?branch=master)](https://travis-ci.com/Zaczero/10MinuteMail.net)
[![GitHub Release](https://img.shields.io/github/v/release/Zaczero/10MinuteMail.net)](https://github.com/Zaczero/10MinuteMail.net/releases/latest)
[![NuGet Release](https://img.shields.io/nuget/v/10MinuteMail.net-API)](https://www.nuget.org/packages/10MinuteMail.net-API/)
[![License](https://img.shields.io/github/license/Zaczero/10MinuteMail.net)](https://github.com/Zaczero/10MinuteMail.net/blob/master/LICENSE)

Simple HTTP API wrapper for [10minutemail.net](https://10minutemail.net/)

## 🌤️ Installation

### Install with NuGet (recommended)

`Install-Package 10MinuteMail.net-API`

### Install with dotnet

`dotnet add PROJECT package 10MinuteMail.net-API`

### Install manually

[Browse latest GitHub release](https://github.com/Zaczero/10MinuteMail.net/releases/latest)

## 🏁 Getting started

### Sample code

```cs
var tenMinuteMail = new TenMinuteMail();

// current email address
var email = tenMinuteMail.GetEmailAddress().Result;
// fetch emails from the inbox
var emails = tenMinuteMail.GetEmails().Result;

// regenerated email address
tenMinuteMail.GenerateNewEmailAddress().Wait();

// current email address (after regeneration)
var email2 = tenMinuteMail.GetEmailAddress().Result;

// extend expiration time to 100 minutes
tenMinuteMail.Reset100Minutes().Wait();

// 6000 seconds (== 100 minutes)
var seconds = tenMinuteMail.GetSecondsLeft().Result;
```

## Footer

### 📧 Contact

* Email: [kamil@monicz.pl](mailto:kamil@monicz.pl)
* PGP: [0x9D7BC5B97BB0A707](https://gist.github.com/Zaczero/158da01bfd5b6d236f2b8ceb62dd9698)

### 📃 License

* [Zaczero/10MinuteMail.net](https://github.com/Zaczero/10MinuteMail.net/blob/master/LICENSE)
* [JamesNK/Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md)
